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

namespace LabelRun
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MouseMove += Form1_MouseMove;
        }
        void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Thread.Sleep(500);
            Random rand=new Random();
            lblRun.Left = rand.Next(0, this.ClientSize.Width - lblRun.Width);
            lblRun.Top = rand.Next(0, this.ClientSize.Height - lblRun.Height);
        }
    }
}
