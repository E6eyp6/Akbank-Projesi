using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        int a;
        int threat;
        int secim;

        private void button1_Click(object sender, EventArgs e)
        {
            a = 0;
            threat = 0;
            secim = 0;
            Random random = new Random();
            threat = threat + random.Next(1, 11);
            while (true)
            {
                a++;
                threat = threat + 15;
                for (int i = 1; i <= 10; i++)
                {
                    listBox1.SelectedItem = i;
                    Thread.Sleep(threat);
                }
                if (a == 10)
                {
                    for (int i = 1; i <= random.Next(1,11); i++)
                    {
                        listBox1.SelectedItem = i;
                        Thread.Sleep(threat);
                    }
                    break;
                }
            }
            label2.Text = listBox1.SelectedItem.ToString();
            Form1.para = Form1.para + 10 + Convert.ToInt32(listBox1.SelectedItem) * Convert.ToInt32(listBox1.SelectedItem);
            label4.Text = Convert.ToString(10 + Convert.ToInt32(listBox1.SelectedItem) * Convert.ToInt32(listBox1.SelectedItem));
            Thread.Sleep(10000);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                listBox1.Items.Add(i);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
