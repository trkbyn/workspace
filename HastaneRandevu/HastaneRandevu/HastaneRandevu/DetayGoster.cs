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
    public partial class DetayGoster : Form
    {
        public DetayGoster()
        {
            InitializeComponent();
        }

        private void DetayGoster_Load(object sender, EventArgs e)
        {
            string tarih1 = Doktor_Randevu_Detay.randevutarihi;
            DateTime tarih3 = System.Convert.ToDateTime(tarih1);
            int yil = tarih3.Year;
            int ay = tarih3.Month;
            int gun = tarih3.Day;
            DateTime tarih2 = new DateTime(yil, ay, gun);
            string tarih4 = tarih2.ToShortDateString();
            tarih4 = tarih4.Replace('.', '-');
            tarih4 = gun.ToString() + "-" + ay.ToString() + "-" + yil.ToString();

            string tarih5 = Doktor_Randevu_Detay.hastadogumtarihi;
            DateTime tarih6 = System.Convert.ToDateTime(tarih5);
            int yil1 = tarih6.Year;
            int ay1 = tarih6.Month;
            int gun1 = tarih6.Day;
            DateTime tarih7 = new DateTime(yil, ay, gun);
            string tarih8 = tarih7.ToShortDateString();
            tarih8 = tarih8.Replace('.', '-');
            tarih8 = gun1.ToString() + "-" + ay1.ToString() + "-" + yil1.ToString();


            this.ActiveControl = label1;
            txtAdSoyad.Text = Doktor_Randevu_Detay.hastaadsoyad;
            txtRandevuSaati.Text = Doktor_Randevu_Detay.saat;
            txtHastaDogumTarihi.Text = tarih8;
            txtRandevuTarihi.Text = tarih4;
            txtCinsiyet.Text = Doktor_Randevu_Detay.cinsiyet;
            txtBaba.Text = Doktor_Randevu_Detay.hastababaadi;
            txtHastaAnne.Text = Doktor_Randevu_Detay.hastaanneadi;
            txtDogumYeri.Text = Doktor_Randevu_Detay.hastadogumyeri;

            if(txtBaba.Text == "")
            {
                txtBaba.Text = "Kayıt Bulunamadı";
            }
            if (txtAdSoyad.Text == "")
            {
                txtAdSoyad.Text = "Kayıt Bulunamadı";
            }
            if (txtCinsiyet.Text == "")
            {
                txtCinsiyet.Text = "Kayıt Bulunamadı";
            }
            if (txtDogumYeri.Text == "")
            {
                txtDogumYeri.Text = "Kayıt Bulunamadı";
            }
            if (txtHastaAnne.Text == "")
            {
                txtHastaAnne.Text = "Kayıt Bulunamadı";
            }
            if (txtHastaDogumTarihi.Text == "")
            {
                txtHastaDogumTarihi.Text = "Kayıt Bulunamadı";
            }
            if (txtRandevuSaati.Text == "")
            {
                txtRandevuSaati.Text = "Kayıt Bulunamadı";
            }
            if (txtRandevuTarihi.Text == "")
            {
                txtRandevuTarihi.Text = "Kayıt Bulunamadı";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Doktorİslemleri ds = new Doktorİslemleri();
            ds.Show();
            this.Hide();
        }
    }
}
