using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class FrmStokAcıklamaDetay : Form
    {
        public FrmStokAcıklamaDetay()
        {
            InitializeComponent();
        }
        public string aciklama;
        private void FrmStokAcıklamaDetay_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = aciklama;
        }
    }
}
