namespace APK_Edit
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using System.Xml;

    using Wrappers;

    /// <summary>
    /// The apk file.
    /// </summary>
    internal class ApkFile
    {
        #region Constants and Fields

        private static readonly string ManifestFileName = TempPath + @"\AndroidManifest.xml";
        private static readonly string ApkToolYmlFileName = TempPath + @"\apktool.yml";
        private static readonly string StringsFileName = TempPath + @"\res\values\strings.xml";

        private readonly FileInfo fileInfo;
        private readonly Aapt.DumpResult aaptDump;
        private readonly string iconPath;

        private static string tempPath;

        private bool enableSigning = true;
        private bool createSeperateSigningFile = true;
        private bool enableBackup = true;
        private bool overWriteBackup = true;
        private string applicationName;
        private bool applicationNameInStringsXml;
        private string applicationNameAttribute;
        private Image defaultIcon;
        private bool isFrameworkApk;
        private bool isSystemApp;

        #endregion

        #region Constructors and Destructors

        public ApkFile()
        {
            this.fileInfo = OpenFile();
            this.aaptDump = Aapt.Dump(this.fileInfo);
            this.iconPath = TempPath + @"\" + this.aaptDump.application.icon.Replace('/', '\\');
        }

        ~ApkFile()
        {
            var path = new DirectoryInfo(TempPath);

            try
            {
                path.Delete(true);
            }
            catch (IOException)
            {
                // TODO - Handle IOException exception (Files in use, delete after reboot action)
            }
        }

        #endregion

        #region Delegates

        public delegate void DecompiledEventHandler();

        public delegate void DecompilingEventHandler();

        public delegate void FrameworkInstallingEventHandler();

        public delegate void FrameworkInstalledEventHandler();

        public delegate void FrameworkMissingEventHandler();

        public delegate void CompiledEventHandler();

        public delegate void CompilingEventHandler();

        #endregion

        #region Public Events

        public event DecompiledEventHandler Decompiled;

        public event DecompilingEventHandler Decompiling;

        public event FrameworkInstallingEventHandler FrameworkInstalling;

        public event FrameworkInstalledEventHandler FrameworkInstalled;

        public event FrameworkMissingEventHandler FrameworkMissing;

        public event DecompiledEventHandler Compiled;

        public event DecompilingEventHandler Compiling;

        #endregion

        #region Public Properties

        public static string TempPath
        {
            get
            {
                if (tempPath == null)
                {
                    var di = new DirectoryInfo(Path.GetTempPath() + Path.GetRandomFileName());
                    if (di.Exists)
                    {
                        di.Delete(true);
                    }

                    di.Create();
                    tempPath = di.FullName;
                }

                return tempPath;
            }
        }

        public string ApplicationName
        {
            get
            {
                return this.applicationName ?? (this.applicationName = this.aaptDump.application.label);
            }

            set
            {
                // Save to xml file...
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(this.applicationNameInStringsXml ? StringsFileName : ManifestFileName);
                if (this.applicationNameInStringsXml)
                {
                    var elements = xmlDoc.SelectNodes("//resources/string");
                    if (elements != null)
                    {
                        for (int i = 0; i < elements.Count; i++)
                        {
                            var xmlAttributeCollection = elements[i].Attributes;
                            if (xmlAttributeCollection != null
                                && xmlAttributeCollection["name"].Value == this.applicationNameAttribute)
                            {
                                elements[i].InnerText = value;
                            }
                        }
                    }
                }
                else
                {
                    var elements = xmlDoc.SelectSingleNode("//manifest/application");
                    if (elements != null)
                    {
                        if (elements.Attributes != null)
                        {
                            var labelAttr = elements.Attributes["android:label"];
                            labelAttr.Value = value;
                        }
                    }
                }

                xmlDoc.Save(StringsFileName);
                this.applicationName = value;
            }
        }

        public bool EnableSigning
        {
            get
            {
                return this.enableSigning;
            }

            set
            {
                this.enableSigning = value;
            }
        }

        public bool CreateSeperateSigningFile
        {
            get
            {
                return this.createSeperateSigningFile;
            }
            
            set
            {
                this.createSeperateSigningFile = value;
            }
        }

        public bool EnableBackup
        {
            get
            {
                return enableBackup;
            }
            set
            {
                enableBackup = value;
            }
        }

        public bool OverWriteBackup
        {
            get
            {
                return overWriteBackup;
            }
            set
            {
                overWriteBackup = value;
            }
        }



        #endregion

        #region Public Methods and Operators

        public void Decompile()
        {
            if (this.Decompiling != null)
            {
                this.Decompiling();
            }

            var decompile = new BackgroundWorker();

            decompile.DoWork += (sender, args) => args.Result = Apktool.Decode(this.fileInfo, new DirectoryInfo(TempPath));

            decompile.RunWorkerCompleted += (sender, args) =>
                {
                    var result = (Apktool.Command.RunResult)args.Result;
                    Trace.TraceInformation(result.Error);
                    Trace.TraceInformation(result.Output);

                    // Parse apktool.yml
                    var fileApktoolYml = new FileInfo(ApkToolYmlFileName);
                    if (fileApktoolYml.Exists)
                    {
                        string content = File.ReadAllText(fileApktoolYml.FullName);
                        this.isFrameworkApk = content.Contains("isFrameworkApk: true");
                        this.isSystemApp = content.Contains("  - 2");
                    }

                    // Update icon
                    this.defaultIcon = ConvertToImage(this.iconPath);

                    // Check ApplicationNameInStringsXml;
                    var xmlFile = new XmlDocument();
                    xmlFile.Load(ManifestFileName);
                    var selectSingleNode = xmlFile.SelectSingleNode("//manifest/application");
                    if (selectSingleNode != null)
                    {
                        if (selectSingleNode.Attributes != null)
                        {
                            var labelAttr = selectSingleNode.Attributes["android:label"];
                            var labelValue = (labelAttr != null) ? labelAttr.Value.ToString(CultureInfo.InvariantCulture) : string.Empty;

                            this.applicationNameInStringsXml = labelValue.StartsWith("@string");
                            this.applicationNameAttribute = this.applicationNameInStringsXml ? labelValue.Replace("@string/", string.Empty) : string.Empty;
                        }
                    }

                    if (result.Error.Contains("Could not decode file"))
                    {
                        throw new Exception("Could not decode file");
                    }

                    // Can't find framework resources for package of id: 2. You must install proper framework files, see project website for more info.
                    if (result.Output.Contains("Can't find"))
                    {
                        if (this.FrameworkMissing != null)
                        {
                            this.FrameworkMissing();
                        }
                    }
                    else
                    {
                        if (this.Decompiled != null)
                        {
                            this.Decompiled();
                        }
                    }
                };
            decompile.RunWorkerAsync();
        }

        public void InstallFramework(string fileName)
        {
            if (this.FrameworkInstalling != null)
            {
                this.FrameworkInstalling();
            }

            var installFramework = new BackgroundWorker();

            installFramework.DoWork += (sender, args) => args.Result = Apktool.InstallFramework(fileName);

            installFramework.RunWorkerCompleted += (sender, args) =>
                {
                    var result = (Apktool.Command.RunResult)args.Result;
                    Trace.TraceInformation(result.Error);
                    Trace.TraceInformation(result.Output);

                    if (this.FrameworkInstalled != null)
                    {
                        this.FrameworkInstalled();
                    }
                };
            installFramework.RunWorkerAsync();
        }

        public void Compile()
        {
            if (this.Compiling != null)
            {
                this.Compiling();
            }

            // Backup file if needed
            if (this.enableBackup)
            {
                var backupFile = new FileInfo(this.fileInfo.FullName + ".backup");

                if (backupFile.Exists)
                {
                    if (this.overWriteBackup)
                    {
                        backupFile.Delete();
                        this.fileInfo.CopyTo(backupFile.FullName);
                    }
                }
                else
                {
                    this.fileInfo.CopyTo(backupFile.FullName);
                }
            }

            var compile = new BackgroundWorker();
            compile.DoWork += (sender, args) =>
                {
                    var result = Apktool.Build(new DirectoryInfo(TempPath), this.fileInfo);
                    Trace.TraceInformation(result.Error);
                    Trace.TraceInformation(result.Output);
                    if (this.enableSigning)
                    {
                        Signapk.Sign(this.fileInfo, !this.createSeperateSigningFile);
                    }
                };

            compile.RunWorkerCompleted += (sender, args) =>
                {
                    if (this.Compiled != null)
                    {
                        this.Compiled();
                    }
                };
            compile.RunWorkerAsync();
        }

        public Image GetIcon()
        {
            return this.defaultIcon;
        }

        public Image SetIcon(string fileName)
        {
            File.Copy(fileName, this.iconPath, true);
            this.defaultIcon = ConvertToImage(this.iconPath);
            return this.defaultIcon;
        }

        #endregion

        #region Methods

        private static Image ConvertToImage(string fileName)
        {
            var icon = new FileInfo(fileName);
            return icon.Exists ? Image.FromStream(new MemoryStream(File.ReadAllBytes(icon.FullName))) : null;
        }

        private static FileInfo OpenFile()
        {
            FileInfo fileInfo = null;
            var args = Environment.GetCommandLineArgs();
            if (args.Count() == 1)
            {
                const string ApkFilter = "Android package files|*.apk";
                using (var openFileApk = new OpenFileDialog { Filter = ApkFilter })
                {
                    if (openFileApk.ShowDialog() == DialogResult.OK)
                    {
                        fileInfo = new FileInfo(openFileApk.FileName);
                    }
                }
            }
            else
            {
                fileInfo = new FileInfo(args[1]);
            }

            if (fileInfo == null || !fileInfo.Exists)
            {
                throw new FileNotFoundException(".apk file not found");
            }

            return fileInfo;
        }

        #endregion
    }
}