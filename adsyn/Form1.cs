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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


     SqlConnection baglanti = new SqlConnection("Data Source = JUPITER\\SQLEXPRESS;Initial Catalog = adisyon90lar; Integrated Security = True;");

        DateTime zaman = DateTime.Today;

        string aciklama = "yok";
        


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="ETA GRUP" && textBox2.Text=="etainşaat1365")                    
            {

            this.Location = Screen.PrimaryScreen.Bounds.Location;
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM z_raporu WHERE ztrh='"+ zaman.ToShortDateString() +"'", baglanti);
            SqlDataReader oku = cmd.ExecuteReader();
            while (oku.Read())
            {
             Form2 fom2 = new Form2();
                    fom2.kontrl = 1;
                    fom2.Show();
            this.Hide();
            }
                baglanti.Close();
                panel1.Visible = true;
                panel2.Visible = false;
            }
            else
            {
                MessageBox.Show("Şifre Hatalı!! ");
            }
            
          
          

           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "ETA GRUP";
            this.Location = Screen.PrimaryScreen.Bounds.Location;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
                
            }
        }

        

       

       

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text=="")
            {
                aciklama = "acıklama yok";
            }
            else
            {
                aciklama = textBox4.Text;
            }
            
            DateTime zaman = DateTime.Today;
            baglanti.Open();
            SqlCommand komuti = new SqlCommand("INSERT INTO z_raporu (ztrh,zns,zks,zbs,zts,zgnb,zgkb,zgtb,znof,zkof,ztof,zof,ztf,zgnf,zgkf,zgtf,znm,zkm,ztm,zkdvr,znktkasa,zkrtkasa,ztplkasa,zackl) values('"+zaman.ToShortDateString()+"','"+""+"','"+""+"','"+""+"','"+""+"','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "','" + textBox3.Text + "','" + "" + "','" + "" + "','" + "" + "','" + "" + "') ", baglanti);
            komuti.ExecuteNonQuery();
            baglanti.Close();
            

            Form2 fom2 = new Form2();
            fom2.kontrl = 1;

            fom2.Show();
            this.Hide();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked==true)
            {
                label2.Visible = true;
                textBox4.Visible = true;               
            }
            else
            {
                label2.Visible = false;
                textBox4.Visible = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
      
            baglanti.Open();
            SqlCommand silkomutue = new SqlCommand("DELETE FROM satis", baglanti);
            silkomutue.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            SqlCommand silkomutuw = new SqlCommand("DELETE FROM satilanurunler", baglanti);
            silkomutuw.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            SqlCommand silkomutud = new SqlCommand("DELETE FROM paraislem", baglanti);
            silkomutud.ExecuteNonQuery();
            baglanti.Close();
           
        }
    }
    }

