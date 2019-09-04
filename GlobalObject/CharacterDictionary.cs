using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileNameChange.GlobalObject
{
    public static class CharacterDictionary
    {
        private static Dictionary<string, string> Dictionary;
        private static string _OthersReplacement;
        public static string OthersReplacement { get { return _OthersReplacement; } }
        public static void Initial(string othersReplacement)
        {
            Initial();
            _OthersReplacement = othersReplacement;

        }
        public static void Initial()
        {
            if (Dictionary == null)
            {
                Dictionary = new Dictionary<string, string>();
            }
            else { return; }
            

        }

        public static void Add(string key,string value)
        {
            if (Dictionary == null)
            {
                Initial();
            }
            Dictionary.Add(key, value);
        }
        public static string GetValue(string key)
        {
            string value;
            if (Dictionary != null) {
                //value = Dictionary[key];
                Dictionary.TryGetValue(key, out value);
                return value;
            }
            else
            {
                return null;
            }
        }
        public static bool Remove(string key)
        {
            return Dictionary.Remove(key);
            
        }

        public static Dictionary<string,string>.KeyCollection Keys { get { return Dictionary.Keys; } }

    }
}
