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
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select*from TBL_ADMIN",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;


        }

        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            listele();
            txtkullaniciadi.Text = "";
            txtsifre.Text = "";
        }

        private void btnislem_Click(object sender, EventArgs e)
        {
            if (btnislem.Text == "Kaydet")
            { 
            SqlCommand komut = new SqlCommand("insert into TBL_ADMIN values(@p1,@p2)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtkullaniciadi.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Yeni Kullanıcı Sisteme Kaydededildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            }
            if (btnislem.Text == "Güncelle")
            {
                SqlCommand komut1 = new SqlCommand("update TBL_ADMIN set Sifre=@p2 where KullaniciAd=@p1", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", txtkullaniciadi.Text);
                komut1.Parameters.AddWithValue("@p2", txtsifre.Text);
                komut1.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kullanıcı Güncelleme İşlemi Başarıyla Yapılmıştır", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
        }
        
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            try
            {
                if (dr != null)
                {
                    txtkullaniciadi.Text = dr["KullaniciAd"].ToString();
                    txtsifre.Text = dr["Sifre"].ToString();
                }
            }
            catch
            {
                MessageBox.Show("Listeleme İşlemi Yapılamadı","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
                 
            
            }

        private void txtkullaniciadi_EditValueChanged(object sender, EventArgs e)
        {
            
                if (txtkullaniciadi.Text != "")
                {
                    btnislem.Text = "Güncelle";
                }
                else
                {
                    btnislem.Text = "Kaydet";
                }                      
        }
     }
  }

