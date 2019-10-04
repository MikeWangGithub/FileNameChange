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
using FCNDBContext.DataAccessLayer;
using FCNDBContext.BussinessEntity;
using FCNDBContext.BussinessLayer;
using System.Diagnostics;

namespace FileNameChange.Threading
{
    /// <summary>
    /// Thread for get a new PIN.
    /// </summary>
    public class ValidatePDF<T> : ParentThread<T>
    {
        private ValidatePDFParameter param;
        //private IHistoryRecorder SuccessRecorder;
        //private IHistoryRecorder SuccessRecorder;
        private int Valid = 0;
        private int Invalid = 0;
        private FCNDBContext.DataAccessLayer.FCNDBContext ctx = new FCNDBContext.DataAccessLayer.FCNDBContext("SQLServerDBString");
        private FilesBLL filebll = new FilesBLL();
        private CheckBLL checkbll = new CheckBLL();
        private int CheckID = 0;
        private bool IsNewCheck = false;
        private bool IsDBConnectionAvailable = false;
        public ValidatePDF(CancellationTokenSource _tokenSource, ICloneable _threadParameter) : base(_tokenSource, _threadParameter)
        {
            if (this.ThreadParameter != null)
            {
                param = (ValidatePDFParameter)this.ThreadParameter;
                
            }
            IsDBConnectionAvailable = SystemConfiguration.GetValue("PDFValidating").Trim().ToLower()=="Database".ToLower()?true:false;
            if (IsDBConnectionAvailable)
            {
                InitCheckId();
            }
            //amount = 0;
        }
        /// <summary>
        /// Traverse RootPath 
        /// </summary>
        /// <returns>If RootPath is not exists ,don't need execute next step</returns>
        public override bool CheckParameter()
        {
            bool rtn = System.IO.Directory.Exists(param.PDFCheckingDir);
            if (rtn)
            {
                if (CheckID == 0)
                {
                    rtn = false;
                    LoggerHelper.Warn("[Can't create checking id] \r\n");
                }
            }
            else
            {
                LoggerHelper.Warn("[" + param.PDFCheckingDir + "] is not Exists.\r\n");
            }
            return rtn;
            
        }
        private void InitCheckId()
        {
            if(param.CheckIDNM.Trim().Length == 0)
            {
                IsNewCheck = true;
            }
            else
            {
                IsNewCheck = false;
            }
            if (!IsNewCheck)
            {
                try
                {
                    int _id = System.Convert.ToInt32(param.CheckIDNM);
                    Check ck = checkbll.GetCheckByID(_id, this.ctx);
                    CheckID = ck.ID;
                }
                catch (Exception ex)
                {

                }
                if (CheckID == 0)
                {
                    try
                    {
                        Check ck = checkbll.GetCheckByName(param.CheckIDNM, this.ctx);
                        CheckID = ck.ID;
                    }
                    catch (Exception ex)
                    {


                    }
                }
                if (CheckID == 0)
                {
                    IsNewCheck = true;
                }
                else
                {
                    return;
                }
            }
            //
            if (checkbll.Insert(param.PDFCheckingDir,this.ctx) == 1)
            {
                CheckID = checkbll.GetSequence(this.ctx);
                if (CheckID == -1)
                {
                    SetDBConnectionUnvailable();
                }
            };
        }
        /// <summary>
        /// recursive  call by self
        /// </summary>
        /// <returns></returns>
        public override T RunSubThread(ICloneable thparam)
        {
            //judage if threading is cancelled.
            this.IsTaskCanceled();
            ValidatePDFParameter param;
            
            if (thparam != null)
            {
                param = (ValidatePDFParameter)thparam;
            }
            else
            {
                return default(T);
            }
            DirectoryInfo originalFold = new DirectoryInfo(param.PDFCheckingDir);

            FileInfo[] OriginalFileList = originalFold.GetFiles("*.pdf");
            foreach (var file in OriginalFileList)
            {
                
                //successamount++;
                //SuccessRecorder.Record(FormatHistory(successamount, file.DirectoryName,file.Name, file.Extension));
                FormatLog(file, (Valid + Invalid + 1));
                Files dbfile = new Files();
                if (!IsNewCheck)
                {
                    try
                    {
                        dbfile = filebll.GetFileByFullName(this.CheckID, file.FullName, this.ctx);
                        if (dbfile.IsValid)
                        {
                            PrintIsValid(dbfile.IsValid);
                            if (dbfile.IsValid) { Valid++; } else { Invalid++; }
                            continue;

                        }
                    }
                    catch
                    {

                    }
                }

                using (Process pr = new Process())
                {
                    //声明一个进程类对象
                    pr.StartInfo.FileName = "\"" + param.VeraPDFPath + "\"";
                    pr.StartInfo.Arguments = " --format mrr \"" + file.FullName + "\" >\"" + param.ResultFilePath + "\"";
                    pr.StartInfo.UseShellExecute = false;
                    pr.StartInfo.CreateNoWindow = true;
                    pr.Start();
                    pr.WaitForExit();
                }
                bool isValid = VeraPDFResultAnalysis.ValidatePDF(param.ResultFilePath);
                PrintIsValid(isValid);
                if (isValid) { Valid++; } else { Invalid++; }
                //record result in db
                if (IsDBConnectionAvailable)
                {
                    SaveCheckResultToDB(file, isValid);
                }
                else
                {
                    // record to a file instead of db
                }
            }
            //if (IsDBConnectionAvailable)
            //{
            //    if(OriginalFileList.Length > 0) { 
            //        bool rtn = filebll.SaveChange(this.ctx);
            //        if (!rtn)
            //        {
            //            this.SetDBConnectionUnvailable();
            //        }
            //    }
            //}
            //update check 's total, valid,invalid
            UpdateTotal(Valid, Invalid);

            //recursive Sub Directory
            if (param.IsContainsSubFold) { 
                foreach (DirectoryInfo dir in originalFold.GetDirectories())
                {
                    ValidatePDFParameter paramSub = (ValidatePDFParameter)param.Clone();
                    paramSub.SetPDFCheckingDir(dir.FullName);
                    RunSubThread(paramSub);
                }
            }

            
            return default(T);

            
        }
        private void UpdateTotal(int valid, int invalid)
        {
            Check check = checkbll.GetCheckByID(CheckID, this.ctx);
            check.Total = valid + invalid;
            check.Valid = valid;
            check.Invalid = invalid;
            checkbll.Update(check, this.ctx);
        }
        private void SaveCheckResultToDB(FileInfo file,bool isValid)
        {
            bool rtn=false;
            if (IsDBConnectionAvailable)
            {
                Files dbfile = new Files();
                if (!IsNewCheck)
                {
                    try
                    {
                        dbfile = filebll.GetFileByFullName(this.CheckID, file.FullName, this.ctx);
                    }
                    catch
                    {

                    }
                }
                dbfile.CheckID = CheckID;
                dbfile.CreateDate = System.DateTime.Now;
                dbfile.ModifyDate = System.DateTime.Now;
                dbfile.FileName = file.Name;

                dbfile.IsValid = isValid;
                dbfile.FileFullName = file.FullName;
                dbfile.FilePath = file.DirectoryName;
                dbfile.Extension = file.Extension;
                dbfile.Size = (int)file.Length;
                dbfile.Size_Abbreviation = StringOpertation.GetByteDescription(file.Length);
                
                if (dbfile.ID==0) { 
                    rtn = filebll.Insert(dbfile, this.ctx);
                }else
                {
                    rtn = filebll.Update(dbfile,this.ctx);
                }
                
                if (!rtn)
                {
                    this.SetDBConnectionUnvailable();
                }
            }


        }
        private void FormatLog(FileInfo file, int index)
        {
            LoggerHelper.Info(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.sss")+":\t"+index.ToString() + "\t" + file.Name + "\t" + StringOpertation.GetByteDescription(file.Length) + "\t" + file.DirectoryName);
        }
        private void PrintIsValid(bool value)
        {
            if(value)
                LoggerHelper.Debug( "\tValid PDF-File\r\n");
            else
                LoggerHelper.Warn ("\tInvalid PDF-File\r\n");

        }
        private void SetDBConnectionUnvailable()
        {
            try
            {
                int x = CheckID = checkbll.GetSequence(this.ctx);
                if(x>0)
                {
                    return;
                }
            }
            catch{
                IsDBConnectionAvailable = false;
                LoggerHelper.Warn("DataBase is closed.\r\n");
                return;
            }

            IsDBConnectionAvailable = false;
            LoggerHelper.Warn("DataBase is closed.\r\n");
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
            //SuccessRecorder.Close();
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
        
        
        
    }
}
