using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Chestionar
{
    public partial class Form2 : Form
    {
        int m, s;
        DataTable test = new DataTable();
        int k = 0;
        int corecte = 0;
        int gresite = 0;
        int ramase = 26;

        string raspunsuri;

        SqlConnection sqlCon = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Documents and Settings\Admin\Desktop\New Folder\Chestionar\Chestionar\chestionar.mdf;Integrated Security=True;User Instance=True");
        
        public Form2()
        {
            InitializeComponent();
            test = fillDataTable();
            init_tabel();
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "26";
        }

        public DataTable fillDataTable()
        {
            string query = "SELECT * FROM intrebari WHERE categorie = 'B'";

            SqlConnection sqlCon = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Documents and Settings\Admin\Desktop\New Folder\Chestionar\Chestionar\chestionar.mdf;Integrated Security=True;User Instance=True");

            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            txtA.BackColor = Color.Yellow;
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            txtB.BackColor = Color.Yellow;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtC.BackColor = Color.Yellow;
        }

    

        private void init_tabel()
        {
            txtIntrebari.Text = test.Rows[k].Field<string>(1);
            txtA.Text = test.Rows[k].Field<string>(2);
            txtB.Text = test.Rows[k].Field<string>(3);
            txtC.Text = test.Rows[k].Field<string>(4);
            raspunsuri = test.Rows[k].Field<string>(5);
            raspunsuri = raspunsuri.Split(new char[] { ' ' })[0];
            k++;
        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            int nu = 0;
            int ok = 0;
            if (txtA.BackColor == Color.Yellow)
                ok=1;
            if (txtB.BackColor == Color.Yellow)
                ok=1;
            if (txtC.BackColor == Color.Yellow)
                ok=1;

            if (ok == 1)
            {
                int r = 0;
                if (txtA.BackColor == Color.Yellow && raspunsuri == "A")
                    r = 1;
                if (txtB.BackColor == Color.Yellow && raspunsuri == "B")
                    r = 1;
                if (txtC.BackColor == Color.Yellow && raspunsuri == "C")
                    r = 1;

                if (r == 1)
                {
                    corecte++;
                    textBox2.Text = corecte.ToString();
                }
                else
                {
                    gresite++;
                    textBox3.Text = gresite.ToString();
                }
                ramase--;
                textBox4.Text = ramase.ToString();
            }
            else if (ok == 0)
            {
                nu = 1;
                MessageBox.Show("Nu ati selectat niciun raspuns!");
            }
            else
            {
                gresite++;
                textBox3.Text = gresite.ToString();
            }

            if (nu == 0)
            {
                txtA.BackColor = Color.White;
                txtB.BackColor = Color.White;
                txtC.BackColor = Color.White;
                init_tabel();
                if (gresite == 5)
                {
                    MessageBox.Show("Respins!");
                    Application.Exit();
                }
                if (gresite <= 4 && ramase == 0)
                {
                    this.Close();
                    Form1 f1 = new Form1();
                    f1.Show();
                    MessageBox.Show("Felicitari! Ai fost delcarat admis cu " + corecte + " puncte!");
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            s = Convert.ToInt32(lblSecunda.Text);
            s--;
            lblSecunda.Text =  Convert.ToString(s);
            if (s <= 0)
            {
                
                m = Convert.ToInt32(lblMinut.Text);

                lblMinut.Text = Convert.ToString(m-1);
                lblSecunda.Text = "59";

            }
            if (lblMinut.Text == "0" && lblSecunda.Text == "0")
            {
                timer1.Stop();
                MessageBox.Show("Timpul a expirat!");
                Application.Exit();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtA.BackColor = Color.White;
            txtB.BackColor = Color.White;
            txtC.BackColor = Color.White;
        }
        

        private void txtIntrebari_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void txtIntrebari_MouseLeave(object sender, EventArgs e)
        {
            
        }

    }
}
