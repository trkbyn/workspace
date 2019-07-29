using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;
//using iTextSharp.text.pdf;
//using iTextSharp.text;
using System.Reflection;
using System.IO;



namespace HastaneRandevu
{
    public partial class RandevuGecmisi : Form
    {
        public RandevuGecmisi()
        {
            InitializeComponent();
        }
        StringFormat strFormat;
        ArrayList arrColumnLefts = new ArrayList();
        ArrayList arrColumnWidths = new ArrayList();
        int iCellHeight = 0;
        int iTotalWidth = 0;
        int iRow = 0;
        bool bFirstPage = false;
        bool bNewPage = false;
        int iHeaderHeight = 0;

        string randevuid;



        SqlConnection con = new SqlConnection("Data Source=DESKTOP-44ST0UO\\SQLEXPRESS;Initial Catalog=Hastane;Integrated Security=True");
        static DataTable GetTable()
        {
       
            DataTable table = new DataTable();
            table.Columns.Add("Hekim Adı", typeof(string));
            table.Columns.Add("Randevu Zamanı", typeof(string));
            table.Columns.Add("Kurum Adı", typeof(string));
            table.Columns.Add("Klinik Adı", typeof(string));

          
         
        

            return table;
        }

        private void RandevuGecmisi_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToResizeColumns = false;

            pictureBox1.Visible = false;
            btnItextsharp.Visible = false;
            label1.Text = "Randevu geçmişinizde son 20 kayıt listelenmektedir.";
          //  dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //  dataGridView1.RowHeadersWidth = 7;

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false; //Gizlenmesini sağlar 
            dataGridView1.BackgroundColor = Color.Brown;

            try
            {
                string ad = Uyeden_Randevuya.ad.ToString();
                string soyad = Uyeden_Randevuya.soyad.ToString();
                label2.Text = "Sn. " + ad.ToUpper() + " " + soyad.ToUpper();
            }
            catch (Exception exx)
            {
                label2.Text = "Hata meydana geldi." + exx;
            }

            DataGridViewButtonColumn dgvBtn = new DataGridViewButtonColumn();
           
            ToolTip tt = new ToolTip();
            dgvBtn.HeaderText = "";

            dgvBtn.Text = " ";

            dgvBtn.Width = 100;
            dgvBtn.FillWeight = 20;
            

            dgvBtn.UseColumnTextForButtonValue = true;

            dgvBtn.DefaultCellStyle.BackColor = Color.Blue;

            dgvBtn.DefaultCellStyle.SelectionBackColor = Color.Red;


            dataGridView1.Columns.Add(dgvBtn);




            //DataGridViewImageColumn img = new DataGridViewImageColumn();

            //img.Image = Image.FromFile("C:\\Users\\Tarık Boyun4\\Desktop\\print_15x15.jpg");



            //img.HeaderText = "  ";





            //dataGridView1.Columns.Add(img);



            //dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            kayitgetir();
            dataGridView1.Columns["Tarih"].Width = 80;
            dataGridView1.Columns["Saat"].Width = 70;

            dataGridView1.Columns["Hekim"].Width = 150;
            dataGridView1.Columns["Kurum Adı"].Width = 280;
            dataGridView1.Columns["Klinik Adı"].Width = 170;

            // toplamları 750 olacak yukarıdakilerin + butonun widthi 100 = 850;

           

            dataGridView1.Columns["Tarih"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["Saat"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["Hekim"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["Kurum Adı"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns["Klinik Adı"].SortMode = DataGridViewColumnSortMode.NotSortable;
            // dataGridView1.Columns[""].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView1.Columns["randevuid"].Visible = false;

            
        }


        private void kayitgetir()
        {
           
            
            string sorgu = "select top 20 randevuid,CONVERT(date, tarih)[Tarih], saat [Saat], upper (doktorad + ' ' +  doktorsoyad) as [Hekim], upper(hastane_adi) as [Kurum Adı], klinik_adi as [Klinik Adı] from(((randevular inner join doktorlar1 on doktorlar1.doktorid = randevular.doktorid) inner join osman_hastane1 on osman_hastane1.hastane_id = randevular.hastaneid) inner join klinikler1 on klinikler1.klinik_id = randevular.klinikid)  where hastaid = ' " + Uyeden_Randevuya.hastaid + "' order by tarih desc,saat desc";
            

           
            con.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter(sorgu,con);
    
          
            //"select tarih, doktorad, doktorsoyad, hastane_adi, klinik_adi from(((randevular inner join doktorlar1 on doktorlar1.doktorid = randevular.doktorid) inner join osman_hastane1 on osman_hastane1.hastane_id = randevular.hastaneid) inner join klinikler1 on klinikler1.klinik_id = randevular.klinikid)  where hastaid = ' "+ doktor_randevu_al_gel.hastaneid + "' order by tarih desc"

        
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);

            

            dataGridView1.DataSource = dtbl;
            dataGridView1.Columns["randevuid"].Visible = false;
            

            con.Close();
        }
        private void button3_Click(object sender, EventArgs e)  //GERİ BUTONU
        {
            RandevuArama ra = new RandevuArama();
            ra.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            //DataGridView dgv = sender as DataGridView;
            //if (dgv != null)
            //{
            //    DataGridViewButtonCell b = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewButtonCell;
            //}

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow selectedrow = dataGridView1.Rows[index];
            //MessageBox.Show(selectedrow.Cells[1].Value.ToString());
            
            randevuid = selectedrow.Cells[1].Value.ToString();


            if (e.ColumnIndex == dataGridView1.Columns[0].Index)
                {
                PrintPreviewDialog onizleme = new PrintPreviewDialog();
                onizleme.Document = printDocument1;
                onizleme.ShowDialog();

            }





        }

       private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
          //  string test = dataGridView1.CurrentRow.Cells[0].Value.ToString();
           string sorgu = "select Substring(cast(tarih as nvarchar(11)),0,11) as [Tarih], saat [Saat], upper (doktorad + ' ' +  doktorsoyad) as [Hekim], upper(hastane_adi) as [Kurum Adı], klinik_adi as [Klinik Adı] from(((randevular inner join doktorlar1 on doktorlar1.doktorid = randevular.doktorid) inner join osman_hastane1 on osman_hastane1.hastane_id = randevular.hastaneid) inner join klinikler1 on klinikler1.klinik_id = randevular.klinikid)  where (hastaid = '" + Uyeden_Randevuya.hastaid + "') and (randevuid = '"+ randevuid + "')";



            con.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter(sorgu, con);


            //"select tarih, doktorad, doktorsoyad, hastane_adi, klinik_adi from(((randevular inner join doktorlar1 on doktorlar1.doktorid = randevular.doktorid) inner join osman_hastane1 on osman_hastane1.hastane_id = randevular.hastaneid) inner join klinikler1 on klinikler1.klinik_id = randevular.klinikid)  where hastaid = ' "+ doktor_randevu_al_gel.hastaneid + "' order by tarih desc"


            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);



            dataGridView1.DataSource = dtbl;


            con.Close();
        

            try
            {
                int iLeftMargin = e.MarginBounds.Left;
                int iTopMargin = e.MarginBounds.Top;
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;
                bFirstPage = true;

                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                                       (double)iTotalWidth * (double)iTotalWidth *
                                       ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;


                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }

                while (iRow <= dataGridView1.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dataGridView1.Rows[iRow];

                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;

                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {

                            e.Graphics.DrawString("Çıktı Başlığı", new Font(dataGridView1.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Çıktı Başlığı", new Font(dataGridView1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();

                            e.Graphics.DrawString(strDate, new Font(dataGridView1.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(dataGridView1.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Çıktı Başlığı", new Font(new Font(dataGridView1.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);


                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;

                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                            new SolidBrush(Cel.InheritedStyle.ForeColor),
                                            new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin,
                                            (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                            }

                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
                                    iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }


                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            kayitgetir();

        }
        
        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dataGridView1.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {/*
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 30;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            //Adding Header row
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(cell.Value.ToString());
                }
            }

            //Exporting to PDF
            string folderPath = "C:\\PDFs\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "DataGridViewExport.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }
        
             */
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            //I supposed your button column is at index 0
            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.print_15x15.Width;
                var h = Properties.Resources.print_15x15.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.print_15x15, new Rectangle(x, y, w, h));
                e.Handled = true;
               
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns[0].Index)
            {
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                // Set the Cell's ToolTipText.  In this case we're retrieving the value stored in 
                // another cell in the same row (see my note below).
                ToolTip toolTip1 = new ToolTip();

                cell.ToolTipText = " Yazdır";

               
            }
        }
    }
}
       
