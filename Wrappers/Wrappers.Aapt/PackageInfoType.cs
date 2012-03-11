using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;

namespace Wrappers
{
    public static partial class Aapt
    {
        public class DumpResult
        {
            public FileInfo sourcefile;
            public PackageType package;
            public ApplicationType application;
            public ActivityType launchable_activity;
            public string[] uses_permission;
            public string[] uses_feature;
            public string sdkVersion;
            public string targetSdkVersion;
            public ScreenType[] supports_screens;
            public LocaleType[] locales;
            public int[] densities;
            public string native_code;

            public enum ScreenType
            {
                Small, Normal, Large
            }

            public class LocaleType
            {
                public string Name;
                public string EnglishName;
                public string PathName;

                public LocaleType(string _Name, string _EnglishName, string _PathName)
                {
                    Name = _Name;
                    EnglishName = _EnglishName;
                    PathName = _PathName;
                }

                public LocaleType(CultureInfo ci)
                {
                    Name = ci.Name;
                    EnglishName = string.Format("{0} ({1})", ci.EnglishName, ci.Name);
                    PathName = ci.Name.Replace("_", "-r");
                }

                public override string ToString()
                {
                    return EnglishName;
                }
            }

            public struct PackageType
            {
                public string name;
                public string versionCode;
                public string versionName;
            }

            public struct ApplicationType
            {
                public string label;
                public string icon;
            }

            public struct ActivityType
            {
                public string name;
                public string label;
                public string icon;
            }
        }

        
    }
}