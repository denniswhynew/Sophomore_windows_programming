using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace C0804
{
    class girl
    {
        public PictureBox Mygirl = new PictureBox();
        public PictureBox MyPictureBox2 = new PictureBox();
        public girl()
        {
            Mygirl.Image = C0804.Properties.Resources.sport1A;
            Mygirl.SizeMode = PictureBoxSizeMode.StretchImage;
            Mygirl.Size = new System.Drawing.Size(50, 70);
            Mygirl.BringToFront();
            Mygirl.BackColor = System.Drawing.Color.Transparent;
            MyPictureBox2.Image = C0804.Properties.Resources._001;
            MyPictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            MyPictureBox2.Size = new System.Drawing.Size(2, 2);
            MyPictureBox2.BackColor = System.Drawing.Color.Transparent;
        }

        public void left(int xx)
        {
            Mygirl.Image = C0804.Properties.Resources.sport_0031;
            Mygirl.Left -= xx;
            MyPictureBox2.Left -= xx;

        }

        public void right(int xx)
        {
            Mygirl.Image = C0804.Properties.Resources.sport_0031A;
            Mygirl.Left += xx;
            MyPictureBox2.Left += xx;

        }

        public void jump(int xx)
        {
            Mygirl.Top += xx;
            MyPictureBox2.Top += xx;

        }
    }
}
