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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = JUPITER\\SQLEXPRESS;Initial Catalog = adisyon90lar; Integrated Security = True;");
        int notno;
        private void Form15_Load(object sender, EventArgs e)
        {
            listView3.Items.Clear();
            DateTime bugun = DateTime.Today;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM notlar where nhtrh='" + bugun.ToShortDateString() + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["nno"].ToString();
                ekle.SubItems.Add(oku["ntrh"].ToString());
                ekle.SubItems.Add(oku["nhtrh"].ToString());
                ekle.SubItems.Add(oku["nott"].ToString());


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

            listView1.Items.Clear();
            

            baglanti.Open();
            SqlCommand komute = new SqlCommand("SELECT *FROM satis where bvadet ='" + bugun.ToShortDateString() + "' and (sodtip ='" + "KISMEN ODENDİ" + "' OR sodtip ='" + "HİÇ ODENMEDİ" + "')", baglanti);
            SqlDataReader okue = komute.ExecuteReader();
            while (okue.Read())
            {

                ListViewItem ekle = new ListViewItem();
                ekle.Text = okue["sno"].ToString();
                ekle.SubItems.Add(okue["smad"].ToString());
                ekle.SubItems.Add(okue["stutar"].ToString());
                ekle.SubItems.Add(okue["bverilen"].ToString());
                ekle.SubItems.Add(okue["bkalan"].ToString());
                ekle.SubItems.Add(okue["starihi"].ToString());
                ekle.SubItems.Add(okue["bvadet"].ToString());
                ekle.SubItems.Add(okue["sodtip"].ToString());
                ekle.SubItems.Add(okue["sacikl"].ToString());


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
            listView2.Items.Clear();
            baglanti.Open();
            SqlCommand komutr = new SqlCommand("SELECT *FROM urunler where stok <=" + 100 + "", baglanti);
            SqlDataReader okur = komutr.ExecuteReader();
            while (okur.Read())
            {

                ListViewItem ekle = new ListViewItem();
                ekle.Text = okur["kod"].ToString();
                ekle.SubItems.Add(okur["ad"].ToString());
                ekle.SubItems.Add(okur["marka"].ToString());
                ekle.SubItems.Add(okur["kategori"].ToString());
                ekle.SubItems.Add(okur["alisf"].ToString());
                ekle.SubItems.Add(okur["satisf"].ToString());
                ekle.SubItems.Add(okur["stok"].ToString());
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

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int satisno = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            listView1.Items.Clear();

            Form10 f0 = new Form10();
            f0.label11.Text = "borc";
            f0.label1.Text = satisno.ToString();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM satis where sno ='" + satisno + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                f0.label2.Text = oku["smad"].ToString();
            }
            baglanti.Close();

            f0.Show();
        }

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notno = int.Parse(listView2.SelectedItems[0].SubItems[0].Text);
            Form12 fs = new Form12();
            fs.label4.Text = "stok";
            fs.textBox1.Text = notno.ToString();
            fs.Show();
        }

        private void listView3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notno = int.Parse(listView3.SelectedItems[0].SubItems[0].Text);
            Form14 fnot = new Form14();
            fnot.label3.Text = "guncelleme";
            fnot.label4.Text = notno.ToString();
            fnot.Show();
        }
    }
}
