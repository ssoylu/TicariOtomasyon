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

namespace Ticari_Otomasyon
{
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void musterihareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute MUSTERİHAREKETLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void firmahareketler()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute FIRMAHAREKETLER", bgl.baglanti());
            da.Fill(dt);
            gridControl3.DataSource = dt;
        }
        void giderlerlistesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * From TBL_GIDERLER Order by ID Asc", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            
        }

        public string ad;
        private void FrmKasa_Load(object sender, EventArgs e)
        {
            lblaktifkullanici.Text = ad;
            musterihareket();
            firmahareketler();
            giderlerlistesi();

            //Toplam Tutar Hesaplama

            SqlCommand komut1 = new SqlCommand("select sum(Tutar)from TBL_FATURADETAY", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lbltoplamtutar.Text = dr1[0].ToString() + " ₺";
            }
            bgl.baglanti().Close();

            //Ödemeler Son ayın faturaları elektrik+su+doğalgaz toplamları

            SqlCommand komut2 = new SqlCommand("Select(ELEKTRIK+SU+DOGALGAZ+INTERNET+EKSTRA)from TBL_GIDERLER order by ID asc", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblödemeler.Text = dr2[0].ToString() + " ₺";
            }
            bgl.baglanti().Close();

            //Son ayın personel maaşları

            SqlCommand komut3 = new SqlCommand("Select MAASLAR from TBL_GIDERLER order by ID asc", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblpersonelmaaslar.Text = dr3[0].ToString() + " ₺";
            }
            bgl.baglanti().Close();

            //Toplam Müşteri sayısı

            SqlCommand komut4 = new SqlCommand("Select count(*) from TBL_MUSTERILER", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblmusterisayisi.Text = dr4[0].ToString();
            }
            bgl.baglanti().Close();

            //Toplam Firma sayısı

            SqlCommand komut5 = new SqlCommand("Select count(*) from TBL_FIRMALAR", bgl.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblfirmasayisi.Text = dr5[0].ToString();
            }
            bgl.baglanti().Close();

            //Toplam Firma Şehir sayısı

            SqlCommand komut6 = new SqlCommand("Select count(Distinct(IL)) from TBL_FIRMALAR", bgl.baglanti());
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblsehirsayisi1.Text = dr6[0].ToString();
            }
            bgl.baglanti().Close();

            //Toplam Müşteri Şehir sayısı

            SqlCommand komut7 = new SqlCommand("Select count(Distinct(IL)) from TBL_MUSTERILER", bgl.baglanti());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                lblsehirsayisi2.Text = dr7[0].ToString();
            }
            bgl.baglanti().Close();

            //Toplam Personel sayısı

            SqlCommand komut8 = new SqlCommand("Select count(*) from TBL_PERSONELLER", bgl.baglanti());
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                lblpersonelsayisi.Text = dr8[0].ToString();
            }
            bgl.baglanti().Close();

            //Toplam Ürün sayısı

            SqlCommand komut9 = new SqlCommand("Select sum(ADET) from TBL_URUNLER", bgl.baglanti());
            SqlDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {
                lblstoksayisi.Text = dr9[0].ToString();
            }
            bgl.baglanti().Close();

            //1.chart kontrole Elektrik faturası son dört ay listeleme



            //2.chart kontrole su faturası son dört ay listeleme

            SqlCommand komut11 = new SqlCommand("Select top 4 ay,Su from TBL_GIDERLER order by ID Desc", bgl.baglanti());
            SqlDataReader dr11 = komut11.ExecuteReader();
            while (dr11.Read())
            {
                chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
            }
            bgl.baglanti().Close();
        }

        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            if (sayac > 0 && sayac <= 5)
            {
                //chart kontrole Elektrik faturası son dört ay listeleme
                groupControl1.Text = "ELEKTRİK";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut10 = new SqlCommand("Select top 4 ay,Elektrık from TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close();
            }

            if (sayac > 5 && sayac <= 10)
            {
                //chart kontrole su faturası son dört ay listeleme
                groupControl1.Text = "SU";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("Select top 4 ay,Su from TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }

                if (sayac > 10 && sayac <= 15)
                {
                    //chart kontrole DOGALGAZ faturası son dört ay listeleme
                    groupControl1.Text = "DOĞALGAZ";
                    chartControl1.Series["Aylar"].Points.Clear();
                    SqlCommand komut12 = new SqlCommand("Select top 4 ay,DOGALGAZ from TBL_GIDERLER order by ID Desc", bgl.baglanti());
                    SqlDataReader dr12 = komut12.ExecuteReader();
                    while (dr12.Read())
                    {
                        chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr12[0], dr12[1]));
                    }
                    bgl.baglanti().Close();
                }
            if (sayac > 15 && sayac <= 20)
                {
                    //chart kontrole INTERNET faturası son dört ay listeleme
                    groupControl1.Text = "İNTERNET";
                    chartControl1.Series["Aylar"].Points.Clear();
                    SqlCommand komut13 = new SqlCommand("Select top 4 ay,INTERNET from TBL_GIDERLER order by ID Desc", bgl.baglanti());
                    SqlDataReader dr13 = komut13.ExecuteReader();
                    while (dr13.Read())
                    {
                        chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr13[0], dr13[1]));
                    }
                    bgl.baglanti().Close();
                }
            if (sayac > 20 && sayac <= 25)
                {
                    //chart kontrole EKSTRAT faturası son dört ay listeleme
                    groupControl1.Text = "EKSTRA";
                    chartControl1.Series["Aylar"].Points.Clear();
                    SqlCommand komut14 = new SqlCommand("Select top 4 ay,EKSTRA from TBL_GIDERLER order by ID Desc", bgl.baglanti());
                    SqlDataReader dr14 = komut14.ExecuteReader();
                    while (dr14.Read())
                    {
                        chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr14[0], dr14[1]));
                    }
                    bgl.baglanti().Close();
                 }
                if(sayac==26)
                {
                    sayac=0;
                }
               
            }
        int sayac2= 0;

        private void timer2_Tick(object sender, EventArgs e)
        {
            sayac2++;
            if (sayac2 > 0 && sayac2 <= 5)
            {
                //chart kontrole Elektrik faturası son dört ay listeleme
                groupControl2.Text = "ELEKTRİK";
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut10 = new SqlCommand("Select top 4 ay,Elektrık from TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                bgl.baglanti().Close();
            }

            if (sayac2 > 5 && sayac2 <= 10)
            {
                //chart kontrole su faturası son dört ay listeleme
                groupControl2.Text = "SU";
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("Select top 4 ay,Su from TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                bgl.baglanti().Close();
            }

            if (sayac2 > 10 && sayac2 <= 15)
            {
                //chart kontrole DOGALGAZ faturası son dört ay listeleme
                groupControl2.Text = "DOĞALGAZ";
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut12 = new SqlCommand("Select top 4 ay,DOGALGAZ from TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr12 = komut12.ExecuteReader();
                while (dr12.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr12[0], dr12[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac2 > 15 && sayac2 <= 20)
            {
                //chart kontrole INTERNET faturası son dört ay listeleme
                groupControl2.Text = "İNTERNET";
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut13 = new SqlCommand("Select top 4 ay,INTERNET from TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr13 = komut13.ExecuteReader();
                while (dr13.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr13[0], dr13[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac2 > 20 && sayac2 <= 25)
            {
                //chart kontrole EKSTRAT faturası son dört ay listeleme
                groupControl2.Text = "EKSTRA";
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut14 = new SqlCommand("Select top 4 ay,EKSTRA from TBL_GIDERLER order by ID Desc", bgl.baglanti());
                SqlDataReader dr14 = komut14.ExecuteReader();
                while (dr14.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr14[0], dr14[1]));
                }
                bgl.baglanti().Close();
            }
            if (sayac2 == 26)
            {
                sayac2 = 0;
            }
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {
            
        }
        }
    }

