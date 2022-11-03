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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

       //  SqlConnection baglanti = new SqlConnection(@"Data Source = (LocalDB)\V12.0;Integrated Security = True;AttachDbFileName='|DataDirectory|\adisyon90lar.mdf'");

        SqlConnection baglanti = new SqlConnection("Data Source = JUPITER\\SQLEXPRESS;Initial Catalog = adisyon90lar; Integrated Security = True;");
        public int kontrl;
        DateTime zaman = DateTime.Today;
        string satis_tutar, masraf_tutar, devir_tutar, aciklama, varmi,n, k,b, nn, s;
        int  satist, masraft, devirt, kasat, curot, t, er, et,g, kasaa, nkasaa, kkasaa,naki_satis, nakit_satis_alinan, kart_satis_alinan, borc__s, b_s_s, fatura__o,fff,kf, nakit_gelen_borc, nakit_kasa, kasa_devir, nakit_odenen_fatura, nakit_masraf,kart_satis, kart_gelen_borc, kart_kasa,kart_odenen_fatura, kart_masraf,toplam_kasa;
        string skartsatis,snakitmasraf;
        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

        private void label50_Click(object sender, EventArgs e)
        {

        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void label57_Click(object sender, EventArgs e)
        {

        }

        private void label58_Click(object sender, EventArgs e)
        {

        }

        private void label53_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label54_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label56_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            FaturaTakipIslemleri ft = new FaturaTakipIslemleri();
            ft.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        int gecmisfatura,toplemgelen;
        bool satis = false;
       
        private void button18_Click(object sender, EventArgs e)
        {
            kasa kasa = new kasa();
            kasa.Show();
            this.Hide();
        }

        private void btnmasa_Click(object sender, EventArgs e)
        {

            Form9 fom9 = new Form9();
            fom9.Show();
            this.Hide();
        }
        private void ztoplamsatis()
        {
            baglanti.Close();
            baglanti.Open();
            SqlCommand cmdsatistoplamj = new SqlCommand("SELECT *FROM satis WHERE starihi='" + zaman.ToShortDateString() + "'", baglanti);
            SqlDataReader djr = cmdsatistoplamj.ExecuteReader();
            if (djr.Read())
            {
                satis = true;
            }
            else
            {
                satis = false;
                label4.Text = "0";
            }
            baglanti.Close();

            baglanti.Open();
            if (satis == true)
            {
                SqlCommand cmdsatistoplam = new SqlCommand("SELECT Sum(stutar) FROM satis WHERE starihi='" + zaman.ToShortDateString() + "'", baglanti);
                SqlDataReader dr = cmdsatistoplam.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    string sss = dr[0].ToString();
                    int sdf = Convert.ToInt32(sss);
                    string ssSayi = string.Format("{0:0,0}", sdf).Replace(",", ".");
                    label4.Text = ssSayi;
                }
                satis = false;
            }
            baglanti.Close();
        }
        private void znakitsatis()
        {
            baglanti.Open();
            SqlCommand cmdnakitsatissj = new SqlCommand("SELECT *FROM satis WHERE starihi='" + zaman.ToShortDateString() + "' and tahsilatb='" + "NAKİT" + "' and ( sodtip='" + "KISMEN ODENDİ" + "' or sodtip='" + "ÖDENDİ" + "')", baglanti);
            SqlDataReader nsja = cmdnakitsatissj.ExecuteReader();

            if (nsja.Read())
            {
                satis = true;
            }
            else
            {
                satis = false;
            }
            baglanti.Close();

            baglanti.Open();
            if (satis == true)
            {
                SqlCommand cmdnakitsatiss = new SqlCommand("SELECT Sum(bverilen) FROM satis WHERE starihi='" + zaman.ToShortDateString() + "' and tahsilatb='" + "NAKİT" + "' and ( sodtip='" + "KISMEN ODENDİ" + "' or sodtip='" + "ÖDENDİ" + "')", baglanti);
                SqlDataReader nsa = cmdnakitsatiss.ExecuteReader();
                if (nsa.HasRows)
                {
                    nsa.Read();
                    satis_tutar = nsa[0].ToString();
                    naki_satis += Convert.ToInt32(satis_tutar);
                    string sSayi = string.Format("{0:0,0}", naki_satis).Replace(",", ".");

                    label6.Text = sSayi;
                }
                satis = false;
            }
            baglanti.Close();
        }
        private void zkarttsatis()
        {
            baglanti.Open();
            SqlCommand cmdkartsatisj = new SqlCommand("SELECT *FROM satis WHERE starihi='" + zaman.ToShortDateString() + "' and tahsilatb='" + "KART" + "' and ( sodtip='" + "KISMEN ODENDİ" + "' or sodtip='" + "ÖDENDİ" + "')", baglanti);

            SqlDataReader ksj = cmdkartsatisj.ExecuteReader();
            satis = false;
            if (ksj.Read())
            {
                satis = true;
            }
            else
            {
                kart_satis = 0;
                satis = false;

            }
            baglanti.Close();
            baglanti.Open();
            if (satis == true)
            {
                SqlCommand cmdkartsatis = new SqlCommand("SELECT Sum(stutar) FROM satis WHERE starihi='" + zaman.ToShortDateString() + "' and tahsilatb='" + "KART" + "' and ( sodtip='" + "KISMEN ODENDİ" + "' or sodtip='" + "ÖDENDİ" + "')", baglanti);
                SqlDataReader ks = cmdkartsatis.ExecuteReader();

                if (ks.HasRows)
                {
                    ks.Read();
                    skartsatis = ks[0].ToString();
                    kart_satis = Convert.ToInt32(skartsatis);
                    string sSayi = string.Format("{0:0,0}", kart_satis).Replace(",", ".");

                    label11.Text = sSayi;

                }
                satis = false;
            }
            baglanti.Close();
           
        }
        private void zborcsatis()
        {
            baglanti.Open();
            SqlCommand cmdborcsatisj = new SqlCommand("SELECT *FROM satis WHERE starihi='" + zaman.ToShortDateString() + "' and (sodtip='" + "KISMEN ODENDİ" + "' or sodtip='" + "HİÇ ODENMEDİ" + "')", baglanti);
            SqlDataReader bsj = cmdborcsatisj.ExecuteReader();
            if (bsj.Read())
            {
                satis = true;
            }
            else
            {
                satis = false;
                b_s_s = 0;
            }
            baglanti.Close();

            baglanti.Open();
            if (satis == true)
            {
                SqlCommand cmdborcsatis = new SqlCommand("SELECT Sum(bkalan) FROM satis WHERE starihi='" + zaman.ToShortDateString() + "' and (sodtip='" + "KISMEN ODENDİ" + "' or sodtip='" + "HİÇ ODENMEDİ" + "')", baglanti);
                SqlDataReader bs = cmdborcsatis.ExecuteReader();

                if (bs.HasRows)
                {
                    bs.Read();
                    satis_tutar = bs[0].ToString();
                    b_s_s = Convert.ToInt32(satis_tutar);
                    string sSayi = string.Format("{0:0,0}", b_s_s).Replace(",", ".");
                    label25.Text = sSayi;

                }
                satis = false;
            }
            baglanti.Close();
        }
        private void zalinannakitborc()
        {
            baglanti.Open();
            SqlCommand cmdalinannakitborcj = new SqlCommand("SELECT *FROM hareketler WHERE htrh='" + zaman.ToShortDateString() + "' and tb='" + "NAKİT" + "' and hotip='" + "SKISMEN ODENDİ" + "'", baglanti);

            SqlDataReader nbj = cmdalinannakitborcj.ExecuteReader();
            if (nbj.Read())
            {
                satis = true;
            }
            else
            {
                satis = false;
                nakit_gelen_borc = 0;
                label17.Text = nakit_gelen_borc.ToString();
            }
            baglanti.Close();

            baglanti.Open();
            if (satis == true)
            {
                SqlCommand cmdalinannakitborc = new SqlCommand("SELECT Sum(hamktr) FROM hareketler WHERE htrh='" + zaman.ToShortDateString() + "' and tb='" + "NAKİT" + "' and hotip='" + "SKISMEN ODENDİ" + "'", baglanti);
                SqlDataReader nb = cmdalinannakitborc.ExecuteReader();

                if (nb.HasRows)
                {
                    nb.Read();
                    satis_tutar = nb[0].ToString();

                    nakit_gelen_borc = Convert.ToInt32(satis_tutar);
                    string sSayi = string.Format("{0:0,0}", nakit_gelen_borc).Replace(",", ".");
                    label17.Text = sSayi;
                }
                satis = false;
            }
            baglanti.Close();
        }
        private void zalinankartborc()
        {
            baglanti.Open();
            SqlCommand cmdalinankartborcj = new SqlCommand("SELECT *FROM hareketler WHERE htrh='" + zaman.ToShortDateString() + "' and tb='" + "KART" + "' and hotip='" + "SKISMEN ODENDİ" + "'", baglanti);

            SqlDataReader kbj = cmdalinankartborcj.ExecuteReader();
            if (kbj.Read())
            {
                satis = true;
            }
            else
            {
                satis = false;
                kart_gelen_borc = 0;
                label23.Text = kart_gelen_borc.ToString();

            }
            baglanti.Close();

            baglanti.Open();
            if (satis == true)
            {
                SqlCommand cmdalinankartborc = new SqlCommand("SELECT Sum(hamktr) FROM hareketler WHERE htrh='" + zaman.ToShortDateString() + "' and tb='" + "KART" + "' and hotip='" + "SKISMEN ODENDİ" + "'", baglanti);
                SqlDataReader kb = cmdalinankartborc.ExecuteReader();
                if (kb.HasRows)
                {
                    kb.Read();
                    satis_tutar = kb[0].ToString();
                    kart_gelen_borc = Convert.ToInt32(satis_tutar);
                    string sSayi = string.Format("{0:0,0}", kart_gelen_borc).Replace(",", ".");
                    label23.Text = sSayi;

                }
                satis = false;
            }
            baglanti.Close();
        }
        private void zalinanborc()
        {
            baglanti.Open();
            SqlCommand cmdalinanborcj = new SqlCommand("SELECT *FROM hareketler WHERE htrh='" + zaman.ToShortDateString() + "' and hotip='" + "SKISMEN ODENDİ" + "'", baglanti);
            SqlDataReader abj = cmdalinanborcj.ExecuteReader();
            if (abj.Read())
            {
                satis = true;
            }
            else
            {
                satis = false;
                label37.Text = "0";
            }
            baglanti.Close();

            baglanti.Open();
            if (satis == true)
            {
                SqlCommand cmdalinanborc = new SqlCommand("SELECT Sum(hamktr) FROM hareketler WHERE htrh='" + zaman.ToShortDateString() + "' and hotip='" + "SKISMEN ODENDİ" + "'", baglanti);
                SqlDataReader ab = cmdalinanborc.ExecuteReader();
                if (ab.HasRows)
                {
                    ab.Read();
                    satis_tutar = ab[0].ToString();
                    toplemgelen = Convert.ToInt32(satis_tutar);
                    string sSayi = string.Format("{0:0,0}", satis_tutar).Replace(",", ".");
                    label37.Text = sSayi;
                    label57.Text = sSayi;
                }
                satis = false;
            }
            baglanti.Close();
        }
        private void zodenmeyenfatura()
        {
            baglanti.Open();
            SqlCommand cmdodenmeyenfaturaj = new SqlCommand("SELECT *FROM faturagirisi WHERE ftrh='" + zaman.ToShortDateString() + "' and (fotip='" + "ÖDENMEDİ" + "' or fotip='" + "KISMEN ÖDENDİ" + "')", baglanti);

            SqlDataReader ofj = cmdodenmeyenfaturaj.ExecuteReader();
            if (ofj.Read())
            {
                satis = true;
            }
            else
            {
                satis = false;
                fatura__o = 0;
                label18.Text = fatura__o.ToString();
            }
            baglanti.Close();

            baglanti.Open();
            if (satis == true)
            {
                SqlCommand cmdodenmeyenfatura = new SqlCommand("SELECT Sum(fk) FROM faturagirisi WHERE ftrh='" + zaman.ToShortDateString() + "' and (fotip='" + "ÖDENMEDİ" + "' or fotip='" + "KISMEN ÖDENDİ" + "')", baglanti);
                SqlDataReader of = cmdodenmeyenfatura.ExecuteReader();
                if (of.HasRows)
                {
                    of.Read();
                    satis_tutar = of[0].ToString();
                    fatura__o = Convert.ToInt32(satis_tutar);
                    string sSayi = string.Format("{0:0,0}", fatura__o).Replace(",", ".");

                    label18.Text = sSayi;
                }
                satis = false;
            }
            baglanti.Close();

        }
        private void znakitodenenfatura()
        {
            baglanti.Open();
            SqlCommand cmdnodenenfaturaj = new SqlCommand("SELECT *FROM faturahareket WHERE htrh='" + zaman.ToShortDateString() + "' and tb='" + "NAKİT" + "'", baglanti);

            SqlDataReader anfj = cmdnodenenfaturaj.ExecuteReader();
            if (anfj.Read())
            {
                satis = true;
            }
            else
            {
                satis = false;
                et = 0;
                nakit_odenen_fatura = et;
                label35.Text = nakit_odenen_fatura.ToString();
            }
            baglanti.Close();

            baglanti.Open();
            if (satis == true)
            {
                SqlCommand cmdnodenenfatura = new SqlCommand("SELECT Sum(hmktr) FROM faturahareket WHERE htrh='" + zaman.ToShortDateString() + "' and tb='" + "NAKİT" + "'", baglanti);
                SqlDataReader anf = cmdnodenenfatura.ExecuteReader();
                if (anf.HasRows)
                {
                    anf.Read();
                    n = anf[0].ToString();

                    et = Convert.ToInt32(n);
                    nakit_odenen_fatura = et;
                    string sSayi = string.Format("{0:0,0}", n).Replace(",", ".");
                    label35.Text = sSayi;
                }
                satis = false;
            }
            baglanti.Close();
        }
        private void znakitodenengecmisfatura()
        {
            baglanti.Open();
            SqlCommand cmdnodenengfaturaj = new SqlCommand("SELECT *FROM faturahareket WHERE htrh='" + zaman.ToShortDateString() + "' and (bicim='" + "sonradan" + "' and tb='" + "NAKİT" + "')", baglanti);

            SqlDataReader angfj = cmdnodenengfaturaj.ExecuteReader();
            if (angfj.Read())
            {
                satis = true;
            }
            else
            {
                satis = false;
                label52.Text = "0";
            }
            baglanti.Close();

            baglanti.Open();
            if (satis == true)
            {
                SqlCommand cmdnodenengfatura = new SqlCommand("SELECT Sum(hmktr) FROM faturahareket WHERE htrh='" + zaman.ToShortDateString() + "' and (bicim='" + "sonradan" + "' and tb='" + "NAKİT" + "')", baglanti);
                SqlDataReader angf = cmdnodenengfatura.ExecuteReader();
                if (angf.HasRows)
                {
                    angf.Read();
                    n = angf[0].ToString();
                    gecmisfatura = Convert.ToInt32(n);
                    string sSayi = string.Format("{0:0,0}", n).Replace(",", ".");
                    label52.Text = sSayi;

                }
                satis = false;
            }
            baglanti.Close();

        }
        private void zkartodenengecmisfatura()
        {
            baglanti.Open();
            SqlCommand cmdkodenengfaturaj = new SqlCommand("SELECT *FROM faturahareket WHERE htrh='" + zaman.ToShortDateString() + "' and (bicim='" + "sonradan" + "' and tb='" + "KART" + "')", baglanti);

            SqlDataReader akgfj = cmdkodenengfaturaj.ExecuteReader();
            if (akgfj.Read())
            {
                satis = true;
            }
            else
            {
                satis = false;
                label49.Text = "0";
            }
            baglanti.Close();

            baglanti.Open();
            if (satis == true)
            {
                SqlCommand cmdkodenengfatura = new SqlCommand("SELECT Sum(hmktr) FROM faturahareket WHERE htrh='" + zaman.ToShortDateString() + "' and (bicim='" + "sonradan" + "' and tb='" + "KART" + "')", baglanti);
                SqlDataReader akgf = cmdkodenengfatura.ExecuteReader();
                if (akgf.HasRows)
                {
                    akgf.Read();
                    n = akgf[0].ToString();
                    gecmisfatura += Convert.ToInt32(n);
                    string sSayi = string.Format("{0:0,0}", n).Replace(",", ".");
                    label49.Text = sSayi;
                }
                satis = false;
            }
            baglanti.Close();
        }
        private void zodenenfatura()
        {
            baglanti.Open();
            SqlCommand cmdkodenenfaturaaj = new SqlCommand("SELECT *FROM faturahareket WHERE htrh='" + zaman.ToShortDateString() + "' and tb='" + "KART" + "'", baglanti);
            SqlDataReader akfaj = cmdkodenenfaturaaj.ExecuteReader();
            if (akfaj.Read())
            {
                satis = true;
            }
            else
            {
                satis = false;
                kart_odenen_fatura = 0;
                er = kart_odenen_fatura;
            }
            baglanti.Close();

            baglanti.Open();
            if (satis == true)
            {
                SqlCommand cmdkodenenfaturaa = new SqlCommand("SELECT Sum(hmktr) FROM faturahareket WHERE htrh='" + zaman.ToShortDateString() + "' and tb='" + "KART" + "'", baglanti);
                SqlDataReader akfa = cmdkodenenfaturaa.ExecuteReader();
                if (akfa.HasRows)
                {
                    akfa.Read();
                    k = akfa[0].ToString();
                    kart_odenen_fatura = Convert.ToInt32(k);
                    er = Convert.ToInt32(k);

                    string sSayi = string.Format("{0:0,0}", k).Replace(",", ".");
                    label33.Text = sSayi;
                    baglanti.Close();
                }
                satis = false;
            }
            baglanti.Close();
        }
        private void ztoplamfatura()
        {
            baglanti.Open();
            SqlCommand cmdtoplafaturaj = new SqlCommand("SELECT *FROM faturagirisi WHERE ftrh='" + zaman.ToShortDateString() + "'", baglanti);
            SqlDataReader tfj = cmdtoplafaturaj.ExecuteReader();
            if (tfj.Read())
            {
                satis = true;
            }
            else
            {
                satis = false;
                label3.Text = "0";
            }
            baglanti.Close();

            baglanti.Open();
            if (satis == true)
            {
                SqlCommand cmdtoplafatura = new SqlCommand("SELECT Sum(fm) FROM faturagirisi WHERE ftrh='" + zaman.ToShortDateString() + "'", baglanti);
                SqlDataReader tf = cmdtoplafatura.ExecuteReader();
                if (tf.HasRows)
                {
                    tf.Read();
                    satis_tutar = tf[0].ToString();
                    string sSayi = string.Format("{0:0,0}", satis_tutar).Replace(",", ".");
                    label3.Text = sSayi;
                }
                satis = false;
            }
            baglanti.Close();

        }
        private void znakitmasraf()
        {
            baglanti.Open();
            SqlCommand cmdnakitmasraff = new SqlCommand("SELECT *FROM masraflar WHERE masraftarihi='" + zaman.ToShortDateString() + "' and masraftb='" + "NAKİT" + "'", baglanti);
            SqlDataReader jnm = cmdnakitmasraff.ExecuteReader();
            if (jnm.Read())
            {
                satis = true;
            }
            else
            {
                satis = false;
                nakit_masraf = 0;
            }
            baglanti.Close();

            baglanti.Open();
            if (satis == true)
            {
                SqlCommand cmdnakitmasraf = new SqlCommand("SELECT Sum(masrafdegeri) FROM masraflar WHERE masraftarihi='" + zaman.ToShortDateString() + "' and masraftb='" + "NAKİT" + "'", baglanti);
                SqlDataReader nm = cmdnakitmasraf.ExecuteReader();
                if (nm.HasRows)
                {
                    nm.Read();
                    snakitmasraf = nm[0].ToString();
                    nakit_masraf = Convert.ToInt32(snakitmasraf);
                    string sSayi = string.Format("{0:0,0}", snakitmasraf).Replace(",", ".");
                    label43.Text = sSayi;

                }
                satis = false;
            }
            baglanti.Close();
        }
        private void zkarttmasraf()
        {
            baglanti.Open();
            SqlCommand cmdkartmasraff = new SqlCommand("SELECT *FROM masraflar WHERE masraftarihi='" + zaman.ToShortDateString() + "' and masraftb='" + "KART" + "'", baglanti);
            SqlDataReader kjm = cmdkartmasraff.ExecuteReader();

            if (kjm.Read())
            {
                satis = true;
            }
            else
            {
                satis = false;
                kart_masraf = 0;
            }
            baglanti.Close();

            baglanti.Open();
            if (satis == true)
            {
                SqlCommand cmdkartmasraf = new SqlCommand("SELECT Sum(masrafdegeri) FROM masraflar WHERE masraftarihi='" + zaman.ToShortDateString() + "' and masraftb='" + "KART" + "'", baglanti);
                SqlDataReader km = cmdkartmasraf.ExecuteReader();
                if (km.HasRows)
                {
                    km.Read();
                    satis_tutar = km[0].ToString();
                    kart_masraf = Convert.ToInt32(satis_tutar);
                    string sSayi = string.Format("{0:0,0}", satis_tutar).Replace(",", ".");
                    label40.Text = sSayi;

                }
                satis = false;
            }
            baglanti.Close();
        }
        private void zmasraflar()
        {
            baglanti.Open();
            SqlCommand cmdmasraflarr = new SqlCommand("SELECT *FROM masraflar WHERE masraftarihi='" + zaman.ToShortDateString() + "'", baglanti);
            SqlDataReader jm = cmdmasraflarr.ExecuteReader();

            if (jm.Read())
            {
                satis = true;
            }
            else
            {
                satis = false;
                label30.Text = "0";
            }
            baglanti.Close();

            baglanti.Open();
            if (satis == true)
            {
                SqlCommand cmdmasraflar = new SqlCommand("SELECT Sum(masrafdegeri) FROM masraflar WHERE masraftarihi='" + zaman.ToShortDateString() + "'", baglanti);
                SqlDataReader m = cmdmasraflar.ExecuteReader();
                if (m.HasRows)
                {
                    m.Read();
                    satis_tutar = m[0].ToString();
                    string aSayi = string.Format("{0:0,0}", satis_tutar).Replace(",", ".");
                    label28.Text = aSayi;
                    label42.Text = aSayi;

                    g += Convert.ToInt32(satis_tutar);
                 
                }
                satis = false;
            }
            baglanti.Close();
        }
        private void zkasadevir()
        {
            SqlCommand cmdkasadevir = new SqlCommand("SELECT *FROM z_raporu WHERE ztrh='" + zaman.ToShortDateString() + "'", baglanti);

            baglanti.Open();
            SqlDataReader oku = cmdkasadevir.ExecuteReader();
            while (oku.Read())
            {
                label10.Text = oku["zkdvr"].ToString();
                kasa_devir = Convert.ToInt32(oku["zkdvr"].ToString());

            }
        }
     


        private void z_satis()
        {
            ztoplamsatis();
            znakitsatis();
            zkarttsatis();
            zborcsatis();
            zalinannakitborc();
            zalinankartborc();
            zalinanborc();
            zodenmeyenfatura();
            znakitodenenfatura();
            znakitodenengecmisfatura();
            zkartodenengecmisfatura();
            zodenenfatura();
            ztoplamfatura();
            znakitmasraf();
            zkarttmasraf();
            zmasraflar();
            zkasadevir();

            string scSayi = string.Format("{0:0,0}", gecmisfatura).Replace(",", ".");
            label51.Text = scSayi;
            t = er + et;
            label20.Text = t.ToString();
            label31.Text = t.ToString();
            g = t;
            
            nakit_kasa =(naki_satis+nakit_gelen_borc+kasa_devir)-(nakit_odenen_fatura+nakit_masraf);
            string eSayi = string.Format("{0:0,0}", nakit_kasa).Replace(",", ".");
            label13.Text = eSayi;
            
            kart_kasa = (kart_satis + kart_gelen_borc) - (kart_odenen_fatura + kart_masraf);
            string rSayi = string.Format("{0:0,0}", kart_kasa).Replace(",", ".");
            label44.Text = rSayi;

            toplam_kasa = nakit_kasa + kart_kasa;
            string tSayi = string.Format("{0:0,0}", toplam_kasa).Replace(",", ".");
            label46.Text = tSayi;

            int satissss = naki_satis + kart_satis;
            string tcSayi = string.Format("{0:0,0}", satissss).Replace(",", ".");
            label58.Text = tcSayi;

            toplemgelen += satissss;
            string tceSayi = string.Format("{0:0,0}", toplemgelen).Replace(",", ".");
            label56.Text = tceSayi;

            int a, b, c;
            a = Convert.ToInt32(label31.Text);
            b=Convert.ToInt32(label28.Text);
            c = a + b;
            label30.Text = c.ToString(); ;

        }






















        private void button14_Click_1(object sender, EventArgs e)
        {
            Form16 f6 = new Form16();
            f6.Show();
            this.Hide();
        }
    
        private void button3_Click(object sender, EventArgs e)
        {
            Form14 fnot = new Form14();
            fnot.Show();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form9 fom9 = new Form9();
            fom9.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DateTime zaman = DateTime.Today;
            dateTimePicker1.Value = Convert.ToDateTime(zaman.ToShortDateString());
            this.Location = Screen.PrimaryScreen.Bounds.Location;
            if (kontrl==1)
            {
            DateTime bugun = DateTime.Today;
            baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT *FROM notlar where nhtrh='" + bugun.ToShortDateString() + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {


                nn = "var";

            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komute = new SqlCommand("SELECT *FROM satis where bvadet ='" + bugun.ToShortDateString() + "' and sodtip ='" + "BORÇ" + "'", baglanti);
            SqlDataReader okue = komute.ExecuteReader();
            while (okue.Read())
            {

                b = "var";

            }
            baglanti.Close();


            baglanti.Open();
            SqlCommand komutt = new SqlCommand("SELECT *FROM urunler where stok <=" + 100 + "", baglanti);
            SqlDataReader okut = komutt.ExecuteReader();
            while (okut.Read())
            {
                s = "var";
               


            }
            baglanti.Close();
            if (nn=="var"||s=="var"||b=="var")
            {
                 Form15 fh = new Form15();
                fh.label5.Text = "hatır";
                fh.Show();
            }
                kontrl = 9;
            }
            

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 fom5 = new Form5();
            fom5.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "etainşaat1365")
            {
            panel3.Visible = true;
            panel5.Visible = false;
            panel4.Visible = false;
                gecmisfatura = 0;
                toplemgelen = 0;
                label6.Text = "0";
                label11.Text = "0";
                label25.Text = "0";
                label4.Text = "0";
                label35.Text = "0";
                label33.Text = "0";
                label20.Text = "0";
                label18.Text = "0";
                label3.Text = "0";
                label30.Text = "0";
                label28.Text = "0";
                label31.Text = "0";
                label40.Text = "0";
                label42.Text = "0";
                label43.Text = "0";
                label37.Text = "0";
                label23.Text = "0";
                label17.Text = "0";
                label10.Text = "0";
                label13.Text = "0";
                label44.Text = "0";
                label46.Text = "0";
                label58.Text = "0";
                label49.Text = "0";
                label51.Text = "0";
                label57.Text = "0";
                zaman = dateTimePicker1.Value;
                z_satis();

            }
                                                                                                
            else
            {
                MessageBox.Show("Şifre Hatalı!! ");
            }
            textBox1.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            button6.Visible = true;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form7 fom7 = new Form7();
            fom7.Show();
            this.Hide();

           
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            panel5.Visible = false;
            panel4.Visible = true;
            panel3.Visible = false;
            
            
          
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                textBox2.Visible = true;
            }
            else
            {
                textBox2.Visible = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox2.Checked == true)
            {
                dateTimePicker1.Visible = true;
                button15.Visible = true;
            }
            else
            {
                dateTimePicker1.Visible = false;
                button15.Visible = false;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "etainşaat1365")
            {
                gecmisfatura = 0;
            toplemgelen = 0;
            label6.Text = "0";
            label11.Text = "0";
            label25.Text = "0";
            label4.Text = "0";
            label35.Text = "0";
            label33.Text = "0";
            label20.Text = "0";
            label18.Text = "0";
            label3.Text = "0";
            label30.Text = "0";
            label28.Text = "0";
            label31.Text = "0";
            label40.Text = "0";
            label42.Text = "0";
            label43.Text = "0";
            label37.Text = "0";
            label23.Text = "0";
            label17.Text = "0";
            label10.Text = "0";
            label13.Text = "0";
            label44.Text = "0";
            label46.Text = "0";
            label58.Text = "0";
            label49.Text = "0";
            label51.Text = "0";
            label57.Text = "0";
            zaman = dateTimePicker1.Value;
            z_satis();
        }
                                                                                                
            else
            {
                MessageBox.Show("Şifre Hatalı!! ");
            }
}

        private void button16_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel3.Visible = false;
            panel5.Visible = false;
            checkBox2.Checked = false;
            label13.Text = "000,0000";
            DateTime z = DateTime.Today;
            dateTimePicker1.Value = Convert.ToDateTime(z.ToShortDateString());
            zaman = dateTimePicker1.Value;
          

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Form12 f12 = new Form12();
            f12.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form5 fom5 = new Form5();
            fom5.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 fom6 = new Form6();
            fom6.Show();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            FaturaGiris faturagiris = new FaturaGiris();
            faturagiris.Show();
            this.Hide();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form11 fom11 = new Form11();
            fom11.Show();
            this.Hide();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            Form8 fom8 = new Form8();
            fom8.Show();
            this.Hide();
            timer1.Stop();
            timer2.Stop();
        }

        private void button14_Click(object sender, EventArgs e)
        {
           
           
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            bool trtr = false;
            baglanti.Close();
            baglanti.Open();
            SqlCommand komuth = new SqlCommand("SELECT *FROM islem where trh='"+zaman.ToShortDateString()+"'", baglanti);
            SqlDataReader okuh = komuth.ExecuteReader();
            while (okuh.Read())
            {
                trtr = true;
            }
            baglanti.Close();


            if (textBox3.Text == "")
            {
                if (trtr == false)
                {

                

                if (textBox2.Text == "")
                {
                    aciklama = "yok";
                }
                else
                {
                    aciklama = textBox2.Text;
                }
                baglanti.Close();

                baglanti.Open();
                SqlCommand komuti = new SqlCommand("UPDATE z_raporu SET zns='" + label6.Text.ToString().Replace(".", "") + "', zks='" + label11.Text.ToString().Replace(".", "") + "', zbs='" + label25.Text.ToString().Replace(".", "") + "', zts='" + label4.Text.ToString().Replace(".", "") + "', zgnb='" + label17.Text.ToString().Replace(".", "") + "', zgkb='" + label23.Text.ToString().Replace(".", "") + "', zgtb='" + label37.Text.ToString().Replace(".", "") + "', znof='" + label35.Text.ToString().Replace(".", "") + "', zkof='" + label33.Text.ToString().Replace(".", "") + "', ztof='" + label20.Text.ToString().Replace(".", "") + "', zof='" + label18.Text.ToString().Replace(".", "") + "', ztf='" + label3.Text.ToString().Replace(".", "") + "', zgnf='" + label52.Text.ToString().Replace(".", "") + "', zgkf='" + label49.Text.ToString().Replace(".", "") + "', zgtf='" + label51.Text.ToString().Replace(".", "") + "', znm='" + label43.Text.ToString().Replace(".", "") + "', zkm='" + label40.Text.ToString().Replace(".", "") + "', ztm='" + label42.Text.ToString().Replace(".", "") + "', zkdvr='" + label10.Text.ToString().Replace(".", "") + "', znktkasa='" + label13.Text.ToString().Replace(".", "") + "', zkrtkasa='" + label44.Text.ToString().Replace(".", "") + "', ztplkasa='" + label46.Text.ToString().Replace(".", "") + "', zackl='" + aciklama + "' WHERE ztrh='" + zaman.ToShortDateString() + "'", baglanti);
                komuti.ExecuteNonQuery();
                baglanti.Close();


                baglanti.Open();
                SqlCommand komut = new SqlCommand("SELECT *FROM kassa", baglanti);
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    kasaa = Convert.ToInt32(oku["kasa"].ToString());
                    nkasaa = Convert.ToInt32(oku["nkasa"].ToString());
                    kkasaa = Convert.ToInt32(oku["kkasa"].ToString());
                }
                baglanti.Close();

                kasaa = kasaa + Convert.ToInt32(label46.Text.ToString().Replace(".", ""));
                nkasaa = nkasaa + Convert.ToInt32(label13.Text.ToString().Replace(".", ""));
                kkasaa = kkasaa + Convert.ToInt32(label44.Text.ToString().Replace(".", ""));

                baglanti.Open();
                SqlCommand komutiv = new SqlCommand("UPDATE kassa SET kasa='" + kasaa + "', nkasa='" + nkasaa + "', kkasa='" + kkasaa + "'", baglanti);
                komutiv.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("başarıyla gerçekleşti");
                panel4.Visible = true;
                panel3.Visible = false;
                panel5.Visible = false;
                checkBox2.Checked = false;
                label13.Text = "000,0000";
                DateTime z = DateTime.Today;
                dateTimePicker1.Value = Convert.ToDateTime(z.ToShortDateString());
                zaman = dateTimePicker1.Value;




                baglanti.Open();
                SqlCommand cmdadetekl = new SqlCommand("INSERT INTO islem (trh) SELECT '" + zaman.ToShortDateString() + "'", baglanti);
                cmdadetekl.ExecuteNonQuery();
                baglanti.Close();
                trtr = false;
            } else
            {
                MessageBox.Show("bu işlem yapıldığından bir daha gerçekleştirilmiyor");

            }
            }
            else
            {
            MessageBox.Show("Şifrenizi Kontrol ediniz");

            }




        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel5.Visible = true;
            panel4.Visible = false;
           
        }
    }
}
