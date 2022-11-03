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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = JUPITER\\SQLEXPRESS;Initial Catalog = adisyon90lar; Integrated Security = True;");
        String tahsilatb;
        private void goster()
        {
            listView1.Items.Clear();
            DateTime zaman = DateTime.Today;
            baglanti.Open();
            SqlCommand cmdg = new SqlCommand("select *from masraflar where masraftarihi='"+zaman.ToShortDateString()+"' ", baglanti);
            SqlDataReader oku = cmdg.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["masrafdegeri"].ToString();
                ekle.SubItems.Add(oku["masrafaciklamasi"].ToString());
                ekle.SubItems.Add(oku["masraftarihi"].ToString());
                ekle.SubItems.Add(oku["masrafsaati"].ToString());
                ekle.SubItems.Add(oku["masraftb"].ToString());

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
        private void button1_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false)
            {
                panel1.Visible = true;
                panel2.Visible = false;
            }
            else
                panel1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            if (panel2.Visible == false)
            {
                panel2.Visible = true;
                panel1.Visible = false;
            }
            else
            {
                panel2.Visible = false;
            }
            goster();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked==true || radioButton2.Checked==true)
            {
            DateTime zsaat = DateTime.Now;
            string saat = zsaat.ToLongTimeString();
            DateTime zaman = DateTime.Today;
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("insert into masraflar (masrafdegeri,masrafaciklamasİ,masraftarihi,masrafsaati,masraftb) values('"+textBox2.Text+"','"+textBox1.Text+"','"+zaman.ToShortDateString()+"','"+saat+"','"+tahsilatb+"')",baglanti);
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla Eklendi");
            textBox1.Text = "";
            textBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Tahsilat Biçimi Seçiniz");
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel3.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel4.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = false;
            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM masraflar", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["masrafdegeri"].ToString();
                ekle.SubItems.Add(oku["masrafaciklamasi"].ToString());
                ekle.SubItems.Add(oku["masraftarihi"].ToString());
                ekle.SubItems.Add(oku["masrafsaati"].ToString());
                ekle.SubItems.Add(oku["masraftb"].ToString());

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
            Form2 fom2 = new Form2();
            fom2.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           listView1.Items.Clear();
            string t1 = dateTimePicker3.Value.ToShortDateString();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM masraflar WHERE masraftarihi='" +t1 + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["masrafdegeri"].ToString();
                ekle.SubItems.Add(oku["masrafaciklamasi"].ToString());
                ekle.SubItems.Add(oku["masraftarihi"].ToString());
                ekle.SubItems.Add(oku["masrafsaati"].ToString());
                ekle.SubItems.Add(oku["masraftb"].ToString());

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
            SqlCommand komut = new SqlCommand("SELECT *FROM masraflar WHERE masraftarihi between '" + t1 + "' and '" + t2 + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["masrafdegeri"].ToString();
                ekle.SubItems.Add(oku["masrafaciklamasi"].ToString());
                ekle.SubItems.Add(oku["masraftarihi"].ToString());
                ekle.SubItems.Add(oku["masrafsaati"].ToString());
                ekle.SubItems.Add(oku["masraftb"].ToString());

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

        private void Form7_Load(object sender, EventArgs e)
        {
            DateTime zaman = DateTime.Today;
            dateTimePicker1.Value = Convert.ToDateTime(zaman.ToShortDateString());
            dateTimePicker2.Value = Convert.ToDateTime(zaman.ToShortDateString());
            dateTimePicker3.Value = Convert.ToDateTime(zaman.ToShortDateString());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            goster();
            panel3.Visible = false;
            panel4.Visible = false;

        }

        private void sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand silkomutu = new SqlCommand("DELETE FROM masraflar", baglanti);
            silkomutu.ExecuteNonQuery();
            baglanti.Close();
            goster();
        }

        private void button12_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked == false)
            {
                radioButton1.Checked = true;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked == false)
            {
                radioButton2.Checked = true;

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                tahsilatb = "NAKİT";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                tahsilatb = "KART";
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
