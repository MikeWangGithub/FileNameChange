using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using FileNameChange.Tools;
using System.Threading;
using FileNameChange.Algorithm;
using FileNameChange.GlobalObject;
using BaseClassLibrary.Tools;
using BaseClassLibrary.Threading;

namespace FileNameChange.Threading
{
    /// <summary>
    /// Thread for get a new PIN.
    /// </summary>
    public class ChangeNavigationPage : ParentThread<bool>
    {
        private ChangeNavigationPageParameter param;
        //private IHistoryRecorder SuccessRecorder;
        private IHistoryRecorder SuccessRecorder;
        private int successamount = 0;
        private StreamReader sr;
        private StreamWriter sw;

        public ChangeNavigationPage(CancellationTokenSource _tokenSource, ICloneable _threadParameter) : base(_tokenSource, _threadParameter)
        {
            if (this.ThreadParameter != null)
            {
                param = (ChangeNavigationPageParameter)this.ThreadParameter;

            }
            //amount = 0;
        }
        /// <summary>
        /// Traverse RootPath 
        /// </summary>
        /// <returns>If RootPath is not exists ,don't need execute next step</returns>
        public override bool CheckParameter()
        {
            //bool rtn = System.IO.Directory.Exists(param.OriginalRootPath);
            //if (rtn)
            //{
            //    //SuccessRecorder = ObjectBuildFactory<IHistoryRecorder>.Instance(SystemConfiguration.HistorRecorderClassName,new object[] { SystemConfiguration.SuccessHistoryName, true });
            //    SuccessRecorder = ObjectBuildFactory<IHistoryRecorder>.Instance(SystemConfiguration.GetValue("HistorRecorderClassName"), new object[] { SystemConfiguration.GetValue("SuccessHistoryName"), true });

            //}
            //else
            //{
            //    LoggerHelper.Warn("[" + param.OriginalRootPath + "] is Exists.\r\n");
            //}
            //return rtn;
            return true;
        }

        /// <summary>
        /// recursive  call by self
        /// </summary>
        /// <returns></returns>
        public override bool RunSubThread(ICloneable thparam)
        {
            //judage if threading is cancelled.
            this.IsTaskCanceled();
            ChangeNavigationPageParameter param;

            if (thparam != null)
            {
                param = (ChangeNavigationPageParameter)thparam;
            }
            else
            {
                return default(bool);
            }
            foreach (string OriginalRootPath in param.OriginalRootPath)
            {
                DirectoryInfo originalFold = new DirectoryInfo(OriginalRootPath);
                successamount = 0;
                LoggerHelper.Info("Start to operate the Fold:" + originalFold.FullName+"\r\n");
                if (!System.IO.Directory.Exists(OriginalRootPath)){
                    LoggerHelper.Warn("The fold[" + originalFold.FullName + "] is not exists! Ignore this fold.\r\n");
                    continue;
                }
                if (param.EnabledFileNameReplacement)
                {

                    FileInfo[] OriginalFileList = originalFold.GetFiles();

                    foreach (var file in OriginalFileList)
                    {
                        string originalFileName = file.Name;

                        
                        if (RegularExpression.IsMatch(originalFileName, param.FileNameRegexRegular))
                        {
                            //LoggerHelper.Info("Matched" + "\r\n");
                            string NewFileName = RegularExpression.Replace(originalFileName, param.FileNameRegexRegular, param.FileNameRegexReplacement);
                            if (File.Exists(file.Directory + "\\" + NewFileName))
                            {
                                LoggerHelper.Info(file.Directory + "\\" + NewFileName + " is exists. Doesn't rename [" + file.Name + "]\r\n");
                            }
                            else
                            {
                                File.Copy(file.FullName, file.Directory + "\\" + NewFileName, true);
                                if (File.Exists(file.Directory + "\\" + NewFileName))
                                { File.Delete(file.FullName); }
                                successamount++;
                            }
                        }

                        //SuccessRecorder.Record(FormatHistory(successamount, file.DirectoryName,file.Name, file.Extension));

                    }
                    LoggerHelper.Info("FileName Replacement is finished! Rename " + successamount.ToString() +" files.\r\n");
                }
                else
                {
                    LoggerHelper.Info("ignore FileName Replacement!\r\n");
                }
                if (param.EnabledHTMLReplacement)
                {
                    successamount = 0;
                    FileInfo[] OriginalFileList = originalFold.GetFiles("*" + param.FileExtension);
                    foreach (var file in OriginalFileList)
                    {
                        try
                        {
                            sr = new StreamReader(file.FullName);
                            string buffer = "";
                            string tempWriteFileName = file.Directory + "\\" + Guid.NewGuid().ToString().Replace('-', '_');

                            sw = new StreamWriter(tempWriteFileName);
                            while ((buffer = sr.ReadLine()) != null)
                            {
                                buffer = RegularExpression.Replace(buffer, param.HTMLRegexRegular, param.HTMLRegexReplacement);
                                sw.WriteLine(buffer);
                            }
                            sr.Close();
                            sw.Close();
                            File.Delete(file.FullName);
                            File.Copy(tempWriteFileName, file.FullName, true);
                            File.Delete(tempWriteFileName);

                            successamount++;
                        }
                        catch
                        {

                        }
                        finally
                        {
                            if (sr != null) { sr.Close(); }
                            if (sw != null) { sw.Close(); }
                        }
                    }
                    LoggerHelper.Info("HTML Replacement is finished! Replace " + successamount.ToString() + " files.\r\n");
                }
                else
                {
                    LoggerHelper.Info("ignore HTML Replacement!\r\n");
                }
            }
            //recursive Sub Directory
            //foreach (DirectoryInfo dir in originalFold.GetDirectories())
            //{
            //    TraverseParameter paramSub = (TraverseParameter)param.Clone();
            //    paramSub.SetOriginalRootPath(dir.FullName);
            //    RunSubThread(paramSub);
            //}

            return default(bool);


        }

        /// <summary>
        /// print log
        /// </summary>
        public override void DoSomethingBeforeRunSub()
        {
            base.DoSomethingBeforeRunSub();
            Debug(this.GetType().ToString() + " threading started.\r\n");


        }
        /// <summary>
        /// print log
        /// </summary>
        public override void DoSomethingAfterRunSub()
        {
            base.DoSomethingAfterRunSub();
            //SuccessRecorder.Close();
            // SuccessRecorder.Close();
            Debug(this.GetType().ToString() + " threading finished.\r\n");
        }
        /// <summary>
        /// encapsulate Log.debug
        /// </summary>
        /// <param name="DebugText"></param>
        private void Debug(string DebugText)
        {
            if (SystemConfiguration.Debug)
            {
                LoggerHelper.Debug(DebugText);
            }
        }
        private void PrintProcess(int failamount)
        {
            if ((successamount % 100) == 0)
            {
                LoggerHelper.Info(successamount.ToString() + " files/directories have been checked and Check process is continuing.\r\n");
            }

        }
        private string FormatHistory(int Index, string Path, string FileName, string ext)
        {
            return "\"" + Index.ToString() + "\",\"" + ext + "\",\"" + Path + "\",\"" + FileName + "\"";
        }
        private List<string> CheckName(string OriginalName)
        {
            List<string> rtn = new List<string>();
            foreach (string item in RegexRegularClass.RegexRegular_InvalidDict.Keys)
            {
                HashSet<string> m = RegularExpression.GetMatchData(OriginalName, RegexRegularClass.RegexRegular_InvalidDict[item]);

                if (m.Count > 0)
                {
                    rtn.Add(item);
                }


            }

            return rtn; ;
        }

    }
}
