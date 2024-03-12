using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Management;
using System.Net.NetworkInformation;
using System.IO;

namespace MyVirus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string sentence = "Selam, Ben MyVirus. Başta Virüs Programıymışım Gibi Gelse de Sana, Ben Aslında Antivirüsüm.";
        private string sentence1 = "Neler Yapabildiğimi Görmek İster misin?";
        private string sentence2 = "Alttaki Butona Benim İçin Tıklarmısın";
        private string sentence3 = "Kabul Et Mükemmeldi, Biraz Korkmuş Gibisin.";
        private string sentence4 = "Merak Etme, Bu Bilgiler Sadece Sistemini Daha İyi Hale Getirmek İçin";
        private string sentence5 = "Hadi Bir Oyun Oynayalım, Biraz Duygularını Yoklayacak Bir Oyun Olacak, Biraz da Okul Aile Birliğinden Gelen Formlar Gibi Olacak";
        private int index = 0;

        private Color[] colors = { Color.Black, Color.White };
        private Random random = new Random();
        private int effectCount = 0;

        private void button1_Click(object sender, EventArgs e)
        {

            string nircmdPath = Application.StartupPath + @"\resources\nircmd.exe";

            Process.Start(nircmdPath, "changesysvolume 1000000");

            string audioPath = Application.StartupPath + @"\resources\Lüks Artvin Earrape (Bass Boosted).wav";

            using (SoundPlayer player = new SoundPlayer(audioPath))
            {
                player.Play();
            }

            listBox1.Visible = true;

            listBox1.Items.Add("I Know Your:");

            hack();
        }

        int timer = 0;
        int speaktimer = 0;
        int hacktimer = 0;

        string programFilesDir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

        // Program Files (x86) dizini (64 bit sistemlerde)
        string programFilesX86Dir = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (speaktimer == 0)
            {
                speak();
            }
            else if (speaktimer == 1)
            {
                speak1();
            }
            else if (speaktimer == 2)
            {
                speak2();
            }
            else if (speaktimer == 3)
            {
                if (hacktimer == 1)
                {
                    speak3();
                }
            }
            else if (speaktimer == 4)
            {
                speak4();
            }

            else if (speaktimer == 5)
            {
                speak5();
            }

            else
            {
                timer1.Stop();
            }
        }

        void speak()
        {
            if (index < sentence.Length)
            {
                label1.Text += sentence[index++];
            }
            else
            {
                index = 0;
                speaktimer = 1;
                Thread.Sleep(1000);
                label1.Text = "";
            }
        }

        void speak1()
        {
            if (index < sentence1.Length)
            {
                label1.Text += sentence1[index++];
            }
            else
            {
                label1.Text = "";
                MessageBox.Show("You Are My ᏉᎥIፈᏖᎥIᎷ");
                speaktimer = 2;
                index = 0;
            }
        }

        void speak2()
        {
            if (index < sentence2.Length)
            {
                label1.Text += sentence2[index++];
            }
            else
            {
                index = 0;
                speaktimer = 3;
                label1.Text = "";
                button1.Visible = true;
                StartEffect();
            }
        }
        void speak3()
        {
            button1.Visible = false;
            listBox1.Visible = false;

            if (this.BackColor == Color.Black) {
                label1.ForeColor = Color.LimeGreen;
            }

            if (index < sentence3.Length)
            {
                label1.Text += sentence3[index++];
            }
            else
            {
                index = 0;
                speaktimer = 4;
                label1.Text = "";
            }


        }

        void speak4()
        {
            if (index < sentence4.Length)
            {
                label1.Text += sentence4[index++];
            }
            else
            {
                index = 0;
                speaktimer = 5;
                label1.Text = "... ";
            }
        }

     void speak5()
        {

            if (index < sentence5.Length)
            {
                label1.Text += sentence5[index++];
            }
            else
            {
                index = 0;
                speaktimer = 6;
                label1.Text = "";

                this.TopMost = false;
                Form2 form2 = new Form2();
                form2.Show();
            }
        }


        void hack()
        {
            hacktimer = 1;

                string bilgisayarAdi = Environment.MachineName;
                listBox1.Items.Add("Computer Name: " + bilgisayarAdi);

                // Oturum İsmi
                string oturumIsmi = Environment.UserName;
                listBox1.Items.Add("Computer's Name: " + oturumIsmi);

                // İşlemci Modeli
                ManagementObjectSearcher cpuSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                foreach (ManagementObject queryObj in cpuSearcher.Get())
                {
                    listBox1.Items.Add("Processor Model: " + queryObj["Name"]);
                }

                // Ekran Kartı Sürücüsü
                ManagementObjectSearcher gpuSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
                foreach (ManagementObject queryObj in gpuSearcher.Get())
                {
                    listBox1.Items.Add("Graphic Card Driver: " + queryObj["DriverVersion"]);
                }

                // IP adresini almak için nslookup komutunu çalıştırma
                Process nslookupProcess = new Process();
                nslookupProcess.StartInfo.FileName = "nslookup";
                nslookupProcess.StartInfo.Arguments = "myip.opendns.com. resolver1.opendns.com";
                nslookupProcess.StartInfo.UseShellExecute = false;
                nslookupProcess.StartInfo.RedirectStandardOutput = true;
                nslookupProcess.Start();
                string nslookupOutput = nslookupProcess.StandardOutput.ReadToEnd();
                nslookupProcess.WaitForExit();
                listBox1.Items.Add("IP Adress: " + nslookupOutput.Trim());

                // Kullanıcı için grup politikalarını almak için gpresult komutunu çalıştırma
                Process gpresultProcess = new Process();
                gpresultProcess.StartInfo.FileName = "gpresult";
                gpresultProcess.StartInfo.Arguments = "/Scope User";
                gpresultProcess.StartInfo.UseShellExecute = false;
                gpresultProcess.StartInfo.RedirectStandardOutput = true;
                gpresultProcess.Start();
                string gpresultOutput = gpresultProcess.StandardOutput.ReadToEnd();
                gpresultProcess.WaitForExit();
                listBox1.Items.Add("And Things: " + gpresultOutput.Trim());

                // Kablosuz ağ profillerini almak için netsh komutunu çalıştırma
                Process netshProcess = new Process();
                netshProcess.StartInfo.FileName = "netsh";
                netshProcess.StartInfo.Arguments = "wlan show profiles key=clear";
                netshProcess.StartInfo.UseShellExecute = false;
                netshProcess.StartInfo.RedirectStandardOutput = true;
                netshProcess.Start();
                string netshOutput = netshProcess.StandardOutput.ReadToEnd();
                netshProcess.WaitForExit();
                listBox1.Items.Add("WIFI Profiles: " + netshOutput.Trim());

                // Ağ yapılandırmasını almak için ipconfig komutunu çalıştırma
                Process ipconfigProcess = new Process();
                ipconfigProcess.StartInfo.FileName = "ipconfig";
                ipconfigProcess.StartInfo.Arguments = "/all";
                ipconfigProcess.StartInfo.UseShellExecute = false;
                ipconfigProcess.StartInfo.RedirectStandardOutput = true;
                ipconfigProcess.Start();
                string ipconfigOutput = ipconfigProcess.StandardOutput.ReadToEnd();
                ipconfigProcess.WaitForExit();
                listBox1.Items.Add("Connection Things: " + ipconfigOutput.Trim());

                IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
                TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();

                // Her bağlantı için bilgileri yazdır
                foreach (TcpConnectionInformation connection in connections)
                {
                    int index = listBox1.TopIndex;
                    index++;
                    listBox1.TopIndex = index;
                    listBox1.Items.Add("Your Ports: " + connection.LocalEndPoint.Address + connection.LocalEndPoint.Port + connection.State);
                }

                ListPrograms(programFilesDir);

               ListPrograms(programFilesX86Dir);

               effectCount++;

               Thread.Sleep(3000);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        void ListPrograms(string directory)
        {

            if (Directory.Exists(directory))
            {
                string[] programs = Directory.GetDirectories(directory);
                foreach (string program in programs)
                {
                    int index = listBox1.TopIndex;
                    index++;
                    listBox1.TopIndex = index;
                    listBox1.Items.Add("Your All Program Names: " + Path.GetFileName(program) + " " + program);
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Kapatmayı engelle
            }
            base.OnFormClosing(e);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }

        private void StartEffect()
    {
        Thread effectThread = new Thread(() =>
        {
            while (effectCount < 1)
            {
                this.Invoke(new Action(() => { this.BackColor = colors[random.Next(colors.Length)]; }));
                Thread.Sleep(500); // 500 milisaniye beklet, isteğe göre değiştirilebilir           
            }
        });

        effectThread.IsBackground = true;
        effectThread.Start();
    }
      
    }
}

