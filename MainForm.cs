using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileNameChange.GlobalObject;
using System.Threading;
using FileNameChange.Tools;
using FileNameChange.Threading;
using System.Text.RegularExpressions;
using BaseClassLibrary.Forms;
using BaseClassLibrary.Configuration;
using BaseClassLibrary.Tools;
using System.Reflection;
using FileNameChange.Algorithm;
using FCNDBContext.BussinessLayer;
using FCNDBContext.BussinessEntity;


namespace FileNameChange
{
    public partial class MainForm : BaseClassLibrary.Forms.BaseForm<bool>
    {
        #region  variable
        
        #endregion
        public MainForm()
        {
            InitializeComponent();
            Initial();
        }
        /// <summary>
        /// Initial form objects
        /// </summary>
        public void Initial()
        {
            //Initial Global System Configuration
            SystemConfiguration.Initial(System.Windows.Forms.Application.ExecutablePath);
            //Inital Global LogClass
            LoggerHelper.Initial(this.rtxtLog, SystemConfiguration.LoggerClassName);
            LoggerHelper.Clear();
            //
            LoadConfigurations();
            //
            RegexRegularClass.Initial(SystemConfiguration.GetValue("RegexRegular_Invalid"));
            
            //Clear TextBox.Text 
            this.txtOriginalDir.Clear();
            //this.txtOriginalDir.Text = @"c:\test";
            this.textBox1.Visible = false;
            this.textBox2.Visible = false;
            //this.button1.Visible = false;

            //rtn.SetFileNameRegexRegular(SystemConfiguration.GetValue("NavigationSourceFileNameRegex"));
            //rtn.SetFileNameRegexReplacement(SystemConfiguration.GetValue("NavigationReplacementFileNameRegex"));
            this.txtFileNameSearchReg.Text = SystemConfiguration.GetValue("NavigationSourceFileNameRegex");
            this.txtFileNameReplacementReg.Text = SystemConfiguration.GetValue("NavigationReplacementFileNameRegex");

            this.txtHTMSearchReg.Text = SystemConfiguration.GetValue("NavigationSourceHTMLRegex");
            this.txtHTMLReplacementReg.Text = SystemConfiguration.GetValue("NavigationReplacementHTMLRegex");



            //Initial CharacterDictionay
            CharacterDictionary.Initial(lstvReplacement.Items[0].SubItems[3].Text.Trim());
            foreach(ListViewItem item in lstvReplacement.Items)
            {
                if(item.Text  == "1")
                {
                    continue;
                }
                CharacterDictionary.Add(item.SubItems[1].Text, item.SubItems[3].Text);
            }

            foreach(var item in CharacterDictionary.Keys)
            {
                LoggerHelper.Debug("key=" + item + ";value=" + CharacterDictionary.GetValue(item).ToString()+"\r\n");
            }

        }

        private void LoadConfigurations()
        {
            SystemConfiguration.AddValue("HistorRecorderClassName", AppConfig.GetAppConfig("HistorRecorderClassName"));
            SystemConfiguration.AddValue("SuccessHistoryName", AppConfig.GetAppConfig("SuccessHistoryName"));
            SystemConfiguration.AddValue("FailHistoryName", AppConfig.GetAppConfig("FailHistoryName"));
            SystemConfiguration.AddValue("InvalidCharacter", AppConfig.GetAppConfig("InvalidCharacter"));
            SystemConfiguration.AddValue("RegexRegular_Invalid", AppConfig.GetAppConfig("RegexRegular_Invalid"));
            SystemConfiguration.AddValue("NameMaxLength", AppConfig.GetAppConfig("NameMaxLength"));
            SystemConfiguration.AddValue("NavigationSourceFileNameRegex", AppConfig.GetAppConfig("NavigationSourceFileNameRegex"));
            SystemConfiguration.AddValue("NavigationReplacementFileNameRegex", AppConfig.GetAppConfig("NavigationReplacementFileNameRegex"));
            SystemConfiguration.AddValue("NavigationSourceHTMLRegex", AppConfig.GetAppConfig("NavigationSourceHTMLRegex"));
            SystemConfiguration.AddValue("NavigationReplacementHTMLRegex", AppConfig.GetAppConfig("NavigationReplacementHTMLRegex"));
            SystemConfiguration.AddValue("PDFValidating", AppConfig.GetAppConfig("PDFValidating"));
            
        }
        #region Threading functions


        public ChangeFileNameParameter GetChangeFileNameParameter()
        {
            ChangeFileNameParameter rtn = new ChangeFileNameParameter();
            rtn.SetOriginalRootPath(this.txtOriginalDir.Text.Trim());
            rtn.SetOutputRootPath(this.txtOutputDir.Text.Trim());
            return rtn;

        }
        public CheckNameParameter GetCheckNameParameter()
        {
            CheckNameParameter rtn = new CheckNameParameter();
            //Outputpath is the checking 's original path. 
            rtn.SetOriginalRootPath(this.txtOutputDir.Text.Trim());
            return rtn;

        }
        public ValidatePDFParameter GetValidatePDFParameter()
        {
            ValidatePDFParameter rtn = new ValidatePDFParameter();
            //Outputpath is the checking 's original path. 
            rtn.SetPDFCheckingDir(this.txtPDFCheckDir.Text.Trim());
            rtn.SetVeraPDFPath(this.txtVerpadExcutePath.Text.Trim());
            rtn.SetResultFilePath(this.txtVeraPDFResultFile.Text.Trim());
            rtn.SetIsContainsSubFold(this.ckbPDFCheckSubFold.Checked);
            rtn.SetCheckIDNM(this.txtCheckIDNM.Text.Trim());
            return rtn;

        }
        public ChangeNavigationPageParameter GetChangeNavigationPageParameter()
        {
            ChangeNavigationPageParameter rtn = new ChangeNavigationPageParameter();
            //Outputpath is the checking 's original path. 
            using (System.IO.StreamReader sr = new System.IO.StreamReader(this.txtReplacementDir.Text.Trim()))
            {
                string filepath = "";
                while ((filepath = sr.ReadLine()) != null)
                {
                    rtn.AddOriginalRootPath(filepath);
                }
                sr.Close();
            }
            //rtn.SetFileNameRegexRegular(SystemConfiguration.GetValue("NavigationSourceFileNameRegex"));
            //rtn.SetFileNameRegexReplacement(SystemConfiguration.GetValue("NavigationReplacementFileNameRegex"));
            rtn.SetFileNameRegexRegular(this.txtFileNameSearchReg.Text.Trim());
            rtn.SetFileNameRegexReplacement(this.txtFileNameReplacementReg.Text.Trim());

            rtn.SetHTMLRegexRegular(this.txtHTMSearchReg.Text.Trim());
            rtn.SetHTMLRegexReplacement(this.txtHTMLReplacementReg.Text.Trim());
            rtn.SetEnabledFileNameReplacement(this.ckbReplaceFileName.Checked);
            rtn.SetEnabledHTMLReplacement(this.ckbReplaceHTML.Checked);
            rtn.SetFileExtension(this.txtNavigationPageExtension.Text.Trim());
            return rtn;

        }
        public TraverseParameter GetTraverseParameter()
        {
            TraverseParameter rtn = new TraverseParameter();
            //Outputpath is the checking 's original path. 
            rtn.SetOriginalRootPath(this.txtOriginalDir.Text.Trim());
            return rtn;

        }
        #endregion
        #region Button Status controll
        /// <summary>
        /// Set buttons are enabled or not.
        /// </summary>
        /// <param name="isEnabled">true:Button are enabled; false: buttons are disenabled.</param>
        public void SetChangeFileNameButtonStatus(bool isEnabled)
        {
            this.btnExcute.Enabled = isEnabled;
            this.btnCheckName.Enabled = isEnabled;
            SetOpenDirButtonStatus(isEnabled);
        }
        public void SetCheckNameButtonStatus(bool isEnabled)
        {
            this.btnCheckName.Enabled = isEnabled;
            this.btnExcute.Enabled = isEnabled;
            SetOpenDirButtonStatus(isEnabled);
        }
        public void SetTraverseButtonStatus(bool isEnabled)
        {
            this.btnTraverse.Enabled = isEnabled;
            SetOpenDirButtonStatus(isEnabled);
        }
        /// <summary>
        /// Set buttons are enabled or not.
        /// </summary>
        /// <param name="isEnabled">true:Button are enabled; false: buttons are disenabled.</param>
        private void SetOpenDirButtonStatus(bool isEnabled)
        {
            this.btnSelectOriginalDir.Enabled = isEnabled;
            this.btnSelectOutputDir.Enabled = isEnabled;
        
        }
        public void SetChangeNavigationPageButtonStatus(bool isEnabled)
        {
            this.btnExcuteReplacement.Enabled = isEnabled;
            this.ckbReplaceFileName.Enabled = isEnabled;
            this.ckbReplaceHTML.Enabled = isEnabled;
            SetReplaceNaviFileNameButtonStatus(isEnabled && this.ckbReplaceFileName.Checked);
            SetReplaceNaviHTMLButtonStatus(isEnabled && this.ckbReplaceHTML.Checked);


        }
        private void SetReplaceNaviFileNameButtonStatus(bool IsEnabled)
        {
            //this.btnBrowseNavigationDir.Enabled = IsEnabled;
            this.txtFileNameSearchReg.Enabled = IsEnabled;
            this.txtFileNameReplacementReg.Enabled = IsEnabled;

        }
        
        private void SetReplaceNaviHTMLButtonStatus(bool IsEnabled)
        {
            //this.btnBrowseNavigationDir.Enabled = IsEnabled;
            this.txtHTMSearchReg.Enabled = IsEnabled;
            this.txtHTMLReplacementReg.Enabled = IsEnabled;

        }

        private void SetValidatePDFButtonStatus(bool isEnabled)
        {
            this.btnExcutePDFValidation.Enabled = isEnabled;
            this.btnSelectPDFCheckingDir.Enabled = isEnabled;
            this.btnSelectPDFResultFile.Enabled = isEnabled;
            this.btnSelectVeraPDF.Enabled = isEnabled;

        }
        #endregion End Button Status controll



        #region Events

        private void BtnSelectOriginalDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDlg.ShowDialog() == DialogResult.OK)
            {
                this.txtOriginalDir.Text = folderBrowserDlg.SelectedPath;
            }
        }
        private void BtnSelectVeraPDF_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtVerpadExcutePath.Text = openFileDialog1.FileName;
            }
        }
        private void BtnSelectPDFResultFile_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtVeraPDFResultFile.Text = openFileDialog1.FileName;
            }
        }

        private void BtnSelectPDFCheckingDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDlg.ShowDialog() == DialogResult.OK)
            {
                this.txtPDFCheckDir.Text = folderBrowserDlg.SelectedPath;
            }
        }
        private void BtnSelectOutputDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDlg.ShowDialog() == DialogResult.OK)
            {
                this.txtOutputDir.Text = folderBrowserDlg.SelectedPath;
            }

        }

        private void BtnAddRule_Click(object sender, EventArgs e)
        {
            if (this.txtOriText.Text.Trim() == "")
            {
                System.Windows.Forms.MessageBox.Show("Original Character is not allowed none","Infomation" );
                return;
            }
            else
            {
                string key = this.txtOriText.Text.Trim();
                if (CharacterDictionary.Keys.Contains<string>(key))
                {
                    System.Windows.Forms.MessageBox.Show("Original Character[" + key + "] has been added,please add another one!", "Infomation");
                    return;
                }
            }
            if (this.txtReplacement.Text.Trim() == "")
            {
                System.Windows.Forms.MessageBox.Show("Replacement Character is not allowed none", "Infomation" );
                return;
            }
            CharacterDictionary.Add(this.txtOriText.Text.Trim(), this.txtReplacement.Text.Trim());
            ListViewItem item = new ListViewItem();
            item.Text = (lstvReplacement.Items.Count + 1).ToString();
            item.SubItems.Add(this.txtOriText.Text.Trim());
            item.SubItems.Add("->");
            item.SubItems.Add(this.txtReplacement.Text.Trim());
            this.lstvReplacement.Items.Add(item);

        }

        private void DeleteCurrentRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstvReplacement.SelectedItems.Count <= 0)
            {
                System.Windows.Forms.MessageBox.Show("Please choose one row first!", "Infomation");
                return;
            }
            bool IsNeedSorting = false;
            foreach(ListViewItem item in lstvReplacement.SelectedItems)
            {
                if (item.Text == "1")
                {
                    System.Windows.Forms.MessageBox.Show("Others row isn't allow to be delete!", "Infomation");
                    //return;
                }
                else
                {
                    if (CharacterDictionary.Remove(item.SubItems[1].Text.ToString()))
                    {
                        lstvReplacement.Items.Remove(item);
                        LoggerHelper.Info(item.SubItems[1].ToString() + " was deleted\r\n");
                        IsNeedSorting = true;
                    }
                }
            }
            if (IsNeedSorting)
            {
                int Index = 1;
                foreach (ListViewItem item in lstvReplacement.Items)
                {
                    item.Text = Index.ToString();
                    Index++;
                }
            }
        }
        private void BtnBrowseNavigationDir_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtReplacementDir.Text = openFileDialog1.FileName;
            }
        }

        private void CkbReplaceFileName_CheckedChanged(object sender, EventArgs e)
        {
            SetReplaceNaviFileNameButtonStatus(((CheckBox)sender).Checked);

        }

        private void CkbReplaceHTML_CheckedChanged(object sender, EventArgs e)
        {
            SetReplaceNaviHTMLButtonStatus(((CheckBox)sender).Checked);
        }
        #endregion Event

        #region Button click Event
        private void Button1_Click(object sender, EventArgs e)
        {
            //LoggerHelper.Info(  VeraPDFResultAnalysis.ValidatePDF(@"c:\test\verapdf.txt").ToString());
            CheckBLL checkbll = new CheckBLL();
            FCNDBContext.DataAccessLayer.FCNDBContext ctx = new FCNDBContext.DataAccessLayer.FCNDBContext("SQLServerDBString");
            Check check = checkbll.GetCheckByID(2, ctx);
            check.CreateDate = DateTime.Now;
            check.Name = "update check";
            ctx.PDFCheck.Attach(check);

            ctx.Entry(check).Property(p => p.Name).IsModified = true;
            //checkbll.Update(check, ctx);
            Check check2 = new Check();
            check2.CreateDate = DateTime.Now;
            check2.Name = "add check";

            ctx.PDFCheck.Add(check2);
            //ctx.Entry(check2).Property(p => p.Name).IsModified = true;
            // context.Entry(file).Property(p => p.Memo).IsModified = true;
            try
            {
                int amount = ctx.SaveChanges();
                LoggerHelper.Info("Savechanges count:" + amount.ToString()+"\r\n");

            }
            catch(Exception ex)
            {
                LoggerHelper.Info("Savechanges count:" + ex.Message.ToString() + "\r\n");

            }

            //checkbll.SaveChange(ctx);

        }
        private async void BtnExcute_Click(object sender, EventArgs e)
        {
            //await RunThread(FileNameChange.Tools.ThreadName.ChangeFileName);
            StartThreadParameter st = new StartThreadParameter(this);
            st.SetgenericTypeName(typeof(System.Boolean));
            st.SetFullThreadName("FileNameChange.Threading.ChangeFileName`1");
            st.SetGetParamgeterFunctionName("GetChangeFileNameParameter");
            st.SetButtonStatusFuncionName("SetChangeFileNameButtonStatus");
            bool x = await RunThread(st);
            //this.richTextBox1.AppendText(x.ToString() + "\r\n");
        }

        private async void BtnCheckName_Click(object sender, EventArgs e)
        {
            //await RunThread(FileNameChange.Tools.ThreadName.CheckName);
            StartThreadParameter st = new StartThreadParameter(this);
            //st.SetFunctoinClass(this);
            st.SetFullThreadName("FileNameChange.Threading.CheckName");
            st.SetGetParamgeterFunctionName("GetCheckNameParameter");
            st.SetButtonStatusFuncionName("SetCheckNameButtonStatus");
            bool x = await RunThread(st);
        }

        private async void BtnTraverse_Click(object sender, EventArgs e)
        {

            //await RunThread(FileNameChange.Tools.ThreadName.Traverse);
            StartThreadParameter st = new StartThreadParameter(this);
            st.SetgenericTypeName(typeof(System.Boolean));
            st.SetFullThreadName("FileNameChange.Threading.ThreadTraverse`1");
            st.SetGetParamgeterFunctionName("GetTraverseParameter");
            st.SetButtonStatusFuncionName("SetTraverseButtonStatus");
            bool x = await RunThread(st);
        }

        private async void BtnExcuteReplacement_Click(object sender, EventArgs e)
        {
            StartThreadParameter st = new StartThreadParameter(this);
            //st.SetFunctoinClass(this);
            st.SetFullThreadName("FileNameChange.Threading.ChangeNavigationPage");
            st.SetGetParamgeterFunctionName("GetChangeNavigationPageParameter");
            st.SetButtonStatusFuncionName("SetChangeNavigationPageButtonStatus");
            bool x = await RunThread(st);
        }
        private async void BtnExcutePDFValidation_Click(object sender, EventArgs e)
        {
            StartThreadParameter st = new StartThreadParameter(this);
            //st.SetFunctoinClass(this);
            st.SetgenericTypeName(typeof(System.Boolean));
            st.SetFullThreadName("FileNameChange.Threading.ValidatePDF`1");
            st.SetGetParamgeterFunctionName("GetValidatePDFParameter");
            st.SetButtonStatusFuncionName("SetValidatePDFButtonStatus");
            bool x = await RunThread(st);
        }




        #endregion Event


    }
}
