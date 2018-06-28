namespace Ticari_Otomasyon
{
    partial class FrmAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdmin));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.TxtSifre = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblsifre = new DevExpress.XtraEditors.LabelControl();
            this.lblkullaniciadi = new DevExpress.XtraEditors.LabelControl();
            this.btnvazgeç = new DevExpress.XtraEditors.SimpleButton();
            this.btngiriş = new DevExpress.XtraEditors.SimpleButton();
            this.Txtkullaniciadi = new DevExpress.XtraEditors.TextEdit();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txtkullaniciadi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(442, 272);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.TxtSifre);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.lblsifre);
            this.groupControl1.Controls.Add(this.lblkullaniciadi);
            this.groupControl1.Controls.Add(this.btnvazgeç);
            this.groupControl1.Controls.Add(this.btngiriş);
            this.groupControl1.Controls.Add(this.Txtkullaniciadi);
            this.groupControl1.Location = new System.Drawing.Point(80, 103);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(274, 132);
            this.groupControl1.TabIndex = 7;
            // 
            // TxtSifre
            // 
            this.TxtSifre.Location = new System.Drawing.Point(87, 69);
            this.TxtSifre.Name = "TxtSifre";
            this.TxtSifre.Properties.UseSystemPasswordChar = true;
            this.TxtSifre.Size = new System.Drawing.Size(146, 20);
            this.TxtSifre.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl1.Location = new System.Drawing.Point(92, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(77, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Kullanıcı Girişi";
            // 
            // lblsifre
            // 
            this.lblsifre.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblsifre.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.lblsifre.Location = new System.Drawing.Point(49, 74);
            this.lblsifre.Name = "lblsifre";
            this.lblsifre.Size = new System.Drawing.Size(32, 13);
            this.lblsifre.TabIndex = 2;
            this.lblsifre.Text = "Şifre :";
            // 
            // lblkullaniciadi
            // 
            this.lblkullaniciadi.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblkullaniciadi.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblkullaniciadi.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.lblkullaniciadi.Location = new System.Drawing.Point(8, 46);
            this.lblkullaniciadi.Name = "lblkullaniciadi";
            this.lblkullaniciadi.Size = new System.Drawing.Size(73, 13);
            this.lblkullaniciadi.TabIndex = 2;
            this.lblkullaniciadi.Text = "Kullanıcı Adı :";
            // 
            // btnvazgeç
            // 
            this.btnvazgeç.Image = ((System.Drawing.Image)(resources.GetObject("btnvazgeç.Image")));
            this.btnvazgeç.Location = new System.Drawing.Point(168, 95);
            this.btnvazgeç.Name = "btnvazgeç";
            this.btnvazgeç.Size = new System.Drawing.Size(65, 23);
            this.btnvazgeç.TabIndex = 1;
            this.btnvazgeç.Text = "Vazgeç";
            // 
            // btngiriş
            // 
            this.btngiriş.Image = ((System.Drawing.Image)(resources.GetObject("btngiriş.Image")));
            this.btngiriş.Location = new System.Drawing.Point(87, 95);
            this.btngiriş.Name = "btngiriş";
            this.btngiriş.Size = new System.Drawing.Size(65, 23);
            this.btngiriş.TabIndex = 1;
            this.btngiriş.Text = "Giriş";
            this.btngiriş.Click += new System.EventHandler(this.btngiriş_Click);
            // 
            // Txtkullaniciadi
            // 
            this.Txtkullaniciadi.EditValue = "";
            this.Txtkullaniciadi.Location = new System.Drawing.Point(87, 39);
            this.Txtkullaniciadi.Name = "Txtkullaniciadi";
            this.Txtkullaniciadi.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.Txtkullaniciadi.Properties.Appearance.Options.UseBackColor = true;
            this.Txtkullaniciadi.Size = new System.Drawing.Size(146, 20);
            toolTipTitleItem1.Text = "Kullanıcı Adı";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.Txtkullaniciadi.SuperTip = superToolTip1;
            this.Txtkullaniciadi.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(172, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(94, 85);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(128, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "SARP Ticari Otomasyon 2018";
            // 
            // FrmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 275);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txtkullaniciadi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblsifre;
        private DevExpress.XtraEditors.LabelControl lblkullaniciadi;
        private DevExpress.XtraEditors.SimpleButton btnvazgeç;
        private DevExpress.XtraEditors.SimpleButton btngiriş;
        private DevExpress.XtraEditors.TextEdit Txtkullaniciadi;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DevExpress.XtraEditors.TextEdit TxtSifre;
        private System.Windows.Forms.Label label1;

    }
}