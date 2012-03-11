using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace Wrappers
{
    public static partial class Java
    {
        public static bool Installed
        {
            get { return (Executable != null); }
        }

        public static FileInfo Executable
        {
            get
            {
                DirectoryInfo installDirectory = InstallDirectory;
                if (installDirectory != null)
                {
                    string fileName = installDirectory.FullName + @"\bin\java.exe";
                    FileInfo returnValue = new FileInfo(fileName);
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
                DirectoryInfo returnValue = null;
                String javaKey32 = "SOFTWARE\\JavaSoft\\Java Runtime Environment";
                String javaKey64 = "SOFTWARE\\Wow6432Node\\JavaSoft\\Java Runtime Environment";

                bool javaKey32Found = false;
                bool javaKey64Found = false;

                using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(javaKey32))
                {
                    javaKey32Found = (baseKey != null);
                }
                using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(javaKey64))
                {
                    javaKey64Found = (baseKey != null);
                }

                if (javaKey32Found || javaKey64Found)
                {
                    using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(javaKey32Found ? javaKey32 : javaKey64))
                    {
                        if (baseKey != null)
                        {
                            String currentVersion = baseKey.GetValue("CurrentVersion").ToString();
                            using (var homeKey = baseKey.OpenSubKey(currentVersion))
                                returnValue = new DirectoryInfo(homeKey.GetValue("JavaHome").ToString());
                        }
                    }
                }
                return returnValue;
            }
        }

        public static void Install()
        {
            string url = (Environment.Is64BitProcess) ?
                "http://javadl.sun.com/webapps/download/AutoDL?BundleId=58126" :
                "http://javadl.sun.com/webapps/download/AutoDL?BundleId=58124";
            string filename = (Environment.Is64BitProcess) ?
                "jre-6u30-windows-x64.exe" :
                "jre-6u30-windows-i586-s.exe";

            WebClient client = new WebClient();
            client.DownloadFile(url, filename);

            // Install with option [/s]
            string result;
            ProcessStartInfo start = new ProcessStartInfo()
            {
                FileName = filename,
                Arguments = "/s",
                UseShellExecute = false,
                RedirectStandardOutput = true
            };

            using (Process process = Process.Start(start))
            using (StreamReader reader = process.StandardOutput)
                result = reader.ReadToEnd();

            //Cleanup downloaded file
            FileInfo javaDownload = new FileInfo(filename);
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
            string result = string.Empty;
            ProcessStartInfo start = new ProcessStartInfo()
            {
                FileName = "MsiExec.exe",
                Arguments = "/X {26A24AE4-039D-4CA4-87B4-2F86416030FF} /QUIET",

                UseShellExecute = false,
                RedirectStandardOutput = true
            };

            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                    result = reader.ReadToEnd();
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
                catch (Exception ex)
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
