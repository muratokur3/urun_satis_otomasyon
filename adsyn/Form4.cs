using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace adsyn
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source = JUPITER\\SQLEXPRESS;Initial Catalog = adisyon90lar; Integrated Security = True;");

        
       public string musteriad;
        public int musterino=1;
        bool borc=true;
        int adett = 1, urunkod,no_urun = 0, urun_no = 0,stok=0,skot,satisa=1;
        string kategorisi, satisno, tahsilatb, masatutar,odemetip;
        string aciklama = "yok";
        int fiyati, tutari, tutar;

        

        private void goster()
        {
            listView1.Items.Clear();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM urunler WHERE kategori='" + kategorisi + "'", baglanti);
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

        public void sgoster()
        {
            listView2.Items.Clear();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM musteris where mno ='" + musterino + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {

                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["ukod"].ToString();
                ekle.SubItems.Add(oku["uad"].ToString());
                ekle.SubItems.Add(oku["umarka"].ToString());
                ekle.SubItems.Add(oku["ukategori"].ToString());
                ekle.SubItems.Add(oku["uadet"].ToString());
                ekle.SubItems.Add(oku["ufiyat"].ToString());
                ekle.SubItems.Add(oku["ututar"].ToString());


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
            toplam();

        }

        public void toplam()
        {
            baglanti.Open();
            SqlCommand cmdtplm = new SqlCommand("SELECT Sum(ututar) FROM musteris WHERE mno='" + musterino + "'", baglanti);
            SqlDataReader dr = cmdtplm.ExecuteReader();
            if (dr.HasRows)
            {

                dr.Read();
                textBox1.Text = dr[0].ToString();
                masatutar = dr[0].ToString();


            }

            baglanti.Close();
        }

        private void eklemekler()
        {




            if (no_urun == 0)
            {
                MessageBox.Show("secim yap");
            }
            else
            {

                //*************************************************************************

                baglanti.Open();
                SqlCommand komuto = new SqlCommand("SELECT  *from musteris WHERE mno='" + musterino + "' AND ukod='" + no_urun + "'", baglanti);
                SqlDataReader okuo = komuto.ExecuteReader();
                while (okuo.Read())
                {
                    urunkod = Convert.ToInt32(okuo["ukod"]);
                    adett = Convert.ToInt32(okuo["uadet"]);
                    fiyati = Convert.ToInt32(okuo["ufiyat"]);
                    tutari = Convert.ToInt32(okuo["ututar"]);
                }
                baglanti.Close();

                baglanti.Open();
                SqlCommand komutao = new SqlCommand("SELECT  *from urunler WHERE kod='" + no_urun + "'", baglanti);
                SqlDataReader okuao = komutao.ExecuteReader();
                while (okuao.Read())
                {
                    stok = Convert.ToInt32(okuao["stok"]);
                    skot = Convert.ToInt32(okuao["stok"]);
                }
                baglanti.Close();
                //*************************************************************************

                if (urunkod == no_urun)
                {
                    adett++;
                    
                    baglanti.Open();
                    SqlCommand cmdadetart = new SqlCommand("UPDATE musteris SET uadet=" + adett + " WHERE mno='" + musterino + "' AND ukod=" + no_urun + "", baglanti);
                    cmdadetart.ExecuteNonQuery();
                    baglanti.Close();

                    tutari += fiyati;

                    baglanti.Open();
                    SqlCommand cmdtutar = new SqlCommand($"UPDATE musteris SET ututar={ tutari.ToString().Replace(",",".") } WHERE mno='{musterino}' AND ukod={no_urun}", baglanti);
                     cmdtutar.ExecuteNonQuery();
                    baglanti.Close();

                   

                }
                else
                {

                    baglanti.Open();
                    SqlCommand cmdadetekl = new SqlCommand("INSERT INTO musteris (mno,uad,ufiyat,uadet,mtutar,ukod,ututar,ukategori,umarka) SELECT '" + musterino + "',ad,satisf,adet,'" + tutar + "',kod,satisf,kategori,marka FROM urunler WHERE kod='" + no_urun + "'", baglanti);
                    cmdadetekl.ExecuteNonQuery();
                    baglanti.Close();

                }
                 stok--;
                    baglanti.Open();
                    SqlCommand cmdstk = new SqlCommand("UPDATE urunler SET stok=" + stok + " WHERE kod='" + no_urun + "'", baglanti);
                    cmdstk.ExecuteNonQuery();
                    baglanti.Close();

            }

        }

        private void cikar()
        {

            if (urun_no == 0)
            {
               MessageBox.Show("secim yap");
            }
            else
            {

                //*************************************************************************

                baglanti.Open();
                SqlCommand komuto = new SqlCommand("SELECT  *from musteris WHERE mno='" + musterino + "' AND ukod='" + urun_no + "'", baglanti);
                SqlDataReader okuo = komuto.ExecuteReader();
                while (okuo.Read())
                {
                    urunkod = Convert.ToInt32(okuo["ukod"]);
                    adett = Convert.ToInt32(okuo["uadet"]);
                    fiyati = Convert.ToInt32(okuo["ufiyat"]);
                    tutari = Convert.ToInt32(okuo["ututar"]);
                }
                baglanti.Close();
                //*************************************************************************



                if (adett > 1)
                {
                    adett--;
                    tutari -= fiyati;
                    baglanti.Open();
                    SqlCommand cmdadetart = new SqlCommand("UPDATE musteris SET uadet='" + adett + "' WHERE mno='" + musterino + "' AND ukod='" + urun_no + "'", baglanti);
                    cmdadetart.ExecuteNonQuery();
                    baglanti.Close();

                    baglanti.Open();
                    SqlCommand cmdtutar = new SqlCommand("UPDATE musteris SET ututar='" + tutari + "' WHERE mno='" + musterino + "' AND ukod='" + urun_no + "'", baglanti);
                    cmdtutar.ExecuteNonQuery();
                    baglanti.Close();
                }
                else
                {
                    baglanti.Open();
                    SqlCommand silkomutu = new SqlCommand("DELETE FROM musteris WHERE mno='" + musterino + "' AND ukod='" + urun_no + "'", baglanti);
                    silkomutu.ExecuteNonQuery();
                    baglanti.Close();
                }
                stok++;
                baglanti.Open();
                SqlCommand cmdstk = new SqlCommand("UPDATE urunler SET stok=" + stok + " WHERE kod='" + no_urun + "'", baglanti);
                cmdstk.ExecuteNonQuery();
                baglanti.Close();

            }
        }

        private void btnanasayfa_Click(object sender, EventArgs e)
        {
            Form2 fom2 = new Form2();
            fom2.Show();
            this.Hide();
        }

        private void btnmasa_Click(object sender, EventArgs e)
        {

            Form9 fom9 = new Form9();
            fom9.Show();
            this.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
            DateTime zaman = DateTime.Today;
            dateTimePicker1.Value = Convert.ToDateTime(zaman.ToShortDateString());

            musterino = Convert.ToInt32(label3.Text);
            musteriad = label4.Text;
            this.Location = Screen.PrimaryScreen.Bounds.Location;   
            urun_no = 0;
            sgoster();
            gosterr();
            label6.Text = musteriad;
            if (label6.Text == "Geçici Müşteri")
            {
                checkBox2.Visible=false;
                label6.Visible = false;
                textBox4.Visible = true;
                textBox4.Text = label6.Text;
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            cikar();
            sgoster();


        }

        private void button21_Click_1(object sender, EventArgs e)
        {

            Form9 fom9 = new Form9();
            fom9.Show();
            this.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                tahsilatb = "KART";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                label2.Visible = true;
                textBox2.Visible = true;
            }
            else
            {
                label2.Visible = false;
                textBox2.Visible = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            kategorisi = button7.Text;
            goster();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            kategorisi = button8.Text;
            goster();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kategorisi = button4.Text;
            goster();
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            kategorisi = ms1.Text;
            goster();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gosterr();
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                gosterr();

            }
            else
            {
                listView1.Items.Clear();
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT *FROM urunler WHERE ad LIKE '%" + textBox5.Text + "%'", baglanti);
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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

            if (textBox6.Text == "")
            {
                gosterr();

            }
            else
            {
                listView1.Items.Clear();
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT *FROM urunler WHERE kod='" + Convert.ToInt32(textBox6.Text) + "'", baglanti);
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

        private void button444_Click(object sender, EventArgs e)
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text=="")
            {
                textBox3.Text = "0";
            }
            else
            {

            
            if (Convert.ToInt32(textBox3.Text)>0)
            {
                groupBox2.Visible = true;
            }
            else
            {
                groupBox2.Visible = false;
            }}


            int a = Convert.ToInt32(textBox3.Text);
            int b = Convert.ToInt32(textBox1.Text);

            int c = b / 3;

            if (a<c)
            {
                textBox3.ForeColor = Color.White;
                textBox3.BackColor = Color.Red;
                }
            else if (a>c && a<2*c)
            {
                textBox3.ForeColor = Color.Black;
                textBox3.BackColor = Color.Gold;

                }
            else
            {
                textBox3.BackColor = Color.DarkGreen;
                textBox3.ForeColor = Color.White;

                }

            
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            kategorisi = button16.Text;
            goster();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            if (groupBox1.Visible==false)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
            }
            else
            {
                groupBox1.Visible = false;
                groupBox2.Visible = true;

            }
        }

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            urun_no = int.Parse(listView2.SelectedItems[0].SubItems[0].Text);
            cikar();
            sgoster();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                textBox1.Text = "0";
            }
        }

   private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            no_urun = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            eklemekler();
            sgoster();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                tahsilatb = "NAKİT";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            eklemekler();
            sgoster();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            kategorisi = button3.Text;
            goster();

        }

        private void button22_Click(object sender, EventArgs e)
        {

        }

      private void satistamamlama()
        {
            if (label6.Text == "Geçici Müşteri")
            {

                musteriad = textBox4.Text;
            }

            satisyuksekdegeral();
            DateTime bugun = DateTime.Today;
            baglanti.Open();
            SqlCommand cmdadetekl = new SqlCommand("INSERT INTO satis (sno,smno,smad,stutar,bverilen,bkalan,starihi,bvadet,tahsilatb,sodtip,sacikl) SELECT '" + satisa + "','" + musterino + "','" + musteriad + "','" + Convert.ToDouble(textBox1.Text) + "','" + Convert.ToDouble(textBox1.Text) + "','" + "0" + "','" + bugun.ToShortDateString() + "','" + "" + "','" + tahsilatb + "','" + "ÖDENDİ" + "','" + aciklama + "'", baglanti);
            cmdadetekl.ExecuteNonQuery();
            baglanti.Close();

           /* ************************************ */
            DateTime zsaat = DateTime.Now;
            string saat = zsaat.ToLongTimeString();
            DateTime zaman = DateTime.Today;
            baglanti.Open();
            SqlCommand komuti = new SqlCommand("INSERT INTO satilanurunler (satisno,suad,sufiyat,suadet,sumarka,sukategori,sutarih,susaat,sutahsilatb,sututar,sumusteri,suaciklama) SELECT '" + satisa + "',uad,ufiyat,uadet,umarka,ukategori,'" + zaman.ToShortDateString() + "','" + saat + "','" + tahsilatb + "','" + Convert.ToDouble(textBox1.Text) + "','" + musteriad + "','" + textBox2.Text + "' FROM musteris WHERE mno='" + musterino + "'", baglanti);
            komuti.ExecuteNonQuery();
            baglanti.Close();
            /*************************************/          
                baglanti.Open();
                SqlCommand cmdadetekil = new SqlCommand("INSERT INTO hareketler (hno,hsatisno,mad,htrh,uvt,sttr,hamktr,tb,hotip,hacikl) SELECT '" + 1010 + "','" + satisa + "','" + musteriad + "','" + bugun.ToShortDateString() + "','" + "" + "','"+ Convert.ToDouble(textBox1.Text) + "','" + Convert.ToDouble(textBox1.Text) + "','" + tahsilatb + "','" + "ÖDENDİ" + "','" + aciklama + "'", baglanti);
                cmdadetekil.ExecuteNonQuery();
                baglanti.Close();           
            /****************************************/
            listView2.Items.Clear();
            label1.Text = "0";
            baglanti.Open();
            SqlCommand silkomutu = new SqlCommand("DELETE FROM musteris where mno='" + musterino + "'", baglanti);
            silkomutu.ExecuteNonQuery();
            baglanti.Close();
        }
       
        private void satisyuksekdegeral()
        {

            baglanti.Close();
            baglanti.Open();
            SqlCommand cmdeydgr = new SqlCommand("SELECT MAX(sno) FROM satis", baglanti);
            SqlDataReader dr = cmdeydgr.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                satisno = dr[0].ToString();
            }
            baglanti.Close();
            satisa = Convert.ToInt32(satisno);
            satisa += 1;
        }

        private void borctanimla()
        {         
                if (textBox3.Text == "0")
                {
                    odemetip = "HİÇ ODENMEDİ";
                /*************************************/

                double st, sv = 0, sk;
                    st = Convert.ToDouble(textBox1.Text);
                    sv = Convert.ToDouble(textBox3.Text);
                    sk = st - sv;
                    DateTime bugun = DateTime.Today;
                    baglanti.Open();
                    SqlCommand cmdadetekl = new SqlCommand("INSERT INTO satis (sno,smno,smad,stutar,bverilen,bkalan,starihi,bvadet,tahsilatb,sodtip,sacikl) SELECT '" + satisa + "','" + musterino + "','" + musteriad + "','" + Convert.ToDouble(textBox1.Text) + "','" + Convert.ToDouble(textBox3.Text) + "','" + sk + "','" + bugun.ToShortDateString() + "','" + dateTimePicker1.Value.ToShortDateString() + "','" + tahsilatb + "','" + odemetip + "','" + aciklama + "'", baglanti);
                    cmdadetekl.ExecuteNonQuery();
                    baglanti.Close();
                /*************************************/
                baglanti.Open();
                    SqlCommand cmdadetekil = new SqlCommand("INSERT INTO hareketler (hno,hsatisno,mad,htrh,uvt,sttr,hamktr,tb,hotip,hacikl) SELECT '"+ 1 +"','" + satisa + "','" + musteriad + "','" + bugun.ToShortDateString() + "','" + dateTimePicker1.Value.ToShortDateString() + "','" + Convert.ToDouble(textBox1.Text) + "','" + Convert.ToDouble(textBox3.Text) + "','" + tahsilatb + "','" + odemetip + "','" + aciklama + "'", baglanti);
                    cmdadetekil.ExecuteNonQuery();
                    baglanti.Close();
                /*************************************/

                DateTime zsaat = DateTime.Now;
                string saat = zsaat.ToLongTimeString();
                DateTime zaman = DateTime.Today;
                baglanti.Open();
                SqlCommand komuti = new SqlCommand("INSERT INTO satilanurunler (satisno,suad,sufiyat,suadet,sumarka,sukategori,sutarih,susaat,sutahsilatb,sututar,sumusteri,suaciklama) SELECT '" + satisa + "',uad,ufiyat,uadet,umarka,ukategori,'" + zaman.ToShortDateString() + "','" + saat + "','" + tahsilatb + "','" + Convert.ToDouble(textBox1.Text) + "','" + musteriad + "','" + textBox2.Text + "' FROM musteris WHERE mno='" + musterino + "'", baglanti);
                komuti.ExecuteNonQuery();
                baglanti.Close();
                /*************************************/
                
                baglanti.Open();
                    SqlCommand silkomutue = new SqlCommand("DELETE FROM musteris where mno='" + musterino + "'", baglanti);
                    silkomutue.ExecuteNonQuery();
                    baglanti.Close();
                /*************************************/

                    Form9 fom9 = new Form9();
                    fom9.Show();
                    this.Hide();

                }
                else
                {
                    odemetip = "KISMEN ODENDİ";
                
                    if (radioButton1.Checked == true || radioButton2.Checked == true)
                    {                    
                        double st, sv = 0, sk;
                        st = Convert.ToDouble(textBox1.Text);
                        sv = Convert.ToDouble(textBox3.Text);
                        sk = st - sv;
                    /*************************************/
                    DateTime bugun = DateTime.Today;
                        baglanti.Open();
                        SqlCommand cmdadetekl = new SqlCommand("INSERT INTO satis (sno,smno,smad,stutar,bverilen,bkalan,starihi,bvadet,tahsilatb,sodtip,sacikl) SELECT '" + satisa + "','" + musterino + "','" + musteriad + "','" + Convert.ToDouble(textBox1.Text) + "','" + Convert.ToDouble(textBox3.Text) + "','" + sk + "','" + bugun.ToShortDateString() + "','" + dateTimePicker1.Value.ToShortDateString() + "','" + tahsilatb + "','" + odemetip + "','" + aciklama + "'", baglanti);
                        cmdadetekl.ExecuteNonQuery();
                        baglanti.Close();
                    /*************************************/
                    DateTime zsaat = DateTime.Now;
                    string saat = zsaat.ToLongTimeString();
                    DateTime zaman = DateTime.Today;
                    baglanti.Open();
                    SqlCommand komuti = new SqlCommand("INSERT INTO satilanurunler (satisno,suad,sufiyat,suadet,sumarka,sukategori,sutarih,susaat,sutahsilatb,sututar,sumusteri,suaciklama) SELECT '" + satisa + "',uad,ufiyat,uadet,umarka,ukategori,'" + zaman.ToShortDateString() + "','" + saat + "','" + tahsilatb + "','" + Convert.ToDouble(textBox1.Text) + "','" + musteriad + "','" + textBox2.Text + "' FROM musteris WHERE mno='" + musterino + "'", baglanti);
                    komuti.ExecuteNonQuery();
                    baglanti.Close();
                    /*************************************/
                    baglanti.Open();
                        SqlCommand cmdadetekil = new SqlCommand("INSERT INTO hareketler (hno,hsatisno,mad,htrh,uvt,sttr,hamktr,tb,hotip,hacikl) SELECT '"+ 1 +"','" + satisa + "','" + musteriad + "','" + bugun.ToShortDateString() + "','" + dateTimePicker1.Value.ToShortDateString() + "','" + Convert.ToDouble(textBox1.Text) + "','" + Convert.ToDouble(textBox3.Text) + "','" + tahsilatb + "','" + odemetip + "','" + aciklama + "'", baglanti);
                        cmdadetekil.ExecuteNonQuery();
                        baglanti.Close();                                      
                    /*************************************/
                    baglanti.Open();
                        SqlCommand silkomutur = new SqlCommand("DELETE FROM musteris where mno='" + musterino + "'", baglanti);
                        silkomutur.ExecuteNonQuery();
                        baglanti.Close();
                    /*************************************/
                    Form9 fom9 = new Form9();
                        fom9.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("tahsilat biçimi seçiniz!");
                    }
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            satisyuksekdegeral();  
            if (textBox1.Text=="0")
            {
                MessageBox.Show("MÜŞTERİYE ŞUAN İÇİN HERHANGİ BİR SATIŞ YAPILMADIĞINDAN İŞLEM TAMAMLANMADI");
            }
            else
            {
                if (checkBox2.Checked==true)
                {
                    borctanimla();                   
                }
                else
                {
                if (radioButton1.Checked == true || radioButton2.Checked == true)
                {
                        satistamamlama();                   
                        Form9 fom9 = new Form9();
                        fom9.Show();
                        this.Hide();
                }
                else
                {
                    MessageBox.Show("Lütfen tahsilat biçimini seçiniz!!!");
                }                
               }              
            }           
        }

        private void ms1_Click(object sender, EventArgs e)
        {
            kategorisi = ms1.Text;
            goster();

        }

        private void sil_Click(object sender, EventArgs e)
        {
            tutar = 0;
            textBox1.Text = "";
            baglanti.Open();
            SqlCommand silkomutu = new SqlCommand("DELETE FROM musteris where mno='" + musterino + "'", baglanti);
            silkomutu.ExecuteNonQuery();
            baglanti.Close();
            listView2.Items.Clear();
            sgoster();
           
        }
    }
}
