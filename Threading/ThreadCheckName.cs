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
    public class CheckName : ParentThread<bool>
    {
        private CheckNameParameter param;
        //private IHistoryRecorder SuccessRecorder;
        private IHistoryRecorder FailRecorder;
        private int failamount=0;
        public CheckName(CancellationTokenSource _tokenSource, ICloneable _threadParameter) : base(_tokenSource, _threadParameter)
        {
            if (this.ThreadParameter != null)
            {
                param = (CheckNameParameter)this.ThreadParameter;
                
            }
            //amount = 0;
        }
        /// <summary>
        /// Check RootPath 
        /// </summary>
        /// <returns>If RootPath is not exists ,don't need execute next step</returns>
        public override bool CheckParameter()
        {
            bool rtn = System.IO.Directory.Exists(param.OriginalRootPath);
            if (rtn)
            {
                //SuccessRecorder = ObjectBuildFactory<IHistoryRecorder>.Instance(SystemConfiguration.HistorRecorderClassName,new object[] { SystemConfiguration.SuccessHistoryName, true });
                FailRecorder = ObjectBuildFactory<IHistoryRecorder>.Instance(SystemConfiguration.GetValue("HistorRecorderClassName"), new object[] { SystemConfiguration.GetValue("FailHistoryName"), true });

            }
            else
            {
                LoggerHelper.Warn("[" + param.OriginalRootPath + "] is Exists.\r\n");
            }
            return rtn;
            
        }

        /// <summary>
        /// recursive  call by self
        /// </summary>
        /// <returns></returns>
        public override bool RunSubThread(ICloneable thparam)
        {
            //judage if threading is cancelled.
            this.IsTaskCanceled();
            CheckNameParameter param;
            List<string> invalidInfo;
            string Info = "";
            if (thparam != null)
            {
                param = (CheckNameParameter)thparam;
            }
            else
            {
                return false;
            }
            //Check Directory 
            DirectoryInfo outputFold = new DirectoryInfo(param.OriginalRootPath);
            invalidInfo = CheckFileName(outputFold.Name);
            Info = "";
            if (invalidInfo != null)
            {
                if (invalidInfo.Count > 0)
                {
                    foreach(string s in invalidInfo)
                    {
                        Info += s + "\r\n";
                    }
                    failamount++;
                    FailRecorder.Record(FormatHistory(failamount, EventSet.DirectoryEvent, Info, outputFold.FullName));
                    PrintProcess(failamount);
                }
            }




            //Check File Name 

            FileInfo[] OriginalFileList = outputFold.GetFiles();
            foreach (var file in OriginalFileList)
            {
                string originalFileName = file.Name;
                invalidInfo = CheckFileName(originalFileName);
                Info = "";
                if (invalidInfo != null)
                {
                    if (invalidInfo.Count > 0)
                    {
                        foreach (string s in invalidInfo)
                        {
                            Info += s + "\r\n";
                        }
                        failamount++;
                        FailRecorder.Record(FormatHistory(failamount, EventSet.FileEvent, Info, file.FullName));
                        PrintProcess(failamount);
                    }
                }
                
            }

            //recursive Sub Directory
            foreach (DirectoryInfo dir in outputFold.GetDirectories())
            {
                CheckNameParameter paramSub = (CheckNameParameter)param.Clone();
                paramSub.SetOriginalRootPath(dir.FullName);
                RunSubThread(paramSub);
            }

            return false;
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
            FailRecorder.Close();
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
            if ((failamount % 100) == 0)
            {
                LoggerHelper.Info(failamount.ToString() + " files/directories have been checked and Check process is continuing.\r\n");
            }

        }
        private string FormatHistory(int Index, EventSet es,string InvalidInfo,string originalFileFullName)
        {
            return "\""+ Index.ToString() + "\",\"" + es.ToString() + "\",\"" + InvalidInfo  + "\",\"" + originalFileFullName + "\"";
        }
        private List<string> CheckFileName(string OriginalName)
        {
            List<string> rtn = new List<string>();
            foreach (string item in RegexRegularClass.RegexRegular_InvalidDict.Keys)
            {
                HashSet<string> m = RegularExpression.GetMatchData(OriginalName, RegexRegularClass.RegexRegular_InvalidDict[item]);
                
                if (m.Count > 0) {
                    rtn.Add(item);
                }
                
            }
            
            return rtn; ;
        }

        
    }
}
