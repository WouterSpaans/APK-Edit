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
    public partial class frmTranslate : Form
    {
        public frmTranslate()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Add_Hover_16;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Add_Normal_16;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmAddTranslation frm = new frmAddTranslation();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // Add new translation
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Add_Clicked_16;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Add_Hover_16;
        }
    }
}
