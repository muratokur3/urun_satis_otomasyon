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
    public partial class kasa : Form
    {
        public kasa()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = JUPITER\\SQLEXPRESS;Initial Catalog = adisyon90lar; Integrated Security = True;");
        int kassa, nkasa, kkasa,islemk,islemnk,islemkk,mkt;
        string ism,ib, ac,nr;

        private void goster()
        {

            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM kassa", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                label2.Text = oku["kasa"].ToString();
                label3.Text = oku["nkasa"].ToString();
                label5.Text = oku["kkasa"].ToString();
               
            }
            baglanti.Close();
        }

        private void kasa_Load(object sender, EventArgs e)
        {

            DateTime zaman = DateTime.Today;
            dateTimePicker3.Value = Convert.ToDateTime(zaman.ToShortDateString());
            goster();
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }
        
        private void cıkıs()
        {
            listView1.Items.Clear();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM paraislem WHERE ib='" + "C" + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["trh"].ToString();
                ekle.SubItems.Add(oku["iy"].ToString());
                ekle.SubItems.Add(oku["nr"].ToString());
                ekle.SubItems.Add(oku["im"].ToString());
                ekle.SubItems.Add("ÇIKIŞ + " +oku["ac"].ToString());
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

        private void giris()
        {
            listView2.Items.Clear();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM paraislem WHERE ib='" + "E" + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["trh"].ToString();
                ekle.SubItems.Add(oku["iy"].ToString());
                ekle.SubItems.Add(oku["nr"].ToString());
                ekle.SubItems.Add(oku["im"].ToString());
                ekle.SubItems.Add("GİRİŞ + " + oku["ac"].ToString());
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

        private void kekle()
        {
            cek();
            islemk = kassa + Convert.ToInt32(textBox4.Text);
            islemkk = kkasa + Convert.ToInt32(textBox4.Text);

            baglanti.Open();
            SqlCommand komuti = new SqlCommand("UPDATE kassa SET kasa='" + islemk + "', kkasa='" + islemkk + "'", baglanti);
            komuti.ExecuteNonQuery();
            baglanti.Close();
            ism = comboBox4.Text;
            mkt = Convert.ToInt32(textBox4.Text);
            ib = "E";

        }

        private void nekle()
        {
            cek();
            islemk = kassa + Convert.ToInt32(textBox4.Text);
            islemnk = nkasa + Convert.ToInt32(textBox4.Text);

            baglanti.Open();
            SqlCommand komuti = new SqlCommand("UPDATE kassa SET kasa='" + islemk + "', nkasa='" + islemnk + "'", baglanti);
            komuti.ExecuteNonQuery();
            baglanti.Close();
            ism = comboBox4.Text;
            mkt = Convert.ToInt32(textBox4.Text);
            ib = "E";


        }

        private void islem()
            {

            DateTime bugun = DateTime.Today;
            baglanti.Open();
            SqlCommand cmdadetekl = new SqlCommand("INSERT INTO paraislem (trh,iy,nr,im,ib,ac) SELECT '" + bugun.ToLongDateString() + "','" + ism + "','"+nr+"','" + mkt + "','" + ib + "','" + ac + "'", baglanti);
            cmdadetekl.ExecuteNonQuery();
            baglanti.Close();

        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.Visible==false)
            {
                groupBox3.Visible = true;
                listView1.Visible = true;
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                listView2.Visible = false;
            }
            else
            {
                groupBox3.Visible = false;
                listView1.Visible = false;
            }
            cıkıs();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listView1.Visible==true)
            {
                listView1.Items.Clear();

                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT *FROM paraislem WHERE ib='" + "C" + "' and trh='"+dateTimePicker3.Value.ToLongDateString()+"'", baglanti);
                SqlDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = oku["trh"].ToString();
                    ekle.SubItems.Add(oku["iy"].ToString());
                    ekle.SubItems.Add(oku["nr"].ToString());
                    ekle.SubItems.Add(oku["im"].ToString());
                    ekle.SubItems.Add(oku["ib"].ToString());
                    ekle.SubItems.Add("ÇIKIŞ + " + oku["ac"].ToString());
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
            else
            {
                
                     listView2.Items.Clear();

                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT *FROM paraislem WHERE ib='" + "E" + "' and trh = '"+dateTimePicker3.Value.ToLongDateString()+"'", baglanti);
                SqlDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    ListViewItem ekle = new ListViewItem();
                    ekle.Text = oku["trh"].ToString();
                    ekle.SubItems.Add(oku["iy"].ToString());
                    ekle.SubItems.Add(oku["nr"].ToString());
                    ekle.SubItems.Add(oku["im"].ToString());
                    ekle.SubItems.Add(oku["ib"].ToString());
                    ekle.SubItems.Add("GİRİŞ + " + oku["ac"].ToString());
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

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.Text = "";

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form2 ff2 = new Form2();
            ff2.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listView2.Visible == false)
            {
                groupBox3.Visible = true;
                listView2.Visible = true;
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                listView1.Visible = false;
            }
            else
            {
                groupBox3.Visible = false;
                listView2.Visible = false;
            }
            giris();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox3.Text=="" || textBox3.Text=="Açıklama")
            {
                ac = "yok";
            }
            else
            {
                ac = textBox3.Text;
            }
            cek();
            if (comboBox3.Text=="NAKİT")
            {
                nr = "NAKİT";
                nekle();
                islem();
            }
            else if (comboBox3.Text == "KART")
            {
                nr = "KART";
                kekle();
                islem();

            }
            else
            {
                MessageBox.Show("tahsilat biçimi seçiniz!!");
            }
            goster();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (groupBox1.Visible==false)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                listView1.Visible = false;
                groupBox3.Visible = false;
                listView2.Visible = false;
            }
            else
            {
                groupBox1.Visible = false;
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (groupBox2.Visible == false)
            {
                groupBox2.Visible = true;
                groupBox1.Visible = false;
                listView1.Visible = false;
                groupBox3.Visible = false;
                listView2.Visible = false;
            }
            else
            {
                groupBox2.Visible = false;

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void nakitislem()
        {
            cek();
            islemk = kassa - Convert.ToInt32(textBox1.Text);
            islemnk= nkasa - Convert.ToInt32(textBox1.Text);

            baglanti.Open();
            SqlCommand komuti = new SqlCommand("UPDATE kassa SET kasa='" + islemk + "', nkasa='" + islemnk + "'", baglanti);
            komuti.ExecuteNonQuery();
            baglanti.Close();
            ism = comboBox1.Text;
            mkt = Convert.ToInt32(textBox1.Text);
            ib = "C";


        }

        private void kartislem()
        {
            cek();
            islemk = kassa - Convert.ToInt32(textBox1.Text);
            islemkk = kkasa - Convert.ToInt32(textBox1.Text);

            baglanti.Open();
            SqlCommand komuti = new SqlCommand("UPDATE kassa SET kasa='" + islemk + "', kkasa='" + islemkk + "'", baglanti);
            komuti.ExecuteNonQuery();
            baglanti.Close();
            ism = comboBox1.Text;
            mkt = Convert.ToInt32(textBox1.Text);
            ib = "C";


        }

        private void cek()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM kassa", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                kassa = Convert.ToInt32(oku["kasa"].ToString());
                nkasa = Convert.ToInt32(oku["nkasa"].ToString());
                kkasa = Convert.ToInt32(oku["kkasa"].ToString());
            }
            baglanti.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox2.Text == "Açıklama")
            {
                ac = "yok";
            }
            else
            {
                ac = textBox2.Text;
            }


            if (comboBox2.Text=="NAKİT")
            {
                nr = "NAKİT";
                nakitislem();
                islem();

            }
            else if(comboBox2.Text=="KART")
            {
                nr = "KART";
                kartislem();
                islem();

            }
            else
            {
                MessageBox.Show("tahsilat biçimi seçiniz!!");
            }
            goster();
        }
    }
}
