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

    /// <summary>
    /// Thread Parameter for Digit Initial
    /// </summary>
    public class ValidatePDFParameter : ICloneable
    {

        /// <summary>
        /// RootPath
        /// program will search all of the files under the RootPath and change name with regular Expression
        /// </summary>
        private string _VeraPDFPath;
        public string VeraPDFPath
        {
            get { return _VeraPDFPath; }
        }
        public void SetVeraPDFPath(string value)
        {
            _VeraPDFPath = value;
        }
        /// <summary>
        /// RootPath
        /// program will search all of the files under the RootPath and change name with regular Expression
        /// </summary>
        private string _ResultFilePath;
        public string ResultFilePath
        {
            get { return _ResultFilePath; }
        }
        public void SetResultFilePath(string value)
        {
            _ResultFilePath = value;
        }
        private string _PDFCheckingDir;
        public string PDFCheckingDir
        {
            get { return _PDFCheckingDir; }
        }
        public void SetPDFCheckingDir(string value)
        {
            _PDFCheckingDir = value;
        }

        private bool _IsContainsSubFold;
        public bool IsContainsSubFold
        {
            get { return _IsContainsSubFold; }
        }
        public void SetIsContainsSubFold(bool value)
        {
            _IsContainsSubFold = value;
        }
        private string  _CheckIDNM;
        public string CheckIDNM
        {
            get { return _CheckIDNM; }
        }
        public void SetCheckIDNM(string value)
        {
            _CheckIDNM = value;
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
    public class ChangeNavigationPageParameter : ICloneable
    {


        /// <summary>
        /// RootPath
        /// program will search all of the files under the RootPath and change name with regular Expression
        /// </summary>
        private List<string> _OriginalRootPath;
        public List<string> OriginalRootPath
        {
            get { return _OriginalRootPath; }
        }
        public void AddOriginalRootPath(string value)
        {
            if (_OriginalRootPath == null)
            {
                _OriginalRootPath = new List<string>();
            };
            _OriginalRootPath.Add(value);
        }

        private string _FileNameRegexRegular;
        public string FileNameRegexRegular
        {
            get { return _FileNameRegexRegular; }
        }
        public void SetFileNameRegexRegular(string value)
        {
            _FileNameRegexRegular = value;
        }

        private string _FileNameRegexReplacement;
        public string FileNameRegexReplacement
        {
            get { return _FileNameRegexReplacement; }
        }
        public void SetFileNameRegexReplacement(string value)
        {
            _FileNameRegexReplacement = value;
        }

        private string _HTMLRegexRegular;
        public string HTMLRegexRegular
        {
            get { return _HTMLRegexRegular; }
        }
        public void SetHTMLRegexRegular(string value)
        {
            _HTMLRegexRegular = value;
        }

        private string _HTMLRegexReplacement;
        public string HTMLRegexReplacement
        {
            get { return _HTMLRegexReplacement; }
        }
        public void SetHTMLRegexReplacement(string value)
        {
            _HTMLRegexReplacement = value;
        }

        private bool _EnabledHTMLReplacement;
        public bool EnabledHTMLReplacement
        {
            get { return _EnabledHTMLReplacement; }
        }
        public void SetEnabledHTMLReplacement(bool value)
        {
            _EnabledHTMLReplacement = value;
        }

        private bool _EnabledFileNameReplacement;
        public bool EnabledFileNameReplacement
        {
            get { return _EnabledFileNameReplacement; }
        }
        public void SetEnabledFileNameReplacement(bool value)
        {
            _EnabledFileNameReplacement = value;
        }

        private string _FileExtension;
        public string FileExtension
        {
            get { return _FileExtension; }
        }
        public void SetFileExtension(string value)
        {
            _FileExtension = value;
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
