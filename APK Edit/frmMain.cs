// --------------------------------------------------------------------------------------------------------------------
// <copyright file="frmMain.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the frmMain type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace APK_Edit
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    /// <summary>
    /// </summary>
    public partial class frmMain : Form
    {
        private ApkFile apkFile;
        private bool closeAfterCompiling;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                this.apkFile = new ApkFile();
                this.apkFile.Decompiling += this.Decompiling;
                this.apkFile.Decompiled += this.Decompiled;
                this.apkFile.FrameworkMissing += this.FrameworkMissing;
                this.apkFile.Compiling += this.Compiling;
                this.apkFile.Compiled += this.Compiled;
                this.apkFile.Decompile();

                textBoxName.Text = this.apkFile.ApplicationName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void Decompiling()
        {
            this.DisableUI();
            labelStatus.Text = "Loading.";
            pictureBoxStatus.Image = Properties.Resources.Loading_64;
        }

        private void Decompiled()
        {
            labelStatus.Text = string.Empty;
            pictureBoxStatus.Image = null;
            pictureBoxHDPI.Image = this.apkFile.GetIcon();
            pictureBoxHDPI.Cursor = Cursors.Hand;
            this.EnableUI();
        }

        private void FrameworkMissing()
        {
            labelStatus.Text = "Framework file missing.";
            pictureBoxStatus.Image = Properties.Resources.FileWarning_128;
            if (openFileDialogFramework.ShowDialog() == DialogResult.OK)
            {
                apkFile.FrameworkInstalling += this.FrameworkInstalling;
                apkFile.FrameworkInstalled += this.FrameworkInstalled;
                apkFile.InstallFramework(openFileDialogFramework.FileName);
            }
            else
            {
                this.Close();
            }
        }

        void FrameworkInstalling()
        {
            labelStatus.Text = "Installing framework.";
            pictureBoxStatus.Image = Properties.Resources.Loading_64;
        }

        void FrameworkInstalled()
        {
            apkFile.Decompile();
        }

        private void Compiling()
        {
            this.DisableUI();
            labelStatus.Text = "Saving changes.";
            pictureBoxStatus.Image = Properties.Resources.Loading_64;
        }

        private void Compiled()
        {
            if (this.closeAfterCompiling)
            {
                this.Close();
            }
            else
            {
                labelStatus.Text = string.Empty;
                pictureBoxStatus.Image = null;
                pictureBoxHDPI.Image = this.apkFile.GetIcon();
                pictureBoxHDPI.Cursor = Cursors.Hand;
                this.EnableUI();
            }
        }

        private void EnableUI()
        {
            btnOK.Enabled = true;
            btnCancel.Enabled = true;
            btnApply.Enabled = true;
            textBoxName.Enabled = true;
            pictureBoxHDPI.Enabled = true;
            labelStatus.Enabled = true;
        }

        private void DisableUI()
        {
            btnOK.Enabled = false;
            btnCancel.Enabled = false;
            btnApply.Enabled = false;
            textBoxName.Enabled = false;
            pictureBoxHDPI.Enabled = false;
            labelStatus.Enabled = false;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.apkFile.ApplicationName = this.textBoxName.Text;
            this.apkFile.Compile();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.closeAfterCompiling = true;
            this.apkFile.ApplicationName = this.textBoxName.Text;
            this.apkFile.Compile();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxHDPI_Click(object sender, EventArgs e)
        {
            if (openFileDialogIcon.ShowDialog() == DialogResult.OK)
            {
                pictureBoxHDPI.Image = apkFile.SetIcon(openFileDialogIcon.FileName);
            }
        }

        private void openFileDialogIcon_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
