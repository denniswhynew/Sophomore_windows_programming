using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _004B
{
    public partial class Form1 : Form
    {
        double X, Y;
        int V, S;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                V = Convert.ToInt32(textBox1.Text);
            }
            catch
            {
                textBox1.Text = "錯誤";
            }
            try
            {
                S = Convert.ToInt32(textBox2.Text);
            }
            catch
            {
                textBox2.Text = "錯誤";
            }
            X = V * (System.Math.Cos(3.14159 * S / 180));
            Y = V * (System.Math.Sin(3.14159 * S / 180));
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Y -= 0.98;
            pictureBox2.Left += (int)X;
            pictureBox2.Top -= (int)Y;
            if(pictureBox2.Top>=this.Height-100)
            {
                pictureBox2.Top = this.Height - 100;
                timer1.Enabled = false;
            }
        }
    }
}
