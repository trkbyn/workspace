using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;

namespace HastaneRandevu
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        public static string tckimlik, sifre;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-44ST0UO\\SQLEXPRESS;Initial Catalog=Hastane;Integrated Security=True");
        private void icPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DısPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {
        Anasayfa anasayfa = new Anasayfa();
            label1.Text = DateTime.Now.ToLongDateString();
            txtKimlik.Text = "12743364516";
            txtSifre.Text = "12345678";
        }

        private void txtKimlik_TextChanged(object sender, EventArgs e)
        {
          
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
       public int hak = 2;
        private void button1_Click(object sender, EventArgs e)
        {
            
            string adad = "";
            string soyadsoyad = "";
            if(hak != 0)
            {
                con.Open();
                SqlCommand komut = new SqlCommand("select * from  hastalar3 where hasta_tc = '" + txtKimlik.Text + "' and hasta_sifre = '" + txtSifre.Text + "'", con);

                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    adad = dr["hasta_ad"].ToString();
                    soyadsoyad= dr["hasta_soyad"].ToString();
                    Uyeden_Randevuya.tcno = txtKimlik.Text;

                    Uyeden_Randevuya.hastaid= dr["hasta_id"].ToString();
                    Uyeden_Randevuya.ad = adad;
                    Uyeden_Randevuya.soyad = soyadsoyad;
                     RandevuArama randevuArama = new RandevuArama();
                     randevuArama.Show();
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
            Hatirla hatirla = new Hatirla();
            hatirla.Show();
            this.Hide();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void txtKimlik_Leave(object sender, EventArgs e)
        {
            if(txtKimlik.TextLength != 11)
            {
                txtKimlik.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UyeOl uyeOl = new UyeOl();
            uyeOl.Show();
            this.Hide();



        }
    }
}
