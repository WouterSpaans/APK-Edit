using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System.Text;

namespace Wrappers
{
    public static partial class Aapt
    {
        public static DumpResult Dump(FileInfo SourceFile)
        {
            DumpResult returnValue = new DumpResult() { sourcefile = SourceFile };

            if (SourceFile.Exists)
                if (SourceFile.Extension.ToLower() == ".apk")
                {
                    // Run external command
                    string[] lines                   = Command.Run(@"dump badging ""{0}""", SourceFile.FullName).Replace("\r", "").Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] packageLine             = GetLines(lines, "package:");
                    string[] applicationLine         = GetLines(lines, "application:");
                    string[] launchable_activityLine = GetLines(lines, "launchable activity");
                    string[] sdkVersionLine          = GetLines(lines, "sdkVersion:");
                    string[] targetSdkVersionLine    = GetLines(lines, "targetSdkVersion:");
                    string[] native_codeLine         = GetLines(lines, "native-code:");
                    string[] uses_permissionLine     = GetLines(lines, "uses-permission:");
                    string[] uses_featureLine        = GetLines(lines, "uses-feature:");
                    string[] supports_screensLine    = GetLines(lines, "supports-screens: ");
                   
                    returnValue.package.name              = SearchValue(packageLine, "name=");
                    returnValue.package.versionCode       = SearchValue(packageLine, "versionCode=");
                    returnValue.package.versionName       = SearchValue(packageLine, "versionName=");
                    returnValue.application.label         = SearchValue(applicationLine, "label=");
                    returnValue.application.icon          = SearchValue(applicationLine, "icon=");
                    returnValue.launchable_activity.name  = SearchValue(launchable_activityLine, "name=");
                    returnValue.launchable_activity.label = SearchValue(launchable_activityLine, "label=");
                    returnValue.launchable_activity.icon  = SearchValue(launchable_activityLine, "icon=");
                    returnValue.sdkVersion                = SearchValue(sdkVersionLine, "sdkVersion:");
                    returnValue.targetSdkVersion          = SearchValue(targetSdkVersionLine, "targetSdkVersion:");
                    returnValue.native_code               = SearchValue(native_codeLine, "native-code: ");
                    returnValue.uses_permission           = SearchValues(uses_permissionLine, "uses-permission:");
                    returnValue.uses_feature              = SearchValues(uses_featureLine, "uses-feature:");
                    returnValue.supports_screens          = Get_Supports_screens(supports_screensLine).ToArray();
                    returnValue.locales                   = Get_Locales(lines).ToArray();
                    returnValue.densities                 = Get_Densities(lines).ToArray();
                }

            return returnValue;
        }

        private static string[] GetLines(string[] str, string SearchValue)
        {
            return str.Where(cust => cust.Contains(SearchValue)).ToArray();
        }

        private static string SearchValue(string[] strArr, string SearchValue)
        {
            string returnValue = "";
            if (strArr.Count() > 0)
            {
                string str = strArr[0];  // Only check first row

                if (!SearchValue.EndsWith("'")) SearchValue += "'"; // Add ' if needed
                int i = str.IndexOf(SearchValue) + SearchValue.Length;
                int j = str.IndexOf("'", i);

                returnValue = str.Substring(i, j - i);
            }

            return returnValue;
        }

        private static string[] SearchValues(string[] strArr, string SearchValue)
        {
            // Add ' if needed
            if (!SearchValue.EndsWith("'")) SearchValue += "'";

            List<string> returnValue = new List<string>();
            foreach (string line in strArr)
            {
                if (line.Contains(SearchValue))
                {
                    // remove pre stuff...
                    // string finalline = line.Replace(SearchValue, "").Replace("'", "").Replace("android.permission.", "").Replace("android.hardware.", "");
                    int last = line.LastIndexOf('.');
                    string stripped = line.Substring(last + 1, line.Length - last - 2).Replace("_", " ");
                    returnValue.Add(CapitalizeWords(stripped));
                }
            }
            return returnValue.ToArray();
        }

        private static List<DumpResult.ScreenType> Get_Supports_screens(string[] supports_screensLine)
        {
            //supports_screens
            List<DumpResult.ScreenType> supports_screensList = new List<DumpResult.ScreenType>();
            if (supports_screensLine.Count() > 0)
            {
                if (supports_screensLine[0].Contains("small")) supports_screensList.Add(DumpResult.ScreenType.Small);
                if (supports_screensLine[0].Contains("normal")) supports_screensList.Add(DumpResult.ScreenType.Normal);
                if (supports_screensLine[0].Contains("large")) supports_screensList.Add(DumpResult.ScreenType.Large);
            }
            return supports_screensList;
        }
   
        private static List<DumpResult.LocaleType> Get_Locales(string[] lines)
        {
            //public string[] locales;
            List<DumpResult.LocaleType> l = new List<DumpResult.LocaleType>();
            string[] localesLine = GetLines(lines, "locales:");
            if (localesLine.Count() > 0)
            {
                char[] split = { ' ' };
                string[] locs = localesLine[0].Replace("locales: ", "").Replace("'", "").Split(split, StringSplitOptions.RemoveEmptyEntries);

                // now add real locales?
                foreach (string Name in locs)
                {
                    string PathName = Name.Replace("_", "-r");

                    string EnglishName;
                    try
                    {
                        CultureInfo culture = CultureInfo.GetCultureInfo(Name.Replace("_", "-"));
                        EnglishName = string.Format("{0} ({1})", culture.EnglishName, Name);
                    }
                    catch
                    {
                        if (Name == ("--_--"))
                            EnglishName = string.Format("Default ({0})", Name);
                        else
                            EnglishName = string.Format("Unknown ({0})", Name);
                    }

                    l.Add(new DumpResult.LocaleType(Name, EnglishName, PathName));
                }

            }
            return l;
        }
        
        private static List<int> Get_Densities(string[] lines)
        {
            //public int[] densities;
            string[] densitiesLine = GetLines(lines, "densities:");
            List<int> desList = new List<int>();
            if (densitiesLine.Count() > 0)
            {
                char[] split = { ' ' };
                string[] tmpArr;
                tmpArr = densitiesLine[0].Replace("densities: ", "").Replace("'", "").Split(split, StringSplitOptions.RemoveEmptyEntries);
                // Convert all

                foreach (string val in tmpArr)
                {
                    int outVal;
                    if (int.TryParse(val, out outVal))
                        desList.Add(outVal);
                }
            }
            return desList;
        }
   
        private static string CapitalizeWords(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            StringBuilder result = new StringBuilder(str);
            result[0] = char.ToUpper(result[0]);
            for (int i = 1; i < result.Length; ++i)
                result[i] = char.IsWhiteSpace(result[i - 1]) ? char.ToUpper(result[i]) : char.ToLower(result[i]);
            return result.ToString();
        }
    }
}
