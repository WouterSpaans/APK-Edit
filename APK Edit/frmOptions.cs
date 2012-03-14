using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace APK_Edit
{
    public partial class frmOptions : Form
    {
        public frmOptions()
        {
            InitializeComponent();
        }



        private void frmOptions_Load(object sender, EventArgs e)
        {
            this.checkBoxCreateSeperateSignFile.Checked = AppSettings.CreateSeperateSigningFile;
            this.checkBoxBackup.Checked = AppSettings.EnableBackup;
            this.checkBoxSigning.Checked = AppSettings.EnableSigning;
            this.checkBoxOverWritebackup.Checked = AppSettings.OverWriteBackup;
            this.checkBoxOverWritebackup.Enabled = this.checkBoxBackup.Checked;
            this.checkBoxCreateSeperateSignFile.Enabled = this.checkBoxSigning.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppSettings.CreateSeperateSigningFile = this.checkBoxCreateSeperateSignFile.Checked;
            AppSettings.EnableBackup = this.checkBoxBackup.Checked;
            AppSettings.EnableSigning = this.checkBoxSigning.Checked;
            AppSettings.OverWriteBackup = this.checkBoxOverWritebackup.Checked;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void checkBoxBackup_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBoxOverWritebackup.Enabled = (((CheckBox)sender).CheckState == CheckState.Checked);
        }

        private void checkBoxSigning_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBoxCreateSeperateSignFile.Enabled = (((CheckBox)sender).CheckState == CheckState.Checked);
        }
    }
}
