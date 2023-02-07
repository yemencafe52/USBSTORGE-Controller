using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USBSTORGController
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            Preparing();
        }

        private bool Preparing()
        {
            bool res = false;
            ReadState();
            return res;
        }

        private void ReadState()
        {
            USBState res = new USBSTORGController().GetState();
            if (res == USBState.ENABLED)
            {
                toolStripStatusLabel2.Text = "Enabled";
                button1.Enabled = false;
                button2.Enabled = true;
            }
            else if (res == USBState.DISABLED)
            {
                toolStripStatusLabel2.Text = "Disabled";
                button2.Enabled = false;
                button1.Enabled = true; ;
            }
            else
            {
                toolStripStatusLabel2.Text = "Unknow";
            }
            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAboutBox fab = new frmAboutBox();
            fab.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(new USBSTORGController().Enable()))
            {
                MessageBox.Show("OOPS, SOMETHING WENT WRONG :(");
            }

            ReadState();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!(new USBSTORGController().Disable()))
            {
                MessageBox.Show("OOPS, SOMETHING WENT WRONG :(");
            }

            ReadState();
        }
    }
}
