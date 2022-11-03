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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        
        string satisno;
            int id = 0,a;

        SqlConnection baglanti = new SqlConnection("Data Source = JUPITER\\SQLEXPRESS;Initial Catalog = adisyon90lar; Integrated Security = True;");

        private void yuksekdegerial()
        {


            baglanti.Open();
            SqlCommand cmdeydgr = new SqlCommand("SELECT Max(kod) FROM urunler", baglanti);
            SqlDataReader dr = cmdeydgr.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                satisno = dr[0].ToString();
            }
            baglanti.Close();

             a = Convert.ToInt32(satisno);
            a += 1;
        }


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
                ekle.SubItems.Add(oku["alisf"].ToString());
                ekle.SubItems.Add(oku["satisf"].ToString());
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



        private void Form5_Load(object sender, EventArgs e)
        {

            this.Location = Screen.PrimaryScreen.Bounds.Location;
            gosterr();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 fom2 = new Form2();
            fom2.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            groupBox1.Visible = false;
            groupBox2.Visible = false;

           
                groupBox3.Visible = true;
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox3.Visible = false;
          
                groupBox1.Visible = true;
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox3.Visible = false;

            groupBox2.Visible = true;
        


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            yuksekdegerial();
            baglanti.Open();
            SqlCommand komuti = new SqlCommand("INSERT INTO urunler (kod,ad,marka,kategori,adet,alisf,satisf,stok) VALUES('"+a+"','" + textBox2.Text + "','" + textBox1.Text + "','" + comboBox1.Text + "','" + 1 + "','"+textBox3.Text+ "','" + textBox5.Text + "','" + 0 + "')", baglanti);
            komuti.ExecuteNonQuery();
            baglanti.Close();
            gosterr();
            textBox2.Text = "";
            
            textBox5.Text = "";
            MessageBox.Show("Başarıyla Eklendi");



        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand silkomutu = new SqlCommand("DELETE FROM urunler where kod='" + textBox6.Text + "'", baglanti);
            silkomutu.ExecuteNonQuery();
            baglanti.Close();
            gosterr();
            textBox6.Text = "";


        }

        private void button7_Click(object sender, EventArgs e)
        {
            

            baglanti.Open();
            SqlCommand komuti = new SqlCommand("UPDATE urunler SET kod='"+id+ "', ad='" + textBox8.Text + "', marka= '" + textBox4.Text + "',kategori='" + comboBox2.Text + "',alisf='" + textBox7.Text.ToString().Replace(",", ".") + "',satisf='" + textBox9.Text.ToString().Replace(",", ".") + "' WHERE kod='" + id+"'", baglanti);
            komuti.ExecuteNonQuery();
            baglanti.Close();
            gosterr();
            textBox8.Text = "";
            comboBox2.Text = "";
            textBox9.Text = "";
            textBox4.Text = "";
            textBox7.Text = "";

            MessageBox.Show("Başarıyla Güncellendi");

        }

        

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

            if (textBox11.Text == "")
            {
                gosterr();

            }
            else
            {
                listView1.Items.Clear();
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT *FROM urunler WHERE kod='" + Convert.ToInt32(textBox11.Text) + "'", baglanti);
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = oku["kod"].ToString();
                    ekle.SubItems.Add(oku["ad"].ToString());
                    ekle.SubItems.Add(oku["marka"].ToString());
                    ekle.SubItems.Add(oku["kategori"].ToString());
                    ekle.SubItems.Add(oku["alisf"].ToString());
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

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

            if (textBox10.Text == "")
            {
                gosterr();

            }
            else
            {
                listView1.Items.Clear();
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT *FROM urunler WHERE ad LIKE '%" + textBox10.Text + "%'", baglanti);
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = oku["kod"].ToString();
                    ekle.SubItems.Add(oku["ad"].ToString());
                    ekle.SubItems.Add(oku["marka"].ToString());
                    ekle.SubItems.Add(oku["kategori"].ToString());
                    ekle.SubItems.Add(oku["alisf"].ToString());
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

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        

        private void textBox3_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox5_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {


            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM urunler where kod='" + id + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textBox8.Text = oku["ad"].ToString();
                textBox4.Text = oku["marka"].ToString();
                textBox7.Text = oku["alisf"].ToString();
                textBox9.Text = oku["satisf"].ToString();
                comboBox2.Text = oku["kategori"].ToString();
            }
            baglanti.Close();
        }
    }
}
