namespace OtelRezervasyonSistemi
{
    partial class RezervasyonForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpGirisTarihi = new System.Windows.Forms.DateTimePicker();
            this.dtpCikisTarihi = new System.Windows.Forms.DateTimePicker();
            this.txtUcret = new System.Windows.Forms.TextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbBxOdaNo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbBxAdSoyad = new System.Windows.Forms.ComboBox();
            this.btnTestSil = new System.Windows.Forms.Button();
            this.btnGeri = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(63, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ad Soyad:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(56, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Giriş Tarihi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(55, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Çıkış Tarihi:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(91, 434);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ücret:";
            // 
            // dtpGirisTarihi
            // 
            this.dtpGirisTarihi.CalendarTitleBackColor = System.Drawing.SystemColors.MenuBar;
            this.dtpGirisTarihi.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpGirisTarihi.Location = new System.Drawing.Point(148, 165);
            this.dtpGirisTarihi.Name = "dtpGirisTarihi";
            this.dtpGirisTarihi.Size = new System.Drawing.Size(199, 27);
            this.dtpGirisTarihi.TabIndex = 13;
            this.dtpGirisTarihi.ValueChanged += new System.EventHandler(this.dtpGirisTarihi_ValueChanged);
            // 
            // dtpCikisTarihi
            // 
            this.dtpCikisTarihi.CalendarTitleBackColor = System.Drawing.SystemColors.MenuBar;
            this.dtpCikisTarihi.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpCikisTarihi.Location = new System.Drawing.Point(148, 255);
            this.dtpCikisTarihi.Name = "dtpCikisTarihi";
            this.dtpCikisTarihi.Size = new System.Drawing.Size(200, 27);
            this.dtpCikisTarihi.TabIndex = 14;
            this.dtpCikisTarihi.ValueChanged += new System.EventHandler(this.dtpCikisTarihi_ValueChanged);
            // 
            // txtUcret
            // 
            this.txtUcret.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtUcret.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtUcret.Location = new System.Drawing.Point(147, 427);
            this.txtUcret.Name = "txtUcret";
            this.txtUcret.Size = new System.Drawing.Size(200, 27);
            this.txtUcret.TabIndex = 15;
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnKaydet.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.Location = new System.Drawing.Point(178, 494);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(87, 41);
            this.btnKaydet.TabIndex = 37;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Location = new System.Drawing.Point(378, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(655, 463);
            this.dataGridView1.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(75, 351);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 20);
            this.label6.TabIndex = 39;
            this.label6.Text = "Oda No:";
            // 
            // cmbBxOdaNo
            // 
            this.cmbBxOdaNo.BackColor = System.Drawing.SystemColors.MenuBar;
            this.cmbBxOdaNo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbBxOdaNo.FormattingEnabled = true;
            this.cmbBxOdaNo.Location = new System.Drawing.Point(147, 348);
            this.cmbBxOdaNo.Name = "cmbBxOdaNo";
            this.cmbBxOdaNo.Size = new System.Drawing.Size(200, 28);
            this.cmbBxOdaNo.TabIndex = 40;
            this.cmbBxOdaNo.SelectedIndexChanged += new System.EventHandler(this.cmbBxOdaNo_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(306, 427);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 16);
            this.label7.TabIndex = 41;
            this.label7.Text = "0";
            this.label7.Visible = false;
            // 
            // cmbBxAdSoyad
            // 
            this.cmbBxAdSoyad.BackColor = System.Drawing.SystemColors.MenuBar;
            this.cmbBxAdSoyad.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbBxAdSoyad.FormattingEnabled = true;
            this.cmbBxAdSoyad.Location = new System.Drawing.Point(147, 75);
            this.cmbBxAdSoyad.Name = "cmbBxAdSoyad";
            this.cmbBxAdSoyad.Size = new System.Drawing.Size(200, 28);
            this.cmbBxAdSoyad.TabIndex = 42;
            // 
            // btnTestSil
            // 
            this.btnTestSil.Location = new System.Drawing.Point(435, 54);
            this.btnTestSil.Name = "btnTestSil";
            this.btnTestSil.Size = new System.Drawing.Size(75, 23);
            this.btnTestSil.TabIndex = 43;
            this.btnTestSil.Text = "sil";
            this.btnTestSil.UseVisualStyleBackColor = true;
            this.btnTestSil.Visible = false;
            // 
            // btnGeri
            // 
            this.btnGeri.BackColor = System.Drawing.Color.Red;
            this.btnGeri.Location = new System.Drawing.Point(12, 12);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(41, 23);
            this.btnGeri.TabIndex = 44;
            this.btnGeri.Text = "<--";
            this.btnGeri.UseVisualStyleBackColor = false;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // RezervasyonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1045, 564);
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.cmbBxAdSoyad);
            this.Controls.Add(this.txtUcret);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbBxOdaNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.dtpCikisTarihi);
            this.Controls.Add(this.dtpGirisTarihi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTestSil);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RezervasyonForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rezervasyon";
            this.Load += new System.EventHandler(this.RezervasyonForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpGirisTarihi;
        private System.Windows.Forms.DateTimePicker dtpCikisTarihi;
        private System.Windows.Forms.TextBox txtUcret;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbBxOdaNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbBxAdSoyad;
        private System.Windows.Forms.Button btnTestSil;
        private System.Windows.Forms.Button btnGeri;
    }
}