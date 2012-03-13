namespace Wrappers
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net;

    using Microsoft.Win32;

    public static class Java
    {
        const string JavaKey32 = "SOFTWARE\\JavaSoft\\Java Runtime Environment";
        const string JavaKey64 = "SOFTWARE\\Wow6432Node\\JavaSoft\\Java Runtime Environment";

        const string Url64Bit = "http://javadl.sun.com/webapps/download/AutoDL?BundleId=58126";
        const string Url32Bit = "http://javadl.sun.com/webapps/download/AutoDL?BundleId=58124";

        const string FileName64Bit = "jre-6u30-windows-x64.exe";
        const string FileName32Bit = "jre-6u30-windows-i586-s.exe";

        public static bool Installed
        {
            get { return Executable != null; }
        }

        public static FileInfo Executable
        {
            get
            {
                var installDirectory = InstallDirectory;
                if (installDirectory != null)
                {
                    var fileName = installDirectory.FullName + @"\bin\java.exe";
                    var returnValue = new FileInfo(fileName);
                    if (returnValue.Exists)
                    {
                        return returnValue;
                    }
                }

                return null;
            }
        }

        public static DirectoryInfo InstallDirectory
        {
            get
            {

                bool javaKey32Found;
                bool javaKey64Found;

                using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(JavaKey32))
                {
                    javaKey32Found = baseKey != null;
                }

                using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(JavaKey64))
                {
                    javaKey64Found = baseKey != null;
                }

                if (javaKey32Found || javaKey64Found)
                {
                    using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(javaKey32Found ? JavaKey32 : JavaKey64))
                    {
                        if (baseKey != null)
                        {
                            using (var homeKey = baseKey.OpenSubKey(baseKey.GetValue("CurrentVersion").ToString()))
                            {
                                if (homeKey != null)
                                {
                                    string javaHome = homeKey.GetValue("JavaHome").ToString();
                                    if (!string.IsNullOrEmpty(javaHome))
                                    {
                                        var javaHomeDirectoryInfo = new DirectoryInfo(javaHome);
                                        if (javaHomeDirectoryInfo.Exists)
                                        {
                                            return javaHomeDirectoryInfo;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                return null;
            }
        }

        public static void Install()
        {
            string url = Environment.Is64BitProcess ? Url64Bit : Url32Bit;
            string filename = Environment.Is64BitProcess ? FileName64Bit : FileName32Bit;

            var client = new WebClient();
            client.DownloadFile(url, filename);

            // Install with option [/s]
            var start = new ProcessStartInfo
                {
                    FileName = filename,
                    Arguments = "/s",
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                };

            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    reader.ReadToEnd();
                }
            }

            // Cleanup downloaded file
            var javaDownload = new FileInfo(filename);
            if (javaDownload.Exists)
            {
                if (WaitForFile(javaDownload.FullName))
                {
                    javaDownload.Delete();
                }
            }
        }

        public static void UnInstall()
        {
            var start = new ProcessStartInfo()
            {
                FileName = "MsiExec.exe",
                Arguments = "/X {26A24AE4-039D-4CA4-87B4-2F86416030FF} /QUIET",
                UseShellExecute = false,
                RedirectStandardOutput = true
            };

            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    reader.ReadToEnd();
                }
            }
        }

        /// <summary> 
        /// Blocks until the file is not locked any more. 
        /// </summary> 
        /// <param name="fullPath"></param> 
        private static bool WaitForFile(string fullPath)
        {
            int numTries = 0;
            while (true)
            {
                ++numTries;
                try
                {
                    // Attempt to open the file exclusively. 
                    using (FileStream fs = new FileStream(fullPath,
                        FileMode.Open, FileAccess.ReadWrite,
                        FileShare.None, 100))
                    {
                        fs.ReadByte();

                        // If we got this far the file is ready 
                        break;
                    }
                }
                catch
                {
                    //Log.LogWarning(
                    //   "WaitForFile {0} failed to get an exclusive lock: {1}",
                    //    fullPath, ex.ToString());

                    if (numTries > 10)
                    {
                        //Log.LogWarning(
                        //    "WaitForFile {0} giving up after 10 tries",
                        //    fullPath);
                        return false;
                    }

                    // Wait for the lock to be released 
                    System.Threading.Thread.Sleep(500);
                }
            }

            //Log.LogTrace("WaitForFile {0} returning true after {1} tries",
            //    fullPath, numTries);
            return true;
        }


    }
}
