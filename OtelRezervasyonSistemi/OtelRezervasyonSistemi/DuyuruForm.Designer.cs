namespace OtelRezervasyonSistemi
{
    partial class DuyuruForm
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
            this.components = new System.ComponentModel.Container();
            this.txtBaslik = new System.Windows.Forms.TextBox();
            this.txtIcerik = new System.Windows.Forms.TextBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.dgvDuyurular = new System.Windows.Forms.DataGridView();
            this.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsSil = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGeri = new System.Windows.Forms.Button();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuyurular)).BeginInit();
            this.ContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBaslik
            // 
            this.txtBaslik.Location = new System.Drawing.Point(38, 95);
            this.txtBaslik.Multiline = true;
            this.txtBaslik.Name = "txtBaslik";
            this.txtBaslik.Size = new System.Drawing.Size(251, 62);
            this.txtBaslik.TabIndex = 0;
            // 
            // txtIcerik
            // 
            this.txtIcerik.Location = new System.Drawing.Point(38, 172);
            this.txtIcerik.Multiline = true;
            this.txtIcerik.Name = "txtIcerik";
            this.txtIcerik.Size = new System.Drawing.Size(426, 253);
            this.txtIcerik.TabIndex = 1;
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnEkle.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEkle.Location = new System.Drawing.Point(38, 462);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(112, 55);
            this.btnEkle.TabIndex = 2;
            this.btnEkle.Text = "EKLE";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // dgvDuyurular
            // 
            this.dgvDuyurular.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDuyurular.ContextMenuStrip = this.ContextMenuStrip;
            this.dgvDuyurular.Location = new System.Drawing.Point(489, 38);
            this.dgvDuyurular.Name = "dgvDuyurular";
            this.dgvDuyurular.RowHeadersWidth = 51;
            this.dgvDuyurular.RowTemplate.Height = 24;
            this.dgvDuyurular.Size = new System.Drawing.Size(544, 479);
            this.dgvDuyurular.TabIndex = 3;
            this.dgvDuyurular.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDuyurular_CellContentClick);
            this.dgvDuyurular.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvDuyurular_MouseDown_1);
            // 
            // ContextMenuStrip
            // 
            this.ContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsSil});
            this.ContextMenuStrip.Name = "cmsSil";
            this.ContextMenuStrip.Size = new System.Drawing.Size(211, 56);
            // 
            // cmsSil
            // 
            this.cmsSil.Name = "cmsSil";
            this.cmsSil.Size = new System.Drawing.Size(210, 24);
            this.cmsSil.Text = "Sil";
            this.cmsSil.Click += new System.EventHandler(this.cmsSil_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(42, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Güncel Duyurular";
            // 
            // btnGeri
            // 
            this.btnGeri.BackColor = System.Drawing.Color.Red;
            this.btnGeri.Location = new System.Drawing.Point(12, 12);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(41, 23);
            this.btnGeri.TabIndex = 23;
            this.btnGeri.Text = "<--";
            this.btnGeri.UseVisualStyleBackColor = false;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // dtpTarih
            // 
            this.dtpTarih.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpTarih.Location = new System.Drawing.Point(38, 431);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(200, 25);
            this.dtpTarih.TabIndex = 24;
            // 
            // DuyuruForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1045, 564);
            this.Controls.Add(this.dtpTarih);
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDuyurular);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.txtIcerik);
            this.Controls.Add(this.txtBaslik);
            this.Name = "DuyuruForm";
            this.Text = "DuyurularForm";
            this.Load += new System.EventHandler(this.DuyuruForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuyurular)).EndInit();
            this.ContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBaslik;
        private System.Windows.Forms.TextBox txtIcerik;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.DataGridView dgvDuyurular;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGeri;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem cmsSil;
    }
}