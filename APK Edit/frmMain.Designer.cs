namespace APK_Edit
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.pictureBoxBrowse = new System.Windows.Forms.PictureBox();
            this.pictureBoxTranslate = new System.Windows.Forms.PictureBox();
            this.pictureBoxSettings = new System.Windows.Forms.PictureBox();
            this.pictureBoxStatus = new System.Windows.Forms.PictureBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.pictureBoxHDPI = new System.Windows.Forms.PictureBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelIcons = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.tabPageDetails = new System.Windows.Forms.TabPage();
            this.labelApkToolVersion = new System.Windows.Forms.Label();
            this.labelApkToolVersionLabel = new System.Windows.Forms.Label();
            this.openFileDialogIcon = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogFramework = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControlMain.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBrowse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTranslate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHDPI)).BeginInit();
            this.tabPageDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(279, 447);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 20;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(198, 447);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(117, 447);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 17;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabPageGeneral);
            this.tabControlMain.Controls.Add(this.tabPageDetails);
            this.tabControlMain.Location = new System.Drawing.Point(7, 7);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(347, 434);
            this.tabControlMain.TabIndex = 21;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.pictureBoxBrowse);
            this.tabPageGeneral.Controls.Add(this.pictureBoxTranslate);
            this.tabPageGeneral.Controls.Add(this.pictureBoxSettings);
            this.tabPageGeneral.Controls.Add(this.pictureBoxStatus);
            this.tabPageGeneral.Controls.Add(this.labelStatus);
            this.tabPageGeneral.Controls.Add(this.pictureBoxHDPI);
            this.tabPageGeneral.Controls.Add(this.textBoxName);
            this.tabPageGeneral.Controls.Add(this.labelIcons);
            this.tabPageGeneral.Controls.Add(this.labelName);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(339, 408);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // pictureBoxBrowse
            // 
            this.pictureBoxBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxBrowse.Image = global::APK_Edit.Properties.Resources.Browse_16;
            this.pictureBoxBrowse.Location = new System.Drawing.Point(265, 376);
            this.pictureBoxBrowse.Name = "pictureBoxBrowse";
            this.pictureBoxBrowse.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxBrowse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBrowse.TabIndex = 29;
            this.pictureBoxBrowse.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxBrowse, "Browse");
            this.pictureBoxBrowse.Click += new System.EventHandler(this.pictureBoxBrowse_Click);
            // 
            // pictureBoxTranslate
            // 
            this.pictureBoxTranslate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxTranslate.Image = global::APK_Edit.Properties.Resources.Translate_16;
            this.pictureBoxTranslate.Location = new System.Drawing.Point(287, 376);
            this.pictureBoxTranslate.Name = "pictureBoxTranslate";
            this.pictureBoxTranslate.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxTranslate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxTranslate.TabIndex = 28;
            this.pictureBoxTranslate.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxTranslate, "Edit Translations");
            this.pictureBoxTranslate.Click += new System.EventHandler(this.pictureBoxTranslate_Click);
            // 
            // pictureBoxSettings
            // 
            this.pictureBoxSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSettings.Image = global::APK_Edit.Properties.Resources.Settings_16;
            this.pictureBoxSettings.Location = new System.Drawing.Point(309, 376);
            this.pictureBoxSettings.Name = "pictureBoxSettings";
            this.pictureBoxSettings.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSettings.TabIndex = 27;
            this.pictureBoxSettings.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxSettings, "Settings");
            this.pictureBoxSettings.Click += new System.EventHandler(this.pictureBoxSettings_Click);
            // 
            // pictureBoxStatus
            // 
            this.pictureBoxStatus.Location = new System.Drawing.Point(131, 166);
            this.pictureBoxStatus.Name = "pictureBoxStatus";
            this.pictureBoxStatus.Size = new System.Drawing.Size(76, 76);
            this.pictureBoxStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxStatus.TabIndex = 25;
            this.pictureBoxStatus.TabStop = false;
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(2, 250);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(335, 13);
            this.labelStatus.TabIndex = 24;
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBoxHDPI
            // 
            this.pictureBoxHDPI.Location = new System.Drawing.Point(50, 32);
            this.pictureBoxHDPI.Name = "pictureBoxHDPI";
            this.pictureBoxHDPI.Size = new System.Drawing.Size(76, 76);
            this.pictureBoxHDPI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxHDPI.TabIndex = 23;
            this.pictureBoxHDPI.TabStop = false;
            this.pictureBoxHDPI.Click += new System.EventHandler(this.pictureBoxHDPI_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.Enabled = false;
            this.textBoxName.Location = new System.Drawing.Point(50, 6);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(275, 20);
            this.textBoxName.TabIndex = 22;
            // 
            // labelIcons
            // 
            this.labelIcons.AutoSize = true;
            this.labelIcons.Location = new System.Drawing.Point(6, 32);
            this.labelIcons.Name = "labelIcons";
            this.labelIcons.Size = new System.Drawing.Size(36, 13);
            this.labelIcons.TabIndex = 1;
            this.labelIcons.Text = "Icons:";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(6, 8);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name:";
            // 
            // tabPageDetails
            // 
            this.tabPageDetails.Controls.Add(this.labelApkToolVersion);
            this.tabPageDetails.Controls.Add(this.labelApkToolVersionLabel);
            this.tabPageDetails.Location = new System.Drawing.Point(4, 22);
            this.tabPageDetails.Name = "tabPageDetails";
            this.tabPageDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDetails.Size = new System.Drawing.Size(339, 408);
            this.tabPageDetails.TabIndex = 1;
            this.tabPageDetails.Text = "Details";
            this.tabPageDetails.UseVisualStyleBackColor = true;
            // 
            // labelApkToolVersion
            // 
            this.labelApkToolVersion.AutoSize = true;
            this.labelApkToolVersion.Enabled = false;
            this.labelApkToolVersion.Location = new System.Drawing.Point(103, 13);
            this.labelApkToolVersion.Name = "labelApkToolVersion";
            this.labelApkToolVersion.Size = new System.Drawing.Size(0, 13);
            this.labelApkToolVersion.TabIndex = 1;
            // 
            // labelApkToolVersionLabel
            // 
            this.labelApkToolVersionLabel.AutoSize = true;
            this.labelApkToolVersionLabel.Location = new System.Drawing.Point(7, 13);
            this.labelApkToolVersionLabel.Name = "labelApkToolVersionLabel";
            this.labelApkToolVersionLabel.Size = new System.Drawing.Size(90, 13);
            this.labelApkToolVersionLabel.TabIndex = 0;
            this.labelApkToolVersionLabel.Text = "Apk Tool version:";
            // 
            // openFileDialogIcon
            // 
            this.openFileDialogIcon.Filter = "Android icon files|*.png";
            // 
            // openFileDialogFramework
            // 
            this.openFileDialogFramework.FileName = "Framework.apk";
            this.openFileDialogFramework.Filter = "Android framework files|*.apk";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 477);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(377, 515);
            this.MinimumSize = new System.Drawing.Size(377, 515);
            this.Name = "frmMain";
            this.Text = "APK Edit 0.5";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBrowse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTranslate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHDPI)).EndInit();
            this.tabPageDetails.ResumeLayout(false);
            this.tabPageDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TabPage tabPageDetails;
        private System.Windows.Forms.Label labelIcons;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.PictureBox pictureBoxHDPI;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.PictureBox pictureBoxStatus;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.OpenFileDialog openFileDialogIcon;
        private System.Windows.Forms.OpenFileDialog openFileDialogFramework;
        private System.Windows.Forms.Label labelApkToolVersion;
        private System.Windows.Forms.Label labelApkToolVersionLabel;
        private System.Windows.Forms.PictureBox pictureBoxSettings;
        private System.Windows.Forms.PictureBox pictureBoxBrowse;
        private System.Windows.Forms.PictureBox pictureBoxTranslate;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}