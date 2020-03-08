using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chestionar
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void btnCatB_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SUCCES!");
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form f1 = new Form1();
            f1.Show();
        }

        private void btnCatA_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SUCCES!");
            this.Close();
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void btnCatC_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SUCCES!");
            this.Close();
            Form6 f6 = new Form6();
            f6.Show();
        }
    }
}
