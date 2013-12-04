namespace XmlTranslate
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_SrcFile = new System.Windows.Forms.Button();
            this.txt_SrcFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_TargetFolder = new System.Windows.Forms.Button();
            this.txt_TargetFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chk_SameToSrc = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_SwapChange = new System.Windows.Forms.Button();
            this.cmb_SrcLang = new System.Windows.Forms.ComboBox();
            this.cmb_TgtLang = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Translate = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_SrcFile);
            this.panel1.Controls.Add(this.txt_SrcFile);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(615, 34);
            this.panel1.TabIndex = 0;
            // 
            // btn_SrcFile
            // 
            this.btn_SrcFile.Location = new System.Drawing.Point(560, 4);
            this.btn_SrcFile.Name = "btn_SrcFile";
            this.btn_SrcFile.Size = new System.Drawing.Size(52, 23);
            this.btn_SrcFile.TabIndex = 2;
            this.btn_SrcFile.Text = "select";
            this.btn_SrcFile.UseVisualStyleBackColor = true;
            this.btn_SrcFile.Click += new System.EventHandler(this.btn_SrcFile_Click);
            // 
            // txt_SrcFile
            // 
            this.txt_SrcFile.Location = new System.Drawing.Point(117, 6);
            this.txt_SrcFile.Name = "txt_SrcFile";
            this.txt_SrcFile.Size = new System.Drawing.Size(437, 21);
            this.txt_SrcFile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source Xml File:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_TargetFolder);
            this.panel2.Controls.Add(this.txt_TargetFolder);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(1, 92);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(615, 45);
            this.panel2.TabIndex = 0;
            // 
            // btn_TargetFolder
            // 
            this.btn_TargetFolder.Location = new System.Drawing.Point(560, 9);
            this.btn_TargetFolder.Name = "btn_TargetFolder";
            this.btn_TargetFolder.Size = new System.Drawing.Size(52, 23);
            this.btn_TargetFolder.TabIndex = 2;
            this.btn_TargetFolder.Text = "select";
            this.btn_TargetFolder.UseVisualStyleBackColor = true;
            this.btn_TargetFolder.Click += new System.EventHandler(this.btn_TargetFolder_Click);
            // 
            // txt_TargetFolder
            // 
            this.txt_TargetFolder.Location = new System.Drawing.Point(117, 10);
            this.txt_TargetFolder.Name = "txt_TargetFolder";
            this.txt_TargetFolder.Size = new System.Drawing.Size(437, 21);
            this.txt_TargetFolder.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Target Folder:";
            // 
            // chk_SameToSrc
            // 
            this.chk_SameToSrc.AutoSize = true;
            this.chk_SameToSrc.Checked = true;
            this.chk_SameToSrc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_SameToSrc.Location = new System.Drawing.Point(13, 70);
            this.chk_SameToSrc.Name = "chk_SameToSrc";
            this.chk_SameToSrc.Size = new System.Drawing.Size(180, 16);
            this.chk_SameToSrc.TabIndex = 3;
            this.chk_SameToSrc.Text = "Same Folder to Source File";
            this.chk_SameToSrc.UseVisualStyleBackColor = true;
            this.chk_SameToSrc.CheckedChanged += new System.EventHandler(this.chk_SameToSrc_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_SwapChange);
            this.panel3.Controls.Add(this.cmb_SrcLang);
            this.panel3.Controls.Add(this.cmb_TgtLang);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(1, 143);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(615, 34);
            this.panel3.TabIndex = 0;
            // 
            // btn_SwapChange
            // 
            this.btn_SwapChange.Location = new System.Drawing.Point(253, 8);
            this.btn_SwapChange.Name = "btn_SwapChange";
            this.btn_SwapChange.Size = new System.Drawing.Size(52, 23);
            this.btn_SwapChange.TabIndex = 2;
            this.btn_SwapChange.Text = "<-->";
            this.btn_SwapChange.UseVisualStyleBackColor = true;
            this.btn_SwapChange.Click += new System.EventHandler(this.btn_SwapChange_Click);
            // 
            // cmb_SrcLang
            // 
            this.cmb_SrcLang.FormattingEnabled = true;
            this.cmb_SrcLang.Location = new System.Drawing.Point(117, 8);
            this.cmb_SrcLang.Name = "cmb_SrcLang";
            this.cmb_SrcLang.Size = new System.Drawing.Size(121, 20);
            this.cmb_SrcLang.TabIndex = 1;
            // 
            // cmb_TgtLang
            // 
            this.cmb_TgtLang.FormattingEnabled = true;
            this.cmb_TgtLang.Location = new System.Drawing.Point(418, 7);
            this.cmb_TgtLang.Name = "cmb_TgtLang";
            this.cmb_TgtLang.Size = new System.Drawing.Size(121, 20);
            this.cmb_TgtLang.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(311, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "target language:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "source language:";
            // 
            // btn_Translate
            // 
            this.btn_Translate.Location = new System.Drawing.Point(446, 192);
            this.btn_Translate.Name = "btn_Translate";
            this.btn_Translate.Size = new System.Drawing.Size(77, 32);
            this.btn_Translate.TabIndex = 2;
            this.btn_Translate.Text = "Translate";
            this.btn_Translate.UseVisualStyleBackColor = true;
            this.btn_Translate.Click += new System.EventHandler(this.btn_Translate_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(529, 192);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(82, 32);
            this.btn_Close.TabIndex = 2;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "youdao",
            "bing"});
            this.comboBox1.Location = new System.Drawing.Point(25, 199);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 231);
            this.Controls.Add(this.chk_SameToSrc);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Translate);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Translater";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_SrcFile;
        private System.Windows.Forms.TextBox txt_TargetFolder;
        private System.Windows.Forms.Button btn_SrcFile;
        private System.Windows.Forms.Button btn_TargetFolder;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_TgtLang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_SrcLang;
        private System.Windows.Forms.Button btn_SwapChange;
        private System.Windows.Forms.Button btn_Translate;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.CheckBox chk_SameToSrc;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}