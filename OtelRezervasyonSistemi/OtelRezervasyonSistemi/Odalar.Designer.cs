namespace OtelRezervasyonSistemi
{
    partial class Odalar
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
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtOdaNo = new System.Windows.Forms.TextBox();
            this.txtOdaTipi = new System.Windows.Forms.TextBox();
            this.txtOdaFiyati = new System.Windows.Forms.TextBox();
            this.cmbOdaDrm = new System.Windows.Forms.ComboBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnGeri = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(44, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Oda No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(40, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Oda Tipi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(28, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Oda Fiyatı:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(8, 335);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Oda Durumu:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(332, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(711, 466);
            this.dataGridView1.TabIndex = 4;
            // 
            // txtOdaNo
            // 
            this.txtOdaNo.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtOdaNo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtOdaNo.Location = new System.Drawing.Point(116, 134);
            this.txtOdaNo.Name = "txtOdaNo";
            this.txtOdaNo.Size = new System.Drawing.Size(200, 27);
            this.txtOdaNo.TabIndex = 11;
            // 
            // txtOdaTipi
            // 
            this.txtOdaTipi.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtOdaTipi.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtOdaTipi.Location = new System.Drawing.Point(116, 194);
            this.txtOdaTipi.Name = "txtOdaTipi";
            this.txtOdaTipi.Size = new System.Drawing.Size(200, 27);
            this.txtOdaTipi.TabIndex = 12;
            // 
            // txtOdaFiyati
            // 
            this.txtOdaFiyati.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtOdaFiyati.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtOdaFiyati.Location = new System.Drawing.Point(116, 267);
            this.txtOdaFiyati.Name = "txtOdaFiyati";
            this.txtOdaFiyati.Size = new System.Drawing.Size(200, 27);
            this.txtOdaFiyati.TabIndex = 13;
            // 
            // cmbOdaDrm
            // 
            this.cmbOdaDrm.BackColor = System.Drawing.SystemColors.MenuBar;
            this.cmbOdaDrm.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbOdaDrm.FormattingEnabled = true;
            this.cmbOdaDrm.Items.AddRange(new object[] {
            "Boş",
            "Dolu",
            "Arızalı"});
            this.cmbOdaDrm.Location = new System.Drawing.Point(116, 332);
            this.cmbOdaDrm.Name = "cmbOdaDrm";
            this.cmbOdaDrm.Size = new System.Drawing.Size(200, 28);
            this.cmbOdaDrm.TabIndex = 14;
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnKaydet.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.Location = new System.Drawing.Point(89, 409);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(92, 49);
            this.btnKaydet.TabIndex = 37;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnGeri
            // 
            this.btnGeri.BackColor = System.Drawing.Color.Red;
            this.btnGeri.Location = new System.Drawing.Point(12, 12);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(41, 23);
            this.btnGeri.TabIndex = 38;
            this.btnGeri.Text = "<--";
            this.btnGeri.UseVisualStyleBackColor = false;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // Odalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1045, 564);
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.cmbOdaDrm);
            this.Controls.Add(this.txtOdaFiyati);
            this.Controls.Add(this.txtOdaTipi);
            this.Controls.Add(this.txtOdaNo);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Odalar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Odalar";
            this.Load += new System.EventHandler(this.Odalar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtOdaNo;
        private System.Windows.Forms.TextBox txtOdaTipi;
        private System.Windows.Forms.TextBox txtOdaFiyati;
        private System.Windows.Forms.ComboBox cmbOdaDrm;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnGeri;
    }
}