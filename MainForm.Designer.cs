namespace FileNameChange
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "1",
            "Others",
            "->",
            "_"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "2",
            "å",
            "->",
            "aa"}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "3",
            "Å",
            "->",
            "AA"}, -1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "4",
            "ä",
            "->",
            "ae"}, -1);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "5",
            "Ä",
            "->",
            "AE"}, -1);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "6",
            "ö",
            "->",
            "oe"}, -1);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "7",
            "Ö",
            "->",
            "OE"}, -1);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(new string[] {
            "8",
            " ",
            "->",
            "_"}, -1);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSelectOutputDir = new System.Windows.Forms.Button();
            this.txtOutputDir = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSelectOriginalDir = new System.Windows.Forms.Button();
            this.txtOriginalDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.rtxtRequirement = new System.Windows.Forms.RichTextBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.btnAddRule = new System.Windows.Forms.Button();
            this.txtReplacement = new System.Windows.Forms.TextBox();
            this.txtOriText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstvReplacement = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteCurrentRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTraverse = new System.Windows.Forms.Button();
            this.btnCheckName = new System.Windows.Forms.Button();
            this.btnExcute = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNavigationPageExtension = new System.Windows.Forms.TextBox();
            this.btnBrowseNavigationDir = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtReplacementDir = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ckbReplaceHTML = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHTMLReplacementReg = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtHTMSearchReg = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckbReplaceFileName = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFileNameReplacementReg = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFileNameSearchReg = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExcuteReplacement = new System.Windows.Forms.Button();
            this.rtxtLog = new System.Windows.Forms.RichTextBox();
            this.folderBrowserDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtxtLog);
            this.splitContainer1.Size = new System.Drawing.Size(1269, 633);
            this.splitContainer1.SplitterDistance = 374;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1269, 374);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.btnSelectOutputDir);
            this.tabPage1.Controls.Add(this.txtOutputDir);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.btnSelectOriginalDir);
            this.tabPage1.Controls.Add(this.txtOriginalDir);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1261, 348);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Change FileName";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(872, 54);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(188, 21);
            this.textBox2.TabIndex = 19;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(872, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(210, 21);
            this.textBox1.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1066, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnSelectOutputDir
            // 
            this.btnSelectOutputDir.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectOutputDir.Location = new System.Drawing.Point(687, 50);
            this.btnSelectOutputDir.Name = "btnSelectOutputDir";
            this.btnSelectOutputDir.Size = new System.Drawing.Size(162, 30);
            this.btnSelectOutputDir.TabIndex = 16;
            this.btnSelectOutputDir.Text = "Browse";
            this.btnSelectOutputDir.UseVisualStyleBackColor = true;
            this.btnSelectOutputDir.Click += new System.EventHandler(this.BtnSelectOutputDir_Click);
            // 
            // txtOutputDir
            // 
            this.txtOutputDir.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOutputDir.Location = new System.Drawing.Point(240, 52);
            this.txtOutputDir.Name = "txtOutputDir";
            this.txtOutputDir.Size = new System.Drawing.Size(440, 26);
            this.txtOutputDir.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(18, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 21);
            this.label4.TabIndex = 14;
            this.label4.Text = "Select Output Directory";
            // 
            // btnSelectOriginalDir
            // 
            this.btnSelectOriginalDir.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectOriginalDir.Location = new System.Drawing.Point(687, 16);
            this.btnSelectOriginalDir.Name = "btnSelectOriginalDir";
            this.btnSelectOriginalDir.Size = new System.Drawing.Size(162, 30);
            this.btnSelectOriginalDir.TabIndex = 13;
            this.btnSelectOriginalDir.Text = "Browse";
            this.btnSelectOriginalDir.UseVisualStyleBackColor = true;
            this.btnSelectOriginalDir.Click += new System.EventHandler(this.BtnSelectOriginalDir_Click);
            // 
            // txtOriginalDir
            // 
            this.txtOriginalDir.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOriginalDir.Location = new System.Drawing.Point(240, 18);
            this.txtOriginalDir.Name = "txtOriginalDir";
            this.txtOriginalDir.Size = new System.Drawing.Size(440, 26);
            this.txtOriginalDir.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "Select Original Directory";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(3, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1255, 257);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(3, 17);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnTraverse);
            this.splitContainer2.Panel2.Controls.Add(this.btnCheckName);
            this.splitContainer2.Panel2.Controls.Add(this.btnExcute);
            this.splitContainer2.Size = new System.Drawing.Size(1249, 237);
            this.splitContainer2.SplitterDistance = 885;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.rtxtRequirement);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(885, 237);
            this.splitContainer3.SplitterDistance = 458;
            this.splitContainer3.TabIndex = 2;
            // 
            // rtxtRequirement
            // 
            this.rtxtRequirement.BackColor = System.Drawing.SystemColors.Control;
            this.rtxtRequirement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtRequirement.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtxtRequirement.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rtxtRequirement.Location = new System.Drawing.Point(0, 0);
            this.rtxtRequirement.Name = "rtxtRequirement";
            this.rtxtRequirement.ReadOnly = true;
            this.rtxtRequirement.Size = new System.Drawing.Size(458, 237);
            this.rtxtRequirement.TabIndex = 2;
            this.rtxtRequirement.Text = resources.GetString("rtxtRequirement.Text");
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.btnAddRule);
            this.splitContainer4.Panel1.Controls.Add(this.txtReplacement);
            this.splitContainer4.Panel1.Controls.Add(this.txtOriText);
            this.splitContainer4.Panel1.Controls.Add(this.label3);
            this.splitContainer4.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.lstvReplacement);
            this.splitContainer4.Size = new System.Drawing.Size(423, 237);
            this.splitContainer4.SplitterDistance = 42;
            this.splitContainer4.TabIndex = 0;
            // 
            // btnAddRule
            // 
            this.btnAddRule.Location = new System.Drawing.Point(331, 8);
            this.btnAddRule.Name = "btnAddRule";
            this.btnAddRule.Size = new System.Drawing.Size(75, 23);
            this.btnAddRule.TabIndex = 4;
            this.btnAddRule.Text = "Add Rule";
            this.btnAddRule.UseVisualStyleBackColor = true;
            this.btnAddRule.Click += new System.EventHandler(this.BtnAddRule_Click);
            // 
            // txtReplacement
            // 
            this.txtReplacement.Location = new System.Drawing.Point(256, 9);
            this.txtReplacement.Name = "txtReplacement";
            this.txtReplacement.Size = new System.Drawing.Size(51, 21);
            this.txtReplacement.TabIndex = 3;
            // 
            // txtOriText
            // 
            this.txtOriText.Location = new System.Drawing.Point(122, 9);
            this.txtOriText.Name = "txtOriText";
            this.txtOriText.Size = new System.Drawing.Size(51, 21);
            this.txtOriText.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "replacement";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "original character";
            // 
            // lstvReplacement
            // 
            this.lstvReplacement.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lstvReplacement.ContextMenuStrip = this.contextMenuStrip1;
            this.lstvReplacement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstvReplacement.FullRowSelect = true;
            this.lstvReplacement.HideSelection = false;
            this.lstvReplacement.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8});
            this.lstvReplacement.Location = new System.Drawing.Point(0, 0);
            this.lstvReplacement.MultiSelect = false;
            this.lstvReplacement.Name = "lstvReplacement";
            this.lstvReplacement.Size = new System.Drawing.Size(423, 191);
            this.lstvReplacement.TabIndex = 0;
            this.lstvReplacement.UseCompatibleStateImageBehavior = false;
            this.lstvReplacement.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "NO.";
            this.columnHeader1.Width = 56;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Oiriginal character";
            this.columnHeader2.Width = 128;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "";
            this.columnHeader3.Width = 31;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Replacement";
            this.columnHeader4.Width = 116;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteCurrentRowToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(190, 26);
            // 
            // deleteCurrentRowToolStripMenuItem
            // 
            this.deleteCurrentRowToolStripMenuItem.Name = "deleteCurrentRowToolStripMenuItem";
            this.deleteCurrentRowToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.deleteCurrentRowToolStripMenuItem.Text = "Delete Current Row";
            this.deleteCurrentRowToolStripMenuItem.Click += new System.EventHandler(this.DeleteCurrentRowToolStripMenuItem_Click);
            // 
            // btnTraverse
            // 
            this.btnTraverse.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTraverse.Location = new System.Drawing.Point(32, 144);
            this.btnTraverse.Name = "btnTraverse";
            this.btnTraverse.Size = new System.Drawing.Size(160, 50);
            this.btnTraverse.TabIndex = 2;
            this.btnTraverse.Text = "Travers Fold";
            this.btnTraverse.UseVisualStyleBackColor = true;
            this.btnTraverse.Click += new System.EventHandler(this.BtnTraverse_Click);
            // 
            // btnCheckName
            // 
            this.btnCheckName.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCheckName.Location = new System.Drawing.Point(32, 88);
            this.btnCheckName.Name = "btnCheckName";
            this.btnCheckName.Size = new System.Drawing.Size(160, 50);
            this.btnCheckName.TabIndex = 1;
            this.btnCheckName.Text = "Check Name";
            this.btnCheckName.UseVisualStyleBackColor = true;
            this.btnCheckName.Click += new System.EventHandler(this.BtnCheckName_Click);
            // 
            // btnExcute
            // 
            this.btnExcute.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExcute.Location = new System.Drawing.Point(32, 13);
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(160, 69);
            this.btnExcute.TabIndex = 0;
            this.btnExcute.Text = "Execute Change";
            this.btnExcute.UseVisualStyleBackColor = true;
            this.btnExcute.Click += new System.EventHandler(this.BtnExcute_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(926, 348);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Select Original Directory";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(742, 342);
            this.panel2.TabIndex = 2;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.label10);
            this.splitContainer5.Panel1.Controls.Add(this.txtNavigationPageExtension);
            this.splitContainer5.Panel1.Controls.Add(this.btnBrowseNavigationDir);
            this.splitContainer5.Panel1.Controls.Add(this.label6);
            this.splitContainer5.Panel1.Controls.Add(this.txtReplacementDir);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer5.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer5.Size = new System.Drawing.Size(742, 342);
            this.splitContainer5.SplitterDistance = 77;
            this.splitContainer5.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(5, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(141, 20);
            this.label10.TabIndex = 19;
            this.label10.Text = "FileName Extension";
            // 
            // txtNavigationPageExtension
            // 
            this.txtNavigationPageExtension.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNavigationPageExtension.Location = new System.Drawing.Point(183, 47);
            this.txtNavigationPageExtension.Name = "txtNavigationPageExtension";
            this.txtNavigationPageExtension.Size = new System.Drawing.Size(446, 26);
            this.txtNavigationPageExtension.TabIndex = 18;
            this.txtNavigationPageExtension.Text = ".htm";
            // 
            // btnBrowseNavigationDir
            // 
            this.btnBrowseNavigationDir.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBrowseNavigationDir.Location = new System.Drawing.Point(635, 11);
            this.btnBrowseNavigationDir.Name = "btnBrowseNavigationDir";
            this.btnBrowseNavigationDir.Size = new System.Drawing.Size(101, 30);
            this.btnBrowseNavigationDir.TabIndex = 17;
            this.btnBrowseNavigationDir.Text = "Browse";
            this.btnBrowseNavigationDir.UseVisualStyleBackColor = true;
            this.btnBrowseNavigationDir.Click += new System.EventHandler(this.BtnBrowseNavigationDir_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(5, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Select Original Directory";
            // 
            // txtReplacementDir
            // 
            this.txtReplacementDir.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtReplacementDir.Location = new System.Drawing.Point(183, 13);
            this.txtReplacementDir.Name = "txtReplacementDir";
            this.txtReplacementDir.Size = new System.Drawing.Size(446, 26);
            this.txtReplacementDir.TabIndex = 15;
            this.txtReplacementDir.Text = "@page=0";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ckbReplaceHTML);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtHTMLReplacementReg);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtHTMSearchReg);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(369, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(367, 261);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // ckbReplaceHTML
            // 
            this.ckbReplaceHTML.AutoSize = true;
            this.ckbReplaceHTML.Location = new System.Drawing.Point(6, 2);
            this.ckbReplaceHTML.Name = "ckbReplaceHTML";
            this.ckbReplaceHTML.Size = new System.Drawing.Size(162, 16);
            this.ckbReplaceHTML.TabIndex = 15;
            this.ckbReplaceHTML.Text = "Replace content of HTML";
            this.ckbReplaceHTML.UseVisualStyleBackColor = true;
            this.ckbReplaceHTML.CheckedChanged += new System.EventHandler(this.CkbReplaceHTML_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(12, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Replacement Regex";
            // 
            // txtHTMLReplacementReg
            // 
            this.txtHTMLReplacementReg.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHTMLReplacementReg.Location = new System.Drawing.Point(155, 52);
            this.txtHTMLReplacementReg.Name = "txtHTMLReplacementReg";
            this.txtHTMLReplacementReg.Size = new System.Drawing.Size(146, 26);
            this.txtHTMLReplacementReg.TabIndex = 10;
            this.txtHTMLReplacementReg.Text = "@page=0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(12, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "Search Regex";
            // 
            // txtHTMSearchReg
            // 
            this.txtHTMSearchReg.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHTMSearchReg.Location = new System.Drawing.Point(155, 20);
            this.txtHTMSearchReg.Name = "txtHTMSearchReg";
            this.txtHTMSearchReg.Size = new System.Drawing.Size(146, 26);
            this.txtHTMSearchReg.TabIndex = 8;
            this.txtHTMSearchReg.Text = "@page=0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ckbReplaceFileName);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtFileNameReplacementReg);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtFileNameSearchReg);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(369, 261);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // ckbReplaceFileName
            // 
            this.ckbReplaceFileName.AutoSize = true;
            this.ckbReplaceFileName.Location = new System.Drawing.Point(6, 2);
            this.ckbReplaceFileName.Name = "ckbReplaceFileName";
            this.ckbReplaceFileName.Size = new System.Drawing.Size(120, 16);
            this.ckbReplaceFileName.TabIndex = 15;
            this.ckbReplaceFileName.Text = "Replace FileName";
            this.ckbReplaceFileName.UseVisualStyleBackColor = true;
            this.ckbReplaceFileName.CheckedChanged += new System.EventHandler(this.CkbReplaceFileName_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(9, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Replacement Regex";
            // 
            // txtFileNameReplacementReg
            // 
            this.txtFileNameReplacementReg.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFileNameReplacementReg.Location = new System.Drawing.Point(152, 52);
            this.txtFileNameReplacementReg.Name = "txtFileNameReplacementReg";
            this.txtFileNameReplacementReg.Size = new System.Drawing.Size(146, 26);
            this.txtFileNameReplacementReg.TabIndex = 10;
            this.txtFileNameReplacementReg.Text = "@page=0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(9, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Search Regex";
            // 
            // txtFileNameSearchReg
            // 
            this.txtFileNameSearchReg.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFileNameSearchReg.Location = new System.Drawing.Point(152, 20);
            this.txtFileNameSearchReg.Name = "txtFileNameSearchReg";
            this.txtFileNameSearchReg.Size = new System.Drawing.Size(146, 26);
            this.txtFileNameSearchReg.TabIndex = 8;
            this.txtFileNameSearchReg.Text = "@page=0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExcuteReplacement);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(745, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(178, 342);
            this.panel1.TabIndex = 1;
            // 
            // btnExcuteReplacement
            // 
            this.btnExcuteReplacement.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExcuteReplacement.Location = new System.Drawing.Point(31, 21);
            this.btnExcuteReplacement.Name = "btnExcuteReplacement";
            this.btnExcuteReplacement.Size = new System.Drawing.Size(125, 117);
            this.btnExcuteReplacement.TabIndex = 3;
            this.btnExcuteReplacement.Text = "Excute Replacement";
            this.btnExcuteReplacement.UseVisualStyleBackColor = true;
            this.btnExcuteReplacement.Click += new System.EventHandler(this.BtnExcuteReplacement_Click);
            // 
            // rtxtLog
            // 
            this.rtxtLog.BackColor = System.Drawing.Color.Black;
            this.rtxtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtLog.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtxtLog.ForeColor = System.Drawing.Color.Transparent;
            this.rtxtLog.Location = new System.Drawing.Point(0, 0);
            this.rtxtLog.Name = "rtxtLog";
            this.rtxtLog.ReadOnly = true;
            this.rtxtLog.Size = new System.Drawing.Size(1269, 255);
            this.rtxtLog.TabIndex = 0;
            this.rtxtLog.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 633);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileNameChangeTools Develeped by ArkivIT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel1.PerformLayout();
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox rtxtLog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDlg;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteCurrentRowToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSelectOutputDir;
        private System.Windows.Forms.TextBox txtOutputDir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSelectOriginalDir;
        private System.Windows.Forms.TextBox txtOriginalDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.RichTextBox rtxtRequirement;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Button btnAddRule;
        private System.Windows.Forms.TextBox txtReplacement;
        private System.Windows.Forms.TextBox txtOriText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lstvReplacement;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnTraverse;
        private System.Windows.Forms.Button btnCheckName;
        private System.Windows.Forms.Button btnExcute;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBrowseNavigationDir;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtReplacementDir;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox ckbReplaceHTML;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHTMLReplacementReg;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtHTMSearchReg;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ckbReplaceFileName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFileNameReplacementReg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFileNameSearchReg;
        private System.Windows.Forms.Button btnExcuteReplacement;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNavigationPageExtension;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

