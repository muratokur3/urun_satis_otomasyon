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
    public partial class FaturaTakipIslemleri : Form
    {
        public FaturaTakipIslemleri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = JUPITER\\SQLEXPRESS;Initial Catalog = adisyon90lar; Integrated Security = True;");
        int ffnoo;
        string ado;

        public void faturagoster()
        {
            listView1.Items.Clear();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM faturagirisi where ffno ='" + Convert.ToInt32(label1.Text) + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["fno"].ToString();
                ekle.SubItems.Add(oku["ffno"].ToString());
                ekle.SubItems.Add(oku["fotip"].ToString());
                ekle.SubItems.Add(oku["ftb"].ToString());
                ekle.SubItems.Add(oku["ftrh"].ToString());
                ekle.SubItems.Add(oku["fvtrh"].ToString());
                ekle.SubItems.Add(oku["fm"].ToString());
                ekle.SubItems.Add(oku["fa"].ToString());
                ekle.SubItems.Add(oku["fk"].ToString());
                ekle.SubItems.Add(oku["fackl"].ToString());


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
        public void gosterr()
        {
            listView1.Items.Clear();
            DateTime zaman = DateTime.Today;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM faturagirisi where ftrh='"+zaman.ToShortDateString()+"'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["fno"].ToString();
                ekle.SubItems.Add(oku["ffno"].ToString());
                ekle.SubItems.Add(oku["fotip"].ToString());
                ekle.SubItems.Add(oku["ftb"].ToString());
                ekle.SubItems.Add(oku["ftrh"].ToString());
                ekle.SubItems.Add(oku["fvtrh"].ToString());
                ekle.SubItems.Add(oku["fm"].ToString());
                ekle.SubItems.Add(oku["fa"].ToString());
                ekle.SubItems.Add(oku["fk"].ToString());
                ekle.SubItems.Add(oku["fackl"].ToString());

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
        private void FaturaTakipIslemleri_Load(object sender, EventArgs e)
        {
            DateTime zaman = DateTime.Today;
            dateTimePicker1.Value = Convert.ToDateTime(zaman.ToShortDateString());
            dateTimePicker2.Value = Convert.ToDateTime(zaman.ToShortDateString());
            dateTimePicker3.Value = Convert.ToDateTime(zaman.ToShortDateString());
            if (label1.Text=="")
            {
                gosterr();
                panel3.Visible = true;
            }
            else
            {
                panel4.Visible = true;
                faturagoster();
            }
            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 fom2 = new Form2();
            fom2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (groupBox2.Visible == false)
            {
                groupBox2.Visible = true;
                groupBox1.Visible = false;
            }
            else
            {
                groupBox2.Visible = false;


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (groupBox1.Visible==false)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
            }
            else
            {
                groupBox1.Visible = false;
               

            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM faturagirisi", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["fno"].ToString();
                ekle.SubItems.Add(oku["ffno"].ToString());
                ekle.SubItems.Add(oku["fotip"].ToString());
                ekle.SubItems.Add(oku["ftb"].ToString());
                ekle.SubItems.Add(oku["ftrh"].ToString());
                ekle.SubItems.Add(oku["fvtrh"].ToString());
                ekle.SubItems.Add(oku["fm"].ToString());
                ekle.SubItems.Add(oku["fa"].ToString());
                ekle.SubItems.Add(oku["fk"].ToString());
                ekle.SubItems.Add(oku["fackl"].ToString());

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
            SqlCommand komut = new SqlCommand("SELECT *FROM faturagirisi WHERE ftrh='" + t1+ "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["fno"].ToString();
                ekle.SubItems.Add(oku["ffno"].ToString());
                ekle.SubItems.Add(oku["fotip"].ToString());
                ekle.SubItems.Add(oku["ftb"].ToString());
                ekle.SubItems.Add(oku["ftrh"].ToString());
                ekle.SubItems.Add(oku["fvtrh"].ToString());
                ekle.SubItems.Add(oku["fm"].ToString());
                ekle.SubItems.Add(oku["fa"].ToString());
                ekle.SubItems.Add(oku["fk"].ToString());
                ekle.SubItems.Add(oku["fackl"].ToString());

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

        private void button7_Click(object sender, EventArgs e)
        {

            string t1 = dateTimePicker1.Value.ToShortDateString();
            string t2 = dateTimePicker2.Value.ToShortDateString();

            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM faturagirisi WHERE ftrh between '" + t1 + "' and '" + t2 + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["fno"].ToString();
                ekle.SubItems.Add(oku["ffno"].ToString());
                ekle.SubItems.Add(oku["fotip"].ToString());
                ekle.SubItems.Add(oku["ftb"].ToString());
                ekle.SubItems.Add(oku["ftrh"].ToString());
                ekle.SubItems.Add(oku["fvtrh"].ToString());
                ekle.SubItems.Add(oku["fm"].ToString());
                ekle.SubItems.Add(oku["fa"].ToString());
                ekle.SubItems.Add(oku["fk"].ToString());
                ekle.SubItems.Add(oku["fackl"].ToString());

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

        private void button1_Click_1(object sender, EventArgs e)
        {
            gosterr();
            
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

        private void button2_Click(object sender, EventArgs e)
        {
            faturagoster();
        }

        private void button10_Click(object sender, EventArgs e)
        {

            listView1.Items.Clear();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM faturagirisi where ffno ='" + Convert.ToInt32(label1.Text) + "' and ( fotip='"+"ÖDENMEDİ"+ "' or fotip='" + "KISMEN ODENDİ" + "')", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["fno"].ToString();
                ekle.SubItems.Add(oku["ffno"].ToString());
                ekle.SubItems.Add(oku["fotip"].ToString());
                ekle.SubItems.Add(oku["ftb"].ToString());
                ekle.SubItems.Add(oku["ftrh"].ToString());
                ekle.SubItems.Add(oku["fvtrh"].ToString());
                ekle.SubItems.Add(oku["fm"].ToString());
                ekle.SubItems.Add(oku["fa"].ToString());
                ekle.SubItems.Add(oku["fk"].ToString());
                ekle.SubItems.Add(oku["fackl"].ToString());


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
            FaturaGiris fg = new FaturaGiris();
            fg.label10.Text = "asd";
            fg.label17.Text = label2.Text;
            fg.textBox5.Text = label1.Text;
            fg.Show();
            this.Hide();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           int no_urun = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM faturagirisi where fno ='" + no_urun + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

               ffnoo=Convert.ToInt32(oku["ffno"]);
            
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komutw = new SqlCommand("SELECT *FROM firmalar where no ='" + ffnoo + "'", baglanti);
            SqlDataReader okuw = komutw.ExecuteReader();
            while (okuw.Read())
            {

                ado = okuw["ad"].ToString();

            }
            baglanti.Close();
            Form17 f7 = new Form17();
            f7.label2.Text = no_urun.ToString();
            f7.label10.Text = ffnoo.ToString();
            f7.label11.Text = ado;
            f7.Show();

        }
    }
}
