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
    public partial class Form2 : Form
    {

    public Form2()
    {
        InitializeComponent();
    }



        int maxtime = 20;
        int zaman;

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        void yatirma()
        {
            timer1.Start();
        }
        

        void bagisla(){

        }

        private void button2_Click(object sender, EventArgs e)
        {
            yatirma();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double b = Convert.ToDouble(textBox2.Text);

            if (b >= 1)
            {
                Form1.para = Form1.para - b;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) {
                maxtime = 70;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                maxtime = 40;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                maxtime = maxtime + 20;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            zaman++;
            label4.Text = "Elapsed Time: " + zaman + " Second";
                //İşlemler

                if (zaman == 1)
                {
                    listBox1.Items.Add("İşlem Başlatıldı");
                    listBox1.Items.Add("Checking Proxy Tunnel Data With LocalXPose...");
                    progressBar1.Value = 10;
                }
                else if (zaman == 10)
                {
                    listBox1.Items.Add("Good News, You're Found Akbank Main Address");
                    listBox1.Items.Add("Trying Money Hashing");
                    progressBar1.Value = 20;
                }
                else if (zaman == 30)
                {
                    listBox1.Items.Add("Success, Trying Receives the Desired Currency Unit...");
                    progressBar1.Value = 25;
                }

                if (zaman >= 30 && zaman < maxtime) {
                    progressBar1.Value = zaman;
                }

                else if (zaman == maxtime)
                {
                    listBox1.Items.Add("Success");

                    if (maxtime == 40 || maxtime == 60 || maxtime == 20)
                    {
                        Random random = new Random();
                        int deneme = random.Next(200, 999);
                        for (int i = 0; i <= deneme; i++)
                        {
                            listBox1.Items.Add("Fatal Exception İd:" + deneme);
                        }
                        listBox1.Items.Add("A Fatal Error Occurred. See Stage Compiler for Details");
                        MessageBox.Show("A Fatal Error Occurred. See Stage Compiler for Details");
                        progressBar1.Value = 0;
                    }
                    else if (maxtime == 70 || maxtime == 90)
                    {
                        double a = Convert.ToDouble(textBox1.Text);
                        if (a >= 1)
                        {
                            Form1.para = Form1.para + a;
                        }
                        progressBar1.Value = 100;
                    }
                    zaman = 0;
                    timer1.Stop();
                }
        }
    }
}
