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
using System.Xml;

namespace Ticari_Otomasyon
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void stoklar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select URUNAD,sum(ADET) as 'Adet' from TBL_URUNLER group by URUNAD having Sum(ADET)<=20 order by sum(ADET)", bgl.baglanti());
            da.Fill(dt);
            gridControlstoklar.DataSource = dt;
        }

        void ajanda()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select top 9 TARIH,SAAT,BASLIK From TBL_NOTLAR order by ID desc", bgl.baglanti());
            da.Fill(dt);
            gridControlajanda.DataSource = dt;
        }

        void firmahareketler()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Exec firmahareket2", bgl.baglanti());
            da.Fill(dt);
            gridControlfirmahareketler.DataSource = dt;
        }
        void Firmafihrist()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select AD,TELEFON1 from TBL_FIRMALAR ", bgl.baglanti());
            da.Fill(dt);
            gridControlfihrist.DataSource = dt;
        }
        void haberler()
        {
            XmlTextReader xmloku = new XmlTextReader("http://www.hurriyet.com.tr/rss/anasayfa");
            while (xmloku.Read())
            {
                if (xmloku.Name == "title")
                {
                    listBox1.Items.Add(xmloku.ReadString());
                }
            }


        }

        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            stoklar();
            ajanda();
            firmahareketler();
            Firmafihrist();
            haberler();
            webBrowser1.Navigate("http://www.tcmb.gov.tr");
            //webBrowser2.Navigate("https://www.google.com.tr");
            //webBrowser3.Navigate("https://www.google.com.tr/");
            //this.reportViewer1.RefreshReport();
            this.webBrowser1.Refresh();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }
    }
}
