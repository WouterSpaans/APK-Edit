namespace APK_Edit
{
    partial class frmOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptions));
            this.groupBoxSigning = new System.Windows.Forms.GroupBox();
            this.checkBoxCreateSeperateSignFile = new System.Windows.Forms.CheckBox();
            this.checkBoxSigning = new System.Windows.Forms.CheckBox();
            this.groupBoxBackup = new System.Windows.Forms.GroupBox();
            this.checkBoxOverWritebackup = new System.Windows.Forms.CheckBox();
            this.checkBoxBackup = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxSigning.SuspendLayout();
            this.groupBoxBackup.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSigning
            // 
            this.groupBoxSigning.Controls.Add(this.checkBoxCreateSeperateSignFile);
            this.groupBoxSigning.Controls.Add(this.checkBoxSigning);
            this.groupBoxSigning.Location = new System.Drawing.Point(12, 89);
            this.groupBoxSigning.Name = "groupBoxSigning";
            this.groupBoxSigning.Size = new System.Drawing.Size(313, 73);
            this.groupBoxSigning.TabIndex = 5;
            this.groupBoxSigning.TabStop = false;
            this.groupBoxSigning.Text = "Signing configuration";
            // 
            // checkBoxCreateSeperateSignFile
            // 
            this.checkBoxCreateSeperateSignFile.AutoSize = true;
            this.checkBoxCreateSeperateSignFile.Location = new System.Drawing.Point(31, 44);
            this.checkBoxCreateSeperateSignFile.Name = "checkBoxCreateSeperateSignFile";
            this.checkBoxCreateSeperateSignFile.Size = new System.Drawing.Size(230, 17);
            this.checkBoxCreateSeperateSignFile.TabIndex = 1;
            this.checkBoxCreateSeperateSignFile.Text = "Create a seperate signed version of the file ";
            this.checkBoxCreateSeperateSignFile.UseVisualStyleBackColor = true;
            // 
            // checkBoxSigning
            // 
            this.checkBoxSigning.AutoSize = true;
            this.checkBoxSigning.Location = new System.Drawing.Point(12, 20);
            this.checkBoxSigning.Name = "checkBoxSigning";
            this.checkBoxSigning.Size = new System.Drawing.Size(226, 17);
            this.checkBoxSigning.TabIndex = 0;
            this.checkBoxSigning.Text = "Automatically sign the file when it is saved.";
            this.checkBoxSigning.UseVisualStyleBackColor = true;
            this.checkBoxSigning.CheckedChanged += new System.EventHandler(this.checkBoxSigning_CheckedChanged);
            // 
            // groupBoxBackup
            // 
            this.groupBoxBackup.Controls.Add(this.checkBoxOverWritebackup);
            this.groupBoxBackup.Controls.Add(this.checkBoxBackup);
            this.groupBoxBackup.Location = new System.Drawing.Point(12, 12);
            this.groupBoxBackup.Name = "groupBoxBackup";
            this.groupBoxBackup.Size = new System.Drawing.Size(313, 71);
            this.groupBoxBackup.TabIndex = 4;
            this.groupBoxBackup.TabStop = false;
            this.groupBoxBackup.Text = "Backup configuration";
            // 
            // checkBoxOverWritebackup
            // 
            this.checkBoxOverWritebackup.AutoSize = true;
            this.checkBoxOverWritebackup.Location = new System.Drawing.Point(31, 44);
            this.checkBoxOverWritebackup.Name = "checkBoxOverWritebackup";
            this.checkBoxOverWritebackup.Size = new System.Drawing.Size(229, 17);
            this.checkBoxOverWritebackup.TabIndex = 1;
            this.checkBoxOverWritebackup.Text = "Overwrite the backup file if it already exists.";
            this.checkBoxOverWritebackup.UseVisualStyleBackColor = true;
            // 
            // checkBoxBackup
            // 
            this.checkBoxBackup.AutoSize = true;
            this.checkBoxBackup.Location = new System.Drawing.Point(12, 20);
            this.checkBoxBackup.Name = "checkBoxBackup";
            this.checkBoxBackup.Size = new System.Drawing.Size(277, 17);
            this.checkBoxBackup.TabIndex = 0;
            this.checkBoxBackup.Text = "Automatically create a backup when the file is saved.";
            this.checkBoxBackup.UseVisualStyleBackColor = true;
            this.checkBoxBackup.CheckedChanged += new System.EventHandler(this.checkBoxBackup_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(251, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmOptions
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 209);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBoxSigning);
            this.Controls.Add(this.groupBoxBackup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOptions";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.groupBoxSigning.ResumeLayout(false);
            this.groupBoxSigning.PerformLayout();
            this.groupBoxBackup.ResumeLayout(false);
            this.groupBoxBackup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSigning;
        private System.Windows.Forms.CheckBox checkBoxCreateSeperateSignFile;
        private System.Windows.Forms.CheckBox checkBoxSigning;
        private System.Windows.Forms.GroupBox groupBoxBackup;
        private System.Windows.Forms.CheckBox checkBoxOverWritebackup;
        private System.Windows.Forms.CheckBox checkBoxBackup;
        private System.Windows.Forms.Button button1;

    }
}