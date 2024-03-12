using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int zaman;
        public static double para = 5000;
        double ilkpara;
      

    public Form1()
    {
        InitializeComponent();
    }


        private void timer1_Tick(object sender, EventArgs e)
        {
            zaman++;
            if (zaman == 7) {
                zaman = 1;
            }
            if (zaman == 5)
            {
                pictureBox1.Image = Image.FromFile(@"..\..\Resources\resim1.jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            if (zaman == 3)
            {
                pictureBox1.Image = Image.FromFile(@"..\..\Resources\resim2.jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            if (zaman == 1)
            {
                pictureBox1.Image = Image.FromFile(@"..\..\Resources\resim3.png");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ilkpara = para;

            timer1.Start();

            label2.Text = para.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "TR") {
                para = ilkpara;
            }
            if (comboBox1.SelectedItem == "USD") { 
                para = ilkpara / 29.94;
            }
            if (comboBox1.SelectedItem == "EUR")
            {
                para = ilkpara / 32.76;

            }
            label2.Text = para.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "TR";
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            MessageBox.Show("Referans Kodunuz: " + random.Next(10000,99999) + " Tek Kullanımlıktır.");
        }

    }
}
