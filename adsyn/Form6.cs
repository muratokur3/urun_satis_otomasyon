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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = JUPITER\\SQLEXPRESS;Initial Catalog = adisyon90lar; Integrated Security = True;");

        public void gosterr()
        {
           listView1.Items.Clear();
            DateTime zaman = DateTime.Today;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM satilanurunler where sutarih='" + zaman.ToShortDateString()+"'", baglanti);
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

        private void Form6_Load(object sender, EventArgs e)
        {
            this.Location = Screen.PrimaryScreen.Bounds.Location;
            DateTime zaman = DateTime.Today;
            dateTimePicker1.Value = Convert.ToDateTime(zaman.ToShortDateString());
            dateTimePicker2.Value = Convert.ToDateTime(zaman.ToShortDateString());
            dateTimePicker3.Value = Convert.ToDateTime(zaman.ToShortDateString());
            gosterr();
        }

        private void button7_Click(object sender, EventArgs e)
        {
          string t1=  dateTimePicker1.Value.ToShortDateString();
          string t2=  dateTimePicker2.Value.ToShortDateString();

            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM satilanurunler WHERE sutarih between '" + t1 + "' and '" + t2 + "'", baglanti);
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
            string t1 = dateTimePicker3.Value.ToShortDateString();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM satilanurunler WHERE sutarih='" + t1+"'", baglanti);
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

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = false;
             listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM satilanurunler", baglanti);
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
            Form2 fom2 = new Form2();
            fom2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gosterr();
            panel2.Visible = false;
            panel1.Visible = false;
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
    }
}
