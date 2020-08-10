using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T06A
{
    public partial class Form1 : Form
    {
        static int[,] Map =
        {
            {3,3,3,3,3,3,3,3,3,3},
            {3,3,0,0,0,0,0,0,0,3},
            {3,3,0,0,0,0,0,0,0,3},
            {3,3,0,0,0,0,0,0,0,3},
            {3,3,0,0,0,0,0,0,0,3},
            {3,3,0,0,0,0,0,0,0,3},
            {3,3,0,0,0,0,0,0,0,3},
            {3,0,0,0,0,0,0,0,0,3},
            {3,3,0,3,3,3,3,0,2,3},
            {3,3,3,3,3,3,3,3,3,3}
        };
        int px, py, x, y, mx, my, bx, by;//x,y 顛倒
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Top = 24;
            pictureBox1.Left = 32;
            px = 1;
            py = 2;
            bx = 3;
            by = 4;
            x = 28;
            y = 30;
            pictureBox3.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Top = 28;
            pictureBox1.Left = 60;
            pictureBox2.Top = 86;
            pictureBox2.Left = 120;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && Map[px, py + 1] != 3) 
            {py += 1;pictureBox1.Left += y;
            if(pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds)&&Map[bx,by + 1] != 3)
            { pictureBox2.Left += y; by += 1; }
            else if (Map[bx, by + 1] != 0 && pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds))
            { py -= 1; pictureBox1.Left -= y; }
            }

            if (e.KeyCode == Keys.Left && Map[px, py - 1] != 3)
            {py -= 1;pictureBox1.Left -= y;
            if (pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds) && Map[bx, by - 1] != 3)
            { pictureBox2.Left -= y; by -= 1; }
            else if (Map[bx, by - 1] != 0 && pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds))
            { py += 1; pictureBox1.Left += y; }
            }

            if (e.KeyCode == Keys.Up && Map[px - 1, py] != 3)
            {px -= 1;pictureBox1.Top -= x;
            if (pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds) && Map[bx-1, by] != 3)
            { pictureBox2.Top -= x; bx -= 1; }
            else if (Map[bx-1, by] != 0 && pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds))
            { px += 1; pictureBox1.Top += x; }
            }

            if (e.KeyCode == Keys.Down && Map[px + 1, py] != 3)
            {px += 1;pictureBox1.Top += x;
            if (pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds) && Map[bx+1, by] != 3)
            { pictureBox2.Top += x; bx += 1; }
            else if (Map[bx+1, by] != 0 && pictureBox1.Bounds.IntersectsWith(pictureBox2.Bounds))
            { px -= 1; pictureBox1.Top -= x; }
            }

            if(Map[bx,by]==2)
            { pictureBox3.Visible = true; }
        }
    }
}
