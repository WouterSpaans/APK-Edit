namespace APK_Edit
{
    using System.Globalization;
    using System.Windows.Forms;

    public class AppSettings
    {
        public static bool EnableBackup
        {
            get
            {
                bool? result = ReadConfigBool("EnableBackup");
                return result.HasValue ? result.Value : true;
            }

            set
            {
                WriteConfigBool("EnableBackup", value);
            }
        }

        public static bool OverWriteBackup
        {
            get
            {
                bool? result = ReadConfigBool("OverWriteBackup");
                return result.HasValue ? result.Value : false;
            }

            set
            {
                WriteConfigBool("OverWriteBackup", value);
            }
        }

        public static bool CreateSeperateSigningFile
        {
            get
            {
                bool? result = ReadConfigBool("CreateSeperateSigningFile");
                return result.HasValue ? result.Value : false;
            }

            set
            {
                WriteConfigBool("CreateSeperateSigningFile", value);
            }
        }

        public static bool EnableSigning
        {
            get
            {
                bool? result = ReadConfigBool("EnableSigning");
                return result.HasValue ? result.Value : true;
            }

            set
            {
                WriteConfigBool("EnableSigning", value);
            }
        }

        private static bool? ReadConfigBool(string key)
        {
            // Read registry
            if (Application.UserAppDataRegistry != null)
            {
                object registryValue = Application.UserAppDataRegistry.GetValue(key);
                if (registryValue != null)
                {
                    bool tempBool;
                    if (bool.TryParse(registryValue.ToString(), out tempBool))
                    {
                        return tempBool;
                    }
                }
            }

            return null;
        }

        private static void WriteConfigBool(string key, bool value)
        {
            // Write registry
            if (Application.UserAppDataRegistry != null)
            {
                Application.UserAppDataRegistry.SetValue(key, value.ToString(CultureInfo.InvariantCulture));
            }
        }
    }
}
