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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnOpenDir = new System.Windows.Forms.Button();
            this.rtxtLog = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.rtxtRequirement = new System.Windows.Forms.RichTextBox();
            this.btnExcute = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.btnOpenDir);
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtxtLog);
            this.splitContainer1.Size = new System.Drawing.Size(1031, 633);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Directory";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(148, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(526, 26);
            this.textBox1.TabIndex = 1;
            // 
            // btnOpenDir
            // 
            this.btnOpenDir.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpenDir.Location = new System.Drawing.Point(681, 9);
            this.btnOpenDir.Name = "btnOpenDir";
            this.btnOpenDir.Size = new System.Drawing.Size(162, 30);
            this.btnOpenDir.TabIndex = 2;
            this.btnOpenDir.Text = "Browse";
            this.btnOpenDir.UseVisualStyleBackColor = true;
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
            this.rtxtLog.Size = new System.Drawing.Size(1031, 329);
            this.rtxtLog.TabIndex = 0;
            this.rtxtLog.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1031, 257);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 17);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.rtxtRequirement);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnExcute);
            this.splitContainer2.Size = new System.Drawing.Size(1025, 237);
            this.splitContainer2.SplitterDistance = 786;
            this.splitContainer2.TabIndex = 0;
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
            this.rtxtRequirement.Size = new System.Drawing.Size(786, 237);
            this.rtxtRequirement.TabIndex = 1;
            this.rtxtRequirement.Text = resources.GetString("rtxtRequirement.Text");
            // 
            // btnExcute
            // 
            this.btnExcute.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExcute.Location = new System.Drawing.Point(44, 44);
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(160, 95);
            this.btnExcute.TabIndex = 0;
            this.btnExcute.Text = "Execute Change";
            this.btnExcute.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 633);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileNameChangeTools Develeped by ArkivIT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnOpenDir;
        private System.Windows.Forms.RichTextBox rtxtLog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RichTextBox rtxtRequirement;
        private System.Windows.Forms.Button btnExcute;
    }
}

