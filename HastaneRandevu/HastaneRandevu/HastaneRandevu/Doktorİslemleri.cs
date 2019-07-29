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
    public partial class Doktorİslemleri : Form
    {
        public Doktorİslemleri()
        {
            InitializeComponent();
            scr_val = 0;
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-44ST0UO\\SQLEXPRESS;Initial Catalog=Hastane;Integrated Security=True");
        int scr_val;
        DataTable dtbl = new DataTable();

        private void button1_Click(object sender, EventArgs e) // geri butonu
        {
            DoktorAnasayfa1 dc = new DoktorAnasayfa1();
            dc.Show();
            this.Hide();
        }

        //select randevuid,randevular.doktorid,tarih, saat,cinsiyet,hastalar3.dogumtarihi,hastalar3.dogumyeri,hastalar3.babaadi,hastalar3.anneadi, upper (hasta_ad + ' ' + hasta_soyad) as ' Hasta', upper(doktorad + ' ' +  doktorsoyad)as 'Hekim' from  ((randevular inner join doktorlar1 on doktorlar1.doktorid = randevular.doktorid) 	 inner join hastalar3 on hastalar3.hasta_id = randevular.hastaid) where doktorlar1.doktorid = '41' and randevular.tarih = '2018-11-08 'order by tarih desc, saat asc
        //select randevuid,randevular.doktorid,tarih, saat,cinsiyet,hastalar3.dogumtarihi,hastalar3.dogumyeri,hastalar3.babaadi,hastalar3.anneadi, upper (hasta_ad + ' ' + hasta_soyad) as ' Hasta', upper(doktorad + ' ' +  doktorsoyad)as 'Hekim' from  ((randevular inner join doktorlar1 on doktorlar1.doktorid = randevular.doktorid) 	 inner join hastalar3 on hastalar3.hasta_id = randevular.hastaid) where doktorlar1.doktorid = 41 and randevular.tarih = '2018-11-07 'order by tarih desc, saat desc
        private void Doktorİslemleri_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false; //Gizlenmesini sağlar 
            dataGridView1.BackgroundColor = Color.Turquoise;
            DataGridViewButtonColumn dgvBtn = new DataGridViewButtonColumn();

           
            dgvBtn.HeaderText = "";

            dgvBtn.Text = " Detay Göster";

            dgvBtn.Width = 100;
            dgvBtn.FillWeight = 20;


            dgvBtn.UseColumnTextForButtonValue = true;

            dgvBtn.DefaultCellStyle.BackColor = Color.Blue;

            dgvBtn.DefaultCellStyle.SelectionBackColor = Color.Red;


            dataGridView1.Columns.Add(dgvBtn);
            try
            {
                string ad = Uyeden_Randevuya.doktorad.ToString().ToUpper();
                string soyad = Uyeden_Randevuya.doktorsoyad.ToString().ToUpper();
                label1.Text = "Sn Dr. " + ad + " " + soyad;
            }
            catch (Exception exx)
            {
                label1.Text = "Hata meydana geldi." + exx;
            }
            label2.Text = DateTime.Now.ToString();
            kayitgetir();
            dataGridView1.Columns["doktorid"].Visible = false;
            dataGridView1.Columns["hekim"].Visible = false;

            dataGridView1.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[11].SortMode = DataGridViewColumnSortMode.NotSortable;
            //  dataGridView1.Columns[12].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.AllowUserToResizeColumns = false;




            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            label3.Text = dataGridView1.Rows.Count.ToString() + " kayıt seçildi ";
            dataGridView1.Columns.Count.ToString();


        }
        SqlDataAdapter da;
        DataSet ds;
        private void kayitgetir()
        {
            // string sorgu = "select top 20 tarih[Tarih], saat [Saat],randevuid [Randevuid],hastaid[Hastaid],randevular.doktorid [Doktorid], randevular.klinikid ,upper (doktorad + ' ' +  doktorsoyad) as [Hekim], upper(hastane_adi) as [Kurum Adı], klinik_adi as [Klinik Adı] from(((randevular inner join doktorlar1 on doktorlar1.doktorid = randevular.doktorid) inner join osman_hastane1 on osman_hastane1.hastane_id = randevular.hastaneid) inner join klinikler1 on klinikler1.klinik_id = randevular.klinikid)  where hastaid = ' " + Uyeden_Randevuya.hastaid + "' order by tarih desc,saat desc";
            string sorgu = "select  randevuid as 'Randevu No',upper(hasta_ad + ' ' + hasta_soyad) as ' İsim Soyisim' ,tarih as ' Randevu Tarihi', saat as 'Randevu Saati',cinsiyet ' Cinsiyet',randevular.doktorid,hastalar3.dogumtarihi as ' Hasta Doğum Tarihi',hastalar3.babaadi as ' Hastanın Baba Adı ',hastalar3.anneadi as ' Hastanın Anne Adı',  upper(doktorad + ' ' + doktorsoyad) as 'Hekim',upper(hastalar3.dogumyeri ) as ' Hasta Doğum Yeri'  from((randevular inner join doktorlar1 on doktorlar1.doktorid = randevular.doktorid)   inner join hastalar3 on hastalar3.hasta_id = randevular.hastaid) where doktorlar1.doktorid = ' " + Uyeden_Randevuya.doktorid + "' order by tarih desc, saat asc";



            //HER ŞEYİ GETİREN SORGU AŞAĞIDAKİ:


            //select top 20 tarih[Tarih],upper (hasta_ad + ' ' +  hasta_soyad) as 'Hasta Ad-Soyad',  saat [Saat],randevuid [Randevuid],hastaid[Hastaid],randevular.doktorid [Doktorid],randevular.klinikid , upper (doktorad + ' ' +  doktorsoyad) as [Hekim], upper(hastane_adi) as [Kurum Adı], klinik_adi as [Klinik Adı] from((((randevular inner join doktorlar1 on doktorlar1.doktorid = randevular.doktorid) inner join osman_hastane1 on osman_hastane1.hastane_id = randevular.hastaneid) inner join klinikler1 on klinikler1.klinik_id = randevular.klinikid)inner join hastalar3 on hastalar3.hasta_id = randevular.hastaid)  where hastaid = ' 82' order by tarih desc,saat desc;

            con.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter(sorgu, con);


            //"select tarih, doktorad, doktorsoyad, hastane_adi, klinik_adi from(((randevular inner join doktorlar1 on doktorlar1.doktorid = randevular.doktorid) inner join osman_hastane1 on osman_hastane1.hastane_id = randevular.hastaneid) inner join klinikler1 on klinikler1.klinik_id = randevular.klinikid)  where hastaid = ' "+ doktor_randevu_al_gel.hastaneid + "' order by tarih desc"


            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);



            dataGridView1.DataSource = dtbl;


            con.Close();





        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         
            int index = e.RowIndex;
            int index2 = e.ColumnIndex; 
            if(e.RowIndex  < 0)
            {
                return;
            }
            if (e.RowIndex >= 0 )
            {
                     DataGridViewRow selectedrow = dataGridView1.Rows[index];
                Doktor_Randevu_Detay.randevuid = selectedrow.Cells[1].Value.ToString();
                Doktor_Randevu_Detay.hastaadsoyad = selectedrow.Cells[2].Value.ToString();
                Doktor_Randevu_Detay.randevutarihi = selectedrow.Cells[3].Value.ToString();
                Doktor_Randevu_Detay.saat = selectedrow.Cells[4].Value.ToString();
                Doktor_Randevu_Detay.cinsiyet = selectedrow.Cells[5].Value.ToString();
                Doktor_Randevu_Detay.doktorid = selectedrow.Cells[6].Value.ToString();
                Doktor_Randevu_Detay.hastadogumtarihi = selectedrow.Cells[7].Value.ToString();
                Doktor_Randevu_Detay.hastababaadi = selectedrow.Cells[8].Value.ToString();
                Doktor_Randevu_Detay.hastaanneadi = selectedrow.Cells[9].Value.ToString();
                Doktor_Randevu_Detay.doktoradsoyad = selectedrow.Cells[10].Value.ToString();
                Doktor_Randevu_Detay.hastadogumyeri = selectedrow.Cells[11].Value.ToString();
            }
            DetayGoster da = new DetayGoster(); 
            da.Show();
            this.Hide();
            

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns[0].Index)
            {
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                // Set the Cell's ToolTipText.  In this case we're retrieving the value stored in 
                // another cell in the same row (see my Mernote below).
                ToolTip toolTip1 = new ToolTip();

                cell.ToolTipText = " Detayları Gör ";

            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            var current = dataGridView1.CurrentRow;
            if (current == null) // Means that you've not clicked the column header
            {
                return;
                //Display the value of a DataGridView's cell to a TextBox    
            }
        }
    }
}
