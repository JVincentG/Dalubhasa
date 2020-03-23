using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dalubhasa03
{
    public partial class p2win : Form
    {
        public p2win()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.URL = "p2win sfx.wav";
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 myform = new Form1();
            myform.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenucs myforms = new MainMenucs();
            myforms.Show();
            this.Hide();
        }
    }
}
