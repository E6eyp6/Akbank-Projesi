using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyVirus
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        bool radiolar = false;
        int progress = 0;
        private string yorumlar = "";
        private int index = 0;
        string[] secim = new string[99999];

        private void radioButton2_CheckedChanged(object sender, EventArgs e) //Başka Biri
        {
            if (radioButton2.Checked == true)
            {
                textBox1.Enabled = true;
                radiolar = false;
                b();
            }
            else {
                textBox1.Enabled = false;
                radiolar = true;
                b();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) //MyVirus
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Kapatmayı engelle
            }
            base.OnFormClosing(e);
        }

        void b() {
            radioButton3.Enabled = radiolar;
            radioButton4.Enabled = radiolar;
            radioButton5.Enabled = radiolar;
            radioButton6.Enabled = radiolar;
            radioButton7.Enabled = radiolar;
            radioButton8.Enabled = radiolar;
            radioButton9.Enabled = radiolar;
            radioButton10.Enabled = radiolar;
            radioButton11.Enabled = radiolar;
            radioButton12.Enabled = radiolar;
            radioButton13.Enabled = radiolar;
            radioButton14.Enabled = radiolar;
            radioButton15.Enabled = radiolar;
            radioButton16.Enabled = radiolar;
            radioButton17.Enabled = radiolar;
            radioButton18.Enabled = radiolar;
            radioButton19.Enabled = radiolar;
            radioButton20.Enabled = radiolar;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Yazdır
            if (index < yorumlar.Length)
            {
                label7.Text += yorumlar[index++];
            }
            else
            {
                index = 0;
                timer1.Stop();
                this.Close();
            }
            ///////
        }

        private void button1_Click(object sender, EventArgs e)
        {
            control();
            yorum();
            timer1.Start();
        }

        void yorum() {
            if (secim[1] == "Elma" && secim[4] == "Matematik") {
                yorumlar += "Genel Bir Seçim yapıyorsun Fakat Düşüncelerin Seni Keskin Gösteriyor Olabilir. ";
            }

            if (secim[2] == "Kızıl" && secim[3] == "Beyaz")
            {
                yorumlar += "Sanki Kızlara Karşı İlgi Duyuyormuşsun Gibi Yada Farklılıkları Seviyormuşsun Gibi Gözüküyor. ";
            }

            if (secim[6] == "Üniversite" && secim[4] == "Matematik" && secim[5] == "Mühendis")
            {
                yorumlar += "Üniversite Seçimin Gayet Mantıklı Çünkü Bilim Adamı Olmayacaksan 2-4 Yılını Vermene Gerek Yok Bence, Matematik te Mantıklı, Sonucta En Yüksek Puan Oradan Gelecek. ";
            }
            else {
                yorumlar += "Gayet İdealsin Ve Seni Önemli Yapan, En Azından Herkesin Seçtiği Seçenekleri Seçmedin, Yada Hep Ucundan Sıyırdın";
            }
        }

        void control() {
            if (radioButton3.Checked == true) {
                secim[1] = "Elma";
            }
            if (radioButton4.Checked == true)
            {
                secim[1] = "Muz";
            }
            if (radioButton5.Checked == true)
            {
                secim[1] = "Karpuz";
            }


            if (radioButton6.Checked == true)
            {
                secim[2] = "Sarışın";
            }
            if (radioButton7.Checked == true)
            {
                secim[2] = "Kızıl";
            }
            if (radioButton8.Checked == true)
            {
                secim[2] = "Kahverengi";
            }

            if (radioButton9.Checked == true)
            {
                secim[3] = "Siyahi";
            }
            if (radioButton10.Checked == true)
            {
                secim[3] = "Esmer";
            }
            if (radioButton11.Checked == true)
            {
                secim[3] = "Beyaz";
            }

            if (radioButton12.Checked == true)
            {
                secim[4] = "Matematik";
            }
            if (radioButton13.Checked == true)
            {
                secim[4] = "Türkçe";
            }
            if (radioButton14.Checked == true)
            {
                secim[4] = "İngilizce";
            }

            if (radioButton15.Checked == true)
            {
                secim[5] = "Mühendis";
            }
            if (radioButton16.Checked == true)
            {
                secim[5] = "Sağlık";
            }
            if (radioButton17.Checked == true)
            {
                secim[5] = "Başka";
            }

            if (radioButton18.Checked == true)
            {
                secim[6] = "Lise";
            }
            if (radioButton19.Checked == true)
            {
                secim[6] = "Üniversite";
            }
            if (radioButton20.Checked == true)
            {
                secim[6] = "Yüksek Lisans";
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.AutoSize = true;
        }
    }
}
