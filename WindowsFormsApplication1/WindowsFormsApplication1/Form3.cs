using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string bilgisayarAdi = Dns.GetHostName();
            string ipAdresi = Dns.GetHostByName(bilgisayarAdi).AddressList[0].ToString();
            label5.Text = ipAdresi;
        }

        int zaman = 0;

        public void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = client.GetStream();

            byte[] data = new byte[1024];
            int bytesRead = stream.Read(data, 0, data.Length);
            string message = Encoding.ASCII.GetString(data, 0, bytesRead);

            string[] parts = message.Split(' ');
            if (parts.Length >= 2)
            {
                string command = parts[0];
                decimal amount;
                if (decimal.TryParse(parts[1], out amount))
                {
                    if (command == "YATIR")
                    {
                        MessageBox.Show(amount + "Kadar Para Atıldı, İyi Kullanımlar Dileriz");

                        Form1.para = Form1.para + Convert.ToDouble(amount);
                    }
                }
                else
                {
                    MessageBox.Show(message + " Adlı Bilgisayar İstek Attı");
                }
            }
            else
            {
                MessageBox.Show(message + " Adlı Bilgisayar İstek Attı");
            }

            if (listBox2.InvokeRequired)
            {
                listBox2.Invoke((MethodInvoker)delegate { listBox2.Items.Add(message); });
            }
            else
            {
                listBox2.Items.Add(message);
            }

            stream.Close();
            client.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //İstek Gönderme
            try
            {
                TcpClient client = new TcpClient(textBox1.Text, 9999); // Sunucu IP'si ve port numarası
                NetworkStream stream = client.GetStream();

                string bilgisayarAdi = Dns.GetHostName();
                string ipAdresi = Dns.GetHostByName(bilgisayarAdi).AddressList[0].ToString();

                string messageToSend = ipAdresi + " " + bilgisayarAdi;
                byte[] data = Encoding.ASCII.GetBytes(messageToSend);

                stream.Write(data, 0, data.Length);
                listBox1.Items.Add("İstek Gönderildi.");

                button3.Invoke((MethodInvoker)delegate
                {
                    button3.Enabled = true;
                });

                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir Hata Oluştu Hata: " + ex.Message);
            }

        }

        private void ParaYatir(decimal miktar)
        {
            try
            {
                TcpClient client = new TcpClient(textBox1.Text, 9999); // Sunucu IP'si ve port numarası
                NetworkStream stream = client.GetStream();

                string messageToSend = "YATIR " + miktar.ToString();
                byte[] data = Encoding.ASCII.GetBytes(messageToSend);

                stream.Write(data, 0, data.Length);
                listBox1.Invoke((MethodInvoker)delegate
                {
                    listBox1.Items.Add("Para Yatırma İsteği Gönderildi.");
                });

                Form1.para = Form1.para - Convert.ToDouble(textBox2.Text);

                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir Hata Oluştu Hata: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread serverThread = new Thread(new ThreadStart(StartServer));
            serverThread.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            zaman++;
        }

        private void StartServer()
        {
            TcpListener server = new TcpListener(IPAddress.Any, 9999);
            server.Start();

            listBox1.Invoke((MethodInvoker)delegate
            {
                listBox1.Items.Add("LAN Açık Adresi Oluşturuldu");
                listBox1.Items.Add("İstek Bekleniyor...");
            });

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                listBox1.Invoke((MethodInvoker)delegate
                {
                    listBox1.Items.Add("Bir Kişi İstekte Bulundu");
                });

                Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
                t.Start(client);

                if (zaman == 20)
                {
                    zaman = 0;
                    break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            decimal yatirilanMiktar;
            if (!Decimal.TryParse(textBox2.Text, out yatirilanMiktar))
            {
                MessageBox.Show("Geçersiz miktar!");
                return;
            }

            ParaYatir(yatirilanMiktar);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
