using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneRandevu
{
    public partial class DoktorSifreHatirla : Form
    {
        public DoktorSifreHatirla()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-44ST0UO\\SQLEXPRESS;Initial Catalog=Hastane;Integrated Security=True");
        RegexUtilities regexUtilities = new RegexUtilities();
        private void btnGonder_Click(object sender, EventArgs e)
        {

            if (txtKimlik.Text == "")
            {
                txtKimlik.BackColor = Color.Yellow;
                MessageBox.Show("Bu alanın doldurulması zorunludur", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKimlik.Focus();
                return;
            }
            else
            {

                txtKimlik.BackColor = Color.LightCyan;

            }
            if (txtEmail.Text == "")
            {
                txtEmail.BackColor = Color.Yellow;
                MessageBox.Show("Bu alanın doldurulması zorunludur", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }




            else
            {


                if (!regexUtilities.IsValidEmail(txtEmail.Text))
                {
                    MessageBox.Show("Lütfen mail formatına uygun bir mail adresi giriniz!!!", "Hata!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();

                    txtEmail.Clear();
                    return;
                }


                string gonderadi, gondersifre, gondermail,gondersoyadi;
                con.Open();
                SqlCommand command = new SqlCommand("Select * from doktorlar1 where doktortc ='" + txtKimlik.Text + "' and  doktoremail = '" + txtEmail.Text + "'", con);
                SqlDataReader oku = null;
                oku = command.ExecuteReader();

                if (oku.Read())
                {
                    gonderadi = oku["doktorad"].ToString();
                    gondersifre = oku["doktorsifre"].ToString();
                    gondersoyadi = oku["doktorsoyad"].ToString();

                    gondermail = oku["doktoremail"].ToString();
                    con.Close();

                    MailMessage ePosta = new MailMessage();
                    ePosta.From = new MailAddress("trkbyn@gmail.com");
                    ePosta.To.Add(gondermail);
                    ePosta.Subject = "Şifre Hatırlatma";
                    ePosta.Body = "Sayın Dr.  " + gonderadi.ToUpper() + " " + gondersoyadi.ToUpper() +  "\nŞifreniz : " + gondersifre;
                    SmtpClient smtp = new SmtpClient();


                    smtp.Credentials = new System.Net.NetworkCredential("trkbyn@gmail.com", "samsun55..");


                    smtp.Port = 587;


                    smtp.Host = "smtp.gmail.com";


                    smtp.EnableSsl = true;


                    object userState = ePosta;

                    /*
                        client.Credentials = New System.Net.NetworkCredential("turkishajan710@gmail.com", "ajan_turkish017")
                        client.Port = 587
                        client.Host = "smtp.gmail.com"
                        client.EnableSsl = True
                        client.Send(msg)
                    */



                    //
                    try
                    {
                        //smtp.SendAsync(ePosta, (object)ePosta);
                        smtp.Send(ePosta.From.ToString(), ePosta.To.ToString(), ePosta.Subject, ePosta.Body);
                    }
                    catch (SmtpException ex)
                    {
                        MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
                    }
                    finally
                    {
                        con.Close();


                        pnlHatırla.Visible = false;


                        MessageBox.Show("Mail Başarıyla Gönderildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


                        DoktorAnasayfa1 anasayfa = new DoktorAnasayfa1();
                        anasayfa.Show();
                        this.Hide();

                    }


                }

                ///////////// hata var!!!!!!!!
                else


                {
                    Label label = new Label();
                    label.Text = "Girmiş olduğunuz e-posta hesabının geçersiz olduğu tespit edilmiştir!" +
                    "\n\n Parola yenileme işlemi için geçerli bir e-posta hesabınızın olması gerekmektedir.";


                    MessageBox.Show(label.Text,
  "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                    DoktorAnasayfa1 anasayfa = new DoktorAnasayfa1();
                    anasayfa.Show();
                    this.Hide();

                }

                con.Close();
            }










        }
        public bool Gonder(string konu, string icerik)
        {
            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress("trkbyn@gmail.com");//buraya kendi gmail hesabınız
            //
            ePosta.To.Add(txtKimlik.Text);//bura şifre unutanın maili textboxdan çekdiniz.


            ePosta.Subject = konu; //butonda veri tabanı çekdikden sonra aldımız değer konu değeri
            //
            ePosta.Body = icerik;  // buda şifremiz
            //
            SmtpClient smtp = new SmtpClient();
            //
            smtp.Credentials = new System.Net.NetworkCredential("trkbyn@gmail.com", "samsun55..");
            //kendi gmail hesabiniz var şifresi
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            object userState = ePosta;
            bool kontrol = true;
            try
            {
                smtp.SendAsync(ePosta, (object)ePosta);
            }
            catch (SmtpException ex)
            {
                kontrol = false;
                System.Windows.Forms.MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
            }
            return kontrol;

        }
        private void button1_Click(object sender, EventArgs e) // geri tuşu
        {
            DoktorAnasayfa1 doktorAnasayfa1 = new DoktorAnasayfa1();
            doktorAnasayfa1.Show();
            this.Hide();
        }

        private void DoktorSifreHatirla_Load(object sender, EventArgs e)
        {
            txtKimlik.Focus();
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
    }
}
