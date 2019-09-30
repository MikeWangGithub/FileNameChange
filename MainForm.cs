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


namespace FileNameChange
{
    public partial class MainForm : Form
    {
        #region  variable
        /// <summary>
        /// MulitThread variable
        /// </summary>
        private Task<bool> task;
        private CancellationTokenSource tokenSource = new CancellationTokenSource();

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
            LoggerHelper.Initial(this.rtxtLog);
            //Clear TextBox.Text 
            this.txtOriginalDir.Clear();
            //this.txtOriginalDir.Text = @"c:\test";
            this.textBox1.Visible = false;
            this.textBox2.Visible = false;
            this.button1.Visible = false;

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
        #region Threading functions
        /// <summary>
        /// Cancel Thread.
        /// </summary>
        private void CancelTask()
        {
            if (tokenSource != null)
            {
                if (tokenSource.IsCancellationRequested == false)
                {
                    tokenSource.Cancel();
                }
            }
        }
        /// <summary>
        /// Set tokenSource for Start a new Thread
        /// </summary>
        /// <returns></returns>
        private CancellationTokenSource StartNewTask()
        {
            tokenSource = new CancellationTokenSource();
            return tokenSource;
        }
        /// <summary>
        /// Execute a thread
        /// </summary>
        /// <param name="ThreadName"></param>
        /// <returns></returns>
        private async Task<bool> RunThread(FileNameChange.Tools.ThreadName threadName)
        {
            DateTime dt1, dt2;
            dt1 = System.DateTime.Now;
            bool rtn = false;
            try
            {
                //Set buttons enabled to be disenable
                this.SetButtonStatus(threadName, false);

                CancellationTokenSource tokenSource = StartNewTask();
                //Get threadparameter
                ICloneable param = GetParameter(threadName);
                //Get context for to execute thread
                ThreadContext<bool> threadContext = new ThreadContext<bool>(threadName, tokenSource, param);
                //Thread  running
                task = threadContext.ThreadRun();
                // wait thread is over
                rtn = await task;

            }
            catch (Exception ex)
            {
                LoggerHelper.Error("Task<int> RunThread Function", ex);

            }
            finally
            {
                //Set buttons enabled from disabled to enabled.
                this.SetButtonStatus(threadName, true);
                dt2 = System.DateTime.Now;
                if (SystemConfiguration.Debug)
                {
                    LoggerHelper.Debug("[" + threadName.ToString() + "] is finished. It took " + (dt2 - dt1).ToString() + "\r\n");
                }
            }
            return rtn;
        }
        /// <summary>
        /// get parameter
        /// </summary>
        /// <param name="ThreadName"></param>
        /// <returns></returns>
        private ICloneable GetParameter(FileNameChange.Tools.ThreadName threadName)
        {
            ICloneable param = null;
            switch (threadName)
            {
                case FileNameChange.Tools.ThreadName.ChangeFileName:
                    param = this.GetChangeFileNameParameter();
                    break;
                case FileNameChange.Tools.ThreadName.CheckName:
                    param = this.GetCheckNameParameter();
                    break;
                case FileNameChange.Tools.ThreadName.Traverse:
                    param = this.GetTraverseParameter();
                    break;

                    
                default:
                    break;
            }
            return param;
        }

        private ChangeFileNameParameter GetChangeFileNameParameter()
        {
            ChangeFileNameParameter rtn = new ChangeFileNameParameter();
            rtn.SetOriginalRootPath(this.txtOriginalDir.Text.Trim());
            rtn.SetOutputRootPath(this.txtOutputDir.Text.Trim());
            return rtn;

        }
        private CheckNameParameter GetCheckNameParameter()
        {
            CheckNameParameter rtn = new CheckNameParameter();
            //Outputpath is the checking 's original path. 
            rtn.SetOriginalRootPath(this.txtOutputDir.Text.Trim());
            return rtn;

        }
        private TraverseParameter GetTraverseParameter()
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
        private void SetChangeFileNameButtonStatus(bool isEnabled)
        {
            this.btnExcute.Enabled = isEnabled;
            this.btnCheckName.Enabled = isEnabled;
            SetOpenDirButtonStatus(isEnabled);
        }
        private void SetCheckNameButtonStatus(bool isEnabled)
        {
            this.btnCheckName.Enabled = isEnabled;
            this.btnExcute.Enabled = isEnabled;
            SetOpenDirButtonStatus(isEnabled);
        }
        private void SetTraverseButtonStatus(bool isEnabled)
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
        /// <summary>
        /// Set buttons are enabled or not.
        /// </summary>
        /// <param name="isEnabled">true:Button are enabled; false: buttons are disenabled.</param>
        private void SetButtonStatus(FileNameChange.Tools.ThreadName threadName, bool flag)
        {
            switch (threadName)
            {
                case FileNameChange.Tools.ThreadName.ChangeFileName:
                    this.SetChangeFileNameButtonStatus(flag);
                    break;
                case FileNameChange.Tools.ThreadName.CheckName:
                    this.SetCheckNameButtonStatus(flag);
                    break;
                case FileNameChange.Tools.ThreadName.Traverse:
                    this.SetTraverseButtonStatus(flag);
                    break;
                default:
                    break;
            }
        }
        #endregion End Button Status controll

        

        private async void BtnExcute_Click(object sender, EventArgs e)
        {
            await RunThread(FileNameChange.Tools.ThreadName.ChangeFileName);
        }

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

        private void Button1_Click(object sender, EventArgs e)
        {
            foreach(string item in SystemConfiguration.RegexRegular_InvalidDict.Keys)
            {
                MatchCollection m = System.Text.RegularExpressions.Regex.Matches(this.textBox1.Text.Trim(), SystemConfiguration.RegexRegular_InvalidDict[item]);
                //string s = "";
                //foreach (Match match in m)
                //{
                //    s += item.ToString();
                //}
                if (m.Count > 0) { LoggerHelper.Debug("[" + this.textBox1.Text.Trim() + "] match " + item + "\r\n"); }
                else { LoggerHelper.Debug("[" + this.textBox1.Text.Trim() + "] doesn't match " + item + "\r\n"); }


            }
        }

        private async void BtnCheckName_Click(object sender, EventArgs e)
        {
            await RunThread(FileNameChange.Tools.ThreadName.CheckName);
        }

        private async void BtnTraverse_Click(object sender, EventArgs e)
        {
            await RunThread(FileNameChange.Tools.ThreadName.Traverse);
        }
    }
}
