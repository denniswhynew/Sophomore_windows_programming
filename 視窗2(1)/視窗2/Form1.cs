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

namespace 視窗2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        UdpClient U;
        Thread Th;
        string password = "0000", cheak;

        private void button1_Click(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            Th = new Thread(Listen);
            Th.Start();
            button1.Enabled = false;
        }

        private void Listen()
        {
            int port = int.Parse(textBox1.Text);
            U = new UdpClient(port);
            IPEndPoint EP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            while(true)
            {
                byte[] B = U.Receive(ref EP);
                string R = Encoding.Default.GetString(B);
                if(password == "0000")
                {
                    password = R[4].ToString();
                }
                if(R[4].ToString() == password)
                {
                    if (R.Substring(1, 1) == "A")
                    {
                        listBox2.Items.Add(textBox5.Text + ">" + R);
                        button2.Enabled = false;
                        if (R == "4A0B") { MessageBox.Show("you win!!"); }
                    }
                    else
                    {
                        string K = chk(R);
                        Send(K, password);
                        listBox1.Items.Add(R + ">" + K);
                        button2.Enabled = true;

                        if (K == "4A0B") { MessageBox.Show("你輸了"); }
                    }
                }
            }
        }

        private string MyIP()
        {
            string hn = Dns.GetHostName();
            IPAddress[] ip = Dns.GetHostEntry(hn).AddressList;
            foreach(IPAddress it in ip)
            {
                if(it.AddressFamily == AddressFamily.InterNetwork)
                {
                    return it.ToString();
                }
            }
            return "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text += " " + MyIP();
        }

        private void Send(string A,string M)
        {
            int Port = int.Parse(textBox3.Text);
            UdpClient S = new UdpClient(textBox2.Text, Port);
            string N = A + M;
            byte[] X = Encoding.Default.GetBytes(N);
            //byte[] N = Encoding.Default.GetBytes(M);
            S.Send(X, X.Length);
            //S.Send(N, N.Length);
            S.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Th.Abort();
                U.Close();
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rv;
            bool isnum = int.TryParse(textBox5.Text, out rv);
            if(textBox5.Text.Length != 5 || isnum == true)
            {
                MessageBox.Show("must need four int and one char");
                return;
            }
            char[] nn = textBox5.Text.ToCharArray();
            cheak = nn[4].ToString();
            char[] C = new char[4];
            for (int i = 0; i <= 3; i++)
            {
                C[i] = nn[i];
            }
            bool rpt = false;

            for (int i = 0; i <= 3; i++) 
            {
                for (int j = 0; j <= 3; j++) 
                {
                    if(C[i] == C[j] && i != j)
                    {
                        rpt = true;
                    }
                }
            }
            if(rpt)
            {
                MessageBox.Show("the number can not repeat!");
                return;
            }
            Send(textBox5.Text,cheak);
        }
        private string chk(string G)
        {
            int A = 0, B = 0;
            char[] C = textBox4.Text.ToCharArray();
            char[] D = G.ToCharArray();

            for(int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    if (C[i] == D[j])
                    {
                        if (i == j)
                            A += 1;
                        else
                            B += 1;
                    }
                }
            }
            return A.ToString() + "A" + B.ToString() + "B";
        }
    }
}
