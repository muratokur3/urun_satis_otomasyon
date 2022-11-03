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
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace adsyn
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = JUPITER\\SQLEXPRESS;Initial Catalog = adisyon90lar; Integrated Security = True;");
        String tttt,hno;
        int a;

        public void gosterr()
        {
            listView1.Items.Clear();
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM satilanurunler where satisno='" + Convert.ToInt32(label1.Text) + "'", baglanti);

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

        public void hareketgoster()
        {
           

            listView2.Items.Clear();
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM hareketler where hsatisno='" + Convert.ToInt32(label1.Text) + "' ORDER BY hno", baglanti);

            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["hno"].ToString();
                ekle.SubItems.Add(oku["htrh"].ToString());
                ekle.SubItems.Add(oku["uvt"].ToString());
                ekle.SubItems.Add(oku["sttr"].ToString());
                ekle.SubItems.Add(oku["hamktr"].ToString());
                ekle.SubItems.Add(oku["tb"].ToString());
                ekle.SubItems.Add(oku["hotip"].ToString());
                ekle.SubItems.Add(oku["mad"].ToString());
                ekle.SubItems.Add(oku["hacikl"].ToString());
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

            baglanti.Close();
            baglanti.Open();
            SqlCommand cmdeydgr = new SqlCommand("SELECT Max(hno) FROM hareketler where hsatisno='" + Convert.ToInt32(label1.Text) + "'", baglanti);
            SqlDataReader dr = cmdeydgr.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                hno = dr[0].ToString();
            }
            baglanti.Close();
            a = Convert.ToInt32(hno);
            a += 1;
        }
       
        public void borcgoster()
        {
            baglanti.Close();

            baglanti.Open();
            SqlCommand komutw = new SqlCommand("SELECT *FROM satis where sno='" + Convert.ToInt32(label1.Text) + "' and ( sodtip ='" + "KISMEN ODENDİ" + "' or sodtip ='" + "HİÇ ODENMEDİ" + "')", baglanti);
            SqlDataReader okuw = komutw.ExecuteReader();
            if (okuw.Read())
            {
                groupBox1.Visible = true;
                string nSayi = string.Format("{0:0,0}", okuw["stutar"]).Replace(",", ".");
                textBox1.Text = nSayi;

                string dSayi = string.Format("{0:0,0}", okuw["bverilen"]).Replace(",", ".");
                textBox2.Text = dSayi;

                string cSayi = string.Format("{0:0,0}", okuw["bkalan"]).Replace(",", ".");
                textBox3.Text =cSayi;

                dateTimePicker1.Value =Convert.ToDateTime( okuw["starihi"].ToString());
                dateTimePicker2.Value =Convert.ToDateTime( okuw["bvadet"].ToString());
            }
            else
            {
                groupBox1.Visible = false;

            }
            baglanti.Close();

        }

        private void Form10_Load(object sender, EventArgs e)
        {
            DateTime zaman = DateTime.Today;
            dateTimePicker1.Value = Convert.ToDateTime(zaman.ToShortDateString());
            dateTimePicker2.Value = Convert.ToDateTime(zaman.ToShortDateString());
            if (label11.Text=="borc")
            {
                button10.Visible = true;
                button31.Visible = false;
            }
            gosterr();
            borcgoster();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
                yuksekdegerial();
            double st, sa, sk;
            st = Convert.ToDouble(textBox1.Text);
            sa = Convert.ToDouble(textBox2.Text);
            sk = Convert.ToDouble(textBox3.Text);
            sa = sa + Convert.ToDouble(textBox6.Text);
            sk = st - sa;
            if (radioButton1.Checked == true || radioButton2.Checked == true || textBox6.Text=="")
                {          
            if (sk==0)
            {
                
           /* ************************************ */
                    baglanti.Open();
                    SqlCommand cmdadetart = new SqlCommand("UPDATE satis SET sodtip='" + "ÖDENDİ" + "', bverilen=" + sa + ",bkalan='" + sk + "' WHERE sno='" + Convert.ToInt32(label1.Text) + "'", baglanti);
                    cmdadetart.ExecuteNonQuery();
                    baglanti.Close();
           /* ************************************ */
                    baglanti.Open();
                    SqlCommand cmdadetar = new SqlCommand("UPDATE satilanurunler SET sutahsilatb='" + tttt + "ile ÖDENDİ" + "' WHERE satisno='" + Convert.ToInt32(label1.Text) + "'", baglanti);
                    cmdadetar.ExecuteNonQuery();
                    baglanti.Close();           
           /* ************************************ */
                    yuksekdegerial();
                    DateTime bugun = DateTime.Today;
                    baglanti.Open();
                    SqlCommand cmdadetekl = new SqlCommand("INSERT INTO hareketler (hno,hsatisno,mad,htrh,uvt,sttr,hamktr,tb,hotip,hacikl) SELECT '"+a+"','" + Convert.ToInt32(label1.Text) + "','" + label2.Text + "','" + bugun.ToShortDateString() + "','" + dateTimePicker2.Value.ToShortDateString() + "','"+st+"','" + Convert.ToDouble(textBox6.Text) + "','" + tttt + "','" + "ODENDİ" + "','" + textBox5.Text + "'", baglanti);
                    cmdadetekl.ExecuteNonQuery();
                    baglanti.Close();
           /* ************************************ */
                    borcgoster();
                    textBox6.Text = "";
           /* ************************************ */
                    Form9 f9= new Form9();
                    f9.Show();
                    this.Hide();
           /* ************************************ */
                       
            }
            else
            {
                baglanti.Open();
                SqlCommand cmdadetart = new SqlCommand("UPDATE satis SET bverilen=" + sa + ",bkalan='" + sk + "',bvadet='"+dateTimePicker2.Value.ToShortDateString()+"' WHERE sno='" + Convert.ToInt32(label1.Text) + "'", baglanti);
                cmdadetart.ExecuteNonQuery();
                baglanti.Close();
                
                Form9 fe9 = new Form9();
                fe9.Show();
                this.Hide();
                DateTime bugune = DateTime.Today;
                baglanti.Open();
                SqlCommand cmdadetekel = new SqlCommand("INSERT INTO hareketler (hno,hsatisno,mad,htrh,uvt,sttr,hamktr,tb,hotip,hacikl) SELECT '"+a+"','" + Convert.ToInt32(label1.Text) + "','" + label2.Text + "','" + bugune.ToShortDateString() + "','" + dateTimePicker2.Value.ToShortDateString() + "','" + st + "','" + Convert.ToDouble(textBox6.Text) + "','" + tttt + "','" + "SKISMEN ODENDİ" + "','" + textBox5.Text + "'", baglanti);

                cmdadetekel.ExecuteNonQuery();
                baglanti.Close();
                borcgoster();
                textBox6.Text = "";
            }
          
              }
                else
                {
                    MessageBox.Show("Tahsilat Biçimini Ve Alınan Miktarı Kontrol Ediniz Seçiniz!!!");
                }  
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false)
            {
                radioButton1.Checked = true;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked == false)
            {
                radioButton2.Checked = true;

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton2.Checked == true)
            {
                tttt = "KART";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true)
            {
                tttt = "NAKİT";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView2.Visible==false)
            {
                listView2.Visible = true;
                listView1.Visible = false;
                groupBox1.Visible = false;
                button3.Visible = true;
                button444.Visible = false;
                hareketgoster();

            }
            else
            {
                listView2.Visible = false;
                listView1.Visible = true;
                groupBox1.Visible = true;
                button3.Visible = false;
                button444.Visible = true;


            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();

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

        private void button3_Click(object sender, EventArgs e)
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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
         

            string sSayi = string.Format("{0:0,0}", textBox6.Text).Replace(",", ".");
            textBox6.Text = sSayi;
        }

        private void button31_Click(object sender, EventArgs e)
        {

            Form9 f9 = new Form9();
            f9.Show();
            this.Hide();
        }
    }
}
