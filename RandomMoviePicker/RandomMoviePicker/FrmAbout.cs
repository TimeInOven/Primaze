using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompactMovieManager
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }
        public FrmAbout(Version p_Version)
        {
            InitializeComponent();
            this.lblVersion.Text = "v" + p_Version.ToString();
          
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void FrmAbout_Shown(object sender, EventArgs e)
        {
            
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
        }
    }
}