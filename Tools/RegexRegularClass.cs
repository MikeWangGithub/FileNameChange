using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileNameChange.Tools
{
    public class RegexRegularClass
    {
        private static Dictionary<string, string> _RegexRegular_InvalidDict;
        public static Dictionary<string, string> RegexRegular_InvalidDict { get { return _RegexRegular_InvalidDict; } }

        public static void Initial(string regulars)
        {
            _RegexRegular_InvalidDict = new Dictionary<string, string>();
            string s = regulars; //SystemConfiguration.GetValue("RegexRegular_Invalid");
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
