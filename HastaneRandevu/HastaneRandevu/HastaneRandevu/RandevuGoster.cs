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

namespace HastaneRandevu
{
    public partial class RandevuGoster : Form
    {
      
        public RandevuGoster()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-44ST0UO\\SQLEXPRESS;Initial Catalog=Hastane;Integrated Security=True");

        private void RandevuGoster_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
            RandevuArama randevu = new RandevuArama();
            string saat = doktor_randevu_al_gel.saat;
            string doktorid = doktor_randevu_al_gel.doktorid;
            string klinikid = doktor_randevu_al_gel.klinikid;
            string randevuid = doktor_randevu_al_gel.randevuid;

            string hastaneid = doktor_randevu_al_gel.hastaneid;

            richTextBox1.Text = doktor_randevu_al_gel.hastaneadi.ToUpper();
            txtDoktoradi.Text = doktor_randevu_al_gel.doktoradi.ToUpper();
            txtKlinik.Text = doktor_randevu_al_gel.klinikadi;
            txtRandevuzamani.Text = doktor_randevu_al_gel.randevuzamani + "    " + saat ;


            Uyeden_Randevuya.tcno.ToString();
            //  SqlCommand komut = new SqlCommand("select * from  hastalar3 where hasta_tc = '" + txtKimlik.Text + "' and hasta_sifre = '" + txtSifre.Text + "'", con);

            //  SqlDataReader dr = komut.ExecuteReader();
            con.Open();


            SqlCommand komut = new SqlCommand("select * from hastalar3  where hasta_tc= @hastatc", con);
            //komut.ExecuteNonQuery();

            txtHastatc.Text = Uyeden_Randevuya.tcno.ToString();

            komut.Parameters.AddWithValue("@hastatc", txtHastatc.Text);




            SqlDataReader dr = komut.ExecuteReader();




            while (dr.Read())


            {


                txtHastatc.Text = dr["hasta_tc"].ToString();
                txtHastaad.Text = dr["hasta_ad"].ToString().ToUpper();
                txtHastaSoyad.Text = dr["hasta_soyad"].ToString().ToUpper();
                txtHastaEmail.Text = dr["email"].ToString();
                txtHastaCinsiyet.Text = dr["cinsiyet"].ToString().ToUpper();

                string dogtarstring= dr["dogumtarihi"].ToString();
                DateTime dagtarhakiki = System.Convert.ToDateTime(dogtarstring);

                txtHastaDogum.Text = dagtarhakiki.ToShortDateString();// dr["dogumtarihi"].ToString();
              
            }
          
            con.Close();

            




        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public static string hastaneadi = "";
        public static string doktoradi = "";
        public static string klinikadi = "";
        public static string randevuzamani = "";

       
        private void btnRandevuKaydet_Click(object sender, EventArgs e)
        {
            

            hastaneadi = richTextBox1.Text;
            doktoradi = txtDoktoradi.Text;
            klinikadi = txtKlinik.Text;
            randevuzamani = txtRandevuzamani.Text;

            string saat = doktor_randevu_al_gel.saat;
            string doktorid = doktor_randevu_al_gel.doktorid;
            string klinikid = doktor_randevu_al_gel.klinikid;
            string randevuid = doktor_randevu_al_gel.randevuid;
           string randevuzamani2 = doktor_randevu_al_gel.randevuzamani;

            string hastaneid = doktor_randevu_al_gel.hastaneid;

            MessageBox.Show(("Randevunuz başarılı bir şekilde kaydedilmiştir. " + "\nAyrıca  " + txtHastaEmail.Text + " e-posta adresinize randevu bildirimi gönderilmiştir." + " \nLütfen randevu saatinizden 15 dakika önce giriş işlemleriniz için nüfus cüzdanınız ile birlikte randevu almış olduğunuz " + richTextBox1.Text + " 'ne başvurunuz."), "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);


           
            //hastaya randevu bilgilerini gerçekten e mail gönder !!!









            RandevuArama anasayfa = new RandevuArama();
            anasayfa.Show();
            this.Hide();
        }


    }
}
