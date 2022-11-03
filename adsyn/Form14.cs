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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = JUPITER\\SQLEXPRESS;Initial Catalog = adisyon90lar; Integrated Security = True;");
        string satisno;
        int a;

        private void yuksekdegerial()
        {


            baglanti.Open();
            SqlCommand cmdeydgr = new SqlCommand("SELECT Max(nno) FROM notlar", baglanti);
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
       

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime zaman = DateTime.Today;
            yuksekdegerial();
            baglanti.Open();
            SqlCommand komuti = new SqlCommand("INSERT INTO notlar (nno,ntrh,nhtrh,nott) VALUES('" + a + "','" + zaman.ToShortDateString() + "','" + dateTimePicker1.Value.ToShortDateString() + "','" + textBox1.Text + "')", baglanti);
            komuti.ExecuteNonQuery();
            baglanti.Close();
            this.Hide();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            DateTime zaman = DateTime.Today;
            dateTimePicker1.Value = Convert.ToDateTime(zaman.ToShortDateString());
            if (label3.Text=="guncelleme")
            {
                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = true;
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT *FROM notlar where nno='" + Convert.ToInt32(label4.Text) + "'", baglanti);
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {

                    
                   dateTimePicker1.Value=Convert.ToDateTime( oku["nhtrh"]);
                    textBox1.Text = oku["nott"].ToString();


                }
                baglanti.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komuti = new SqlCommand("UPDATE notlar SET nno='" + Convert.ToInt32(label4.Text) + "', nhtrh='" + dateTimePicker1.Value.ToShortDateString() + "', nott= '" + textBox1.Text + "' WHERE nno='" + Convert.ToInt32(label4.Text) + "'", baglanti);
            komuti.ExecuteNonQuery();
            baglanti.Close();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand silkomutu = new SqlCommand("DELETE FROM notlar where nno='" +Convert.ToInt32(label4.Text) + "'", baglanti);
            silkomutu.ExecuteNonQuery();
            baglanti.Close();
            this.Hide();
        }
    }
}
