using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace adsyn
{
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = JUPITER\\SQLEXPRESS;Initial Catalog = adisyon90lar; Integrated Security = True;");
        string tb,satisno;
        public string fn, fad;
        int a;

        public void borcgoster()
        {
            baglanti.Close();

            baglanti.Open();
            SqlCommand komutw = new SqlCommand("SELECT *FROM faturagirisi where fno='" + Convert.ToInt32(label2.Text) + "'", baglanti);
            SqlDataReader okuw = komutw.ExecuteReader();
            if (okuw.Read())
            {

                textBox1.Text = okuw["fm"].ToString();
                textBox2.Text = okuw["fa"].ToString();
                textBox3.Text = okuw["fk"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(okuw["ftrh"].ToString());
                if (okuw["fm"].ToString()==okuw["fa"].ToString())
                {
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    dateTimePicker2.Enabled = false;
                    radioButton1.Enabled = false;
                    radioButton2.Enabled = false;
                    button1.Enabled = false;
                }
                else
                {
                    dateTimePicker2.Value = Convert.ToDateTime(okuw["fvtrh"].ToString());
                }
            }
            baglanti.Close();

        }
        private void yuksekdegerial()
        {

            baglanti.Close();
            baglanti.Open();
            SqlCommand cmdeydgr = new SqlCommand("SELECT Max(hno) FROM faturahareket where hfaturano='" + Convert.ToInt32(label2.Text)+"'", baglanti);
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
        private void Form17_Load(object sender, EventArgs e)
        {
            DateTime zaman = DateTime.Today;
            dateTimePicker1.Value = Convert.ToDateTime(zaman.ToShortDateString());
            dateTimePicker2.Value = Convert.ToDateTime(zaman.ToShortDateString());

            borcgoster();
             baglanti.Open();
              SqlCommand komut = new SqlCommand("SELECT *FROM faturagirisi where fno='" + Convert.ToInt32(label2.Text) + "'", baglanti);
              SqlDataReader oku = komut.ExecuteReader();
              while (oku.Read())
              {
                  label12.Text = oku["fno"].ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            double ft, fa, fk;

            ft = Convert.ToDouble(textBox1.Text);
            fa = Convert.ToDouble(textBox2.Text);
            fk = Convert.ToDouble(textBox3.Text);
            fa += Convert.ToDouble(textBox4.Text);
            fk = ft - fa;
            if (textBox4.Text == "")
            {
                MessageBox.Show("Alınacak Miktar Alanını Doldurunuz!!!");
            }
            else
            {

            
            if (fk == 0)
            {
                if (radioButton1.Checked == true || radioButton2.Checked == true)
                {
                    baglanti.Open();
                    SqlCommand cmdadetart = new SqlCommand("UPDATE faturagirisi SET fa=" + fa + ",fk='" + fk + "',fotip='"+tb+"İLE ODENDİ"+"' WHERE fno='" + Convert.ToInt32(label2.Text) + "'", baglanti);
                    cmdadetart.ExecuteNonQuery();
                    baglanti.Close();
                        
                        this.Hide();
                    }
                else
                {
                    MessageBox.Show("Tahsilat Biçimi Seçiniz!!!");
                }
            }
            else
            {
                baglanti.Open();
                SqlCommand cmdadetart = new SqlCommand("UPDATE faturagirisi SET fa=" + fa + ",fotip='" + "KISMEN ODENDİ" + "',fk='" + fk + "',fvtrh='" + dateTimePicker2.Value.ToShortDateString() + "' WHERE fno='" + Convert.ToInt32(label2.Text) + "'", baglanti);
                cmdadetart.ExecuteNonQuery();
                baglanti.Close();
                    
                this.Hide();
            }

            yuksekdegerial();
            DateTime bugun = DateTime.Today;
            baglanti.Open();
            SqlCommand cmdadetekl = new SqlCommand("INSERT INTO faturahareket (hno,hfaturano,fno,fad,htrh,hutrh,hmktr,bicim,tb,ackl) SELECT '" + a + "','" +Convert.ToInt32( label2.Text) + "','" + Convert.ToInt32(label10.Text) + "','" + label11.Text + "','" + bugun.ToShortDateString() + "','" + dateTimePicker2.Value.ToShortDateString() + "','" + Convert.ToDouble(textBox4.Text) + "','" + "sonradan" + "','" + tb + "','" + textBox5.Text + "'", baglanti);
            cmdadetekl.ExecuteNonQuery();
            baglanti.Close();
             }


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            tb = "NAKİT";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            tb = "KART";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (groupBox1.Visible==false)
            {
                groupBox1.Visible = true;
                listView2.Visible = false;
                listView3.Visible = false;
            }
            else
            {

                groupBox1.Visible = false;
                listView2.Visible = true;
                listView3.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView2.Visible == false)
            {
                groupBox1.Visible = false;
                listView2.Visible = true;
                listView3.Visible = false;
            }
            else
            {

                groupBox1.Visible = true;
                listView2.Visible = false;
                listView3.Visible = false;
            }
            listView2.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM faturahareket where hfaturano='" + Convert.ToInt32(label2.Text) + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
               
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["hno"].ToString();
                ekle.SubItems.Add(oku["fno"].ToString());
                ekle.SubItems.Add(oku["fad"].ToString());
                ekle.SubItems.Add(oku["htrh"].ToString());
                ekle.SubItems.Add(oku["hutrh"].ToString());
                ekle.SubItems.Add(oku["hmktr"].ToString());
                ekle.SubItems.Add(oku["tb"].ToString());
                ekle.SubItems.Add(oku["ackl"].ToString());
                

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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView3.Visible==false)
            {
                listView2.Visible = false;
                groupBox1.Visible = false;
                listView3.Visible = true;
                listView3.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM gfatura where sirano=" + Convert.ToInt32(label2.Text) + "", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["kod"].ToString();
                ekle.SubItems.Add(oku["adi"].ToString());
                ekle.SubItems.Add(oku["adet"].ToString());
                ekle.SubItems.Add(oku["birimfiyat"].ToString());
                ekle.SubItems.Add(oku["toplamfiyat"].ToString());
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
            else
            {
                listView2.Visible = false;
                groupBox1.Visible = true;
                listView3.Visible = false;
            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
        }
    }
}
