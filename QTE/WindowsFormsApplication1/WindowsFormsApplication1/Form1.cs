using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        bool pauza = false;
        Gra MojaGra;
        public Form1()
        {
            InitializeComponent();
            UstawEkran();
            MojaGra = new Gra(this);            
        }

        public void UstawEkran()
        {
            Screen ekran = Screen.PrimaryScreen;
            int wys = ekran.WorkingArea.Height;
            int szer = (ekran.WorkingArea.Width/2)-89;
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            Wyrownaj(wys, szer);
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            btP.Visible = false;
            button8.Visible = false;
            panel4.BackColor = System.Drawing.Color.Black;

        }
        public void Wyrownaj(int x,int y)
        {
            int p1 = 90;
            int p2 = (int)(x * 0.25);
            int p3 = (int)(x * 0.5);
            int p4 = (int)(x * 0.75);
            label1.Location = new Point(y-186, p1);
            button1.Location = new Point(y, p2);
            button2.Location = new Point(y, p3);
            button3.Location = new Point(y, p4);
            panel1.Location = new Point((y / 2) + 250, 80);
            panel2.Location = new Point((y / 2) + 104, 80);
            panel3.Location = new Point(10, 10);
            panel4.Location = new Point(y/2, 250);
            panel5.Location = new Point(y , 250);
            btP.Location = new Point((y * 2), 10);
            button8.Location = new Point((y * 2), 120);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Klikniecie();           
            MojaGra.muzyka.Stop();
            MojaGra.NiePokaz();
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            label1.Visible = true;
            btP.Visible = false;
            button1.Visible = true;
            button3.Visible = true;
            button2.Visible = true;
            button8.Visible = false;
            this.BackColor = System.Drawing.Color.Black;
            panel4.BackColor = System.Drawing.Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Klikniecie();
            panel1.Visible = true;
            panel2.Visible = false;
            label1.Visible = false;
            btP.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            button1.Visible = false;
            button3.Visible = false;
            button2.Visible = false;
            button8.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Klikniecie();
            this.Close();           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Klikniecie();
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            label1.Visible = true;
            btP.Visible = false;
            button1.Visible = true;
            button3.Visible = true;
            button2.Visible = true;
            button8.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Klikniecie();
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            label1.Visible = false;
            btP.Visible = false;
            button1.Visible = false;
            button3.Visible = false;
            button2.Visible = false;
            button8.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Klikniecie();
            panel3.Visible = true;
            panel4.Visible = true;
            panel5.Visible = false;
            btP.Visible = true;
            panel2.Visible = false;
            label1.Visible = false;           
            button1.Visible = false;
            button3.Visible = false;
            button2.Visible = false;
            button8.Visible = false;
            MojaGra.reset();
            MojaGra.Graj();

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Klikniecie();
            if (!pauza)
            {
                //TRWA PAUZA               
                MojaGra.ZacznijPauze();
                MojaGra.muzyka.Stop();
                pauza = true;
                this.BackColor = System.Drawing.Color.DarkBlue;
                panel4.BackColor = System.Drawing.Color.DarkBlue;
                textBox1.BackColor = System.Drawing.Color.DarkBlue;
            }
            else
            {
                //KONIEC PAUZY                
                MojaGra.ZakonczPauze();
                MojaGra.muzyka.PlayLooping();
                pauza = false;
                this.BackColor = System.Drawing.Color.Black;
                panel4.BackColor = System.Drawing.Color.Black;
                textBox1.BackColor = System.Drawing.Color.Black;
                textBox1.Focus();
            }          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

           
            if (textBox1.Text.Length > 1)
            {
                textBox1.Text.Substring(1);
                textBox1.Focus();
                textBox1.SelectionStart = textBox1.Text.Length;
                MojaGra.TestKlawisza();
                textBox1.Text = "";

            }
            else
            {
                textBox1.Focus();
                textBox1.SelectionStart = textBox1.Text.Length;
                MojaGra.TestKlawisza();
                textBox1.Text = "";
            }
        }
        private void Klikniecie()
        {
            string sciezka = Application.StartupPath + "\\Flash01.mp3";
            WMPLib.WindowsMediaPlayer klik = new WindowsMediaPlayer();
            klik.URL = sciezka;
            klik.controls.play();
        }

        private void button4_Click1(object sender, EventArgs e)
        {
            Klikniecie();            
            MojaGra.NiePokaz();
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            label1.Visible = true;
            btP.Visible = false;
            button1.Visible = true;
            button3.Visible = true;
            button2.Visible = true;
            button8.Visible = false;
            this.BackColor = System.Drawing.Color.Black;
            panel4.BackColor = System.Drawing.Color.Black;
        }
    }
}
