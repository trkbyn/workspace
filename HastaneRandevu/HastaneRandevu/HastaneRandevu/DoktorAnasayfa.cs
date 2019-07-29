using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneRandevu
{
    public partial class DoktorGiris : Form
    {
        public DoktorGiris()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-SJHO8JO\\SQLEXPRESS3;Initial Catalog=Hastane;Integrated Security=True");


        private void btnHatırla_Click(object sender, EventArgs e)
        {
            DoktorSifreHatirla doktorSifreHatirla = new DoktorSifreHatirla();
            doktorSifreHatirla.Show();
            this.Hide();

        }
        public int hak = 2;


        private void btnGiris_Click(object sender, EventArgs e)
        {
            string doktorad = "";
            string doktorsoyad = "";
            if (hak != 0)
            {
                con.Open();
                SqlCommand komut = new SqlCommand("select * from  doktorlar1 where doktortc = '" + txtKimlik.Text + "' and doktorsifre = '" + txtSifre.Text + "'", con);

                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    doktorad = dr["doktorad"].ToString();
                    doktorsoyad = dr["doktorsoyad"].ToString();

                    Uyeden_Randevuya.doktortc = txtKimlik.Text;

                    Uyeden_Randevuya.doktorad = doktorad;
                    Uyeden_Randevuya.doktorsoyad = doktorsoyad;
                    Doktorİslemleri doktorİslemleri = new Doktorİslemleri();
                    doktorİslemleri.Show();
                    this.Hide();
                }



                else
                {
                    MessageBox.Show("Hatalı Giriş ", "Hata", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    hak--;
                    txtKimlik.Clear();
                    txtSifre.Clear();
                }

                con.Close();
            }
            else
            {
                MessageBox.Show("Giriş Başarısız ", "Hata", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void btnUyeol_Click(object sender, EventArgs e)
        {
            DoktorUyeOl uyeOl = new DoktorUyeOl();
            uyeOl.Show();
            this.Hide();
        }
    }
}
