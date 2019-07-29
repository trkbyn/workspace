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
using System.Text.RegularExpressions;

namespace HastaneRandevu
{
    public partial class UyeOl : Form
    {

        public RandevuArama RandevuAramaformu;
        public UyeOl()
        {
         //   RandevuAramaformu = new RandevuArama();
            InitializeComponent();
          //  RandevuAramaformu.uyeolformu = this;
        }
        public static string kimlik = "";
        public static string ad = "";
        public static string soyad = "";
        public static string cinsiyet = "";
        public static string dogumtarihi = "";
        public static string dogumyeri = "";
        public static string babaadi = "";
        public static string anneadi = "";
        // public static string email = "";
        DoktorUyeOl doktorUyeOl = new DoktorUyeOl();


        SqlConnection con = new SqlConnection("Data Source=DESKTOP-44ST0UO\\SQLEXPRESS;Initial Catalog=Hastane;Integrated Security=True");
        private void UyeOl_Load(object sender, EventArgs e)
        {
            label15.Text = @"işaretli alanların doldurulması 
zorunludur.";

            dataGridView1.Visible = false;
         /*   txtKimlik.BackColor = Color.Teal;
            txtAd.BackColor = Color.Teal;
            txtSoyad.BackColor = Color.Teal;
            cmbCinsiyet.BackColor = Color.White;
            txtSifre.BackColor = Color.Teal;
            txtSifreOnay.BackColor = Color.Teal;
            txtEmail.BackColor = Color.Teal;*/

            DateTime dt = this.dtTarih.Value.Date;
            dtTarih.Format = DateTimePickerFormat.Custom;

            dtTarih.CustomFormat = "dd.MM.yyyy";


            var dateAndTime = DateTime.Now;
            var date = dateAndTime.Date;





        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        


          /*  public bool EpostaKontrol(string epostaAdresi)
        {
            string epostaKalibi = @"^(([^<>()[\]\\.,;:\s@\""]+"
            + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
            + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
            + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
            + @"[a-zA-Z]{2,}))$";

            Regex reg = new Regex(epostaKalibi);
            bool kontrol = reg.IsMatch(epostaAdresi);

            return kontrol;
        }*/



        //TEMİZLEME 
        public void temizle()
        {
            txtKimlik.Clear();
            txtAd.Clear();
            txtSoyad.Clear();
            dtTarih.MinDate = DateTime.Now;
            txtDogumYeri.Clear();
            txtBabaadi.Clear();
            txtAnneadi.Clear();
            txtSifre.Clear();
            txtSifreOnay.Clear();
            txtEmail.Clear();


        }


        public bool TckimliknoDogrula()
        {
            bool? durum;
            long tckimlik = long.Parse(txtKimlik.Text);
            if (txtKimlik.Text == String.Empty || txtKimlik.Text == "")
            {
                MessageBox.Show("Lütfen Tc Kimlik numaranızı doğru giriniz!22222");

            }
            else
            {
                int dogumyili = int.Parse(dtTarih.Value.Year.ToString());
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
        private void btnOnayla_Click(object sender, EventArgs e)  // onayla butonu
        {
           
            RegexUtilities regexUtilities = new RegexUtilities();
            if (txtKimlik.TextLength != 11) {txtKimlik.Clear();Textuyari(); txtKimlik.BackColor = Color.Yellow;txtKimlik.Focus(); return; } else { txtKimlik.BackColor = Color.LightCyan; }
            if (txtAd.Text == "") { txtAd.BackColor = Color.Yellow; Textuyari(); txtAd.Focus(); return; } else { txtAd.BackColor = Color.LightCyan; }
            if (txtSoyad.Text == "") { txtSoyad.BackColor = Color.Yellow; Textuyari(); txtSoyad.Focus(); return; } else { txtSoyad.BackColor = Color.LightCyan; }
            if(cmbCinsiyet.SelectedIndex == -1) { MessageBox.Show(" Lütfen cinsiyet seçiniz!"," Hata",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1); cmbCinsiyet.Focus(); return;} else { cmbCinsiyet.BackColor = Color.MintCream; }
            if (txtSifre.Text == "") { txtSifre.BackColor = Color.Yellow;txtSifre.Focus(); Textuyari(); return; } else { txtSifre.BackColor = Color.LightCyan; }
            if (txtSifreOnay.Text == "") { txtSifreOnay.BackColor = Color.Yellow; txtSifreOnay.Focus(); Textuyari(); return; } else { txtSifreOnay.BackColor = Color.LightCyan; }
            if (txtEmail.Text == "") { txtEmail.BackColor = Color.Yellow; txtEmail.Focus(); Textuyari(); return;  } else { txtEmail.BackColor = Color.LightCyan; }
            //  if (dtTarih.Value.Year.ToString() == "") { dtTarih.Value.Year.ToString().BackColor = Color.Yellow; return; } else { txtDogum.BackColor = Color.LightCyan; }
            if (txtSifre.Text.Length < 8 || txtSifre.Text.Length > 16)
            {
                MessageBox.Show("Parolanız en az 8 , en fazla 16 karakter olmalı ve parolanızda büyük/küçük harf ve rakam bulunmalıdır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSifre.Clear();
                txtSifreOnay.Clear();
                txtSifre.Focus();
                return;
            }

            bool nedondu = TckimliknoDogrula();
            if (nedondu == false)
            {
                
                txtKimlik.BackColor = Color.Yellow;
                return;
            }

            if (txtSifre.Text == txtSifreOnay.Text)
            {
                
                if (!regexUtilities.IsValidEmail(txtEmail.Text))
                {
                    MessageBox.Show("Lütfen mail formatına uygun bir mail adresi giriniz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    txtEmail.Clear();
                    txtEmail.Focus();
                }
                        //  EMAİL KONTROLÜ //

                // TCKİMLİK NO KONTROLU YAP 

                else
                {
                    try
                    {
                        con.Open();
                        SqlCommand command = new SqlCommand("INSERT INTO  hastalar3 (hasta_tc , hasta_ad , hasta_soyad , cinsiyet , dogumtarihi , dogumyeri , babaadi , anneadi,hasta_sifre,email) values (@hasta_tc,@hasta_ad , @hasta_soyad , @cinsiyet , @dogumtarihi , @dogumyeri,@babaadi,@anneadi,@hasta_sifre,@email)");
                        //  cmd2.Connection = con;
                        // cmd2.CommandType = CommandType.Text;
                        // cmd2.CommandText = "INSERT INTO  hastalar3 (hasta_tc , hasta_ad , hasta_soyad , cinsiyet , dogumtarihi , dogumyeri , babadi , anneadi) values (@hasta_tc,@hasta_ad , @hasta_soyad , @cinsiyet , @dogumtarihi , @dogumyeri,@babadi,@anneadi)";
                        // "INSERT INTO  hastalar3 (hasta_tc , hasta_ad , hasta_soyad , cinsiyet , dogumtarihi , dogumyeri , babadi , anneadi) values (@hasta_tc,@hasta_ad , @hasta_soyad , @cinsiyet , @dogumtarihi , @dogumyeri,@babadi,@anneadi)";
                        kimlik = txtKimlik.Text;


                        command.Connection = con;
                        command.Parameters.AddWithValue("@hasta_tc", txtKimlik.Text);
                        command.Parameters.AddWithValue("@hasta_ad", txtAd.Text);
                        command.Parameters.AddWithValue("@hasta_soyad", txtSoyad.Text);
                        command.Parameters.AddWithValue("@cinsiyet", cmbCinsiyet.SelectedItem.ToString());
                        command.Parameters.AddWithValue("@dogumtarihi", dtTarih.Value.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@dogumyeri", txtDogumYeri.Text);
                        command.Parameters.AddWithValue("@babaadi", txtBabaadi.Text);
                        command.Parameters.AddWithValue("@anneadi", txtAnneadi.Text);
                        command.Parameters.AddWithValue("@hasta_sifre", txtSifre.Text);
                        command.Parameters.AddWithValue("@email", txtEmail.Text);
                        try
                        {
                        command.ExecuteNonQuery();
                            MessageBox.Show("Kayıt Başarıyla Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            Anasayfa anasayfa = new Anasayfa();
                            anasayfa.Show();
                            this.Hide();
                        }
                        catch (Exception )
                        {
                            MessageBox.Show(@"Sistemde zaten kaydınız vardır! Eğer parolanızı hatırlamıyorsanız lütfen parola hatırlatma ekranını kullanınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Hatirla hatirla = new Hatirla();
                            hatirla.Show();
                            this.Hide();
                            
                        }
                        
                        

                        //  int neoldu = command.ExecuteNonQuery();
                        // MessageBox.Show(neoldu.ToString());

                        dataGridView1.Visible = true;

                        con.Close();




                    }

                    catch (SqlException)
                    {
                        MessageBox.Show("Hata Oluştu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }



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


        
         public void kisigetir()
        {
           
            con.Open();

            
            SqlCommand cmd = new SqlCommand("select * from hastalar3 order by hasta_id ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();

            



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

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            kisigetir();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void txtKimlik_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtKimlik_Leave(object sender, EventArgs e)
        {
            if(txtKimlik.TextLength != 11)
            {
                txtKimlik.Clear();
            }
        }
    }
}
