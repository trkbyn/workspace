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
    public partial class RandevuArama : Form
    {
      
        public RandevuArama()
        {
            InitializeComponent();
            
           
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-44ST0UO\\SQLEXPRESS;Initial Catalog=Hastane;Integrated Security=True");

        String[] saatler_ideal = new String[] { "9.00", "9.15", "9.30", "9.45","10.00","10.15", "10.30", "10.45", "11.00", "11.15", "11.30", "11.45","12.00", "12.15","12.30","12.45","13.00" , "13.15","13.30","13.45","15.00","15.15","15.30","15.45","16.00","16.15","16.30","16.45"};

        
     
        private void RandevuArama_Load(object sender, EventArgs e)
        {
            pnlStars.Visible = false;
       
           // tabControl1.SelectedTab = tabHesapBilgilerim;
            button12.FlatStyle = FlatStyle.Flat;
            button28.FlatStyle = FlatStyle.Flat;
            button4.FlatStyle = FlatStyle.Flat;
            button7.FlatStyle = FlatStyle.Flat;
            button11.FlatStyle = FlatStyle.Flat;
            button27.FlatStyle = FlatStyle.Flat;
            button5.FlatStyle = FlatStyle.Flat;
            button6.FlatStyle = FlatStyle.Flat;
            button10.FlatStyle = FlatStyle.Flat;
            button26.FlatStyle = FlatStyle.Flat;
            button14.FlatStyle = FlatStyle.Flat;
            button15.FlatStyle = FlatStyle.Flat;
            button16.FlatStyle = FlatStyle.Flat;
            button17.FlatStyle = FlatStyle.Flat;
            button18.FlatStyle = FlatStyle.Flat;
            button19.FlatStyle = FlatStyle.Flat;
            button20.FlatStyle = FlatStyle.Flat;
            button21.FlatStyle = FlatStyle.Flat;
            button22.FlatStyle = FlatStyle.Flat;
            button23.FlatStyle = FlatStyle.Flat;
            button24.FlatStyle = FlatStyle.Flat;
            button25.FlatStyle = FlatStyle.Flat;

            Form1 form1 = new Form1();
            RandevuGecmisi rg = new RandevuGecmisi();
            
            





            grbHosgeldin.Visible = true;
            button13.Text = "09:30";
            button3.Text = "10:00";
            button8.Text = "10:15";
            button12.Text = "10:30";
            button4.Text = "11:00";
            button7.Text = "11:15";
            button11.Text = "11:30";
            button5.Text = "12:00";
            button6.Text = "12:15";
            button10.Text = "12:30";
            button14.Text = "13:00";
            button15.Text = "13:15";
            button16.Text = "13:30";
            tabsaatler.Visible = false;
            label22.Visible= false;
            label19.Text = "14:00-15:00 öğle tatilimizdir. ";
                


            try
            {
                string ad = Uyeden_Randevuya.ad.ToString();
                string soyad = Uyeden_Randevuya.soyad.ToString();
                label1.Text = "Sn. " + ad.ToUpper() + " " + soyad.ToUpper();
            }catch (Exception exx)
            {
               label1.Text =  "Hata meydana geldi." + exx;
            }
            dateTimePicker1.MinDate = DateTime.Today.AddDays(1);

            

            label1.Visible = true;
            lblTarih.Text = DateTime.Now.ToString();

            // con.Open();

            //   SqlCommand cmd = new SqlCommand("SELECT il_adi FROM osman_hastane1 GROUP BY il_adi", con);
            //"SELECT il_adi FROM osman_hastane1 GROUP BY il_adi",
            //  SqlDataReader da = cmd.ExecuteReader();
            // cmbSehir.SelectionChangeCommitted -= cmbSehir_SelectionChangeCommitted ;


            DataTable dt = new DataTable();



             SqlDataAdapter da = new SqlDataAdapter("SELECT il_adi,sehirid FROM osman_hastane1 where sehirid>0 GROUP BY il_adi,sehirid", con);
            da.Fill(dt);
            
            cmbSehir.ValueMember = "sehirid";
            cmbSehir.DisplayMember = "il_adi";


            DataRow row = dt.NewRow();
            
            row[0] = "İl seçiniz";
            
            dt.Rows.InsertAt(row, 0);
          


            

            cmbSehir.DataSource = dt;
         

            

            //////////////////////////////////
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "Select klinikler1.klinik_adi ,klinikler1.hastane_id,osman_hastane1.hastane_adi from klinikler1 join osman_hastane1 on klinikler1.hastane_id = osman_hastane1.hastane_id order by klinik_adi  ";
            komut.Connection = con;
            komut.CommandType = CommandType.Text;
            
            con.Open();
            DataTable taa = new DataTable();
            SqlDataAdapter daa = new SqlDataAdapter(komut);
            daa.Fill(taa);
            con.Close();

            ///////////////////////////////

            // doktor_randevu_al_gel.doktoradi = dataGridView1.Rows[0].Cells[0].Value.ToString();
           



            pnlStars.Enabled = false;
            cmbİlce.Enabled = false;
            cmbKlinik.Enabled = false;
            cmbHastane.Enabled = false;
            cmbDoktor.Enabled = false;

         //   kayitGetir();

        }

        private void kayitGetir()
        {
            con.Open();
            string kayit = "SELECT * from randevular";
            //musteriler tablosundaki tüm kayıtları çekecek olan sql sorgusu.
            SqlCommand komut = new SqlCommand(kayit, con);
            //Sorgumuzu ve baglantimizi parametre olarak alan bir SqlCommand nesnesi oluşturuyoruz.
            SqlDataAdapter da = new SqlDataAdapter(komut);
            //SqlDataAdapter sınıfı verilerin databaseden aktarılması işlemini gerçekleştirir.
            DataTable dt = new DataTable();
            da.Fill(dt);
            //Bir DataTable oluşturarak DataAdapter ile getirilen verileri tablo içerisine dolduruyoruz.
            dataGridView1.DataSource = dt;
            //Formumuzdaki DataGridViewin veri kaynağını oluşturduğumuz tablo olarak gösteriyoruz.
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }



        private void kimlikBilgileriToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
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
                txtDogumTarihi.Text =  System.Convert.ToDateTime(esastarih).ToShortDateString();
                txtDogumYeri.Text = dr["dogumyeri"].ToString().ToUpper();
                txtBabaadi.Text = dr["babaadi"].ToString().ToUpper();
                txtAnneadi.Text = dr["anneadi"].ToString().ToUpper();
            }
            dr.Close();
            dr = null;
            con.Close();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            
        }

        private void cmbSehir_SelectedIndexChanged(object sender, EventArgs e)
        {

            cmbİlce.Enabled = true;
            cmbKlinik.Enabled = true;
            cmbHastane.Enabled = true;
            cmbDoktor.Enabled = true;
            pnlStars.Enabled = true;


            if (cmbSehir.SelectedIndex ==0)  //!= -1)
            {
                try { cmbİlce.Items.Clear();    } catch (Exception ) { cmbİlce.Text = ""; }
                try { cmbHastane.Items.Clear(); } catch (Exception ) { cmbHastane.Text = ""; }
                try  { cmbKlinik.Items.Clear(); } catch (Exception ) { cmbKlinik.Text = ""; }
                try { cmbDoktor.Items.Clear();  } catch (Exception ) { cmbDoktor.Text = ""; }

                cmbİlce.Enabled = false;
                cmbHastane.Enabled = false;
                cmbKlinik.Enabled = false;
                cmbDoktor.Enabled = false;
                pnlStars.Enabled = false;

                cmbHastane.SelectedIndex = -1;
                cmbİlce.SelectedIndex = -1;
                cmbKlinik.SelectedIndex = -1;
                cmbDoktor.SelectedIndex = -1;


            }


            if (cmbSehir.SelectedIndex >-1)  //!= -1)
            {
                // cmbSehir.SelectionChangeCommitted -= cmbSehir_SelectionChangeCommitted;
                
                DataTable dt = new DataTable();
                string bune = cmbSehir.Text;     //SelectedValue.ToString();
                
                SqlDataAdapter daa = new SqlDataAdapter("SELECT il_adi,ilce_adi FROM osman_hastane1 where il_adi ='" + cmbSehir.Text + "' AND  sehirid>-1 GROUP BY il_adi,ilce_adi", con);
                daa.Fill(dt);
                cmbİlce.ValueMember = "sehirid";
                cmbİlce.DisplayMember = "ilce_adi";
                cmbİlce.DataSource = dt;

                //   cmbSehir.SelectionChangeCommitted += cmbSehir_SelectionChangeCommitted;

            }


        }

        private void cmbİlce_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (cmbSehir.SelectedIndex > -1)  //!= -1)
            {

                // cmbSehir.SelectionChangeCommitted -= cmbSehir_SelectionChangeCommitted;



                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter("select il_adi,ilce_adi,hastane_adi,hastane_id from osman_hastane1 where il_adi = '" + cmbSehir.Text + "' and ilce_adi='" + cmbİlce.Text + "' and       sehirid > -1 order by il_adi,ilce_adi,hastane_adi,hastane_id", con);
                da2.Fill(dt2);
                cmbHastane.ValueMember = "hastane_id";
                cmbHastane.DisplayMember = "hastane_adi";
                cmbHastane.DataSource = dt2;



                //   cmbSehir.SelectionChangeCommitted += cmbSehir_SelectionChangeCommitted;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            il_ilce_hastane_klinik.il = cmbSehir.SelectedValue.ToString();
            il_ilce_hastane_klinik.ilce = cmbİlce.SelectedValue.ToString();
         //   il_ilce_hastane_klinik.hastane = cmbHastane.SelectedItem.ToString();
        //    il_ilce_hastane_klinik.klinik = cmbKlinik.SelectedValue.ToString();
        //    il_ilce_hastane_klinik.doktor = cmbDoktor.SelectedItem.ToString();

         //   RandevuGoster randevuGoster = new RandevuGoster();
          //    randevuGoster.Show();
            //  this.Hide();
            // EN SON GELECEK !!!
        }




        private void cmbKlinik_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmbDoktor.Items.Clear();

            if (cmbKlinik.SelectedIndex > -1)
            {
                DataTable dt2 = new DataTable();
                string aa = cmbKlinik.SelectedValue.ToString();

             //   if (aa == "System.Data.DataRowView") { cmbKlinik.SelectedIndex = 0; };

                string sqlcumle = "SELECT upper(doktorad) + ' '+ upper(doktorsoyad ) AS Kisi, doktorid from doktorlar1 where hastane_id = '" + cmbHastane.SelectedValue + "'" + " and klinikid='" + cmbKlinik.SelectedValue + "'";
                SqlDataAdapter da2 = new SqlDataAdapter(sqlcumle, con);
                da2.Fill(dt2);
                cmbDoktor.ValueMember = "doktorid";
                cmbDoktor.DisplayMember = "Kisi";
                cmbDoktor.DataSource = dt2;


                int kactanevar = cmbDoktor.Items.Count;
                if (kactanevar < 1)
                {
                    cmbDoktor.Text = "";
                }

            }
        }



        private void cmbHastane_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            if (cmbSehir.SelectedIndex > -1)  //!= -1)
            {

                // cmbSehir.SelectionChangeCommitted -= cmbSehir_SelectionChangeCommitted;



                DataTable dt22 = new DataTable();
              //  string aa = cmbHastane.SelectedValue.ToString();
                string sqlcumle = "select klinik_adi,klinik_id from klinikler1 where hastane_id = '" + cmbHastane.SelectedValue + "'";
                SqlDataAdapter da22 = new SqlDataAdapter("select klinik_adi,klinik_id from klinikler1", con);
                da22.Fill(dt22);
                cmbKlinik.ValueMember = "klinik_id";
                cmbKlinik.DisplayMember = "klinik_adi";
                cmbKlinik.DataSource = dt22;

                //   cmbSehir.SelectionChangeCommitted += cmbSehir_SelectionChangeCommitted;

            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)  // randevu ara
        {
            grbHosgeldin.Visible = false;

          if(cmbSehir.SelectedIndex == 0)
            {
                tabsaatler.Visible = false;
                label22.Visible = false;
                grbHosgeldin.Visible = true;
                MessageBox.Show("Lütfen il seçiniz","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                
            }

           else if (cmbDoktor.SelectedIndex == -1 )
            {
                MessageBox.Show("Bu klinikteki doktorlar şu an izinlidir!" +
                    "\nLütfen başka bir hastane seçiniz!"," Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1);
                tabsaatler.Visible = false;
                label22.Visible = false;
                grbHosgeldin.Visible = true;
                return;
            }

            else
            {
                tabsaatler.Visible = true;
                doktor_randevu_al_gel.sehiradi = cmbSehir.Text;
                doktor_randevu_al_gel.sehirid = cmbSehir.SelectedValue.ToString();

                doktor_randevu_al_gel.ilceadi = cmbİlce.Text;
                // doktor_randevu_al_gel.ilceid = cmbİlce.SelectedValue.ToString();

                doktor_randevu_al_gel.hastaneadi = cmbHastane.Text;
                doktor_randevu_al_gel.hastaneid = cmbHastane.SelectedValue.ToString();

                doktor_randevu_al_gel.klinikadi = cmbKlinik.Text;
                doktor_randevu_al_gel.klinikid = cmbKlinik.SelectedValue.ToString();


                doktor_randevu_al_gel.doktoradi = cmbDoktor.Text;
                doktor_randevu_al_gel.doktorid = cmbDoktor.SelectedValue.ToString();

                doktor_randevu_al_gel.randevuzamani = dateTimePicker1.Text;

                tabPage1.Text = dateTimePicker1.Text;
                label22.Visible = true;
                label22.Text = "Dr. " + cmbDoktor.Text;
              //  randevudoldur();
               varolanlari_disable_yap();
                con.Close();
            }
        }public string randevuid = "";
    
        public void varolanlari_disable_yap()
        {
            con.Open();

            butonlari_sifirla();
           

            string[] saatler_gercek = new String[100];

         


            string tarih1 =doktor_randevu_al_gel.randevuzamani;
            DateTime tarih3 =   System.Convert.ToDateTime(tarih1);
            int yil = tarih3.Year;
            int ay= tarih3.Month;
            int gun = tarih3.Day;
            DateTime tarih2 = new DateTime(yil, ay, gun);
            int doktorid = System.Convert.ToInt32(doktor_randevu_al_gel.doktorid);
            int klinikid = System.Convert.ToInt32(doktor_randevu_al_gel.klinikid);



            string tarih4 = tarih2.ToShortDateString();
            tarih4 = tarih4.Replace('.', '-');
            tarih4 = yil.ToString() + "-" + ay.ToString() + "-" + gun.ToString();

 
            
            string sqlcumle = "select * from randevular where  tarih= + CONVERT(varchar, '" + tarih4 + "', 23)" + "  and doktorid=" + doktorid + "  and klinikid=" + klinikid + " order by saat";

            SqlCommand sqlcom = new SqlCommand(sqlcumle, con);

 

           

            //SqlDataReader reader =new SqlDataReader;
            SqlDataReader reader1 = sqlcom.ExecuteReader();
            int kactane = 0;
            while (reader1.Read()==true)
            {
                saatler_gercek[kactane] = reader1["saat"].ToString();
                string saat = saatler_gercek[kactane];
                DateTime saat1 = System.Convert.ToDateTime(saat);
                string saat2 = saat1.ToShortTimeString();

                kactane = kactane + 1;
                var results = Array.FindAll(saatler_ideal, s => s.Equals(saat2));
                if (!(results is  null))
                {
                   

                    if (saat == "09:00:00") { button1.Enabled=  false; button1.BackColor = Color.Yellow; }
                    if (saat == "09:15:00") { button9.Enabled = false; button9.BackColor = Color.Yellow; }
                    if (saat == "09:30:00") { button13.Enabled = false; button13.BackColor = Color.Yellow; }
                    if (saat == "09:45:00") { button29.Enabled = false; button29.BackColor = Color.Yellow; }
                    if (saat == "10:00:00") { button3.Enabled = false; button3.BackColor = Color.Yellow; }
                    if (saat == "10:15:00") { button8.Enabled = false; button8.BackColor = Color.Yellow; }
                    if (saat == "10:30:00") { button12.Enabled = false; button12.BackColor = Color.Yellow; }
                    if (saat == "10:45:00") { button28.Enabled = false; button28.BackColor = Color.Yellow; }
                    if (saat == "11:00:00") { button4.Enabled = false; button4.BackColor = Color.Yellow; }
                    if (saat == "11:15:00") { button7.Enabled = false; button7.BackColor = Color.Yellow; }
                    if (saat == "11:30:00") { button11.Enabled = false; button11.BackColor = Color.Yellow; }
                    if (saat == "11:45:00") {  button27.Enabled = false; button27.BackColor = Color.Yellow; }
                    if (saat == "12:00:00") { button5.Enabled = false; button5.BackColor = Color.Yellow; }
                    if (saat == "12:15:00") { button6.Enabled = false; button6.BackColor = Color.Yellow; }
                    if (saat == "12:30:00") { button10.Enabled = false; button10.BackColor = Color.Yellow; }
                    if (saat == "12:45:00") { button26.Enabled = false; button26.BackColor = Color.Yellow; }
                    if (saat == "13:00:00") { button14.Enabled = false; button14.BackColor = Color.Yellow; }
                    if (saat == "13:15:00") { button15.Enabled = false; button15.BackColor = Color.Yellow; }
                    if (saat == "13:30:00") { button16.Enabled = false; button16.BackColor = Color.Yellow; }
                    if (saat == "13:45:00") { button17.Enabled = false; button17.BackColor = Color.Yellow; }
                    if (saat == "15:00:00") { button18.Enabled = false; button18.BackColor = Color.Yellow; }
                    if (saat == "15:15:00") { button19.Enabled = false; button19.BackColor = Color.Yellow; }
                    if (saat == "15:30:00") { button20.Enabled = false; button20.BackColor = Color.Yellow; }
                    if (saat == "15:45:00") { button21.Enabled = false; button21.BackColor = Color.Yellow; }
                    if (saat == "16:00:00") { button22.Enabled = false; button22.BackColor = Color.Yellow; }
                    if (saat == "16:15:00") { button23.Enabled = false; button23.BackColor = Color.Yellow; }
                    if (saat == "16:30:00") { button24.Enabled = false; button24.BackColor = Color.Yellow; }
                    if (saat == "16:45:00") { button25.Enabled = false; button25.BackColor = Color.Yellow; }
                    /* if (saat == "11:45:00") { button27.Enabled = false; button27.BackColor = Color.Yellow; }
                     if (saat == "11:45:00") { button27.Enabled = false; button27.BackColor = Color.Yellow; }
                     if (saat == "11:45:00") { button27.Enabled = false; button27.BackColor = Color.Yellow; }
                     if (saat == "11:45:00") { button27.Enabled = false; button27.BackColor = Color.Yellow; }
                     if (saat == "11:45:00") { button27.Enabled = false; button27.BackColor = Color.Yellow; }
                     if (saat == "11:45:00") { button27.Enabled = false; button27.BackColor = Color.Yellow; }
                     if (saat == "11:45:00") { button27.Enabled = false; button27.BackColor = Color.Yellow; }
                     */
                    Dolutooltip();
   
                }
                else
                {
                    this.Enabled = true;
                }

            }
 

            //SqlCommand cmd = new SqlCommand(" select * from randevular where tarih = " , con);

        }
        
        public void butonlari_sifirla()
        {


            foreach (Control ctrl in tabPage1.Controls)
            {
                if (ctrl is Button)
                {
                    //if (ctrl.BackColor != Color.Yellow)
                    {
                        ctrl.Enabled = true;
                        ctrl.BackColor = Color.Teal;
                    }
                }

            }

        }
        public void Dolutooltip()
        {
            foreach (Control ctrl in tabPage1.Controls)
            {
                if (ctrl is Button)
                {
                    if(ctrl.BackColor == Color.Teal)
                    { 
                        ToolTip tt = new ToolTip();

                        tt.SetToolTip(ctrl, "Uygun");

                        tt.IsBalloon = true;

                    }
                }

            }
        }


        private void btnTemizle_Click_1(object sender, EventArgs e)
        {
            cmbSehir.SelectedIndex = 0;
            cmbHastane.SelectedIndex = -1;
            cmbİlce.SelectedIndex = -1;
            cmbKlinik.SelectedIndex = -1;
            cmbDoktor.SelectedIndex = -1;

            cmbİlce.Enabled = false;
            cmbKlinik.Enabled = false;
            cmbHastane.Enabled = false;
            cmbDoktor.Enabled = false;
            pnlStars.Enabled = false;
            tabsaatler.Visible = false;
            grbHosgeldin.Visible = true;
            label22.Visible = false;


        }

        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void lblDoktor_Click(object sender, EventArgs e)
        {

        }

        private void lblHastane_Click(object sender, EventArgs e)
        {

        }

        private void lblKlinik_Click(object sender, EventArgs e)
        {

        }

        private void lblİlce_Click(object sender, EventArgs e)
        {

        }

        private void lblSehir_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbSehir_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void grbSaat_Enter(object sender, EventArgs e)
        {

        }

        private void tabRandevuAra_Click(object sender, EventArgs e)
        {

        }

        private void grbHosgeldin_Enter(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void pbfour_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)  //9.00
        {

            string saat = "9:00";

            butonlar(saat.ToString());
      
        }
        public void uyarı()
        {
           DialogResult sec =  MessageBox.Show("Randevu bilgilerinizi kontrol ettikten sonra randevunuzu kaydedebilirsiniz!" , " Bilgi" , MessageBoxButtons.OK,MessageBoxIcon.Information);
          
                RandevuGoster goster = new RandevuGoster();
                goster.Show();
                this.Hide();
            
           
                     
                    
                      
        }


        public void butonlar(string saat)
        {

            doktor_randevu_al_gel.saat = saat.ToString();
            doktor_randevu_al_gel.doktorid = cmbDoktor.SelectedValue.ToString();
            doktor_randevu_al_gel.doktoradi = cmbDoktor.Text.ToString();

            doktor_randevu_al_gel.sehirid = cmbSehir.SelectedValue.ToString();
            doktor_randevu_al_gel.sehiradi = cmbSehir.Text.ToString();

            doktor_randevu_al_gel.ilceid = cmbİlce.SelectedValue.ToString();
            doktor_randevu_al_gel.ilceadi = cmbİlce.Text.ToString();

            doktor_randevu_al_gel.hastaneid = cmbHastane.SelectedValue.ToString();
            doktor_randevu_al_gel.hastaneadi = cmbHastane.Text.ToString();

            doktor_randevu_al_gel.klinikid = cmbKlinik.SelectedValue.ToString();
            doktor_randevu_al_gel.klinikadi = cmbKlinik.Text.ToString();

            doktor_randevu_al_gel.hastaid = Uyeden_Randevuya.hastaid;
           

            try {
                con.Open();
                string sqlcumle = "insert into randevular (tarih,saat,dolubos,hastaid,doktorid,klinikid,hastaneid) values (@tarih,@saat,@dolubos,@hastaid,@doktorid,@klinikid,@hastaneid)";
                SqlCommand cmd = new SqlCommand(sqlcumle, con);
                string tarih1 = dateTimePicker1.Value.ToString();
                DateTime tarih2 = System.Convert.ToDateTime(tarih1);
                cmd.Parameters.AddWithValue("@tarih", tarih2);
                cmd.Parameters.AddWithValue("@saat", saat.ToString());
                cmd.Parameters.AddWithValue("@doktorid", cmbDoktor.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@klinikid", cmbKlinik.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@hastaid", doktor_randevu_al_gel.hastaid);
                cmd.Parameters.AddWithValue("@dolubos", 1);
                cmd.Parameters.AddWithValue("@hastaneid", cmbHastane.SelectedValue.ToString());

                int aa =cmd.ExecuteNonQuery();
               // MessageBox.Show(aa.ToString());
                //string sqlcumle = "insert into randevular (tarih,saat,dolubos,hastaid,doktorid,klinikid) values "(; //@tarih,@saat,@dolubos,@hastaid,@doktorid,@klinikid"; ";



                // MessageBox.Show("Kayıt Başarıyla Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //   ("INSERT INTO Biletler(musteri_id,koltuk_no,satismirezervasyonmu,sefer_id,cinsiyet) VALUES ('" + musteri_id + "','" + koltuk_no + "','" + satismirezervasyonmu + "','" + sefer_id + "','" + yolcu_cinsiyet + "')", DB.baglanti);

                uyarı();
            }
            catch(Exception  exx)
            {
                MessageBox.Show(exx.Message.ToString() + "   randevu hata");
            }

            con.Close();
            
        }



        private void button9_Click(object sender, EventArgs e) // 9.15
        {
            string saat = "09:15";
           
            butonlar(saat);
        }

        private void button13_Click(object sender, EventArgs e) // 09.30
        {
            string saat = "09:30";
           
            butonlar(saat);
            
        }

        private void button29_Click(object sender, EventArgs e) //9.45
        {
            string saat = "09:45";
           
            butonlar(saat);
        }

        private void button3_Click(object sender, EventArgs e) //10.00
        {

            string saat = "10:00";
            
            butonlar(saat);
        }

        private void button8_Click(object sender, EventArgs e)//10.15
        {
            string saat = "10:15";
           
            butonlar(saat);
        }

        private void button12_Click(object sender, EventArgs e)//10.30
        {

            string saat = "10:30";
           
            butonlar(saat);
        }

        private void button28_Click(object sender, EventArgs e) //10.45
        {


            string saat = "10:45";
           
            butonlar(saat);
        }

        private void button4_Click(object sender, EventArgs e)//11.00
        {
            string saat = "11:00";
           
            butonlar(saat);
        }

        private void button7_Click(object sender, EventArgs e)//11.15
        {
            string saat = "11:15";
           
            butonlar(saat);
        }

        private void button11_Click(object sender, EventArgs e)//11.30
        {
            string saat = "11:30";
           
            butonlar(saat);
        }

        private void button27_Click(object sender, EventArgs e)//11.45
        {
            string saat = "11:45";
            
            butonlar(saat);
        }

        private void button5_Click(object sender, EventArgs e)
        {

            string saat = "12:00";
           
            butonlar(saat);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string saat = "12:15";
            
            butonlar(saat);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string saat = "12:30";
            
            butonlar(saat);
        }

        private void button26_Click(object sender, EventArgs e)
        {

            string saat = "12:45";
           
            butonlar(saat);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string saat = "13:00";
            
            butonlar(saat);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string saat = "13:15";
            
            butonlar(saat);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string saat = "13:30";
          
            butonlar(saat);
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            string saat = "13:45";
            
            butonlar(saat);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string saat = "15:00";
            
            butonlar(saat);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string saat = "15:15";
           
            butonlar(saat);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string saat = "15:30";
           
            butonlar(saat);
        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            string saat = "15:45";
            
            butonlar(saat);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            string saat = "16:00";
           
            butonlar(saat);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            string saat = "16:15";
           
            butonlar(saat);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            string saat = "16:30";
           
            butonlar(saat);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            string saat = "16:45";
           
            butonlar(saat);
        }

        private void tabHesapBilgilerim_Click(object sender, EventArgs e)
        {
           
        }

        private void grbHosgeldin_Enter_1(object sender, EventArgs e)
        {

        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void RandevuArama_MouseMove(object sender, MouseEventArgs e)
        {
          
        }

        private void gfgfdToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void iletişimBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            string hangitab = tabControl1.SelectedTab.Name.ToString();
            
            if (hangitab == "tabGecmis")
            {
                //if( RandevuGecmisi.listeler == null)
                // {
                //     MessageBox.Show("hata");
                //     return;
                // }
                // else
                // {
                // RandevuGecmisi frm1 = new RandevuGecmisi();


                // frm1.ShowDialog();

                // }
                RandevuGecmisi frm1 = new RandevuGecmisi();


                frm1.Show();
                this.Hide();

            }
            if (hangitab == "tabHesapBilgilerim")
            {
                //if( RandevuGecmisi.listeler == null)
                // {
                //     MessageBox.Show("hata");
                //     return;
                // }
                // else
                // {
                // RandevuGecmisi frm1 = new RandevuGecmisi();


                // frm1.ShowDialog();

                // }
                HesapBilgilerim frm1 = new HesapBilgilerim();


                frm1.Show();
                this.Hide();
            }
            if (hangitab == "tabPageDegerlendir")
            {
                //if( RandevuGecmisi.listeler == null)
                // {
                //     MessageBox.Show("hata");
                //     return;
                // }
                // else
                // {
                // RandevuGecmisi frm1 = new RandevuGecmisi();


                // frm1.ShowDialog();

                // }
                RandevuListele frm1 = new RandevuListele();


                frm1.Show();
                this.Hide();
            }
        }
    }
}
