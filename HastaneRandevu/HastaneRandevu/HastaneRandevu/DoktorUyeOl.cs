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
    public partial class DoktorUyeOl : Form
    {
        public DoktorUyeOl()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection("Data Source=DESKTOP-44ST0UO\\SQLEXPRESS;Initial Catalog=Hastane;Integrated Security=True");
        public static string doktorkimlik = "";
        ErrorProvider provider = new ErrorProvider();

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DoktorUyeOl_Load(object sender, EventArgs e)
        {
            label15.Text = @"işaretli alanların doldurulması zorunludur.";
            label12.Text = @"Çalıştığınız Hastanenin İli";
            label17.Text = @"Çalıştığınız Hastanenin İlçesi";
            label18.Text = @"Çalıştığınız Hastane";
            label23.Text = @"Çalıştığınız Birim";

            txtKimlik.Text = "12737364744";
            txtAd.Text = "tarık";
            txtSoyad.Text = "boyun";
            txtDogum.Text = "1994";
            txtEmail.Text = "trkbyn@gmail.com";
            txtSifre.Text = "1";
            txtSifreOnay.Text = "1";
  

            SqlCommand komut = new SqlCommand(" select il_adi  from osman_hastane1 group by il_adi", con);
            SqlDataReader dr;
            con.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbDoktoril.Items.Add(dr["il_adi"]);
            }
            con.Close();

            SqlCommand komut2 = new SqlCommand(" select *  from klinikler1 order by klinik_adi", con);
            SqlDataReader dr2;
            con.Open();
            dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbDoktorKlinik.Items.Add(dr2["klinik_adi"]);
            }
            con.Close();
         
         /*   DataRowView SecilenSatir = cmbDoktorHastane.SelectedItem as DataRowView;

            if (null == SecilenSatir)
                return;

            SecilenSatir.Row.Delete();*/

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT il_adi,sehirid FROM osman_hastane1 where sehirid>0 GROUP BY il_adi,sehirid", con);
            da.Fill(dt);
            cmbDoktoril.ValueMember = "sehirid";
            cmbDoktoril.DisplayMember = "il_adi";
            cmbDoktoril.DataSource = dt;
            ////////////////////////////////////////////////////
            ///


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
        public bool  TckimliknoDogrula()
        {
            bool? durum;
            long tckimlik = long.Parse(txtKimlik.Text);
            if (txtKimlik.Text == String.Empty || txtKimlik.Text == "")
            {
                MessageBox.Show("Lütfen Tc Kimlik numaranızı doğru giriniz!22222");

            }
            else
            {
                int dogumyili = int.Parse(txtDogum.Text);
                string ad = txtAd.Text.ToUpper();
                string soyad = txtSoyad.Text.ToUpper();


                try
                {
                    using (Kimlik.KPSPublicSoapClient servis = new Kimlik.KPSPublicSoapClient())
                    {
                        durum = servis.TCKimlikNoDogrula(tckimlik, ad, soyad, dogumyili);
                    }
                }
                catch
                {
                    durum = null;
                    MessageBox.Show("catchde hata var. Hata no : 1 ");
                    return false;
                }
                if (durum == true)
                {
                 //  MessageBox.Show((ad + " " + soyad + " T.C vatandaşıdır"), " Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Böyle bir T.C. vatandaşı bulunamamıştır!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return false;
                }
                
            }
            return false;

        }
        public void Textuyari()
        {
            MessageBox.Show(" Bu alanın kullanımı zorunludur", " Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }
        private void btnOnayla_Click(object sender, EventArgs e)
        {
            
            RegexUtilities regexUtilities = new RegexUtilities();
            
            if (txtKimlik.Text== ""  ){ txtKimlik.BackColor = Color.Yellow; return; }       else{ txtKimlik.BackColor = Color.LightCyan;}
            if (txtAd.Text == "") { txtAd.BackColor = Color.Yellow;Textuyari();txtAd.Focus(); return; }               else { txtAd.BackColor = Color.LightCyan; }
            if (txtSoyad.Text == "") { txtSoyad.BackColor = Color.Yellow; Textuyari();txtSoyad.Focus(); return; }         else { txtSoyad.BackColor = Color.LightCyan; }
            if (txtSifre.Text == "") { txtSifre.BackColor = Color.Yellow; Textuyari(); txtSifre.Focus(); return; }         else { txtSifre.BackColor = Color.LightCyan; }
            if (txtSifreOnay.Text == "") { txtSifreOnay.BackColor = Color.Yellow; Textuyari(); txtSifreOnay.Focus(); return; }  else { txtSifreOnay.BackColor = Color.LightCyan; }
            if (txtEmail.Text == "") { txtEmail.BackColor = Color.Yellow; Textuyari();txtEmail.Focus();   return; }         else { txtEmail.BackColor = Color.LightCyan; }
            if (txtDogum.Text == "") { txtDogum.BackColor = Color.Yellow; Textuyari();txtDogum.Focus(); return; }         else { txtDogum.BackColor = Color.LightCyan; }


            if (txtSifre.Text.Length < 8 || txtSifre.Text.Length > 16)
            {
                MessageBox.Show("Parolanız en az 8 , en fazla 16 karakter olmalı ve parolanızda büyük/küçük harf ve rakam bulunmalıdır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSifre.Clear();
                txtSifreOnay.Clear();
                txtSifre.Focus();
                return;
            }

            {
                /////////////////////////////////////////////////////////
                ///
                try
                {
                    

                   bool nedondu= TckimliknoDogrula();
                    if (nedondu==false)
                    {
                        txtKimlik.BackColor = Color.Yellow;

                        return;
                    }

                    if (regexUtilities.IsValidEmail(txtEmail.Text))
                    {
                        if (txtSifre.Text == txtSifreOnay.Text)
                        {
                            try
                            {
                                con.Open();
                                SqlCommand command = new SqlCommand("INSERT INTO  doktorlar1 (doktortc , doktorad , doktorsoyad ,  doktorsifre,doktoremail,hastane_id,klinikid) values (@doktortc,@doktorad , @doktorsoyad ,  @doktorsifre,@doktoremail,@hastane_id,@klinikid)");
                                //  cmd2.Connection = con;
                                // cmd2.CommandType = CommandType.Text;
                                // cmd2.CommandText = "INSERT INTO  hastalar3 (hasta_tc , hasta_ad , hasta_soyad , cinsiyet , dogumtarihi , dogumyeri , babadi , anneadi) values (@hasta_tc,@hasta_ad , @hasta_soyad , @cinsiyet , @dogumtarihi , @dogumyeri,@babadi,@anneadi)";
                                // "INSERT INTO  hastalar3 (hasta_tc , hasta_ad , hasta_soyad , cinsiyet , dogumtarihi , dogumyeri , babadi , anneadi) values (@hasta_tc,@hasta_ad , @hasta_soyad , @cinsiyet , @dogumtarihi , @dogumyeri,@babadi,@anneadi)";
                                doktorkimlik = txtKimlik.Text;


                                command.Connection = con;
                                command.Parameters.AddWithValue("@doktortc", txtKimlik.Text);
                                command.Parameters.AddWithValue("@doktorad", txtAd.Text);
                                command.Parameters.AddWithValue("@doktorsoyad", txtSoyad.Text);
                                // command.Parameters.AddWithValue("@cinsiyet", cmbCinsiyet.SelectedItem.ToString());
                                //command.Parameters.AddWithValue("@dogumtarihi", dtTarih.Value);
                                //command.Parameters.AddWithValue("@dogumyeri", txtDogumYeri.Text);
                                // command.Parameters.AddWithValue("@babaadi", txtBabaadi.Text);
                                // command.Parameters.AddWithValue("@anneadi", txtAnneadi.Text);
                                command.Parameters.AddWithValue("@doktorsifre", txtSifre.Text);
                                command.Parameters.AddWithValue("@doktoremail", txtEmail.Text);
                                command.Parameters.AddWithValue("@hastane_id", cmbDoktorHastane.SelectedValue);
                                command.Parameters.AddWithValue("@klinikid", cmbDoktorKlinik.SelectedValue);
                              //  string b = cmbDoktorHastane.SelectedValue.ToString();
                               // MessageBox.Show(b.ToString());
                               try
                                {
                                    command.ExecuteNonQuery();
                                    MessageBox.Show("Kayıt Başarıyla Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                    DoktorAnasayfa1 anasayfa = new DoktorAnasayfa1();
                                    anasayfa.Show();
                                    this.Hide();
                                }
                                catch (Exception )
                                {
                                    MessageBox.Show(@"Sistemde zaten kaydınız vardır! Eğer parolanızı hatırlamıyorsanız lütfen parola hatırlatma ekranını kullanınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    DoktorSifreHatirla hatirla = new DoktorSifreHatirla();
                                    hatirla.Show();
                                    this.Hide();
                                }


                                //  int neoldu = command.ExecuteNonQuery();
                                //   MessageBox.Show(neoldu.ToString());


                                // dataGridView1.Visible = true;

                                con.Close();
                              

                            }

                            catch (SqlException)
                            {
                                MessageBox.Show("Hata Oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            }
                        }

                        else
                        {
                            MessageBox.Show("Şifreler Uyuşmuyor",
                              "Şifre Hatası",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Exclamation,
                             MessageBoxDefaultButton.Button1);
                            txtSifre.Clear();
                            txtSifreOnay.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen mail formatına uygun bir mail adresi giriniz!", "Hata!",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);
                        txtEmail.Clear();
                        txtEmail.Focus();
                    }
                }
                catch (Exception exx)
                {
                    MessageBox.Show(" Hata " + exx);
                }


                //  TextboxKontrol();
                
            }
            /////////////////////////////////////////////////
           


        }
        public void kisigetir()
        {

            con.Open();


            SqlCommand cmd = new SqlCommand("select * from doktorlar1 order by doktorid ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            //dataGridView1.DataSource = dt;

            con.Close();





        }
      

        public  void temizle()
        {
            txtAd.Clear();
            txtKimlik.Clear();
            txtSoyad.Clear();
            txtSifre.Clear();
            txtSifreOnay.Clear();
            txtEmail.Clear();
            txtDogum.Clear();
            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            kisigetir();
           
        }

        private void cmbDoktoril_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            if (cmbDoktoril.SelectedIndex > -1)  //!= -1)
            {

                // cmbSehir.SelectionChangeCommitted -= cmbSehir_SelectionChangeCommitted;

                DataTable dt = new DataTable();
                string bune = cmbDoktoril.Text;     //SelectedValue.ToString();

                SqlDataAdapter daa = new SqlDataAdapter("SELECT il_adi,ilce_adi FROM osman_hastane1 where il_adi ='" + cmbDoktoril.Text + "' AND  sehirid > -1 GROUP BY il_adi,ilce_adi", con);
                daa.Fill(dt);
                cmbDoktorİlce.ValueMember = "sehirid";
                cmbDoktorİlce.DisplayMember = "ilce_adi";
                cmbDoktorİlce.DataSource = dt;

                //DataTable dt2 = new DataTable();
                //SqlDataAdapter da2 = new SqlDataAdapter("select il_adi,ilce_adi,hastane_adi,hastane_id from osman_hastane1 where il_adi = '" + cmbDoktoril.Text + "' and sehirid > -1 group by il_adi,ilce_adi,hastane_adi,hastane_id" , con);
                //da2.Fill(dt2);
                //cmbDoktorHastane.ValueMember = "sehirid";
                //cmbDoktorHastane.DisplayMember = "hastane_adi";
                //cmbDoktorHastane.DataSource = dt2;

                //   cmbSehir.SelectionChangeCommitted += cmbSehir_SelectionChangeCommitted;

            }
        }

        private void cmbDoktorİlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDoktoril.SelectedIndex > -1)  //!= -1)
            {

                // cmbSehir.SelectionChangeCommitted -= cmbSehir_SelectionChangeCommitted;

 

                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter("select il_adi,ilce_adi,hastane_adi,hastane_id from osman_hastane1 where il_adi = '" + cmbDoktoril.Text +  "' and ilce_adi='" + cmbDoktorİlce.Text +  "' and       sehirid > -1 order by il_adi,ilce_adi,hastane_adi,hastane_id", con);
                da2.Fill(dt2);
                cmbDoktorHastane.ValueMember = "hastane_id";
                cmbDoktorHastane.DisplayMember = "hastane_adi";
                cmbDoktorHastane.DataSource = dt2;

                //   cmbSehir.SelectionChangeCommitted += cmbSehir_SelectionChangeCommitted;

            }


        }

        private void cmbDoktorHastane_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDoktoril.SelectedIndex > -1)  //!= -1)
            {

                // cmbSehir.SelectionChangeCommitted -= cmbSehir_SelectionChangeCommitted;



                DataTable dt2 = new DataTable();
                string aa = cmbDoktorHastane.SelectedValue.ToString();
                string sqlcumle = "select klinik_adi,klinik_id from klinikler1 where hastane_id = '" + cmbDoktorHastane.SelectedValue + "'";
                SqlDataAdapter da2 = new SqlDataAdapter("select klinik_adi,klinik_id from klinikler1 order by klinik_adi", con);
                da2.Fill(dt2);
                cmbDoktorKlinik.ValueMember = "klinik_id";
                cmbDoktorKlinik.DisplayMember = "klinik_adi";
                cmbDoktorKlinik.DataSource = dt2;

                //   cmbSehir.SelectionChangeCommitted += cmbSehir_SelectionChangeCommitted;

            }
        }

        private void cmbDoktorKlinik_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtKimlik_Leave(object sender, EventArgs e)
        {
            if (txtKimlik.TextLength != 11)
            {
                txtKimlik.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)//geri tuşu
        {
            DoktorAnasayfa1 dr = new DoktorAnasayfa1();
            dr.Show();
            this.Hide();
        }



        //şartlar
        //1 . email kontrolü
        //2 . tckimlikno kontrol
        //3 . şifrelerin uyuşması
        //4 . textboxların dolu olması 





        /*long tckimlik = long.Parse(txtKimlik.Text);
        int dogumyili = int.Parse(txtDogum.Text);
        string ad = txtAd.Text.ToUpper();
        string soyad = txtSoyad.Text.ToUpper();
        bool? durum;

        try
        {
            using(Kimlik.KPSPublicSoapClient servis = new Kimlik.KPSPublicSoapClient())
            {
                durum = servis.TCKimlikNoDogrula(tckimlik, ad, soyad, dogumyili);
            }
        }
        catch
        {
            durum = null;
            MessageBox.Show("catchde hata var. Hata no : 1 ");
        }
        if (durum == true)
        {
            MessageBox.Show(ad + " " + soyad + " T.C vatandaşıdır");

        }
        else
        {
            MessageBox.Show("Böyle bir T.C vatandaşı bulunamamıştır");
        }*/
    }
}
        

