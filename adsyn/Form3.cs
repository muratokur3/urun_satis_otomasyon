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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = JUPITER\\SQLEXPRESS;Initial Catalog = adisyon90lar; Integrated Security = True;");
        string masatutar,musteriad;
       



        public void mgecmgoster()
        {
            listView1.Items.Clear();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM satis where smno ='" + Convert.ToInt32(label1.Text) + "' and( sodtip ='" + "KISMEN ODENDİ" + "' or sodtip ='" + "HİÇ ODENMEDİ" + "')", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["sno"].ToString();
                ekle.SubItems.Add(oku["smad"].ToString());
                ekle.SubItems.Add(oku["stutar"].ToString());
                ekle.SubItems.Add(oku["bverilen"].ToString());
                ekle.SubItems.Add(oku["bkalan"].ToString());
                ekle.SubItems.Add(oku["starihi"].ToString());
                ekle.SubItems.Add(oku["bvadet"].ToString());
                ekle.SubItems.Add(oku["sodtip"].ToString());
                ekle.SubItems.Add(oku["sacikl"].ToString());


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
        public void satisgoster()
        {
            listView1.Items.Clear();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM satis where smno ='"+Convert.ToInt32(label1.Text)+"'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["sno"].ToString();
                ekle.SubItems.Add(oku["smad"].ToString());
                ekle.SubItems.Add(oku["stutar"].ToString());
                ekle.SubItems.Add(oku["bverilen"].ToString());
                ekle.SubItems.Add(oku["bkalan"].ToString());
                ekle.SubItems.Add(oku["starihi"].ToString());
                ekle.SubItems.Add(oku["bvadet"].ToString());
                ekle.SubItems.Add(oku["sodtip"].ToString());
                ekle.SubItems.Add(oku["sacikl"].ToString());


                listView1.Items.Add(ekle);
                ListView listView = this.listView1;
                int i = 0;
                Color shaded = Color.Brown;
                foreach (ListViewItem item in listView.Items)
                {
                    if (i++ % 2 == 1)
                    {
                        item.BackColor = Color.Green;
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



        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.label3.Text = label1.Text;
            f4.label4.Text=label2.Text;
            f4.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
           
            satisgoster();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            mgecmgoster();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            satisgoster();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
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

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int satisno = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
           
            Form10 f0 = new Form10();
            f0.label1.Text = satisno.ToString();
            f0.label2.Text = label2.Text;


            f0.Show();
            this.Hide();
        }
    }
}
