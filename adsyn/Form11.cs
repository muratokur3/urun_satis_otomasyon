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

namespace adsyn
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = JUPITER\\SQLEXPRESS;Initial Catalog = adisyon90lar; Integrated Security = True;");
        int notno;
        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
           
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM satis where sodtip ='" + "KISMEN ODENDİ" + "' OR sodtip ='" + "HİÇ ODENMEDİ" + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["sno"].ToString();
                ekle.SubItems.Add(oku["smad"].ToString());
                ekle.SubItems.Add(oku["stutar"].ToString());
                ekle.SubItems.Add(oku["bverilen"].ToString());
                ekle.SubItems.Add(oku["bkalan"].ToString());
                ekle.SubItems.Add(oku["starihi"].ToString());
                ekle.SubItems.Add(oku["bvadet"].ToString());
                ekle.SubItems.Add(oku["sodtip"].ToString());
                ekle.SubItems.Add(oku["sacikl"].ToString());


                listView1.Items.Add(ekle);
                ListView listView = this.listView1;
                int i = 0;
                Color shaded = Color.Brown;
                foreach (ListViewItem item in listView.Items)
                {
                    if (i++ % 2 == 1)
                    {
                        item.BackColor = Color.Green;
                        item.ForeColor = Color.White;
                        item.UseItemStyleForSubItems = true;
                    }
                    else
                    {
                        item.BackColor = Color.Yellow;
                        item.UseItemStyleForSubItems = true;
                    }
                }

            }
            baglanti.Close();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int satisno = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            listView1.Items.Clear();

            Form10 f0 = new Form10();
            f0.label11.Text="borc";
            f0.label1.Text = satisno.ToString();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM satis where sno ='" + satisno + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                f0.label2.Text = oku["smad"].ToString();
            }
            baglanti.Close();

            f0.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            groupBox1.Visible = false;
            groupBox2.Visible = true;
            groupBox3.Visible = false;
            listView2.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM urunler where stok <=" + 100 + "", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
               
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["kod"].ToString();
                ekle.SubItems.Add(oku["ad"].ToString());
                ekle.SubItems.Add(oku["marka"].ToString());
                ekle.SubItems.Add(oku["kategori"].ToString());
                ekle.SubItems.Add(oku["alisf"].ToString());
                ekle.SubItems.Add(oku["satisf"].ToString());
                ekle.SubItems.Add(oku["stok"].ToString());
                listView2.Items.Add(ekle);
                ListView listView = this.listView2;
                int i = 0;
                Color shaded = Color.Brown;
                foreach (ListViewItem item in listView.Items)
                {
                    if (i++ % 2 == 1)
                    {
                        item.BackColor = Color.Green;
                        item.ForeColor = Color.White;
                        item.UseItemStyleForSubItems = true;
                    }
                    else
                    {
                        item.BackColor = Color.Yellow;
                        item.UseItemStyleForSubItems = true;
                    }
                }
            }
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = true;
            listView3.Items.Clear();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM notlar", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["nno"].ToString();
                ekle.SubItems.Add(oku["ntrh"].ToString());
                ekle.SubItems.Add(oku["nhtrh"].ToString());
                ekle.SubItems.Add(oku["nott"].ToString());


                listView3.Items.Add(ekle);
                ListView listView = this.listView3;
                int i = 0;
                Color shaded = Color.Brown;
                foreach (ListViewItem item in listView.Items)
                {
                    if (i++ % 2 == 1)
                    {
                        item.BackColor = Color.Green;
                        item.ForeColor = Color.White;
                        item.UseItemStyleForSubItems = true;
                    }
                    else
                    {
                        item.BackColor = Color.Yellow;
                        item.UseItemStyleForSubItems = true;
                    }
                }

            }
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM satis where sodtip ='" + "KISMEN ODENDİ" + "' OR sodtip ='" + "HİÇ ODENMEDİ" + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["sno"].ToString();
                ekle.SubItems.Add(oku["smad"].ToString());
                ekle.SubItems.Add(oku["stutar"].ToString());
                ekle.SubItems.Add(oku["bverilen"].ToString());
                ekle.SubItems.Add(oku["bkalan"].ToString());
                ekle.SubItems.Add(oku["starihi"].ToString());
                ekle.SubItems.Add(oku["bvadet"].ToString());
                ekle.SubItems.Add(oku["sodtip"].ToString());
                ekle.SubItems.Add(oku["sacikl"].ToString());


                listView1.Items.Add(ekle);
                ListView listView = this.listView1;
                int i = 0;
                Color shaded = Color.Brown;
                foreach (ListViewItem item in listView.Items)
                {
                    if (i++ % 2 == 1)
                    {
                        item.BackColor = Color.Green;
                        item.ForeColor = Color.White;
                        item.UseItemStyleForSubItems = true;
                    }
                    else
                    {
                        item.BackColor = Color.Yellow;
                        item.UseItemStyleForSubItems = true;
                    }
                }
            }
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            DateTime bugun = DateTime.Today;

            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM satis where bvadet ='" + bugun.ToShortDateString() + "' and (sodtip ='" + "KISMEN ODENMEDİ" + "' OR sodtip ='" + "HİÇ ODENMEDİ" + "')", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["sno"].ToString();
                ekle.SubItems.Add(oku["smad"].ToString());
                ekle.SubItems.Add(oku["stutar"].ToString());
                ekle.SubItems.Add(oku["bverilen"].ToString());
                ekle.SubItems.Add(oku["bkalan"].ToString());
                ekle.SubItems.Add(oku["starihi"].ToString());
                ekle.SubItems.Add(oku["bvadet"].ToString());
                ekle.SubItems.Add(oku["sodtip"].ToString());
                ekle.SubItems.Add(oku["sacikl"].ToString());


                listView1.Items.Add(ekle);
                ListView listView = this.listView1;
                int i = 0;
                Color shaded = Color.Brown;
                foreach (ListViewItem item in listView.Items)
                {
                    if (i++ % 2 == 1)
                    {
                        item.BackColor = Color.Green;
                        item.ForeColor = Color.White;
                        item.UseItemStyleForSubItems = true;
                    }
                    else
                    {
                        item.BackColor = Color.Yellow;
                        item.UseItemStyleForSubItems = true;
                    }
                }
            }
            baglanti.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
          
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM satis where bvadet ='" + dateTimePicker1.Value.ToShortDateString() + "' and (sodtip ='" + "KISMEN ODENMEDİ" + "' OR sodtip ='" + "HİÇ ODENMEDİ" + "')", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["sno"].ToString();
                ekle.SubItems.Add(oku["smad"].ToString());
                ekle.SubItems.Add(oku["stutar"].ToString());
                ekle.SubItems.Add(oku["bverilen"].ToString());
                ekle.SubItems.Add(oku["bkalan"].ToString());
                ekle.SubItems.Add(oku["starihi"].ToString());
                ekle.SubItems.Add(oku["bvadet"].ToString());
                ekle.SubItems.Add(oku["sodtip"].ToString());
                ekle.SubItems.Add(oku["sacikl"].ToString());


                listView1.Items.Add(ekle);
                ListView listView = this.listView1;
                int i = 0;
                Color shaded = Color.Brown;
                foreach (ListViewItem item in listView.Items)
                {
                    if (i++ % 2 == 1)
                    {
                        item.BackColor = Color.Green;
                        item.ForeColor = Color.White;
                        item.UseItemStyleForSubItems = true;
                    }
                    else
                    {
                        item.BackColor = Color.Yellow;
                        item.UseItemStyleForSubItems = true;
                    }
                }
            }
            baglanti.Close();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            listView3.Items.Clear();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM notlar", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["nno"].ToString();
                ekle.SubItems.Add(oku["ntrh"].ToString());
                ekle.SubItems.Add(oku["nhtrh"].ToString());               
                ekle.SubItems.Add(oku["nott"].ToString());


                listView3.Items.Add(ekle);
                ListView listView = this.listView3;
                int i = 0;
                Color shaded = Color.Brown;
                foreach (ListViewItem item in listView.Items)
                {
                    if (i++ % 2 == 1)
                    {
                        item.BackColor = Color.Green;
                        item.ForeColor = Color.White;
                        item.UseItemStyleForSubItems = true;
                    }
                    else
                    {
                        item.BackColor = Color.Yellow;
                        item.UseItemStyleForSubItems = true;
                    }
                }
            }
            baglanti.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listView3.Items.Clear();
            DateTime bugun = DateTime.Today;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM notlar where nhtrh='"+bugun.ToShortDateString()+"'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["nno"].ToString();
                ekle.SubItems.Add(oku["ntrh"].ToString());
                ekle.SubItems.Add(oku["nhtrh"].ToString());
                ekle.SubItems.Add(oku["nott"].ToString());
                listView3.Items.Add(ekle);
                ListView listView = this.listView3;
                int i = 0;
                Color shaded = Color.Brown;
                foreach (ListViewItem item in listView.Items)
                {
                    if (i++ % 2 == 1)
                    {
                        item.BackColor = Color.Green;
                        item.ForeColor = Color.White;
                        item.UseItemStyleForSubItems = true;
                    }
                    else
                    {
                        item.BackColor = Color.Yellow;
                        item.UseItemStyleForSubItems = true;
                    }
                }
            }
            baglanti.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listView3.Items.Clear();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM notlar where nhtrh='" + dateTimePicker2.Value.ToShortDateString() + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["nno"].ToString();
                ekle.SubItems.Add(oku["ntrh"].ToString());
                ekle.SubItems.Add(oku["nhtrh"].ToString());
                ekle.SubItems.Add(oku["nott"].ToString());


                listView3.Items.Add(ekle);
                ListView listView = this.listView3;
                int i = 0;
                Color shaded = Color.Brown;
                foreach (ListViewItem item in listView.Items)
                {
                    if (i++ % 2 == 1)
                    {
                        item.BackColor = Color.Green;
                        item.ForeColor = Color.White;
                        item.UseItemStyleForSubItems = true;
                    }
                    else
                    {
                        item.BackColor = Color.Yellow;
                        item.UseItemStyleForSubItems = true;
                    }
                }
            }
            baglanti.Close();
        }

        private void listView3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notno = int.Parse(listView3.SelectedItems[0].SubItems[0].Text);
            Form14 fnot = new Form14();
            fnot.label3.Text = "guncelleme";
            fnot.label4.Text = notno.ToString();
            fnot.Show();
        }

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {   notno = int.Parse(listView2.SelectedItems[0].SubItems[0].Text);
            Form12 fs = new Form12();
            fs.label4.Text = "stok";
            fs.textBox1.Text = notno.ToString();
            fs.Show();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            DateTime zaman = DateTime.Today;
            dateTimePicker1.Value = Convert.ToDateTime(zaman.ToShortDateString());
            dateTimePicker2.Value = Convert.ToDateTime(zaman.ToShortDateString());
          
        }

        private void button444_Click(object sender, EventArgs e)
        {

            Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
            xla.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook wb = xla.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);

            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)xla.ActiveSheet;
            int i = 1;
            int j = 1;
            foreach (ListViewItem item in listView1.Items)
            {
                ws.Cells[i, j] = item.Text.ToString();
                foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
                {
                    ws.Cells[i, j] = subitem.Text.ToString();
                    j++;
                }
                j = 1;
                i++;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

            Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
            xla.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook wb = xla.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);

            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)xla.ActiveSheet;
            int i = 1;
            int j = 1;
            foreach (ListViewItem item in listView3.Items)
            {
                ws.Cells[i, j] = item.Text.ToString();
                foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
                {
                    ws.Cells[i, j] = subitem.Text.ToString();
                    j++;
                }
                j = 1;
                i++;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM urunler where stok <=" + Convert.ToInt32(textBox1.Text) + "", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["kod"].ToString();
                ekle.SubItems.Add(oku["ad"].ToString());
                ekle.SubItems.Add(oku["marka"].ToString());
                ekle.SubItems.Add(oku["kategori"].ToString());
                ekle.SubItems.Add(oku["alisf"].ToString());
                ekle.SubItems.Add(oku["satisf"].ToString());
                ekle.SubItems.Add(oku["stok"].ToString());
                listView2.Items.Add(ekle);
                ListView listView = this.listView2;
                int i = 0;
                Color shaded = Color.Brown;
                foreach (ListViewItem item in listView.Items)
                {
                    if (i++ % 2 == 1)
                    {
                        item.BackColor = Color.Green;
                        item.ForeColor = Color.White;
                        item.UseItemStyleForSubItems = true;
                    }
                    else
                    {
                        item.BackColor = Color.Yellow;
                        item.UseItemStyleForSubItems = true;
                    }
                }
            }
            baglanti.Close();
        }
    }
}
