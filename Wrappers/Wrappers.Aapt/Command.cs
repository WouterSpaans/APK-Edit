using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace Wrappers
{
    public partial class Aapt
    {
        public static class Command
        {
            private static FileInfo _FileInfo;
            public static FileInfo FileInfo
            {
                get
                {
                    if (_FileInfo != null)
                        return _FileInfo;

                    _FileInfo = new FileInfo(Path.GetDirectoryName(
                                               System.Reflection.Assembly.GetCallingAssembly().Location) +
                                               @"\Tools\apktool\aapt.exe");
                    return _FileInfo;
                }
            }

            public static string Run(string argument, params object[] args)
            {
                string result;
                ProcessStartInfo start = new ProcessStartInfo()
                {
                    FileName               = FileInfo.FullName,
                    Arguments              = string.Format(argument, args),
                    UseShellExecute        = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow         = true
                };

                using (Process process     = Process.Start(start))
                using (StreamReader reader = process.StandardOutput)
                    result                 = reader.ReadToEnd();

                return result;
            }

        }
    }
}