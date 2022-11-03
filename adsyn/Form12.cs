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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = JUPITER\\SQLEXPRESS;Initial Catalog = adisyon90lar; Integrated Security = True;");
        int no_urun,stok;
        
        public void gosterr()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM urunler", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["kod"].ToString();
                ekle.SubItems.Add(oku["ad"].ToString());
                ekle.SubItems.Add(oku["marka"].ToString());
                ekle.SubItems.Add(oku["kategori"].ToString());
                ekle.SubItems.Add(oku["stok"].ToString());
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



        public void kgosterr()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM urunler where kategori='"+comboBox2.Text+"'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["kod"].ToString();
                ekle.SubItems.Add(oku["ad"].ToString());
                ekle.SubItems.Add(oku["marka"].ToString());
                ekle.SubItems.Add(oku["kategori"].ToString());
                ekle.SubItems.Add(oku["stok"].ToString());
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
        private void Form12_Load(object sender, EventArgs e)
        {
            this.Location = Screen.PrimaryScreen.Bounds.Location;
            if (label4.Text=="stok")
            {
                button5.Visible = false;
                button6.Visible = true;
            }
            gosterr();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kgosterr();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gosterr();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            no_urun = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = no_urun.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM urunler where kod='" + textBox1.Text + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                stok = Convert.ToInt32(oku["stok"]);

            }
            stok = stok - Convert.ToInt32(textBox2.Text);

            baglanti.Close();
            baglanti.Open();
            SqlCommand komuti = new SqlCommand("UPDATE urunler SET stok='" + stok + "' WHERE kod='" + textBox1.Text + "'", baglanti);
            komuti.ExecuteNonQuery();
            baglanti.Close();
            gosterr();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 fom2 = new Form2();
            fom2.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                listView1.Items.Clear();
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT *FROM urunler WHERE ad LIKE '%" + textBox3.Text + "%'", baglanti);
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = oku["kod"].ToString();
                    ekle.SubItems.Add(oku["ad"].ToString());
                    ekle.SubItems.Add(oku["marka"].ToString());
                    ekle.SubItems.Add(oku["kategori"].ToString());
                    ekle.SubItems.Add(oku["stok"].ToString());
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
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="" || textBox2.Text=="")
            {
 MessageBox.Show("Ürün kodu Ve Stok Adetini Kontrol Ediniz!!");
          
            }
            else
            { 
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM urunler where kod='" + textBox1.Text + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                stok=Convert.ToInt32( oku["stok"]);

            }
            stok = stok + Convert.ToInt32(textBox2.Text);

            baglanti.Close();
            baglanti.Open();
            SqlCommand komuti = new SqlCommand("UPDATE urunler SET stok='" + stok + "' WHERE kod='" + textBox1.Text + "'", baglanti);
            komuti.ExecuteNonQuery();
            baglanti.Close();
            gosterr();
               
            }
        }
    }
}
