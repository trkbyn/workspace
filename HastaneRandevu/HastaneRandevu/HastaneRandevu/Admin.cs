using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneRandevu
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                Adminİslemleri adminİslemleri = new Adminİslemleri();
                adminİslemleri.ShowDialog();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Hatalı giriş", "Hata", MessageBoxButtons.OK);
            }

        }

    }
}