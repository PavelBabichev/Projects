using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessNumber
{
    public partial class Form1 : Form
    {
        int i = 0;
        int upperBound = 2000;
        int bottomBound = 0;
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Загадайте число от 1 до 2000","", MessageBoxButtons.OK, MessageBoxIcon.Information);
            while (true)
            {
               if (DialogResult.Yes==MessageBox.Show("Ваше число "+((upperBound+bottomBound)/2).ToString()+"?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
               {
                   i++;
                   MessageBox.Show("Попыток - "+i.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   if (DialogResult.No == MessageBox.Show("Сыграем еще раз?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) break;
                   else
                   {
                       MessageBox.Show("Загадайте число от 1 до 2000", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       i = 0;
                       upperBound = 2000;
                       bottomBound = 0;
                   }
               }
               else
               {
                   if (DialogResult.Yes == MessageBox.Show("Ваше число больше?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                   {
                       bottomBound = (upperBound + bottomBound) / 2;
                       i++;
                   }
                   else
                   {
                       upperBound = (upperBound + bottomBound) / 2;
                       i++;
                   }
               }
            }
            this.Close();
        }
    }
}
