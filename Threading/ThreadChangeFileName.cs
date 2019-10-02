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
    public class ChangeFileName<T> : ParentThread<T>
    {
        private ChangeFileNameParameter param;
        private IHistoryRecorder SuccessRecorder;
        //private IHistoryRecorder FailRecorder;
        private int successamount=0,failamount=0;
        public ChangeFileName(CancellationTokenSource _tokenSource, ICloneable _threadParameter) : base(_tokenSource, _threadParameter)
        {
            if (this.ThreadParameter != null)
            {
                param = (ChangeFileNameParameter)this.ThreadParameter;
                
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
                SuccessRecorder = ObjectBuildFactory<IHistoryRecorder>.Instance(SystemConfiguration.GetValue("HistorRecorderClassName"),new object[] { SystemConfiguration.GetValue("SuccessHistoryName"), true });
                //FailRecorder = ObjectBuildFactory<IHistoryRecorder>.Instance(SystemConfiguration.HistorRecorderClassName, new object[] { SystemConfiguration.FailHistoryName, true });

            }
            else
            {
                LoggerHelper.Warn("[" + param.OriginalRootPath + "] is Exists.");
            }
            if (param.OriginalRootPath.Trim().ToLower() == param.OutputRootPath.Trim().ToLower())
            {
                LoggerHelper.Warn("Origina Directory is not allowed to be the same as Output Directory . Please choose another Output Directory.\r\n");
                rtn = false;
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
            bool IsNameChanged = true;
            ChangeFileNameParameter param;
            if (thparam != null)
            {
                param = (ChangeFileNameParameter)thparam;
            }
            else
            {
                return default(T);
            }
            //Directory Change
            DirectoryInfo outputFold = new DirectoryInfo(param.OutputRootPath);
            string newOutputPath = ConvertToValidName(outputFold.Name);
            IsNameChanged = !(newOutputPath == outputFold.Name);
            if (IsNameChanged)
            {
                outputFold = new DirectoryInfo(param.OutputRootPath.Substring(0, param.OutputRootPath.Length - outputFold.Name.Length) + newOutputPath);
            }
            //outputFold.
            if (!System.IO.Directory.Exists(outputFold.FullName))
            {
                try { outputFold.Create(); }
                catch
                {
                    LoggerHelper.Warn("Program cann't create fold:" + outputFold.FullName + "\r\n");
                    return default(T);
                }
                if (!System.IO.Directory.Exists(outputFold.FullName))
                {
                    LoggerHelper.Warn("Program cann't create fold:" + outputFold.FullName + "\r\n");
                    return default(T);
                }
            }
            //if (IsValidName(outputFold.Name))
            //{
            //    successamount++;
            //    SuccessRecorder.Record(FormatHistory(successamount,EventSet.DirectoryEvent, IsNameChanged, param.OriginalRootPath, outputFold.FullName, "directory event"));

            //}
            //else
            //{
            //    failamount++;
            //    FailRecorder.Record(FormatHistory(failamount, EventSet.DirectoryEvent, IsNameChanged, param.OriginalRootPath, outputFold.FullName, "directory event"));
            //}
            successamount++;
            SuccessRecorder.Record(FormatHistory(successamount,EventSet.DirectoryEvent, IsNameChanged, param.OriginalRootPath, outputFold.FullName, "directory event"));
            PrintProcess(failamount, successamount);



            //File Name Change
            DirectoryInfo originalFold = new DirectoryInfo(param.OriginalRootPath);

            FileInfo[] OriginalFileList = originalFold.GetFiles();
            foreach(var file in OriginalFileList)
            {
                string originalFileName = file.Name;
                string newFileName = ConvertToValidName(originalFileName);
                IsNameChanged = !(originalFileName == newFileName);
                //rename file
                if (!System.IO.File.Exists(outputFold.FullName + "\\" + newFileName)) {
                    try
                    {
                        System.IO.File.Copy(file.FullName, outputFold.FullName + "\\" + newFileName, true);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        LoggerHelper.Warn("File[" + file.FullName + "] cann't be renamed\r\n" );
                        //System.IO.File.Copy(file.FullName, outputFold.FullName + "\\" + newFileName, true);
                    }

                }
                else
                {
                    //
                    FileInfo f = new FileInfo(outputFold.FullName + "\\" + newFileName);
                    
                    if(f.Length!= file.Length)
                    {
                        //It's not the same file
                        if (f.IsReadOnly)
                        {
                            f.IsReadOnly = false;
                        }
                        try
                        {
                            System.IO.File.Copy(file.FullName, outputFold.FullName + "\\" + newFileName, true);
                        }
                        catch (UnauthorizedAccessException ex)
                        {
                            LoggerHelper.Warn("File[" + file.FullName + "] cann't be renamed\r\n");
                            //System.IO.File.Copy(file.FullName, outputFold.FullName + "\\" + newFileName, true);
                        }
                    }
                }
                
                //if (IsValidName(newFileName))
                //{
                
                //}
                //else
                //{
                //    failamount++;
                //    FailRecorder.Record(FormatHistory(failamount, EventSet.FileEvent, IsNameChanged, file.FullName, outputFold.FullName + "\\" + newFileName, file.DirectoryName));
                //}
                successamount++;
                SuccessRecorder.Record(FormatHistory(successamount, EventSet.FileEvent, IsNameChanged, file.FullName, outputFold.FullName + "\\" + newFileName, file.DirectoryName));
                PrintProcess(failamount, successamount);
                
            }

            //recursive Sub Directory
            foreach (DirectoryInfo dir in originalFold.GetDirectories())
            {
                ChangeFileNameParameter paramSub = (ChangeFileNameParameter)param.Clone();
                paramSub.SetOriginalRootPath(dir.FullName);
                paramSub.SetOutputRootPath(outputFold.FullName + "\\" + dir.Name);
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
            SuccessRecorder.Close();
            //FailRecorder.Close();
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
        private void PrintProcess(int failamount, int successamount)
        {
            if (((failamount + successamount) % 100) == 0)
            {
                LoggerHelper.Info((failamount + successamount).ToString() + " files have been renamed and FileNameChange is continuing.\r\n");
            }

        }
        private string FormatHistory(int Index, EventSet es, bool IsNameChanged,string originalFileFullName,string outputFileFullName,string originalPath)
        {
            return Index.ToString() + "\t" + es.ToString() + "\t" + (IsNameChanged ? "Y" : "N") + "\t" + originalFileFullName + "\t" + outputFileFullName + "\t" + originalPath;
        }
        private string ConvertToValidName(string OriginalName)
        {
            HashSet<string> invalidCharacter = RegularExpression.GetMatchData(OriginalName, SystemConfiguration.GetValue("InvalidCharacter"));
            string newFileName = OriginalName;
            if (invalidCharacter.Count > 0)
            {
                //find invalid character

                foreach (string key in invalidCharacter)
                {
                    string replacement = CharacterDictionary.GetValue(key);
                    if (replacement == null)
                    {
                        //Others invalid character
                        newFileName = RegularExpression.Replace(newFileName, "[" + key + "]", CharacterDictionary.OthersReplacement);
                    }
                    else
                    {
                        newFileName = RegularExpression.Replace(newFileName, "[" + key + "]", CharacterDictionary.GetValue(key));
                    }
                }
            }
            return newFileName;
        }

        //private bool IsValidName(string Name)
        //{
        //    bool rtn = true;
        //    if (Name.Length > SystemConfiguration.NameMaxLength)
        //    {
        //        rtn = false;
        //    }
        //    else
        //    {
        //        if (RegularExpression.GetMatchData(Name, SystemConfiguration.InvalidCharacter).Count > 0)
        //        {
        //            rtn = false;
        //        }
                
        //    }
        //    return rtn;
        //}
    }
}
