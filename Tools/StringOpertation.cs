using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileNameChange.Tools
{
    class StringOpertation
    {
        public static string GetByteDescription(long length)
        {
            string rtn = "";
            if (length < 1024)
            {
                rtn = length.ToString("N0") + "B";
            }
            else if (length < 1024 * 1024)
            {
                rtn = (length / 1024).ToString("N1") + "KB";
            }
            else if (length < 1024 * 1024 * 1024)
            {
                rtn = (length / (1024 * 1024)).ToString("N1") + "MB";
            }
            else
            {
                rtn = (length / (1024 * 1024 * 1024)).ToString("N1") + "GB";
            }
            return rtn;
        }
    }
}
