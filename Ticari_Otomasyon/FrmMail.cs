using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Ticari_Otomasyon
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }
        public string mail;
        private void FrmMail_Load(object sender, EventArgs e)
        {
           TxtMailAdres.Text = mail;
        }
        void temizle()
        {
            TxtMailAdres.Text = "";
            TxtKonu.Text = "";
            RchMesaj.Text = "";
        }

        private void BtnGönder_Click(object sender, EventArgs e)
        {
            MailMessage mesajim = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("dsyyazilim@hotmail.com", "04051988serhat");
            istemci.Port = 587;
            istemci.Host = "smtp.live.com";
            istemci.EnableSsl = true;
            if (label3.Text != "")
            {
                Attachment ekle = new Attachment(@label3.Text);
                mesajim.Attachments.Add(ekle);
            }
   
            mesajim.To.Add(TxtMailAdres.Text);
            mesajim.From = new MailAddress("dsyyazilim@hotmail.com");
            mesajim.Subject = TxtKonu.Text;
            mesajim.Body = RchMesaj.Text;
            istemci.Send(mesajim);
            MessageBox.Show("Mail Gönderme İşlemi Yapılmıştır", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            temizle();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            {
                openFileDialog1.ShowDialog();
                label3.Text = openFileDialog1.FileName.ToString();

                //if (openFileDialog1.ShowDialog() == DialogResult.OK) //pencerede bir dosya sececeğimiz için kullanılır
                //{
                //    string yol = openFileDialog1.FileName.ToString(); //yol değişkenini string ifade olarak gösterecek
                //    label3.Text = (System.IO.Path.GetFileNameWithoutExtension(yol));

                //}
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FontDialog yenifont = new FontDialog();
            yenifont.ShowColor = true;
            yenifont.ShowDialog();
            RchMesaj.Font = yenifont.Font;
            RchMesaj.ForeColor = yenifont.Color; 
        }
    }
}
