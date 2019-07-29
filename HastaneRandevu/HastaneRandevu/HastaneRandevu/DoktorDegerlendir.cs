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
    public partial class DoktorDegerlendir : Form
    {
        string text = "Bu alana sağlık tesisi ile ilgili yorumlarınızı yazabilirsiniz";
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-44ST0UO\\SQLEXPRESS;Initial Catalog=Hastane;Integrated Security=True");
        bool kayitVarMi;
            RandevuListele rl = new RandevuListele();
        public DoktorDegerlendir()
        {
            InitializeComponent();
            txtYorum.Text = text;
        
        }

        private void DoktorDegerlendir_Load(object sender, EventArgs e)
        {
            int doktorid = System.Convert.ToInt32(doktor_randevu_al_gel.doktorid);
            int klinikid = System.Convert.ToInt32(doktor_randevu_al_gel.klinikid);
            int hastaid = System.Convert.ToInt32(doktor_randevu_al_gel.hastaid);
            int randevuid = System.Convert.ToInt32(doktor_randevu_al_gel.randevuid);
            kayitVarMi = false;
            SqlDataReader dr;
            try
            {
                
                SqlCommand komut = new SqlCommand("select randevupuan2,randevupuan,yorum from  randevuistatistik2 where randevuid=" + randevuid + "", con);
                    con.Open();

                dr = komut.ExecuteReader();
                if (dr.Read())
                {

                    kayitVarMi = true;
                    txtYorum.Text = dr[2].ToString();
                    switch (dr[0].ToString())
                    {
                        case "1":
                            rbHizmet1.Checked=true;
                            break;
                        case "2":
                            rbHizmet2.Checked = true;
                            break;
                        case "3":
                            rbHizmet3.Checked = true;
                            break;
                        case "4":
                            rbHizmet4.Checked = true;
                            break;
                        case "5":
                            rbHizmet5.Checked = true;
                            break;
                        
                    }
                    switch (dr[1].ToString())
                    {
                        case "1":
                            rbDoktor1.Checked = true;
                            break;
                        case "2":
                            rbDoktor2.Checked = true;
                            break;
                        case "3":
                            rbDoktor3.Checked = true;
                            break;
                        case "4":
                            rbDoktor4.Checked = true;
                            break;
                        case "5":
                            rbDoktor5.Checked = true;
                            break;

                    }
                }
                
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }

            this.ActiveControl = label1;
            txtHekim.ReadOnly = true;
            txtKlinik.ReadOnly = true;
            txtMuayeneTarihi.ReadOnly = true;
            txtSaglıkTesisi.ReadOnly = true;



            txtYorum.ForeColor = Color.Black;

            //  SqlCommand komut = new SqlCommand("select * from  hastalar3 where hasta_tc = '" + txtKimlik.Text + "' and hasta_sifre = '" + txtSifre.Text + "'", con);

            //  SqlDataReader dr = komut.ExecuteReader();
            string tarih1 = doktor_randevu_al_gel.randevuzamani;
            DateTime tarih3 = System.Convert.ToDateTime(tarih1);
            int yil = tarih3.Year;
            int ay = tarih3.Month;
            int gun = tarih3.Day;
            DateTime tarih2 = new DateTime(yil, ay, gun);



            string tarih4 = tarih2.ToShortDateString();
            tarih4 = tarih4.Replace('.', '-');
            tarih4 = gun.ToString() + "-" + ay.ToString() + "-" + yil.ToString();

            txtHekim.Text = doktor_randevu_al_gel.doktoradi;
            txtKlinik.Text = doktor_randevu_al_gel.klinikadi;
            txtMuayeneTarihi.Text = tarih4 + " " + doktor_randevu_al_gel.saat;
            txtSaglıkTesisi.Text = doktor_randevu_al_gel.hastaneadi;

            //rbDoktor1.Text = "1";
            //rbDoktor2.Text = "2";
            //rbDoktor3.Text = "3";
            //rbDoktor4.Text = "4";
            //rbDoktor5.Text = "5";
            //rbHizmet1.Text = "1";
            //rbHizmet2.Text = "2";
            //rbHizmet3.Text = "3";
            //rbHizmet4.Text = "4";
            //rbHizmet5.Text = "5";





        }

        private void txtYorum_Enter(object sender, EventArgs e)
        {
            if (txtYorum.Text == text)
            {
                txtYorum.Text = "";
                txtYorum.ForeColor = Color.SteelBlue;
            }
        }

        private void txtYorum_Leave(object sender, EventArgs e)
        {
            if (txtYorum.Text == "")
            {
                txtYorum.Text = text;
                txtYorum.ForeColor = Color.Black;

            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RandevuListele rl = new RandevuListele();
            rl.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnDegerlendir_Click(object sender, EventArgs e)
        {

            int doktorid = System.Convert.ToInt32(doktor_randevu_al_gel.doktorid);
            int klinikid = System.Convert.ToInt32(doktor_randevu_al_gel.klinikid);
            int hastaid = System.Convert.ToInt32(doktor_randevu_al_gel.hastaid);
            int randevuid = System.Convert.ToInt32(doktor_randevu_al_gel.randevuid);
            if (txtYorum.Text == text)
            {
                MessageBox.Show("Lütfen değerli yorumlarınızı bizimle paylaşınız", "Bilgi!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                txtYorum.Focus();
                return;
            }
            if (rbHizmet1.Checked == false && rbHizmet2.Checked == false && rbHizmet3.Checked == false && rbHizmet4.Checked == false && rbHizmet5.Checked == false )
            {
                MessageBox.Show("Lütfen aldığınız hizmetlere puan veriniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                rbHizmet5.Select();

                pnlHizmetrating.Focus();
                return;
             
            }
            if (rbDoktor1.Checked == false && rbDoktor2.Checked == false && rbDoktor3.Checked == false && rbDoktor4.Checked == false && rbDoktor5.Checked == false)
            {
                MessageBox.Show("Lütfen sizi muayene eden hekime puan veriniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                pnlDoktorrating.Focus();
                rbDoktor5.Select();
                return;

            }
            else
            {
               
                try
                {
                    string star = "";
                    if (rbDoktor1.Checked)
                    {
                        star = "1";
                    }
                    else if (rbDoktor2.Checked)
                    {
                        star = "2";
                    }
                    else if (rbDoktor3.Checked)
                    {
                        star = "3";
                    }
                    else if (rbDoktor4.Checked)
                    {
                        star = "4";
                    }
                    else if (rbDoktor5.Checked)
                    {
                        star = "5";
                    }
                    string star2 = "";

                    if (rbHizmet1.Checked)
                    {
                        star2 = "1";
                    }
                    else if (rbHizmet2.Checked)
                    {
                        star2 = "2";
                    }
                    else if (rbHizmet3.Checked)
                    {
                        star2 = "3";
                    }
                    else if (rbHizmet4.Checked)
                    {
                        star2 = "4";
                    }
                    else if (rbHizmet5.Checked)
                    {
                        star2 = "5";
                    }
                    if (kayitVarMi == false)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("insert into randevuistatistik2 (hastaid,doktorid,randevuid, randevupuan , randevupuan2,yorum)values(@hastaid,@doktorid,@randevuid,@randevupuan,@randevupuan2,@yorum)", con);
                        cmd.Parameters.AddWithValue("@hastaid", hastaid);
                        cmd.Parameters.AddWithValue("@doktorid", doktorid);
                        cmd.Parameters.AddWithValue("@randevuid", randevuid);
                        cmd.Parameters.AddWithValue("@randevupuan", star); // doktor puanı
                        cmd.Parameters.AddWithValue("@randevupuan2", star2); // hizmet puanı
                        cmd.Parameters.AddWithValue("@yorum", txtYorum.Text);
                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("İşlem başarıyla gerçekleştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

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
                    else if (kayitVarMi == true)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE  randevuistatistik2 SET randevupuan= @randevupuan,randevupuan2= @randevupuan2,yorum=@yorum where randevuid=@randevuid", con);
                        cmd.Parameters.AddWithValue("@randevuid", randevuid);
                        cmd.Parameters.AddWithValue("@randevupuan", star); // doktor puanı
                        cmd.Parameters.AddWithValue("@randevupuan2", star2); // hizmet puanı
                        cmd.Parameters.AddWithValue("@yorum", txtYorum.Text);
                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Güncelleme başarıyla gerçekleştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

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
                    //UPDATE randevuistatistik2
                    //  SET yorum = 'Alfred2 ' where istatistikid = '31';

                  

                    
                    RandevuListele rl = new RandevuListele();
                    rl.Show();
                    this.Hide();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                con.Close();
            }
        }
    }
}
