using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace dalubhasa03
{
    public partial class Form1 : Form
    {

        double cdown = 15;
        Timer MyTimer = new Timer();
        int number;



        private string cors;

        Bitmap img1 = Properties.Resources._20200313_182707;
        Bitmap img2 = Properties.Resources.blastb;
        Bitmap img3 = Properties.Resources._20200313_1810111;
        Bitmap img4 = Properties.Resources.blasta;
        public Form1()
        {
            InitializeComponent();


            ShowSelect();

            pictureBox1.Image = img1; //assign image1 to picturebox here
            pictureBox2.Image = img3;

            MyTimer.Interval = (1000); // 15 sec
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
            MyTimer.Start();


        




            axWindowsMediaPlayer1.URL = "Gameplay sfx.wav";
            axWindowsMediaPlayer1.Ctlcontrols.play();

          
        }

        private void p1correctsfx()
        {
            axWindowsMediaPlayer2.URL = "p1correct sfx.wav";
            axWindowsMediaPlayer2.Ctlcontrols.play();
        }

        private void p2correctsfx()
        {
            axWindowsMediaPlayer3.URL = "p2correct sfx.wav";
            axWindowsMediaPlayer3.Ctlcontrols.play();
        }

        private void p1wrongsfx()
        {
            axWindowsMediaPlayer2.URL = "p1incorrect sfx.wav";
            axWindowsMediaPlayer2.Ctlcontrols.play();
        }

        private void p2wrongsfx()
        {
            axWindowsMediaPlayer3.URL = "p2incorrect sfx.wav";
            axWindowsMediaPlayer3.Ctlcontrols.play();
        }

        public void MyTimer_Tick(object sender, EventArgs e)
        {

            cdown--;
            if (cdown < 0)
            {
                cdown = 0.1;
                label11.Text = "0";
            }
            label11.Text = cdown.ToString();
            if (cdown == 0)
            {
                MyTimer.Stop();
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                MessageBox.Show("Into the next question.", "Time Runs Out!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                axWindowsMediaPlayer1.Ctlcontrols.play();
                ShowSelect();
                bothenable();
                MyTimer.Start();
                Reset();
            }

        }

     
   
        public void giftimer2_tick(object sender, EventArgs e)
        {
           
                
               
                
                
            
        }
        public void leftp2()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
           
        }
    
        public void ShowSelect()
        {
            string connection = "datasource=127.0.0.1;port=3306;username=root;password=;database=questiondb";
            MySqlConnection dbcon = new MySqlConnection(connection);
            dbcon.Open();
            var rnd = new Random();
            int rng = rnd.Next(1, 5);
            // You sql command
            MySqlCommand selectData;

            // Create the sql command
            selectData = dbcon.CreateCommand();

            // Declare the sript of sql command
            selectData.CommandText = "SELECT `q_id`, `question`, `choice_a`, `choice_b`, `choice_c`, `correct_ans` FROM `questiontbl` WHERE q_id=" + rng;

            // Declare a reader, through which we will read the data.
            MySqlDataReader rdr = selectData.ExecuteReader();

            // Read the data
            while (rdr.Read())
            {

                label10.Text = (string)rdr["question"];
                label1.Text = (string)rdr["choice_a"];
                label2.Text = (string)rdr["choice_b"];
                label3.Text = (string)rdr["choice_c"];
                cors = (string)rdr["correct_ans"];
            }

            rdr.Close();
           

     

            winner();

          
        }


        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
            {
                button1.PerformClick();
            }
            if (e.KeyCode == Keys.W)
            {
                button2.PerformClick();
            }
            if (e.KeyCode == Keys.E)
            {
                button3.PerformClick();
            }
            if (e.KeyCode == Keys.J)
            {
                button4.PerformClick();
            }
            if (e.KeyCode == Keys.K)
            {
                button5.PerformClick();
            }
            if (e.KeyCode == Keys.L)
            {
                button6.PerformClick();
            }
        }

        private void Reset()
        {
            cdown = 16;
        }

        private void bothenable()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
        }

        private void bothlose()
        {
            if (button1.Visible == false && button4.Visible == false)
            {
                ShowSelect();
                Reset();
                bothenable();
            }

        }
        private void btndisablep1()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }
        private void btnvisdisablep1()
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
        }

        private void btndisablep2()
        {
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
        }
        private void btnvisdisablep2()
        {
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
        }
        private void winner()
        {
            if (pictureBox1.Left > 1100)
            {
                p1win myform = new p1win();
                myform.Show();
                MyTimer.Stop();
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                this.Hide();
                
            }

            if (pictureBox2.Left > 1100)
            {
                p2win myform = new p2win();
                myform.Show();
                MyTimer.Stop();
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                this.Hide();
                
            }
        }

        private void backstepp1()
        {
            if (pictureBox1.Image == img1)
            {
                pictureBox1.Image = img2;
                btndisablep2();

                timer1.Start();
                
                

            }
            

        }
        

        private void backstepp2()
        {
            if ( pictureBox2.Image == img3)
            {
                pictureBox2.Image = img4;
                btndisablep1();

                string text = label11.Text;

                if (int.TryParse(text, out number))
                    cdown = number;
                label11.Text = cdown.ToString();
                timer2.Start();
            }
            


        }

        public void button1_Click(object sender, EventArgs e)
        {

            if (label1.Text == cors)
            {
                pictureBox1.Left = pictureBox1.Left + 105;
                ShowSelect();
                bothenable();
                Reset();
                p1correctsfx();
            }
            else if (label1.Text != cors)
            {
                btnvisdisablep1();
                if (pictureBox1.Left > 105)
                {
                    backstepp1();
                }
                bothlose();
                p1wrongsfx();
                
            }
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label2.Text == cors)
            {
                pictureBox1.Left = pictureBox1.Left + 105;
                ShowSelect();
                bothenable();
                Reset();
                p1correctsfx();
            }
            else if (label2.Text != cors)
            {
                btnvisdisablep1();
                if (pictureBox1.Left > 105)
                {
                    backstepp1();
                }
                bothlose();
                p1wrongsfx();
                
            }
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label3.Text == cors)
            { 
                pictureBox1.Left = pictureBox1.Left + 105;
                ShowSelect();
                bothenable();
                Reset();
                p1correctsfx();
            } 
            else if (label3.Text != cors)
            {
                btnvisdisablep1();
                if (pictureBox1.Left > 105)
                {
                    backstepp1();
                }
                bothlose();
                p1wrongsfx();
                
            }
            
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (label1.Text == cors)
            { 
                pictureBox2.Left = pictureBox2.Left + 105;
                ShowSelect();
                bothenable();
                Reset();
                p2correctsfx();
            }
            else if (label1.Text != cors)
            {
                btnvisdisablep2();
                if (pictureBox2.Left > 105)
                {
                    backstepp2();
                    leftp2();
                    
                }
                bothlose();
                p2wrongsfx();
               
            }
           
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (label2.Text == cors)
            {
                pictureBox2.Left = pictureBox2.Left + 105;
                ShowSelect();
                bothenable();
                Reset();
                p2correctsfx();
            }
            else if (label2.Text != cors)
            {
                btnvisdisablep2();
                if (pictureBox2.Left > 105)
                {
                    backstepp2();
                    
                }
                bothlose();
                p2wrongsfx();
                
            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (label3.Text == cors)
            { 
                pictureBox2.Left = pictureBox2.Left + 105;
                ShowSelect();
                bothenable();
                Reset();
                p2correctsfx();
            }
            else if (label3.Text != cors)
            {
                btnvisdisablep2();
                if (pictureBox2.Left > 105)
                {
                    backstepp2();
                   
                   

                }
                bothlose();
                p2wrongsfx();
                

            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = img1;
            
            if (pictureBox1.Image == img1)
            {
                pictureBox1.Left = pictureBox1.Left - 105;
            }
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            timer1.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            pictureBox2.Image = img3;

            
            
            if (pictureBox2.Image == img3)
           {
                pictureBox2.Left = pictureBox2.Left - 105;
                leftp2();
                timer2.Stop();
                label11.Text = number.ToString();
                cdown = number;
            }
            
        }
    }
}
