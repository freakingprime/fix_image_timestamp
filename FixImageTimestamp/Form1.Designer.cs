namespace FixImageTimestamp {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.chkUseTimePattern = new System.Windows.Forms.CheckBox();
            this.chkIncludeSubfolders = new System.Windows.Forms.CheckBox();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.lvwPreview = new System.Windows.Forms.ListView();
            this.headerFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerCurrentTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerExpectedTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerDifferent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headerFullPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuLvwPreview = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItem_openImage = new System.Windows.Forms.ToolStripMenuItem();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.chkShowFailOnly = new System.Windows.Forms.CheckBox();
            this.menuLvwPreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Location = new System.Drawing.Point(13, 13);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(375, 20);
            this.txtFolderPath.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(394, 11);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // chkUseTimePattern
            // 
            this.chkUseTimePattern.AutoSize = true;
            this.chkUseTimePattern.Location = new System.Drawing.Point(12, 39);
            this.chkUseTimePattern.Name = "chkUseTimePattern";
            this.chkUseTimePattern.Size = new System.Drawing.Size(215, 17);
            this.chkUseTimePattern.TabIndex = 2;
            this.chkUseTimePattern.Text = "Use time in file name if EXIF is not found";
            this.chkUseTimePattern.UseVisualStyleBackColor = true;
            this.chkUseTimePattern.CheckedChanged += new System.EventHandler(this.chkUseTimePattern_CheckedChanged);
            // 
            // chkIncludeSubfolders
            // 
            this.chkIncludeSubfolders.AutoSize = true;
            this.chkIncludeSubfolders.Location = new System.Drawing.Point(12, 62);
            this.chkIncludeSubfolders.Name = "chkIncludeSubfolders";
            this.chkIncludeSubfolders.Size = new System.Drawing.Size(115, 17);
            this.chkIncludeSubfolders.TabIndex = 3;
            this.chkIncludeSubfolders.Text = "Include sub folders";
            this.chkIncludeSubfolders.UseVisualStyleBackColor = true;
            this.chkIncludeSubfolders.CheckedChanged += new System.EventHandler(this.chkIncludeSubfolders_CheckedChanged);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Location = new System.Drawing.Point(12, 85);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(75, 23);
            this.btnAnalyze.TabIndex = 4;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(93, 85);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 5;
            this.btnProcess.Text = "Fix now";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // lvwPreview
            // 
            this.lvwPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwPreview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.headerFileName,
            this.headerCurrentTime,
            this.headerExpectedTime,
            this.headerType,
            this.headerStatus,
            this.headerDifferent,
            this.headerFullPath});
            this.lvwPreview.ContextMenuStrip = this.menuLvwPreview;
            this.lvwPreview.FullRowSelect = true;
            this.lvwPreview.GridLines = true;
            this.lvwPreview.Location = new System.Drawing.Point(12, 114);
            this.lvwPreview.MultiSelect = false;
            this.lvwPreview.Name = "lvwPreview";
            this.lvwPreview.Size = new System.Drawing.Size(610, 336);
            this.lvwPreview.TabIndex = 6;
            this.lvwPreview.UseCompatibleStateImageBehavior = false;
            this.lvwPreview.View = System.Windows.Forms.View.Details;
            this.lvwPreview.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwPreview_ColumnClick);
            // 
            // headerFileName
            // 
            this.headerFileName.Text = "Filename";
            // 
            // headerCurrentTime
            // 
            this.headerCurrentTime.Text = "Current";
            // 
            // headerExpectedTime
            // 
            this.headerExpectedTime.Text = "Expect";
            // 
            // headerType
            // 
            this.headerType.Text = "Type";
            // 
            // headerStatus
            // 
            this.headerStatus.Text = "Status";
            // 
            // headerDifferent
            // 
            this.headerDifferent.Text = "Diff";
            // 
            // headerFullPath
            // 
            this.headerFullPath.Text = "Full path";
            // 
            // menuLvwPreview
            // 
            this.menuLvwPreview.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_openImage});
            this.menuLvwPreview.Name = "menuLvwPreview";
            this.menuLvwPreview.Size = new System.Drawing.Size(104, 26);
            this.menuLvwPreview.Opening += new System.ComponentModel.CancelEventHandler(this.menuLvwPreview_Opening);
            // 
            // menuItem_openImage
            // 
            this.menuItem_openImage.Name = "menuItem_openImage";
            this.menuItem_openImage.Size = new System.Drawing.Size(103, 22);
            this.menuItem_openImage.Text = "Open";
            this.menuItem_openImage.Click += new System.EventHandler(this.menuItem_openImage_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(174, 87);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(110, 20);
            this.txtStatus.TabIndex = 7;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(441, 87);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(181, 20);
            this.progressBar.TabIndex = 8;
            // 
            // chkShowFailOnly
            // 
            this.chkShowFailOnly.AutoSize = true;
            this.chkShowFailOnly.Location = new System.Drawing.Point(290, 89);
            this.chkShowFailOnly.Name = "chkShowFailOnly";
            this.chkShowFailOnly.Size = new System.Drawing.Size(91, 17);
            this.chkShowFailOnly.TabIndex = 9;
            this.chkShowFailOnly.Text = "Show fail only";
            this.chkShowFailOnly.UseVisualStyleBackColor = true;
            this.chkShowFailOnly.CheckedChanged += new System.EventHandler(this.chkShowFailOnly_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 462);
            this.Controls.Add(this.chkShowFailOnly);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lvwPreview);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.chkIncludeSubfolders);
            this.Controls.Add(this.chkUseTimePattern);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFolderPath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(650, 300);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuLvwPreview.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.CheckBox chkUseTimePattern;
        private System.Windows.Forms.CheckBox chkIncludeSubfolders;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.ListView lvwPreview;
        private System.Windows.Forms.ColumnHeader headerFileName;
        private System.Windows.Forms.ColumnHeader headerCurrentTime;
        private System.Windows.Forms.ColumnHeader headerStatus;
        private System.Windows.Forms.ColumnHeader headerExpectedTime;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.CheckBox chkShowFailOnly;
        private System.Windows.Forms.ColumnHeader headerType;
        private System.Windows.Forms.ContextMenuStrip menuLvwPreview;
        private System.Windows.Forms.ToolStripMenuItem menuItem_openImage;
        private System.Windows.Forms.ColumnHeader headerFullPath;
        private System.Windows.Forms.ColumnHeader headerDifferent;
    }
}

