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
    public partial class FrmFirmalar : Form
    {
        public FrmFirmalar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void firmaliste()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_FIRMALAR Order by ID Asc", bgl.baglanti());
            DataTable dt=new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
                     
        }
        void sehirlistesi()
        {
            SqlCommand komut = new SqlCommand("Select  Sehir From TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbİl.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();

        }
        
        void Temizle()
        {
            Txtid.Text = "";
            TxtAd.Text = "";
            TxtYGorev.Text="";
            TxtYetkili.Text="";
            MskYetkiliTcno.Text="";
            TxtSektor.Text="";
            MskTelefon1.Text="";
            MskTelefon2.Text="";
            MskTelefon3.Text="";
            TxtMail.Text="";
            MskFax.Text="";
            Cmbİl.Text="";
            Cmbİlce.Text="";
            TxtVergi.Text="";
            RchAdres.Text="";
            TxtKod1.Text = "";
            TxtKod2.Text="";
            TxtKod3.Text="";
            TxtAd.Focus();
        }
        void carikodciklamalar()
        {
            SqlCommand komut = new SqlCommand("Select FIRMAKOD1 from TBL_KODLAR", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                RchKod1.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();
        }

        private void Frmfirmalar_Load(object sender, EventArgs e)
        {
            firmaliste();
            Temizle();
            sehirlistesi();
            carikodciklamalar();
        }
        
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
             DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
             if (dr != null)
             {
                 Txtid.Text = dr["ID"].ToString();
                 TxtAd.Text = dr["AD"].ToString();
                 TxtYGorev.Text = dr["YETKILISTATU"].ToString();
                 TxtYetkili.Text = dr["YETKILIADSOYAD"].ToString();
                 MskYetkiliTcno.Text = dr["YETKILITC"].ToString();
                 TxtSektor.Text = dr["SEKTOR"].ToString();
                 MskTelefon1.Text = dr["TELEFON1"].ToString();
                 MskTelefon2.Text = dr["TELEFON2"].ToString();
                 MskTelefon3.Text = dr["TELEFON3"].ToString();
                 TxtMail.Text = dr["MAIL"].ToString();
                 MskFax.Text = dr["FAX"].ToString();
                 Cmbİl.Text = dr["IL"].ToString();
                 Cmbİlce.Text = dr["ILCE"].ToString();
                 TxtVergi.Text = dr["VERGIDAIRE"].ToString();
                 RchAdres.Text = dr["ADRES"].ToString();
                 TxtKod1.Text = dr["OZELKOD1"].ToString();
                 TxtKod2.Text = dr["OZELKOD2"].ToString();
                 TxtKod3.Text = dr["OZELKOD3"].ToString();

             }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_FIRMALAR(AD,YETKILISTATU,YETKILIADSOYAD,YETKILITC,SEKTOR,TELEFON1,TELEFON2,TELEFON3,MAIL,FAX,IL,ILCE,VERGIDAIRE,ADRES,OZELKOD1,OZELKOD2,OZELKOD3)values(@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10,@P11,@P12,@P13,@P14,@P15,@P16,@P17)", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", TxtAd.Text);
            komut.Parameters.AddWithValue("@P2", TxtYGorev.Text);
            komut.Parameters.AddWithValue("@P3", TxtYetkili.Text);
            komut.Parameters.AddWithValue("@P4", MskYetkiliTcno.Text);
            komut.Parameters.AddWithValue("@p5", TxtSektor.Text);
            komut.Parameters.AddWithValue("@P6", MskTelefon1.Text);
            komut.Parameters.AddWithValue("@P7", MskTelefon2.Text);
            komut.Parameters.AddWithValue("@P8", MskTelefon3.Text);
            komut.Parameters.AddWithValue("@P9", TxtMail.Text);
            komut.Parameters.AddWithValue("@P10",MskFax.Text);
            komut.Parameters.AddWithValue("@P11",Cmbİl.Text);
            komut.Parameters.AddWithValue("@P12", Cmbİlce.Text);
            komut.Parameters.AddWithValue("@P13", TxtVergi.Text);
            komut.Parameters.AddWithValue("@P14", RchAdres.Text);
            komut.Parameters.AddWithValue("@P15", TxtKod1.Text);
            komut.Parameters.AddWithValue("@P16", TxtKod2.Text);
            komut.Parameters.AddWithValue("@P17", TxtKod3.Text);          
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            firmaliste();
            Temizle();            

        }

        private void Cmbİl_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Cmbİlce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("Select ILCE From TBL_ILCELER where Sehir=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Cmbİl.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbİlce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete From TBL_FIRMALAR where ID=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            firmaliste();
            MessageBox.Show("Firma Listeden Slindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            Temizle();
            
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_FIRMALAR set AD=@P1,YETKILISTATU=@P2,YETKILIADSOYAD=@P3,YETKILITC=@P4,SEKTOR=@P5,TELEFON1=@P6,TELEFON2=@P7,TELEFON3=@P8,MAIL=@P9,FAX=@P10,IL=@P11,ILCE=@P12,VERGIDAIRE=@P13,ADRES=@P14,OZELKOD1=@P15,OZELKOD2=@P16,OZELKOD3=@P17 where ID=@P18", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", TxtAd.Text);
            komut.Parameters.AddWithValue("@P2", TxtYGorev.Text);
            komut.Parameters.AddWithValue("@P3", TxtYetkili.Text);
            komut.Parameters.AddWithValue("@P4", MskYetkiliTcno.Text);
            komut.Parameters.AddWithValue("@P5", TxtSektor.Text);
            komut.Parameters.AddWithValue("@P6", MskTelefon1.Text);
            komut.Parameters.AddWithValue("@P7", MskTelefon2.Text);
            komut.Parameters.AddWithValue("@P8", MskTelefon3.Text);
            komut.Parameters.AddWithValue("@P9", TxtMail.Text);
            komut.Parameters.AddWithValue("@P10", MskFax.Text);
            komut.Parameters.AddWithValue("@P11", Cmbİl.Text);
            komut.Parameters.AddWithValue("@P12", Cmbİlce.Text);
            komut.Parameters.AddWithValue("@P13", TxtVergi.Text);
            komut.Parameters.AddWithValue("@P14", RchAdres.Text);
            komut.Parameters.AddWithValue("@P15", TxtKod1.Text);
            komut.Parameters.AddWithValue("@P16", TxtKod2.Text);
            komut.Parameters.AddWithValue("@P17", TxtKod3.Text);
            komut.Parameters.AddWithValue("@P18", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            firmaliste();
            Temizle();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

       
    }
}
