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
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = JUPITER\\SQLEXPRESS;Initial Catalog = adisyon90lar; Integrated Security = True;");
        string satisno,musteriad;
        int a,musterinoo,musterino;
        private void gosteriyosun()
        {
            listView2.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM firmalar", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["no"].ToString();
                ekle.SubItems.Add(oku["ad"].ToString());
                ekle.SubItems.Add(oku["isi"].ToString());
                ekle.SubItems.Add(oku["numara"].ToString());
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
        private void yuksekdegerial()
        {


            baglanti.Open();
            SqlCommand cmdeydgr = new SqlCommand("SELECT Max(no) FROM firmalar", baglanti);
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
            SqlCommand komut = new SqlCommand("SELECT *FROM firmalar", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["no"].ToString();
                ekle.SubItems.Add(oku["ad"].ToString());
                ekle.SubItems.Add(oku["isi"].ToString());
                ekle.SubItems.Add(oku["numara"].ToString());
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
            if (listView2.Visible == false)
            {
                listView2.Visible = true;
                gosteriyosun();

            }
            else
                listView2.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox3.Visible = false;
            groupBox1.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox3.Visible = true;
            groupBox1.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox1.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click_1(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komuti = new SqlCommand("UPDATE firmalar SET ad='" + textBox8.Text + "', isi='" + textBox7.Text + "', numara= '" + textBox11.Text + "' WHERE no='" + musterinoo + "'", baglanti);
            komuti.ExecuteNonQuery();
            baglanti.Close();
            gosterr();
            textBox8.Text = "";
            textBox7.Text = "";
            textBox11.Text = "";
            MessageBox.Show("Başarıyla Güncellendi");
            gosteriyosun();
        }

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            musterinoo = int.Parse(listView2.SelectedItems[0].SubItems[0].Text);
            baglanti.Open();
            SqlCommand komuto = new SqlCommand("SELECT  *from firmalar WHERE no='" + musterinoo + "'", baglanti);
            SqlDataReader okuo = komuto.ExecuteReader();
            while (okuo.Read())
            {
                textBox8.Text = okuo["ad"].ToString();
                textBox7.Text = okuo["isi"].ToString();
                textBox11.Text = okuo["numara"].ToString();

            }
            baglanti.Close();
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            gosterr();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                gosterr();

            }
            else
            {
                listView1.Items.Clear();
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT *FROM firmalar WHERE no='" + Convert.ToInt32(textBox2.Text) + "'", baglanti);
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = oku["no"].ToString();
                    ekle.SubItems.Add(oku["ad"].ToString());
                    ekle.SubItems.Add(oku["isi"].ToString());
                    ekle.SubItems.Add(oku["numara"].ToString());
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            if (textBox4.Text == "")
            {
                gosterr();

            }
            else
            {
                listView1.Items.Clear();
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT *FROM firmalar WHERE ad LIKE '%" + textBox4.Text + "%'", baglanti);
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = oku["no"].ToString();
                    ekle.SubItems.Add(oku["ad"].ToString());
                    ekle.SubItems.Add(oku["isi"].ToString());
                    ekle.SubItems.Add(oku["numara"].ToString());
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

        private void button31_Click(object sender, EventArgs e)
        {

            Form2 fom2 = new Form2();
            fom2.Show();
            this.Hide();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                  && !char.IsSeparator(e.KeyChar);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand silkomutu = new SqlCommand("DELETE FROM firmalar where no='" + textBox6.Text + "'", baglanti);
            silkomutu.ExecuteNonQuery();
            baglanti.Close();
            gosterr();
            textBox6.Text = "";
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            int musterinooo = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            baglanti.Open();
            SqlCommand komuto = new SqlCommand("SELECT  *from firmalar WHERE no='" + musterinooo + "'", baglanti);
            SqlDataReader okuo = komuto.ExecuteReader();
            while (okuo.Read())
            {
                musteriad = okuo["ad"].ToString();
                musterino = Convert.ToInt32(okuo["no"]);
            }
            baglanti.Close();
            FaturaTakipIslemleri f3 = new FaturaTakipIslemleri();
            f3.label1.Text = musterino.ToString();
            f3.label2.Text = musteriad;
            f3.Show();
            this.Hide();



        
    }

        private void button10_Click_1(object sender, EventArgs e)
        {
            yuksekdegerial();
            baglanti.Open();
            SqlCommand komuti = new SqlCommand("INSERT INTO firmalar (no,ad,isi,numara) VALUES('" + a + "','" + textBox1.Text + "','" + textBox5.Text + "','" + textBox3.Text + "')", baglanti);
            komuti.ExecuteNonQuery();
            baglanti.Close();
            gosterr();
            textBox3.Text = "";
            textBox1.Text = "";
            textBox5.Text = "";
            MessageBox.Show("Başarıyla Eklendi");
        }
    }
}
