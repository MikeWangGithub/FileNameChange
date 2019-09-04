using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileNameChange.Tools;
using System.IO;

namespace FileNameChange.Tools
{
    public class FileHistoryRecorder :  IHistoryRecorder
    {
        private StreamWriter sw;
        private string _FileName;
        /// <summary>
        /// true:append; false:overwrite
        /// </summary>
        public bool IsAppend { get;  }


        public FileHistoryRecorder()
        {
            
        }
        public FileHistoryRecorder(string FileName):base()
        {
            SetRecorderStoredName(FileName);
            Initial();
        }
        public FileHistoryRecorder(string FileName, bool Append):this(FileName)
        {
            IsAppend = Append;
        }
        
        public void Initial()
        {
            if (sw == null)
            {
                if (!System.IO.File.Exists(this.RecorderStoredName))
                {
                    if (System.IO.Directory.GetParent(this.RecorderStoredName).Exists)
                    {
                        using( System.IO.File.Create(this.RecorderStoredName) ){
                        }
                    }
                    
                }
                if (System.IO.File.Exists(this.RecorderStoredName))
                    sw = new StreamWriter(this.RecorderStoredName, IsAppend,Encoding.UTF8);
            }
            
        }
        public void Open()
        {
            if (System.IO.File.Exists(this.RecorderStoredName))
                sw = new StreamWriter(this.RecorderStoredName, IsAppend, Encoding.UTF8);
        }
        public string RecorderStoredName { get { return _FileName; } }
        public void SetRecorderStoredName(string FileName)
        {
            this._FileName = FileName;
        }
      
        
        public bool Record(string value)
        {

            bool rtn = true;
            Initial();
            if (sw == null)
            {
                return false;
            }
            try { 
                sw.WriteLine(value);
                rtn = true;
            }
            catch
            {
                rtn = false;
            }
            return rtn;

        }

        public bool Record(IEnumerable<string > objList)
        {
            bool rtn = true;
            foreach(var value in objList)
            {
                rtn = rtn && Record(value);
            }
            return rtn;
        }

        public void Close()
        {
            if (sw != null)
            {
                sw.Close();
            }
        }

    }
}
