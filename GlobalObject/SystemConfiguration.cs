using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileNameChange.Tools;

namespace FileNameChange.GlobalObject
{
    /// <summary>
    /// System Configuration .
    /// All properties come from App.config
    /// Global Class. Can be used by everyone and anywhere.
    /// </summary>
    public static class SystemConfiguration
    {
        private static bool _Debug;
        public static bool Debug
        {
            get { return _Debug; }
        }
        private static void SetDebug(bool value)
        {
            _Debug = value;
        }

        private static string _LoggerClassName;
        public static string LoggerClassName { get { return _LoggerClassName; } }
        private static void SetLoggerClassName(string value)
        {
            _LoggerClassName = value;
        }

        private static string _HistorRecorderClassName;
        public static string HistorRecorderClassName { get { return _HistorRecorderClassName; } }
        private static void SetHistorRecorderClassName(string value)
        {
            _HistorRecorderClassName = value;
        }

        private static string _SuccessHistoryName;
        public static string SuccessHistoryName { get { return AppPath + "\\" + _SuccessHistoryName; } }
        private static void SetSuccessHistoryName(string value)
        {
            _SuccessHistoryName = value;
        }
        private static string _FailHistoryName;
        public static string FailHistoryName { get { return AppPath + "\\" + _FailHistoryName; } }
        private static void SetFailHistoryName(string value)
        {
            _FailHistoryName = value;
        }

        private static string _AppPath;
        public static string AppPath { get { return _AppPath; } }
        private static void SetAppPath(string value)
        {
            _AppPath = value;
        }

        private static string _ExecutedPath;
        public static string ExecutedPath { get { return _ExecutedPath; } }
        private static void SetExecutedPath(string value)
        {
            _ExecutedPath = value;
        }

        
        private static string _InvalidCharacter;
        public static string InvalidCharacter { get { return _InvalidCharacter; } }
        private static void SetInvalidCharacter(string value)
        {
            _InvalidCharacter = value;
        }

        private static int _NameMaxLength;
        public static int NameMaxLength { get { return _NameMaxLength; } }
        private static void SetNameMaxLength(int value)
        {
            _NameMaxLength = value;
        }

        //<add key = "RegexRegular_Invalid" value="(19|20)[0-9]{2}[0-1]{1}[0-2]{1}[0-3]{1}[0-9]{1}(_|-)[0-9]{4}%.{50,}" />
        private static Dictionary<string,string> _RegexRegular_InvalidDict;
        public static Dictionary<string, string> RegexRegular_InvalidDict { get { return _RegexRegular_InvalidDict; } }

        private static Dictionary<string, string> _Configurations;

        public static Dictionary<string, string> Configurations
        {
            get { return _Configurations; }
        }
        public static void AddValue(string key,string value)
        {
            if (_Configurations != null)
            {
                //if()
                _Configurations.Add(key, value);
            }
        }

        public static void SetValue(string key, string value)
        {
            if (_Configurations != null)
            {
                //if()
                _Configurations[key] = value;
            }
        }
        public static void Initial(string executedPath)
        {
            _Configurations = new Dictionary<string, string>();
            AddValue("ExecutedPath", executedPath);
            AddValue("AppPath", System.IO.Directory.GetCurrentDirectory());

            //SetExecutedPath(executedPath);
            //SetAppPath(System.IO.Directory.GetCurrentDirectory());
        
            LoadConfiguraion();
            

        }
        private static void LoadConfiguraion()
        {

            //Set debug
            SetDebug((AppConfig.GetAppConfig("debug").Trim().ToLower() == "true") ? true : false);
            //AddValue("Debug", AppConfig.GetAppConfig("debug").Trim().ToLower());

            //Set logger
            //SetLoggerClassName(AppConfig.GetAppConfig("Logger"));
            AddValue("LoggerClassName", AppConfig.GetAppConfig("Logger"));
            //Set HistorRecorderClass
            SetHistorRecorderClassName(AppConfig.GetAppConfig("HistorRecorderClass"));
            //Set HistorName
            SetSuccessHistoryName(AppConfig.GetAppConfig("SuccessHistoryName"));
            //set FailHistoryName
            SetFailHistoryName(AppConfig.GetAppConfig("FailHistoryName"));
            //Set InvalidCharacter
            SetInvalidCharacter(AppConfig.GetAppConfig("InvalidCharacter"));
            try
            {
                int x = System.Convert.ToInt32(AppConfig.GetAppConfig("NameMaxLength"));
                SetNameMaxLength(x);
            }
            catch
            {
                SetNameMaxLength(50);
            }

            //RegexRegular_Invalid
            _RegexRegular_InvalidDict = new Dictionary<string, string>();
            string s = AppConfig.GetAppConfig("RegexRegular_Invalid");
            string[] ls = s.Split('%');
            foreach (string i in ls)
            {
                string[] x1 = i.Split(':');
                if (x1.Length >= 2)
                {
                    _RegexRegular_InvalidDict.Add(x1[0], x1[1]);
                }

            }

        }



    }
}
