using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework1
{
    public partial class Form1 : Form
    {
        string[] renome = { "Бабичев", "Павел", "Александрович" };
        int len = 0;
        int val = 0;
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
           
        }

        void Form1_Load(object sender, EventArgs e)
        {
           
            foreach  (string item in renome)
            {
                MessageBox.Show(item, "Rezume", MessageBoxButtons.OK, MessageBoxIcon.Information);
                len += item.Length;
                val++;
            }
            MessageBox.Show("Конец","Avg - "+(len/val).ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
