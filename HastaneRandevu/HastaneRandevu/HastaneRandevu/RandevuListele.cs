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
    public partial class RandevuListele : Form
    {
        public RandevuListele()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-44ST0UO\\SQLEXPRESS;Initial Catalog=Hastane;Integrated Security=True");

        private void RandevuListele_Load(object sender, EventArgs e)
        {

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //  dataGridView1.RowHeadersWidth = 7;
            // dataGridView1.Columns[3].Visible = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false; //Gizlenmesini sağlar 
           // dataGridView1.BackgroundColor = Color.Brown;

            DataGridViewButtonColumn dgvBtn = new DataGridViewButtonColumn();

            dataGridView1.Columns.Add(dgvBtn);

            dgvBtn.HeaderText = "";

            dgvBtn.Text = "Değerlendir";

            dgvBtn.UseColumnTextForButtonValue = true;

            dgvBtn.DefaultCellStyle.BackColor = Color.Blue;

            dgvBtn.DefaultCellStyle.SelectionBackColor = Color.Red;

            RandevuGecmisi rg = new RandevuGecmisi();
            kayitgetir();
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns["randevuid"].Visible = false;

           // dataGridView1.Columns["Tarih"].SortMode = DataGridViewColumnSortMode.NotSortable;


        }
        private void kayitgetir()
        {


            string sorgu = "select top 20 randevuid,tarih[Tarih], saat [Saat],randevuid [Randevuid],hastaid[Hastaid],randevular.doktorid [Doktorid], randevular.klinikid ,upper (doktorad + ' ' +  doktorsoyad) as [Hekim], upper(hastane_adi) as [Kurum Adı], klinik_adi as [Klinik Adı] from(((randevular inner join doktorlar1 on doktorlar1.doktorid = randevular.doktorid) inner join osman_hastane1 on osman_hastane1.hastane_id = randevular.hastaneid) inner join klinikler1 on klinikler1.klinik_id = randevular.klinikid)  where hastaid = ' " + Uyeden_Randevuya.hastaid + "' order by tarih desc,saat desc";

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
        public string hekim;
        public string muayenetarihi ;
        public string hastane ;
        public string klinik ;
        public string muayenesaati ;


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            int index2 = e.ColumnIndex;
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.RowIndex >= 0)
            {



                DataGridViewRow selectedrow = dataGridView1.Rows[index];
                doktor_randevu_al_gel.randevuzamani = selectedrow.Cells[2].Value.ToString();

                doktor_randevu_al_gel.saat = selectedrow.Cells[3].Value.ToString();
                doktor_randevu_al_gel.randevuid = selectedrow.Cells[4].Value.ToString();
                doktor_randevu_al_gel.hastaid = selectedrow.Cells[5].Value.ToString();
                doktor_randevu_al_gel.doktorid = selectedrow.Cells[6].Value.ToString();
                doktor_randevu_al_gel.klinikid = selectedrow.Cells[7].Value.ToString();

                doktor_randevu_al_gel.doktoradi = selectedrow.Cells[8].Value.ToString();

                doktor_randevu_al_gel.hastaneadi = selectedrow.Cells[9].Value.ToString();
                doktor_randevu_al_gel.klinikadi = selectedrow.Cells[10].Value.ToString();
           //     MessageBox.Show(selectedrow.Cells[1].Value.ToString());

            }


            DoktorDegerlendir dd = new DoktorDegerlendir();
                dd.Show();
                this.Hide();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RandevuArama ra = new RandevuArama();
            ra.Show();
            this.Hide();

        }
    }
}
