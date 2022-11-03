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
    public partial class FaturaGiris : Form
    {
        public FaturaGiris()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source = JUPITER\\SQLEXPRESS;Initial Catalog = adisyon90lar; Integrated Security = True;");
        Int32 a=1,stok,bay;
        bool no;
        string alinditb,alinmaditb,odeme,aciklama="YOK",faturano,firmaninadi;
        int toplam;
        private void faturagirisiyap()
        {
            if (textBox9.Text=="0")
            {
                textBox12.Text = textBox14.Text;
            }
            DateTime zamaan = DateTime.Today;
            baglanti.Open();
            SqlCommand komuti = new SqlCommand("INSERT INTO faturagirisi (fno,ffno,ftb,fotip,ftrh,fvtrh,fm,fa,fk,fackl) VALUES('" + a + "','" + textBox5.Text + "','" + alinmaditb + "','" + odeme + "','" + zamaan.ToShortDateString() + "','" + dateTimePicker2.Value.ToShortDateString() + "','" + textBox14.Text.ToString().Replace(",", ".") + "','" + textBox9.Text.ToString().Replace(",", ".") + "'," + Convert.ToInt32(textBox12.Text.ToString().Replace(",", ".")) + ",'" + aciklama + "')", baglanti);
            komuti.ExecuteNonQuery();
            baglanti.Close();

            if (odeme == "ÖDENMEDİ")
            {
                alinmaditb = "ÖDEME YOK";
            }
            baglanti.Open();
             SqlCommand cmdadetekl = new SqlCommand("INSERT INTO faturahareket (hno,hfaturano,fno,fad,htrh,hutrh,hmktr,tb,bicim,ackl) SELECT " + 1 + "," + a + ",'" + Convert.ToInt32(textBox5.Text) + "','" + firmaninadi + "','" + zamaan.ToShortDateString() + "','" + dateTimePicker2.Value.ToShortDateString() + "','" + Convert.ToInt32(textBox9.Text) + "','" + alinmaditb + "','" + "ilk" + "','" + textBox13.Text + "'", baglanti);
            cmdadetekl.ExecuteNonQuery();
            baglanti.Close();

            checkBox1.Checked = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;



            MessageBox.Show("başarıla gerçekleştirildi");
        }
       
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


        private void button2_Click(object sender, EventArgs e)
        {
            if (groupBox3.Visible == false)
            {
                groupBox3.Visible = true;
                groupBox2.Visible =false;
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
            else
                groupBox3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komuto = new SqlCommand("SELECT  *from firmalar WHERE no='" + textBox5.Text + "'", baglanti);
            SqlDataReader okuo = komuto.ExecuteReader();
            while (okuo.Read())
            {
                firmaninadi = okuo["ad"].ToString();
            }
            baglanti.Close();
            if (textBox5.Text == "")
            {
                MessageBox.Show("BOŞ ALANLARI GEÇMEYİNİZ!!!");
            }
             else
            {
                    
               
                if (checkBox2.Checked==true)
            {
                aciklama = textBox13.Text;
            }
            else
            {
                aciklama = "YOK";
            }

            if (checkBox1.Checked==true)
            {
              
                if (textBox9.Text=="0")
                {
                 odeme = "ÖDENMEDİ";
                    alinmaditb = "";
                    textBox9.Text = textBox12.Text;
                    faturagirisiyap();
                        Form2 f2 = new Form2();
                        f2.Show();
                        this.Hide();
                }
                else
                {
                  odeme = "KISMEN ÖDENDİ";
                if (radioButton3.Checked==true || radioButton4.Checked==true)
                {
                        faturagirisiyap();
                            Form2 f2 = new Form2();
                            f2.Show();
                            this.Hide();
                        }
                else
                {
                    MessageBox.Show("TAHSİLAT BİÇİMİ SEÇİNİZ PATRON!!");

                }
                }
               
            }
            else
            {
                odeme = "ÖDENDİ";
                if (radioButton1.Checked == true || radioButton2.Checked == true)
                {
                    DateTime zamaan = DateTime.Today;
                    baglanti.Open();
                    SqlCommand komuti = new SqlCommand("INSERT INTO faturagirisi (fno,ffno,ftb,fotip,ftrh,fvtrh,fm,fa,fk,fackl) VALUES('" + a + "','" + textBox5.Text + "','"+alinditb+"','" + odeme + "','" + zamaan.ToShortDateString() + "','" + "" + "','" + textBox14.Text.ToString().Replace(",", ".") + "','" + textBox14.Text.ToString().Replace(",", ".") + "','" + textBox12.Text.ToString().Replace(",", ".") + "','" + aciklama + "')", baglanti);
                    komuti.ExecuteNonQuery();
                    baglanti.Close();

                    
                    baglanti.Open();
                    SqlCommand cmdadetekl = new SqlCommand("INSERT INTO faturahareket (hno,hfaturano,fno,fad,htrh,hutrh,hmktr,tb,bicim,ackl) SELECT " + 1 + "," + a + ",'" + Convert.ToInt32(textBox5.Text) + "','" + firmaninadi + "','" + zamaan.ToShortDateString() + "','" + "" + "','" + Convert.ToInt32(textBox14.Text) + "','" + alinditb + "','"+"ilk"+"','" + textBox13.Text + "'", baglanti);
                    cmdadetekl.ExecuteNonQuery();
                    baglanti.Close();

                    checkBox1.Checked = false;
                    radioButton1.Visible = false;
                    radioButton2.Visible = false;
                    MessageBox.Show("başarıla gerçekleştirildi");
                        Form2 f2 = new Form2();
                        f2.Show();
                        this.Hide();
                    }
                else
                {
                    MessageBox.Show("TAHSİLAT BİÇİMİ SEÇİNİZ PATRON!!");

                }
            }


            }
           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                alinditb = "NAKİT";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                alinditb = "KART";
            }
        }

        private void FaturaGiris_Load(object sender, EventArgs e)
        {
            this.Location = Screen.PrimaryScreen.Bounds.Location;

            no = true;
            DateTime zaman = DateTime.Today;
            dateTimePicker1.Value = Convert.ToDateTime(zaman.ToShortDateString());
            dateTimePicker2.Value = Convert.ToDateTime(zaman.ToShortDateString());
            if (label10.Text=="asd")
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 fom2 = new Form2();
            fom2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            int id = 0;
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM urunler where UrunId='"+id+"'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
               textBox1.Text = oku["UrunId"].ToString();
                textBox2.Text = oku["UrunAd"].ToString();
            }
            baglanti.Close();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int id = 0;
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM urunler where UrunId='" + id + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textBox1.Text = oku["UrunId"].ToString();
                textBox2.Text = oku["UrunAd"].ToString();
            }
            baglanti.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked==true)
            {
                groupBox4.Visible = true;
                groupBox1.Visible = false;

            }
            else
            {
                groupBox1.Visible = true;
                groupBox4.Visible = false;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
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

        private void listView2_DoubleClick(object sender, EventArgs e)
        {

            int id = 0;
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM urunler where kod='" + id + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textBox1.Text = oku["kod"].ToString();
                textBox2.Text = oku["ad"].ToString();
                textBox4.Text = oku["alisf"].ToString();
            }
            baglanti.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox3.Text=="" || textBox3.Text=="0")
            {
                MessageBox.Show("adet giriniz!!!!");
            }
            else
            {  int a, b,c;
            a = Convert.ToInt32(textBox3.Text);
            b = Convert.ToInt32(textBox4.Text);
            c = a * b;
         
            string nSayi = string.Format("{0:0,0}", c).Replace(",", ".");

            textBox6.Text =""+nSayi.ToString();

            }
         

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (groupBox2.Visible == false)
            {
                groupBox2.Visible = true;
                groupBox3.Visible = false;
                gosteriyosun();

            }
            else
                groupBox2.Visible = false;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
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

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

            if (textBox11.Text == "")
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

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                gosteriyosun();

            }
            else
            {
                listView2.Items.Clear();
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT *FROM firmalar WHERE no='" + Convert.ToInt32(textBox8.Text) + "'", baglanti);
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
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                gosteriyosun();

            }
            else
            {
                listView2.Items.Clear();
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT *FROM firmalar WHERE ad LIKE '%" + textBox7.Text + "%'", baglanti);
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
        }

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int musterinoo;
            musterinoo = int.Parse(listView2.SelectedItems[0].SubItems[0].Text);
            baglanti.Open();
            SqlCommand komuto = new SqlCommand("SELECT  *from firmalar WHERE no='" + musterinoo + "'", baglanti);
            SqlDataReader okuo = komuto.ExecuteReader();
            while (okuo.Read())
            {
                textBox5.Text = okuo["no"].ToString();
              firmaninadi = okuo["ad"].ToString();
            }
            baglanti.Close();
        }

        private void textBox12_MouseClick(object sender, MouseEventArgs e)
        {

            int a, b, c;
            a = Convert.ToInt32(textBox14.Text);
            b = Convert.ToInt32(textBox9.Text);
            c = a - b;
            String g = "" + c.ToString();

            string nSayi = string.Format("{0:0,0}", g).Replace(",", ".");

            textBox12.Text = "" + nSayi.ToString();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                alinmaditb = "NAKİT";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void ggoster()
        {
            listView3.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *FROM gfatura where sirano="+a+"", baglanti);
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

        private void listView3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           int urun_no = int.Parse(listView3.SelectedItems[0].SubItems[0].Text);
           
            int ay;


            baglanti.Open();
            SqlCommand komutvr = new SqlCommand("SELECT *FROM gfatura where sirano="+a+" and kod='" + urun_no + "'", baglanti);
            SqlDataReader okuvr = komutvr.ExecuteReader();
            while (okuvr.Read())
            {

               ay = Convert.ToInt32(okuvr["adet"]);
               bay = Convert.ToInt32(okuvr["toplamfiyat"]);

            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komutv = new SqlCommand("SELECT *FROM urunler where kod='" + urun_no + "'", baglanti);
            SqlDataReader okuv = komutv.ExecuteReader();
            while (okuv.Read())
            {

                stok = Convert.ToInt32(okuv["stok"]);

            }
            stok -= Convert.ToInt32(textBox3.Text);
            toplam -= bay;
            textBox14.Text = toplam.ToString();

            baglanti.Close();
            baglanti.Open();
            SqlCommand komutie = new SqlCommand("UPDATE urunler SET stok='" + stok + "' WHERE kod='" + urun_no + "'", baglanti);
            komutie.ExecuteNonQuery();
            baglanti.Close();











             baglanti.Open();
            SqlCommand silkomutu = new SqlCommand("DELETE FROM gfatura where sirano=" + a + " and kod='" + urun_no + "'", baglanti);
            silkomutu.ExecuteNonQuery();
            baglanti.Close();
            ggoster();

        }

        private void button9_Click(object sender, EventArgs e)
        {
         
            if (no==true)
            {
                baglanti.Close();
                baglanti.Open();
                SqlCommand cmdeydgr = new SqlCommand("SELECT Max(sirano) FROM gfatura", baglanti);
                SqlDataReader dr = cmdeydgr.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    faturano = dr[0].ToString();
                }
                baglanti.Close();
                a = Convert.ToInt32(faturano);
                a += 1;
                no = false;
            }
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("şütfen boş alanları düzgün bir biçimde doldurunuz");
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT *FROM gfatura where sirano=" + a + " and kod='" + textBox1.Text + "'", baglanti);
                SqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    MessageBox.Show("bu ürünün aynısı zaten listede mevcut lüfen ürünü silip tekrardan ekleyiniz bubaa!");
                }
                else
                {
                    baglanti.Close();
                    baglanti.Open();
                    SqlCommand komuti = new SqlCommand("INSERT INTO gfatura (sirano,kod,adi,adet,birimfiyat,toplamfiyat) VALUES('" + a + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "'," + textBox6.Text.ToString().Replace(".", "") + ")", baglanti);
                    komuti.ExecuteNonQuery();
                    baglanti.Close();
                    ggoster();

                    baglanti.Open();
                    SqlCommand komutv = new SqlCommand("SELECT *FROM urunler where kod='" + textBox1.Text + "'", baglanti);
                    SqlDataReader okuv = komutv.ExecuteReader();
                    while (okuv.Read())
                    {

                        stok = Convert.ToInt32(okuv["stok"]);

                    }
                    stok += Convert.ToInt32(textBox3.Text);
                    toplam += Convert.ToInt32(textBox6.Text.ToString().Replace(".", ""));
                    textBox14.Text = toplam.ToString();
                    baglanti.Close();
                    baglanti.Open();
                    SqlCommand komutie = new SqlCommand("UPDATE urunler SET stok='" + stok + "' WHERE kod='" + textBox1.Text + "'", baglanti);
                    komutie.ExecuteNonQuery();
                    baglanti.Close();


                }
                baglanti.Close();
            }

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                alinmaditb = "KART";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            radioButton3.Checked = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            radioButton4.Checked = true;

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                label16.Visible = true;
                textBox13.Visible = true;
            }
            else
            {
                label16.Visible = false;
                textBox13.Visible = false;
            }
        }

       
    }
}
