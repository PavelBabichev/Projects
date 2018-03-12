using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MouseEvent
{
    public partial class Form1 : Form
    {
        bool flag = false;
        public Form1()
        {
            InitializeComponent();
           this.MouseClick += Form1_MouseClick;
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
           this.MouseMove += Form1_MouseMove;
        }
       
        void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = "Координаты мыши х=" + e.X.ToString() + ", y=" + e.Y.ToString();
        }

        void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                flag = false;
            }
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                flag = true;
            }
        }

        void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (flag) this.Close();
                else
                {
                    if (e.X > 10 && e.Y > 10 && e.Y < (this.Width - 10) && e.X < (this.Height - 10))
                        MessageBox.Show("Текущая точка находится внутри прямоугольника.");
                    else if(e.X < 10 || e.Y < 10 || e.Y > (this.Width - 10) || e.X > (this.Height - 10))
                        MessageBox.Show("Текущая точка находится снаружи прямоугольника.");
                    else
                        MessageBox.Show("Текущая точка находится на границе прямоугольника.");
                }
              
            }
            else if(e.Button==MouseButtons.Right)
            {
                Text = "Ширина=" + (this.Width - 20).ToString() + ", Высота=" + (this.Height - 20).ToString();
                Thread.Sleep(1000);
            }
        }
    }
}
