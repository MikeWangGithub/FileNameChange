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
        #endregion End Button Status controll



        #region Events

        private void BtnSelectOriginalDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDlg.ShowDialog() == DialogResult.OK)
            {
                this.txtOriginalDir.Text = folderBrowserDlg.SelectedPath;
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
            string dir = @"c:\testMike_Wang0";
            int index = 0;
            try
            {
                if (!System.IO.Directory.Exists(dir))
                {
                    System.IO.Directory.CreateDirectory(dir);
                }
                System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(dir);
                
                while (dirInfo.Exists)
                {
                    index++;
                    string subdir= "testMike_Wang0" + index.ToString();
                    dirInfo = dirInfo.CreateSubdirectory(subdir);
                    if (index > 50)
                    {
                        break;
                    }
                   
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Error (dir + "\r\n" ,ex);
            }
            

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
            StartThreadParameter st = new StartThreadParameter();
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


        #endregion Event

        
    }
}
