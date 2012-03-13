namespace Wrappers
{
    using System.IO;

    public partial class Signapk
    {
        public static string Sign(string apkFile, bool overWrite)
        {
            return Sign(new FileInfo(apkFile), overWrite).FullName;
        }

        public static FileInfo Sign(FileInfo apkFile, bool overWrite)
        {
            var signedApkFile = new FileInfo(Path.ChangeExtension(apkFile.FullName, null) + "-signed" + apkFile.Extension);
            
            Command.Run(
                "-w  \"{0}\\testkey.x509.pem\" \"{0}\\testkey.pk8\" \"{1}\" \"{2}\"",
                Path.GetDirectoryName(System.Reflection.Assembly.GetCallingAssembly().Location) + @"\Tools\signapk",
                apkFile.FullName,
                signedApkFile.FullName);

            if (overWrite)
            {
                apkFile.Delete();
                signedApkFile.MoveTo(apkFile.FullName);
            }

            return signedApkFile;
        }
    }
}
