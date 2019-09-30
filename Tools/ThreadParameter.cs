using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FileNameChange.Tools
{
    public enum EventSet { DirectoryEvent=1, FileEvent=2 }
    /// <summary>
    /// Thread Name Set
    /// </summary>
    public enum ThreadName { ChangeFileName = 1,CheckName=2 ,Traverse=3}
    /// <summary>
    /// Thread Parameter for Digit Initial
    /// </summary>
    public class ChangeFileNameParameter : ICloneable
    {

        /// <summary>
        /// RootPath
        /// program will search all of the files under the RootPath and change name with regular Expression
        /// </summary>
        private string _OriginalRootPath;
        public string OriginalRootPath
        {
            get { return _OriginalRootPath; }
        }
        public void SetOriginalRootPath(string value)
        {
            _OriginalRootPath = value;
        }
        private string _OutputRootPath;
        public string OutputRootPath
        {
            get { return _OutputRootPath; }
        }
        public void SetOutputRootPath(string value)
        {
            _OutputRootPath = value;
        }
        /// <summary>
        /// Copy object, high effective than create object
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
    /// <summary>
    /// Thread Parameter for Digit Initial
    /// </summary>
    public class CheckNameParameter : ICloneable
    {

        /// <summary>
        /// RootPath
        /// program will search all of the files under the RootPath and change name with regular Expression
        /// </summary>
        private string _OriginalRootPath;
        public string OriginalRootPath
        {
            get { return _OriginalRootPath; }
        }
        public void SetOriginalRootPath(string value)
        {
            _OriginalRootPath = value;
        }
        
        /// <summary>
        /// Copy object, high effective than create object
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }


    /// <summary>
    /// Thread Parameter for Digit Initial
    /// </summary>
    public class TraverseParameter : ICloneable
    {

        /// <summary>
        /// RootPath
        /// program will search all of the files under the RootPath and change name with regular Expression
        /// </summary>
        private string _OriginalRootPath;
        public string OriginalRootPath
        {
            get { return _OriginalRootPath; }
        }
        public void SetOriginalRootPath(string value)
        {
            _OriginalRootPath = value;
        }

        /// <summary>
        /// Copy object, high effective than create object
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

}
