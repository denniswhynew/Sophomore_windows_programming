using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C0804
{
    public partial class Form1 : Form
    {
        girl mygirl = new girl();
        int vx,vy,ay;
        bool left; bool isOnGround;
        bool right; bool jump;
        PictureBox[] brick = new PictureBox[10];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            timer1.Enabled = true;
            left = false; right = false; jump = false; isOnGround = true;
            mygirl.Mygirl.Left = 200;
            mygirl.Mygirl.Top = 560;
            mygirl.MyPictureBox2.Left = 225;
            mygirl.MyPictureBox2.Top = 630;
            this.Controls.Add(mygirl.Mygirl);
            vx=5;vy=0;ay=2;
            int[] squareXArray = new int[] { 270, 270, 150, 10, 5, 320, 320 };
            int[] squareWArray = new int[] { 220, 220, 180, 180, 375, 180, 180 };
            for (int i = 0; i < 7; i++)
            {
                brick[i] = new PictureBox();
                brick[i].Image = C0804.Properties.Resources._002;
                brick[i].Location = new Point(squareXArray[i], 140 + 70 * i);
                brick[i].Size = new System.Drawing.Size(squareWArray[i], 20); ;
                brick[i].BringToFront();
                brick[i].BackColor = System.Drawing.Color.Transparent;
                this.Controls.Add(brick[i]);
            }


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) { left = true;  }
            if (e.KeyCode == Keys.Right) { right = true;}
            if (e.KeyCode == Keys.Space) { jump = true; }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (left) { mygirl.left(vx); }
            if (right) { mygirl.right(vx); }
            if (isOnGround) {isOnGroundTrue();}
            if (!isOnGround) {isOnGroundFalse(); }
            OnGroundSet();

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) { left = false; mygirl.Mygirl.Image = C0804.Properties.Resources.sport1; }
            if (e.KeyCode == Keys.Right) { right = false; mygirl.Mygirl.Image = C0804.Properties.Resources.sport1A; }
            if (e.KeyCode == Keys.Space) { jump = false; }
        }

        private void isOnGroundTrue()
        {
            jumpMode();
            fallMode();
        }

        private void fallMode()
        {
            for (int i=0; i < 7; i++)
            {
                if (mygirl.MyPictureBox2.Top == brick[i].Top)
                {
                    if (!(brick[i].Bounds.IntersectsWith(mygirl.MyPictureBox2.Bounds)))
                    {
                        isOnGround = false;
                    }
                }
            }
        }

        private void isOnGroundFalse()
        {
            vy += ay;
            mygirl.jump(vy);
            if (vy >= 18) { vy = 18;}
        }

        private void jumpMode()
        {
            if (jump) {
                vy = -20;
                isOnGround = false;
            }
        }

        private void OnGroundSet()
        {
            if (mygirl.MyPictureBox2.Top >= 630)
            {
                mygirl.Mygirl.Top = 560; mygirl.MyPictureBox2.Top = 630;
                vy = 0;
                isOnGround = true;
            }
            if (vy >= 0)
            {
                for (int i = 0; i < 7; i++)
                {
                    if ((brick[i].Bounds.IntersectsWith(mygirl.MyPictureBox2.Bounds)))
                    {
                        if (mygirl.MyPictureBox2.Top >= brick[i].Top)
                        {
                            mygirl.Mygirl.Top = brick[i].Top - 70;
                            mygirl.MyPictureBox2.Top = brick[i].Top;
                            vy = 0;
                            isOnGround = true;
                        }
                    }
                }
            }

        }
    }
}
