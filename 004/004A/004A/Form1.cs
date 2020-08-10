using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _004A
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            pictureBox1.Top = -12000;
            pictureBox1.Left = 0;
            timer1.Enabled = false;
            pictureBox1.Controls.Add(this.pictureBox2);
            pictureBox1.Controls.Add(this.pictureBox3);
            pictureBox2.Top = 12650;
            pictureBox3.Top = 9000;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Top += 16;
            pictureBox2.Top -= 16;
            if (pictureBox1.Top >= 0) { timer1.Enabled = false; }
            if (pictureBox2.Bounds.IntersectsWith(pictureBox3.Bounds))
            {
                pictureBox3.Image = _004A.Properties.Resources.fire_0018;
                pictureBox2.Image = null;
                timer1.Enabled = false;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S) { timer1.Enabled = true; }
            if (e.KeyCode == Keys.Left) { pictureBox2.Left -= 8; }
            if (e.KeyCode == Keys.Right) { pictureBox2.Left += 8; }
        }

    }
}
