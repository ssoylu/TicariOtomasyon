using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using System.Threading;


namespace Ticari_Otomasyon
{
    public partial class SplashScreen1 : SplashScreen
    {
        public SplashScreen1()
        {
            InitializeComponent();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
            
        }

        private void SplashScreen1_Load(object sender, EventArgs e)
        {
            Thread.Sleep(4000);
            this.Hide();
            //FrmAnaModül menü = new FrmAnaModül();
            //menü.Show();
            
        }
    }
}