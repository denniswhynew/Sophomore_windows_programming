using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        Graphics g;
        float f;
        ColorDialog colorDialog1 = new ColorDialog();
        public string obj;
        public int x0, y0, x1, y1, ss;
        Pen pen = new Pen(Color.Black, 3);
        
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }

        bool isMouseDown = false;
        List<Point> points = new List<Point>();

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Interval = 1;
            timer1.Enabled = true;
            ss = 0;
            comboBox1.Items.Add("畫筆");
            comboBox1.Items.Add("直線");
            comboBox1.Items.Add("矩形");
            comboBox1.Items.Add("圓形");
            for (int i = 1; i <= 10; i++)
            {
                comboBox2.Items.Add(i);
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(800, 600);
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.Transparent);
            pen = new Pen(colorDialog1.Color, 4);
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            obj = "畫筆";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Jpg Files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                g = Graphics.FromImage(pictureBox1.Image);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Jpg Files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            f = Convert.ToSingle(comboBox2.Text);
            pen = new Pen(colorDialog1.Color, f);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            f = Convert.ToSingle(comboBox2.Text);
            pen = new Pen(colorDialog1.Color, f);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            obj = comboBox1.Text;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = new Point(e.X, e.Y);
            isMouseDown = true;
            points.Clear();
            points.Add(p);

            ss = 1;
            x0 = e.X; y0 = e.Y;
           
           
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //pictureBox1.Image = new Bitmap(800, 600);
            try
            {
                g = Graphics.FromImage(pictureBox1.Image);
            }
            catch
            {
                MessageBox.Show("請開新檔案!");
            }
           // g.Clear(Color.White);
            x1 = e.X; y1 = e.Y;
            ss = 0;
            isMouseDown = false;
            Point p = new Point(e.X, e.Y);
            Point pStart = points[0];
            Point pLast = points[points.Count - 1];
            if(obj=="直線")
            {
                g.DrawLine(pen, pStart, p);
               // g.DrawLine(pen, x0, y0, x1, y1);
                
            }
            else if(obj=="矩形")
            {
                g.DrawRectangle(pen, pStart.X, pStart.Y, p.X - pStart.X, p.Y - pStart.Y);
                //g.DrawRectangle(pen, x0, y0, x1, y1);
            }
            else if(obj=="圓形")
            {
                g.DrawEllipse(pen, pStart.X, pStart.Y, p.X - pStart.X, p.Y - pStart.Y);
                //g.DrawEllipse(pen, x0, y0, x1, y1);
            }

            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

           // g.DrawLine(pen, 100, 100, 200, 200);
            
           // Point p = new Point(e.X, e.Y);
           // if (points.Count > 0 && isMouseDown)
           // {
               // Point pStart = points[0];
               // Point pLast = points[points.Count - 1];
               if (obj == "畫筆") { 
                if (e.Button == MouseButtons.Left)
                {
                    //pictureBox1.Image = new Bitmap(800, 600);
                    g = Graphics.FromImage(pictureBox1.Image);
                    //g.Clear(Color.White);
                    
                    x1 = e.X; y1 = e.Y;
                   // g.DrawLine(pen, pLast, p);
                    g.DrawLine(pen, x0, y0, x1, y1);
                    x0 = x1; y0 = y1;
                    
                }
               }
            //points.Add(p);

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }
    }
}
