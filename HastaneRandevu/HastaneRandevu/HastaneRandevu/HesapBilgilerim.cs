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
    public partial class HesapBilgilerim : Form
    {
        public HesapBilgilerim()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-44ST0UO\\SQLEXPRESS;Initial Catalog=Hastane;Integrated Security=True");
        string hastaParolasi;
        private void tabControl1_Click(object sender, EventArgs e)
        {
            string hangitab = tabControl1.SelectedTab.Name.ToString();

            if(hangitab == "tabPage2") // iletisim 
            {
                con.Open();

                maskedTextBox1.Focus();
                SqlCommand komut = new SqlCommand("select email from hastalar3  where hasta_id= '" + Uyeden_Randevuya.hastaid + "'", con);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    txtEmail.Text = dr["email"].ToString();



                }
                con.Close();

            }
            if (hangitab == "tabPageParola") // parola 
            {
           


            }
            if (hangitab == "tabPageGuvenlik") // guvenlik 
            {

            label27.Text = "Güvenlik Sorusu";
                label22.Text = "Kişisel Güvenlik Sorusu";
                label21.Text = "Cevap";
                label23.Text = "Geçerli Parolanız";
                comboBox1.SelectedIndex = 0;

                this.ActiveControl = label27;
            }
          
        }

        private void HesapBilgilerim_Load(object sender, EventArgs e)
        {
            SqlDataReader dr2;
            try
            {

                SqlCommand komut2 = new SqlCommand("select hasta_sifre from  hastalar3 where hasta_id=" + Uyeden_Randevuya.hastaid + "", con);
                con.Open();

                dr2 = komut2.ExecuteReader();
                if (dr2.Read())
                {
                    hastaParolasi = dr2["hasta_sifre"].ToString();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Hasta sifresi okunamadı");
            }
            finally
            {
                con.Close();
            }

                    label22.Visible = false;
            textBox1.Visible = false;
            label25.Visible = false;
            label28.Text = "işaretli alanların doldurulması zorunludur.";
            label20.Text = @"Güvenlik sorusu eklemeniz, yardım için HRS'ye başvurduğunuzda,
HRS hesabının sahibi olduğunuzu doğrulamamıza yardımcı olur.";
            label12.Text = @"Belirlediğiniz bu parola ile sadece HRS uygulamasına giriş 
yapabilir ve randevu işlemlerini gerçekleştirebilirsiniz.";
            label19.Text = "* işaretli alanların doldurulması zorunludur";
            pnlKimlik.Visible = true;
            
            Uyeden_Randevuya.tcno.ToString();
            //  SqlCommand komut = new SqlCommand("select * from  hastalar3 where hasta_tc = '" + txtKimlik.Text + "' and hasta_sifre = '" + txtSifre.Text + "'", con);

            //  SqlDataReader dr = komut.ExecuteReader();
            con.Open();


            SqlCommand komut = new SqlCommand("select * from hastalar3  where hasta_tc= @hastatc", con);
            //komut.ExecuteNonQuery();

            txtKimlik.Text = Uyeden_Randevuya.tcno.ToString();

            komut.Parameters.AddWithValue("@hastatc", txtKimlik.Text);




            SqlDataReader dr = komut.ExecuteReader();




            while (dr.Read())


            {


                txtKimlik.Text = dr["hasta_tc"].ToString();
                txtAd.Text = dr["hasta_ad"].ToString().ToUpper();
                txtSoyad.Text = dr["hasta_soyad"].ToString().ToUpper();

                txtCinsiyet.Text = dr["cinsiyet"].ToString().ToUpper();
                string esastarih = dr["dogumtarihi"].ToString().ToUpper();
                txtDogumTarihi.Text = System.Convert.ToDateTime(esastarih).ToShortDateString();
                txtDogumYeri.Text = dr["dogumyeri"].ToString().ToUpper();
                txtBabaadi.Text = dr["babaadi"].ToString().ToUpper();
                txtAnneadi.Text = dr["anneadi"].ToString().ToUpper();
            }
            dr.Close();
            dr = null;
            if (txtKimlik.Text == "")
            {
                txtKimlik.Text = "Kayıt Bulunamadı";
            }
            if (txtAd.Text == "")
            {
                txtAd.Text = "Kayıt Bulunamadı";
            }
            if (txtCinsiyet.Text == "")
            {
                txtCinsiyet.Text = "Kayıt Bulunamadı";
            }
            if (txtSoyad.Text == "")
            {
                
                txtSoyad.Text = "Kayıt Bulunamadı";
            }
            if (txtDogumTarihi.Text == "")
            {
                txtDogumTarihi.Text = "Kayıt Bulunamadı";
            }
            if (txtDogumYeri.Text == "")
            {
                txtDogumYeri.Text = "Kayıt Bulunamadı";
            }
            if (txtBabaadi.Text == "")
            {
                txtBabaadi.Text = "Kayıt Bulunamadı";
            }
            if (txtAnneadi.Text == "")
            {
                txtAnneadi.Text = "Kayıt Bulunamadı";
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RandevuArama ra = new RandevuArama();
            ra.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RandevuArama ra = new RandevuArama();
            ra.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
           
        }

        private void txtGecerliParola_Enter(object sender, EventArgs e)
        {
      
        }

        private void txtYeniParola_Click(object sender, EventArgs e)
        {

        }

                UyeOl uyeol = new UyeOl();
        private void btnKaydetİletisim_Click(object sender, EventArgs e)
        {
            RegexUtilities regexUtilities = new RegexUtilities();
            //foreach (Control ctl in this.pnlİletisim.Controls)
            //{
            //    if (ctl is MaskedTextBox)
            //    {
            //        if (((MaskedTextBox)ctl).MaskFull == false)
            //        {
            //           MessageBox.Show(((MaskedTextBox)ctl).Name + " isimli maskedtextbox içeriği eksik");
            //        }
            //    }


            //}
             
           if (maskedTextBox1.MaskFull == false) { maskedTextBox1.BackColor = Color.Yellow; uyeol.Textuyari(); maskedTextBox1.Focus(); return; } else { maskedTextBox1.BackColor = Color.White; }
            if (maskedTextBox2.MaskFull == false) { maskedTextBox2.BackColor = Color.Yellow; uyeol.Textuyari(); maskedTextBox2.Focus(); return; } else { maskedTextBox2.BackColor = Color.White; }
            if (txtEmail.Text == "") { txtEmail.BackColor = Color.Yellow; uyeol.Textuyari(); txtEmail.Focus(); return; } else { txtEmail.BackColor = Color.White; }

            if (!regexUtilities.IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Lütfen mail formatına uygun bir mail adresi giriniz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtEmail.Clear();
                txtEmail.Focus();
            }
            else
            {
                con.Open();


                SqlCommand cmd = new SqlCommand("UPDATE iletisim1 SET ceptelefonu=@ceptelefonu,sabittelefon=@sabittelefon,email=@email where hastaid=@hastaid");
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@ceptelefonu", maskedTextBox1.Text);
                cmd.Parameters.AddWithValue("@sabittelefon", maskedTextBox2.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@hastaid", Uyeden_Randevuya.hastaid);
                
                    try
                    {
                        DialogResult dialogResult = MessageBox.Show("Sistemde bulunan iletişim bilginizi güncellemek üzeresiniz. \n\nİşlemi onaylıyor musunuz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dialogResult == DialogResult.Yes)
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("İletişim bilgileriniz başarıyla güncellenmiştir.", "Onay", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                        }

                    }
                    //Sistemde bulunan iletişim bilginizi güncellemek üzeresiniz
                    // İşlemi onaylıyor musunuz ?
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }

                
            



                con.Close();



            }





        }

        private void btnKaydetParola_Click(object sender, EventArgs e)
        {
            if (txtGecerliParola.Text == "") { txtGecerliParola.BackColor = Color.Yellow; uyeol.Textuyari(); txtGecerliParola.Focus(); return; } else { txtGecerliParola.BackColor = Color.White; }
            if (txtYeniParola.Text == "") { txtYeniParola.BackColor = Color.Yellow; uyeol.Textuyari(); txtYeniParola.Focus(); return; } else { txtYeniParola.BackColor = Color.White; }
            if (txtYeniParolaTekrar.Text == "") { txtYeniParolaTekrar.BackColor = Color.Yellow; uyeol.Textuyari(); txtYeniParolaTekrar.Focus(); return; } else { txtYeniParolaTekrar.BackColor = Color.White; }

          if(  txtYeniParola.Text.Length < 8 || txtYeniParola.Text.Length > 16)
            {
                MessageBox.Show("Parolanız en az 8 , en fazla 16 karakter olmalı ve parolanızda büyük/küçük harf ve rakam bulunmalıdır.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtYeniParola.Clear();
                txtYeniParolaTekrar.Clear();
                txtYeniParola.Focus();
            }

            if (hastaParolasi != txtGecerliParola.Text)
            {

                MessageBox.Show("Sistemdeki parola ile girdiğiniz parola uyuşmamaktadır. ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txtGecerliParola.Focus();
                txtGecerliParola.Clear();
            }

            else
            {

                if (txtYeniParola.Text == txtYeniParolaTekrar.Text)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE  hastalar3 SET hasta_sifre= @sifre where hasta_id=@hastaid", con);
                    cmd.Parameters.AddWithValue("@hastaid", Uyeden_Randevuya.hastaid);
                    cmd.Parameters.AddWithValue("@sifre", txtYeniParola.Text); // doktor puanı
                   
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Şifre güncelleme başarıyla gerçekleştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                    }
                    catch (Exception exx)
                    {
                        MessageBox.Show("hata " + exx);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler uyuşmuyor",
                    "Şifre Hatası",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation,
                   MessageBoxDefaultButton.Button1);
                    txtYeniParola.Clear();
                    txtYeniParolaTekrar.Clear();
                }
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RandevuArama ra = new RandevuArama();
                ra.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RandevuArama ra = new RandevuArama();
            ra.Show();
            this.Hide();
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 4)
            {
              label22.Visible  = true;
                label25.Visible = true;
                textBox1.Visible = true;
            }
            if (comboBox1.SelectedIndex == 0)
            {
                label22.Visible = false;
                label25.Visible = false;
                textBox1.Visible = false;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                label22.Visible = false;
                label25.Visible = false;
                textBox1.Visible = false;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                label22.Visible = false;
                label25.Visible = false;
                textBox1.Visible = false;
            }
            if (comboBox1.SelectedIndex == 3)
            {
                label22.Visible = false;
                label25.Visible = false;
                textBox1.Visible = false;
            }
        }

        private void btnGuvenlikKaydet_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("Bu alanda seçim zorunludur", "Bilgi");
            }
        }

        private void tabPageGuvenlik_Click(object sender, EventArgs e)
        {

        }

        private void pnlParola_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
