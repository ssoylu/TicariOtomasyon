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
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_FATURABILGI Order by FATURABILGIID Asc", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void Temizle()
        {
            Txtid.Text = "";
            TxtSeri.Text = "";
            TxtSırano.Text="";
            msktarih.Text = "";
            msksaat.Text = "";
            txtvergidaire.Text = "";
            txtalici.Text = "";
            txtteslimeden.Text = "";
            txtteslimalan.Text = "";
        }
        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            listele();
            Temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (txtfauraid.Text == "")
            {
                SqlCommand komut = new SqlCommand("insert into TBL_FATURABILGI(SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN) VALUES(@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8)", bgl.baglanti());

                komut.Parameters.AddWithValue("@P1", TxtSeri.Text);
                komut.Parameters.AddWithValue("@P2", TxtSırano.Text);
                komut.Parameters.AddWithValue("@P3", msktarih.Text);
                komut.Parameters.AddWithValue("@P4", msksaat.Text);
                komut.Parameters.AddWithValue("@P5", txtvergidaire.Text);
                komut.Parameters.AddWithValue("@P6", txtalici.Text);
                komut.Parameters.AddWithValue("@P7", txtteslimeden.Text);
                komut.Parameters.AddWithValue("@P8", txtteslimalan.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                Temizle();
            }
            //firma carisi
            if (txtfauraid.Text != "" && comboBox1.Text == "Firma")
            {
                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(txtfiyat.Text);
                miktar = Convert.ToDouble(txtmiktar.Text);
                tutar = miktar * fiyat;
                txttutar.Text = tutar.ToString();
                SqlCommand komut2 = new SqlCommand("insert into TBL_FATURADETAY(URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID)values(@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@P1", txtürünad.Text);
                komut2.Parameters.AddWithValue("@P2", txtmiktar.Text);
                komut2.Parameters.AddWithValue("@P3", decimal.Parse(txtfiyat.Text));
                komut2.Parameters.AddWithValue("@P4", decimal.Parse(txttutar.Text));
                komut2.Parameters.AddWithValue("@P5", txtfauraid.Text);
                bgl.baglanti().Close();
                komut2.ExecuteNonQuery();

                // HareketTablosuna veri girişi

                SqlCommand komut3 = new SqlCommand("insert into TBL_FIRMAHAREKETLER(URUNID,ADET,PERSONEL,FIRMA,FIYAT,TOPLAM,FATURAID,TARIH)values(@h1,@h2,@h3,@h4,@h5,@h6,@h7,@h8)", bgl.baglanti());
                komut3.Parameters.AddWithValue("@h1", txtürünid.Text);
                komut3.Parameters.AddWithValue("@h2", txtmiktar.Text);
                komut3.Parameters.AddWithValue("@h3", txtpersonel.Text);
                komut3.Parameters.AddWithValue("@h4", txtfirma.Text);
                komut3.Parameters.AddWithValue("@h5", decimal.Parse(txtfiyat.Text));
                komut3.Parameters.AddWithValue("@h6", decimal.Parse(txttutar.Text));
                komut3.Parameters.AddWithValue("@h7", txtfauraid.Text);
                komut3.Parameters.AddWithValue("@h8", msktarih.Text);
                komut3.ExecuteNonQuery();
                bgl.baglanti().Close();

                // Stok sayısını azaltma

                SqlCommand komut4 = new SqlCommand("update TBL_URUNLER set ADET=ADET-@s1 where  ID=@s2", bgl.baglanti());
                komut4.Parameters.AddWithValue("@s1", txtmiktar.Text);
                komut4.Parameters.AddWithValue("@s2", txtürünid.Text);
                komut4.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Fatura Ait Ürün Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 

             
            //Müşteri carisi
            if (txtfauraid.Text != ""&&comboBox1.Text=="Müşteri")
            {
                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(txtfiyat.Text);
                miktar = Convert.ToDouble(txtmiktar.Text);
                tutar = miktar * fiyat;
                txttutar.Text = tutar.ToString();
                SqlCommand komut2 = new SqlCommand("insert into TBL_FATURADETAY(URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID)values(@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@P1", txtürünad.Text);
                komut2.Parameters.AddWithValue("@P2", txtmiktar.Text);
                komut2.Parameters.AddWithValue("@P3", decimal.Parse( txtfiyat.Text));
                komut2.Parameters.AddWithValue("@P4", decimal.Parse( txttutar.Text));
                komut2.Parameters.AddWithValue("@P5", txtfauraid.Text);
                bgl.baglanti().Close();
                komut2.ExecuteNonQuery();
                
                // HareketTablosuna veri girişi

                SqlCommand komut3 = new SqlCommand("insert into TBL_MUSTERİHAREKETLER(URUNID,ADET,PERSONEL,MUSTERI,FIYAT,TOPLAM,FATURAID,TARIH)values(@h1,@h2,@h3,@h4,@h5,@h6,@h7,@h8)", bgl.baglanti());
                komut3.Parameters.AddWithValue("@h1", txtürünid.Text);
                komut3.Parameters.AddWithValue("@h2", txtmiktar.Text);
                komut3.Parameters.AddWithValue("@h3", txtpersonel.Text);
                komut3.Parameters.AddWithValue("@h4", txtfirma.Text);
                komut3.Parameters.AddWithValue("@h5", decimal.Parse(txtfiyat.Text));
                komut3.Parameters.AddWithValue("@h6", decimal.Parse(txttutar.Text));
                komut3.Parameters.AddWithValue("@h7", txtfauraid.Text);
                komut3.Parameters.AddWithValue("@h8", msktarih.Text);
                komut3.ExecuteNonQuery();
                bgl.baglanti().Close();

                // Stok sayısını azaltma

                SqlCommand komut4 = new SqlCommand("update TBL_URUNLER set ADET=ADET-@s1 where  ID=@s2", bgl.baglanti());
                komut4.Parameters.AddWithValue("@s1", txtmiktar.Text);
                komut4.Parameters.AddWithValue("@s2", txtürünid.Text);
                komut4.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Fatura Ait Ürün Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Txtid.Text = dr["FATURABILGIID"].ToString();
                TxtSeri.Text = dr["SERI"].ToString();
                TxtSırano.Text = dr["SIRANO"].ToString();
                msktarih.Text = dr["TARIH"].ToString();
                msksaat.Text = dr["SAAT"].ToString();
                txtvergidaire.Text = dr["VERGIDAIRE"].ToString();
                txtalici.Text = dr["ALICI"].ToString();
                txtteslimeden.Text = dr["TESLIMEDEN"].ToString();
                txtteslimalan.Text = dr["TESLIMALAN"].ToString();
            }
        }

       
        private void BtnSil_Click_1(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From TBL_FATURABILGI where FATURABILGIID=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            MessageBox.Show("Fatura Slindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            Temizle();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_FATURABILGI set SERI=@P1,SIRANO=@P2,TARIH=@P3,SAAT=@P4,VERGIDAIRE=@P5,ALICI=@P6,TESLIMEDEN=@P7,TESLIMALAN=@P8 WHERE FATURABILGIID=@P9", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", TxtSeri.Text);
            komut.Parameters.AddWithValue("@P2", TxtSırano.Text);
            komut.Parameters.AddWithValue("@P3", msktarih.Text);
            komut.Parameters.AddWithValue("@P4", msksaat.Text);
            komut.Parameters.AddWithValue("@P5", txtvergidaire.Text);
            komut.Parameters.AddWithValue("@P6", txtalici.Text);
            komut.Parameters.AddWithValue("@P7", txtteslimeden.Text);
            komut.Parameters.AddWithValue("@P8", txtteslimalan.Text);
            komut.Parameters.AddWithValue("@P9", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaUrunDetay fr = new FrmFaturaUrunDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                fr.id = dr["FATURABILGIID"].ToString();
            }
            fr.Show();

        }

        private void BtnBul_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select URUNAD,SATISFIYAT from TBL_URUNLER where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtürünid.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtürünad.Text = dr[0].ToString();
                txtfiyat.Text = dr[1].ToString();
            }
            bgl.baglanti().Close();
        }
    }
}
