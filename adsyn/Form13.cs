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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = JUPITER\\SQLEXPRESS;Initial Catalog = adisyon90lar; Integrated Security = True;");
        public void satisgoster()
        {
            listView1.Items.Clear();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM satis where smno ='" + 99999 + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["sno"].ToString();
                ekle.SubItems.Add(oku["smad"].ToString());
                ekle.SubItems.Add(oku["stutar"].ToString());
                ekle.SubItems.Add(oku["starihi"].ToString());
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
        public void gosteri()
        {
            int satisno = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            listView2.Items.Clear();
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM satilanurunler where satisno='" +satisno + "'", baglanti);

            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["satisno"].ToString();
                ekle.SubItems.Add(oku["sumusteri"].ToString());
                ekle.SubItems.Add(oku["suad"].ToString());
                ekle.SubItems.Add(oku["sufiyat"].ToString());
                ekle.SubItems.Add(oku["suadet"].ToString());
                ekle.SubItems.Add(oku["sumarka"].ToString());
                ekle.SubItems.Add(oku["sukategori"].ToString());
                ekle.SubItems.Add(oku["sutarih"].ToString());
                ekle.SubItems.Add(oku["susaat"].ToString());
                ekle.SubItems.Add(oku["sutahsilatb"].ToString());
                ekle.SubItems.Add(oku["sututar"].ToString());
                ekle.SubItems.Add(oku["suaciklama"].ToString());
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

        public void gosterr()
        {
            listView1.Items.Clear();
            DateTime zaman = DateTime.Today;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM satis where smno ='" + 99999 + "' and starihi='" + zaman.ToShortDateString() + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["sno"].ToString();
                ekle.SubItems.Add(oku["smad"].ToString());
                ekle.SubItems.Add(oku["stutar"].ToString());
                ekle.SubItems.Add(oku["starihi"].ToString());
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
        private void Form13_Load(object sender, EventArgs e)
        {
            DateTime zaman = DateTime.Today;
            dateTimePicker1.Value = Convert.ToDateTime(zaman.ToShortDateString());
            dateTimePicker2.Value = Convert.ToDateTime(zaman.ToShortDateString());
            dateTimePicker3.Value = Convert.ToDateTime(zaman.ToShortDateString());
            satisgoster();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            satisgoster();

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            gosterr();
            panel2.Visible = false;
            panel1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {

            string t1 = dateTimePicker1.Value.ToShortDateString();
            string t2 = dateTimePicker2.Value.ToShortDateString();

            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM satis WHERE smno ='" + 99999 + "' and starihi between '" + t1 + "' and '" + t2 + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["sno"].ToString();
                ekle.SubItems.Add(oku["smad"].ToString());
                ekle.SubItems.Add(oku["stutar"].ToString());
                ekle.SubItems.Add(oku["starihi"].ToString());
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

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listView2.Visible = true;
            groupBox3.Visible = false;
            gosteri();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (groupBox3.Visible==false)
            {
                groupBox3.Visible = true;
                listView2.Visible = false;
            }
            else
            {
                Form9 f9 = new Form9();
                f9.Show();
                this.Hide();
            }
                        
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

        private void button5_Click(object sender, EventArgs e)
        {

            Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
            xla.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook wb = xla.Workbooks.Add(Microsoft.Office.Interop.Excel.XlSheetType.xlWorksheet);

            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)xla.ActiveSheet;
            int i = 1;
            int j = 1;
            foreach (ListViewItem item in listView2.Items)
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
    }
}
