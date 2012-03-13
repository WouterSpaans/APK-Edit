namespace Wrappers
{
    using System;
    using System.Diagnostics;
    using System.IO;

    public partial class Signapk
    {
        public static class Command
        {
            private static FileInfo fileInfo;

            public static FileInfo FileInfo
            {
                get
                {
                    if (fileInfo != null)
                    {
                        return fileInfo;
                    }

                    fileInfo = new FileInfo(Path.GetDirectoryName(
                                               System.Reflection.Assembly.GetCallingAssembly().Location) +
                                               @"\Tools\signapk\signapk.jar");
                    return fileInfo;
                }
            }

            public static RunResult Run(string argument, params object[] args)
            {
                return Run(argument, true, args);
            }

            public static RunResult Run(string argument, bool waitForExit = true, params object[] args)
            {
                var runResult = new RunResult();
                try
                {
                    string arguments = argument != null && args != null ? string.Format(argument, args) : string.Empty;
                    var process = new Process();
                    process.StartInfo.WorkingDirectory = FileInfo.DirectoryName;
                    process.StartInfo.FileName = Java.Executable.FullName;
                    process.StartInfo.Arguments = string.Format("-jar \"{0}\" {1}", FileInfo.FullName, arguments);
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.ErrorDialog = false;

                    if (waitForExit)
                    {
                        process.StartInfo.RedirectStandardOutput = true;
                        process.StartInfo.RedirectStandardError = true;
                        process.Start();
                        StreamReader outputReader = process.StandardOutput;
                        StreamReader errorReader = process.StandardError;

                        runResult.Output = outputReader.ReadToEnd();
                        runResult.Error = errorReader.ReadToEnd();
                        process.WaitForExit();
                        runResult.Succes = true;
                    }
                    else
                    {
                        process.Start();
                        runResult.Output = string.Empty;
                        runResult.Error = string.Empty;
                        runResult.Succes = true;
                    }
                }
                catch (Exception ex)
                {
                    runResult.Output = string.Empty;
                    runResult.Error = ex.Message;
                    runResult.Succes = false;
                }
                return runResult;
            }

            public struct RunResult
            {
                public bool Succes;
                public string Output;
                public string Error;
            }
        }
    }
}