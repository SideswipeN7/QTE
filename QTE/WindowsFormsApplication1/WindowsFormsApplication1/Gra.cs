using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using WindowsFormsApplication1;
using WMPLib;

namespace WindowsFormsApplication1
{
    class Gra
    {
        Form1 aplikacja;
        public System.Media.SoundPlayer muzyka;
        int zycie = 3;
        int punkty = 0;
        bool pauza = false;
        bool pokaz = true;
        bool raz = true;
        //Reset gry
        public void reset()
        {
            this.zycie = 3;
            this.punkty = 0;
            this.raz = true;
            this.pokaz = true;
            aplikacja.pictureBox3.Visible = true;
            aplikacja.pictureBox2.Visible = true;
            aplikacja.pictureBox1.Visible = true;
        }
        //Stworzenie gry
        public Gra(Form1 x)
        {
            this.aplikacja = x;
        }
        //Koniec Gry
        private void KoniecGry()
        {
            //Pokazanie menu koniec gry tylko raz
            if (pokaz==true && zycie<=0)
            {
                //muzyka w tle sie zatrzymuje
                muzyka.Stop();      
                //pojawai się panel z koniec gry
                this.aplikacja.panel5.Visible = true;
                //zmamiana X na ponkty zdonyte
                this.aplikacja.label10.Text = punkty.ToString();
                //raz puszcza muzykę na koniec
                ZagrajRaz();   
            }
        }
        private void ZagrajRaz()
        {
            if (raz)
            {
                //sciezka pliku
                string sciezka = Application.StartupPath + "\\smb_mariodie.wav";
                System.Media.SoundPlayer muzyka2 = new System.Media.SoundPlayer();               
                muzyka2.SoundLocation = sciezka;
                muzyka2.Play();                
                var t =Task.Delay(2000);
                t.Wait();
                raz = false;
            }
            
        }
        
        public void UsunZycie()
        {
            zycie--;
            string sciezka = Application.StartupPath + "\\electruc.mp3";
            WMPLib.WindowsMediaPlayer klik = new WindowsMediaPlayer();
            klik.URL = sciezka;            
            switch (zycie)
            {
                case 2: aplikacja.pictureBox3.Visible = false; klik.controls.play(); break;
                case 1: aplikacja.pictureBox2.Visible = false; klik.controls.play(); break;
                case 0: aplikacja.pictureBox1.Visible = false; klik.controls.play(); KoniecGry(); break;
            }
        }
        public void ZacznijPauze()
        {
            this.aplikacja.button8.Visible = true;
            pauza = true;
        }
        public void ZakonczPauze()
        {
            this.aplikacja.button8.Visible = false;
            pauza = false;
        }
        private void PodswietlLitere(int x)
        {
            switch (x)
            {
                case 0:aplikacja.labelQ.ForeColor = System.Drawing.Color.DarkRed; break;
                case 1: aplikacja.labelW.ForeColor = System.Drawing.Color.DarkRed; break;
                case 2: aplikacja.labelE.ForeColor = System.Drawing.Color.DarkRed; break;
                case 3: aplikacja.labelA.ForeColor = System.Drawing.Color.DarkRed; break;
                case 4: aplikacja.labelS.ForeColor = System.Drawing.Color.DarkRed; break;
                case 5: aplikacja.labelD.ForeColor = System.Drawing.Color.DarkRed; break;
                case 6: aplikacja.labelZ.ForeColor = System.Drawing.Color.DarkRed; break;
                case 7: aplikacja.labelX.ForeColor = System.Drawing.Color.DarkRed; break;
                case 8: aplikacja.labelC.ForeColor = System.Drawing.Color.DarkRed; break;
            }
        }

        private void ZgaslLitere(int x)
        {
            switch (x)
            {
                case 0: aplikacja.labelQ.ForeColor = System.Drawing.Color.DarkGray; break;
                case 1: aplikacja.labelW.ForeColor = System.Drawing.Color.DarkGray; break;
                case 2: aplikacja.labelE.ForeColor = System.Drawing.Color.DarkGray; break;
                case 3: aplikacja.labelA.ForeColor = System.Drawing.Color.DarkGray; break;
                case 4: aplikacja.labelS.ForeColor = System.Drawing.Color.DarkGray; break;
                case 5: aplikacja.labelD.ForeColor = System.Drawing.Color.DarkGray; break;
                case 6: aplikacja.labelZ.ForeColor = System.Drawing.Color.DarkGray; break;
                case 7: aplikacja.labelX.ForeColor = System.Drawing.Color.DarkGray; break;
                case 8: aplikacja.labelC.ForeColor = System.Drawing.Color.DarkGray; break;
            }
        }
        private bool Porownaj(int x)
        {
            switch (x)
            {
                case 0: if(aplikacja.labelQ.ForeColor == System.Drawing.Color.DarkRed) return true; break;
                case 1: if(aplikacja.labelW.ForeColor == System.Drawing.Color.DarkRed) return true; break;
                case 2: if(aplikacja.labelE.ForeColor == System.Drawing.Color.DarkRed) return true; break;
                case 3: if(aplikacja.labelA.ForeColor == System.Drawing.Color.DarkRed) return true; break;
                case 4: if(aplikacja.labelS.ForeColor == System.Drawing.Color.DarkRed) return true; break;
                case 5: if(aplikacja.labelD.ForeColor == System.Drawing.Color.DarkRed) return true; break;
                case 6: if(aplikacja.labelZ.ForeColor == System.Drawing.Color.DarkRed) return true; break;
                case 7: if(aplikacja.labelX.ForeColor == System.Drawing.Color.DarkRed) return true; break;
                case 8: if(aplikacja.labelC.ForeColor == System.Drawing.Color.DarkRed) return true; break;
            }
            return false;
        }
        public void TestKlawisza()
        {
            
            switch (aplikacja.textBox1.Text)
            {
                case "q": if (Porownaj(0)) { punkty++; ZgaslLitere(0); } else { UsunZycie(); }; break;
                case "w": if (Porownaj(1)) { punkty++; ZgaslLitere(1); } else { UsunZycie(); }; break;
                case "e": if (Porownaj(2)) { punkty++; ZgaslLitere(2); } else { UsunZycie(); }; break;
                case "a": if (Porownaj(3)) { punkty++; ZgaslLitere(3); } else { UsunZycie(); }; break;
                case "s": if (Porownaj(4)) { punkty++; ZgaslLitere(4); } else { UsunZycie(); }; break;
                case "d": if (Porownaj(5)) { punkty++; ZgaslLitere(5); } else { UsunZycie(); }; break;
                case "z": if (Porownaj(6)) { punkty++; ZgaslLitere(6); } else { UsunZycie(); }; break;
                case "x": if (Porownaj(7)) { punkty++; ZgaslLitere(7); } else { UsunZycie(); }; break;
                case "c": if (Porownaj(8)) { punkty++; ZgaslLitere(8); } else { UsunZycie(); }; break;               
            }
        }

        public void Graj()
        {
            System.Windows.Forms.Timer zegar = new System.Windows.Forms.Timer();
            zegar.Interval = 2000;
            zegar.Tick += delegate { Wykonaj(); };
            zegar.Start();
            Muzyka();
            aplikacja.pictureBox3.Visible = true;
            aplikacja.pictureBox2.Visible = true;
            aplikacja.pictureBox1.Visible = true;
        }
        private int Losuj()
        {
            System.Random x = new Random(System.DateTime.Now.Millisecond);
            int znak = x.Next(0, 8);
            return znak;
        }

        private void Wykonaj()
        {
            if (zycie > 0)
            {
                if (!pauza)
                {
                    int znak = Losuj();
                    PodswietlLitere(znak);
                    System.Windows.Forms.Timer zegar = new System.Windows.Forms.Timer();
                    zegar.Interval = 2000;
                    zegar.Tick += delegate { ZgaslLitere(znak); };
                    zegar.Start();
                }
            }

        }
        public void NiePokaz()
        {
            pokaz = false;
        }
        private void Muzyka()
        {
            string sciezka = Application.StartupPath + "\\epix_sax_guy_8_bit.wav";
            muzyka = new System.Media.SoundPlayer();
            muzyka.SoundLocation = sciezka;
            muzyka.PlayLooping();

        }

    }

}
