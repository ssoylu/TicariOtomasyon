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
    public partial class FrmFaturaUrunDuzenleme : Form
    {
        public FrmFaturaUrunDuzenleme()
        {
            InitializeComponent();
        }

        public string urunid;
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmFaturaUrunDuzenleme_Load(object sender, EventArgs e)
        {
            txtürünid.Text = urunid;
            SqlCommand komut = new SqlCommand("select*from TBL_FATURADETAY where FATURAURUNID=@p1 ", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", urunid);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtfiyat.Text = dr[3].ToString();
                txtmiktar.Text=dr[2].ToString();
                txttutar.Text = dr[4].ToString();
                txtürünad.Text = dr[1].ToString();
                bgl.baglanti().Close();
            }
        }

        void temizle()
        {
            txtürünad.Text = "";
            txttutar.Text = "";
            txtürünid.Text = "";
            txtmiktar.Text = "";
            txtfiyat.Text = "";
        }
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_FATURADETAY set URUNAD=@P1,MIKTAR=@P2,FIYAT=@P3,TUTAR=@P4 WHERE FATURAURUNID=@P5", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtürünad.Text);
            komut.Parameters.AddWithValue("@P2", txtmiktar.Text);
            komut.Parameters.AddWithValue("@P3", decimal.Parse(txtfiyat.Text));
            komut.Parameters.AddWithValue("@P4",decimal.Parse(txttutar.Text));
            komut.Parameters.AddWithValue("@P5", txtürünid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Değişiklikler Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut= new SqlCommand("delete TBL_FATURADETAY where FATURAURUNID=@P1",bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtürünid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            temizle();
        }
    }
}
