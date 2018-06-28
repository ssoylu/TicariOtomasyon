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
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        
        private void btngiriş_Click(object sender, EventArgs e)
        { 
            SqlCommand komut = new SqlCommand("Select * From TBL_ADMIN where KullaniciAd=@P1 and Sifre=@P2", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", Txtkullaniciadi.Text);
            komut.Parameters.AddWithValue("@P2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmAnaModül fr = new FrmAnaModül();
                fr.kullanici = Txtkullaniciadi.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı yada Şifre", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bgl.baglanti().Close();
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {

            
        }
    }
}
