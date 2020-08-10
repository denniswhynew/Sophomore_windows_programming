using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _008
{
    public partial class Form1 : Form
    {
        PictureBox[] pic = new PictureBox[30];
        PictureBox[] fire = new PictureBox[20];
        int k;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            k = 0;
            DoubleBuffered = true;
            timer1.Enabled = true;
            pp.Controls.Add(this.bee);
            for(int i = 0; i < 30; i++)
            {
                PictureBox ss = new PictureBox();
                ss.Image = _008.Properties.Resources.UFO;
                ss.SizeMode = PictureBoxSizeMode.StretchImage;
                ss.Size = new System.Drawing.Size(90, 70);
                ss.BackColor = System.Drawing.Color.Transparent;
                ss.Location = new Point(i % 10 * 90, (i / 10) * 90);
                ss.BringToFront();
                pic[i] = ss;
                pp.Controls.Add(pic[i]);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && bee.Left <= 770) { bee.Left += 20; }
            if (e.KeyCode == Keys.Left && bee.Left > 7) { bee.Left -= 20; }
            if (e.KeyCode == Keys.Space) 
            {
                if(k < 30)
                {
                    PictureBox aa = new PictureBox();
                    aa.Image = _008.Properties.Resources.bullet;
                    aa.Size = new System.Drawing.Size(21, 21);
                    aa.SizeMode = PictureBoxSizeMode.StretchImage;
                    aa.BackColor = System.Drawing.Color.Transparent;
                    aa.Left = bee.Left + 60;
                    aa.Top = bee.Top;
                    aa.BringToFront();
                    fire[k] = aa;
                    pp.Controls.Add(fire[k]);
                    k += 1;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (k > 0)
            {
                for (int i = 0; i < k; i++)
                {
                    fire[i].Top -= 30;
                    for (int j = 0; j < 30; j++)
                    {
                        if (pic[j].Bounds.IntersectsWith(fire[i].Bounds))
                        {
                            pp.Controls.Remove(fire[i]);
                            fire[i].Dispose();
                            fire[i] = fire[k - 1];
                            fire[k - 1].Dispose();
                            pp.Controls.Remove(pic[j]);
                            pic[j].Dispose();
                            pic[j].Location = new Point(-60, -60);
                            k--;
                        }
                    }
                    if (fire[i].Top <= bee.Top - 800)
                    {
                        pp.Controls.Remove(fire[i]);
                        fire[i].Dispose();
                        fire[i] = fire[k - 1];
                        fire[k - 1].Dispose();
                        k--;
                    }
                }
            }
        }
    }
}
