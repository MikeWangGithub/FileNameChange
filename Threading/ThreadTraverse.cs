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

namespace FileNameChange.Threading
{
    /// <summary>
    /// Thread for get a new PIN.
    /// </summary>
    public class ThreadTraverse<T> : ParentThread<T>
    {
        private TraverseParameter param;
        //private IHistoryRecorder SuccessRecorder;
        private IHistoryRecorder SuccessRecorder;
        private int successamount = 0;
        
        public ThreadTraverse(CancellationTokenSource _tokenSource, ICloneable _threadParameter) : base(_tokenSource, _threadParameter)
        {
            if (this.ThreadParameter != null)
            {
                param = (TraverseParameter)this.ThreadParameter;
                
            }
            //amount = 0;
        }
        /// <summary>
        /// Traverse RootPath 
        /// </summary>
        /// <returns>If RootPath is not exists ,don't need execute next step</returns>
        public override bool CheckParameter()
        {
            bool rtn = System.IO.Directory.Exists(param.OriginalRootPath);
            if (rtn)
            {
                //SuccessRecorder = ObjectBuildFactory<IHistoryRecorder>.Instance(SystemConfiguration.HistorRecorderClassName,new object[] { SystemConfiguration.SuccessHistoryName, true });
                SuccessRecorder = ObjectBuildFactory<IHistoryRecorder>.Instance(SystemConfiguration.HistorRecorderClassName, new object[] { SystemConfiguration.SuccessHistoryName, true });

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
        public override T RunSubThread(ICloneable thparam)
        {
            //judage if threading is cancelled.
            this.IsTaskCanceled();
            TraverseParameter param;
            
            if (thparam != null)
            {
                param = (TraverseParameter)thparam;
            }
            else
            {
                return default(T);
            }
            DirectoryInfo originalFold = new DirectoryInfo(param.OriginalRootPath);

            FileInfo[] OriginalFileList = originalFold.GetFiles();
            foreach (var file in OriginalFileList)
            {
                string originalFileName = file.Name;
                
                successamount++;
                SuccessRecorder.Record(FormatHistory(successamount, file.DirectoryName,file.Name, file.Extension));
                
            }

            //recursive Sub Directory
            foreach (DirectoryInfo dir in originalFold.GetDirectories())
            {
                TraverseParameter paramSub = (TraverseParameter)param.Clone();
                paramSub.SetOriginalRootPath(dir.FullName);
                RunSubThread(paramSub);
            }

            return default(T);

            
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
            SuccessRecorder.Close();
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
        private string FormatHistory(int Index, string Path, string FileName,string ext)
        {
            return "\""+ Index.ToString() + "\",\"" + ext  + "\",\"" + Path + "\",\"" + FileName + "\"";
        }
        private List<string> CheckName(string OriginalName)
        {
            List<string> rtn = new List<string>();
            foreach (string item in SystemConfiguration.RegexRegular_InvalidDict.Keys)
            {
                HashSet<string> m = RegularExpression.GetMatchData(OriginalName, SystemConfiguration.RegexRegular_InvalidDict[item]);
                
                if (m.Count > 0) {
                    rtn.Add(item);
                }
                

            }
            
            return rtn; ;
        }
        
    }
}
