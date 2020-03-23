using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace dalubhasa03
{
    public partial class MainMenucs : Form
    {
        
       
        public MainMenucs()
        {
            InitializeComponent();
            pictureBox1.Controls.Add(pictureBox2);
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.BackColor = Color.Transparent;


            //axWindowsMediaPlayer1.URL = "C:/Users/Vincent/source/repos/dalubhasa03/dalubhasa03/bin/Debug/Menutheme.wav";
            axWindowsMediaPlayer1.URL = "Menutheme.wav";
            axWindowsMediaPlayer1.Ctlcontrols.play();

            

        }

  

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void frogsfx()
        {
            axWindowsMediaPlayer2.URL = "Frog sfx.wav";
            axWindowsMediaPlayer2.Ctlcontrols.play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frogsfx();
            DialogResult exit = MessageBox.Show("Are you sure you want to quit?","Exit",MessageBoxButtons.YesNo);
            if (exit == DialogResult.Yes)
            {
                this.Close();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            frogsfx();
            

            Form1 myform = new Form1();
            myform.Show();
            this.Hide();
        }
    }
}
