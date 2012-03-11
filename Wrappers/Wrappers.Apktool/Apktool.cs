using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Wrappers
{
    public static partial class Apktool
    {
        public static string Version
        {
            get
            {
                return Command.Run(null, null).Output.Substring(9, 5);
            }
        }
        public static Command.RunResult Decode(string apkFile, string directory, bool decodeSources = true, bool decodeResources = true, bool debugMode = false, bool forceDeleteDestination = true, string frameworkTag = null, bool keepBrokenResources = false)
        {
            return Decode(new FileInfo(apkFile), new DirectoryInfo(directory), decodeSources, decodeResources, debugMode, forceDeleteDestination, frameworkTag, keepBrokenResources);
        }

        public static Command.RunResult Decode(FileInfo apkFile, DirectoryInfo directory, bool decodeSources = true, bool decodeResources = true, bool debugMode = false, bool forceDeleteDestination = true, string frameworkTag = null, bool keepBrokenResources = false)
        {
            string optionalArgs = string.Empty;
            if (!decodeSources) optionalArgs += "-s ";
            if (!decodeResources) optionalArgs += "-r ";
            if (debugMode) optionalArgs += "-d ";
            if (forceDeleteDestination) optionalArgs += "-f ";
            if (frameworkTag != null) optionalArgs += string.Format("-t {0} ", frameworkTag);
            if (keepBrokenResources) optionalArgs += "--keep-broken-res ";

            return Command.Run("d {0} \"{1}\" \"{2}\"", optionalArgs, apkFile.FullName, directory.FullName);
        }

       

        public static Command.RunResult Build(string directory, string apkFile, bool forceAll = false, bool debugMode = false)
        {
            return Build(new DirectoryInfo(directory), new FileInfo(apkFile), forceAll, debugMode);
        }

        public static Command.RunResult Build(DirectoryInfo directory, FileInfo apkFile, bool forceAll = false, bool debugMode = false)
        {
            string optionalArgs = string.Empty;
            if (forceAll) optionalArgs += "-f ";
            if (debugMode) optionalArgs += "-d ";

            return Command.Run("b {0} \"{1}\" \"{2}\"", optionalArgs, directory.FullName, apkFile.FullName);
        }

        public static Command.RunResult InstallFramework(string apkFile, string frameworkTag = null)
        {
            return InstallFramework(new FileInfo(apkFile), frameworkTag);
        }

        public static Command.RunResult InstallFramework(FileInfo apkFile, string frameworkTag = null)
        {
            return Command.Run("if \"{0}\" {1}", apkFile.FullName, frameworkTag ?? "");
        }

    }
}
