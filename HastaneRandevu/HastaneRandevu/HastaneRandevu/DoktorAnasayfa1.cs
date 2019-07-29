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
    public partial class DoktorAnasayfa1 : Form
    {
        public DoktorAnasayfa1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-44ST0UO\\SQLEXPRESS;Initial Catalog=Hastane;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            DoktorUyeOl uyeOl = new DoktorUyeOl();
            uyeOl.Show();
            this.Hide();

        }
        public int hak = 2;

        private void button1_Click(object sender, EventArgs e)
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
                    Uyeden_Randevuya.doktorid = dr["doktorid"].ToString();
                    //string a = doktor_randevu_al_gel.randevuzamani;
                    Uyeden_Randevuya.doktorad = doktorad;
                    Uyeden_Randevuya.doktorsoyad = doktorsoyad;

                    Doktorİslemleri doktor = new Doktorİslemleri();
                    doktor.Show();
                    this.Hide();
                }



                else
                {
                    MessageBox.Show("Hatalı Giriş ", "Hata", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    hak--;
                    txtKimlik.Clear();
                    txtSifre.Clear();
                    txtKimlik.Focus();
                    
                }

                con.Close();
            }
            else
            {
                MessageBox.Show("Giriş Başarısız ", "Hata", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void btnHatırla_Click(object sender, EventArgs e)
        {
            DoktorSifreHatirla sifre = new DoktorSifreHatirla();
            sifre.Show();
            this.Hide();
        }

        private void txtKimlik_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtKimlik_Leave(object sender, EventArgs e)
        {
            if (txtKimlik.TextLength != 11)
            {
                txtKimlik.Clear();
            }
        }

        private void DoktorAnasayfa1_Load(object sender, EventArgs e)
        {
            txtKimlik.Text = "12737364744";
            txtSifre.Text = "1";
        }
    }
}
