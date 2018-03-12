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

namespace LabelList
{
    struct Points
    {
      public  int x;
       public int y;
    }
    public partial class Form1 : Form
    {
        List<Label> list;
        Points start;
        Points finish;
        Label lbl=new Label();
        int i = 0;
        public Form1()
        {
            InitializeComponent();
            this.MouseDown += Form1_MouseDown;
            this.MouseUp += Form1_MouseUp;
            this.Load += Form1_Load;
        }

        void lbl_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                Label lbl = (sender as Label);
                int X = e.X + lbl.Left;
                int Y = e.Y + lbl.Top;
                Label label = findLabel(X,Y, false);
                if (label != null)
                {
                    this.Text = "Площадь - " + (label.Height * label.Width).ToString() + " X=" + label.Left.ToString() + " Y=" + label.Top.ToString();
                }
            }
        }

        void Form1_Load(object sender, EventArgs e)
        {
            list = new List<Label>();
        }

        

        void lbl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Label lbl = (sender as Label);
            int X = e.X + lbl.Left;
            int Y = e.Y + lbl.Top;
            
            if (e.Button == MouseButtons.Left)
            {
                Label label = findLabel(X,Y, true);
                if (label != null)
                {
                    list.Remove(label);
                    this.Controls.Remove(label);
                }
            }
        }

        void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int temp;
                finish.x = e.X;
                finish.y = e.Y;
                if (finish.x < start.x)
                {
                    temp=finish.x;
                    finish.x = start.x;
                    start.x = temp;
                }
                if (finish.y < start.y)
                {
                    temp = finish.y;
                    finish.y = start.y;
                    start.y = temp;
                }
                if ((finish.x - start.x) > 9 && (finish.y - start.y) > 9)
                {
                    list.Add(new Label());
                    list[i].MouseClick += lbl_MouseClick;
                    list[i].MouseDoubleClick += lbl_MouseDoubleClick;
                    list[i].Location = new Point(start.x, start.y);
                    list[i].Size = new Size(finish.x - start.x, finish.y - start.y);
                    list[i].BackColor = Color.Gray;
                    list[i].BorderStyle = BorderStyle.FixedSingle;
                    list[i].Text = (i+1).ToString();
                    list[i].TextAlign = ContentAlignment.MiddleCenter;
                    this.Controls.Add(list[i]);
                    i++;
                }
                else MessageBox.Show("Минимальный размер label должен быть не менее 10х10");
            }
        }

        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                start.x = e.X;
                start.y = e.Y;
            }
        }
        Label findLabel(int x, int y, bool findTop)
        {
            Label temp = null;
            foreach (Label item in list)
            {
                if ((x > item.Left && x < item.Right) && (y > item.Top && y < item.Bottom))
                {
                    if (findTop)
                        return item;
                    else temp = item;
                }
            }
            return temp;
        }
    }
}
