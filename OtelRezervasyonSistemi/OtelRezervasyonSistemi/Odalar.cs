using MySql.Data.MySqlClient;
using OtelRezervasyonSistemi.SERVICE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelRezervasyonSistemi
{
    public partial class Odalar : Form
    {
        OdaService odaService = new OdaService();
        public Odalar()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string odaNo = txtOdaNo.Text.Trim();
                string odaTipi = txtOdaTipi.Text.Trim();
                decimal odaFiyati;
                bool fiyatValid = decimal.TryParse(txtOdaFiyati.Text.Trim(), out odaFiyati);
                string odaDurumu = cmbOdaDrm.SelectedItem?.ToString();

                if (string.IsNullOrWhiteSpace(odaNo) || string.IsNullOrWhiteSpace(odaTipi) || !fiyatValid || odaFiyati <= 0 || string.IsNullOrWhiteSpace(odaDurumu))
                {
                    MessageBox.Show("Lütfen tüm alanları doğru şekilde doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (MySqlConnection conn = new MySqlConnection("Server = 172.21.54.253; Database = 25_132330001; Uid = 25_132330001; Pwd = !nif.ogr01ER"))
                {
                    conn.Open();

                    string query = "INSERT INTO TblOda (oda_no, oda_tipi, fiyat, durum_id) " +
                                   "VALUES (@OdaNo, @OdaTipi, @Fiyat, (SELECT durum_id FROM TblDurum WHERE durum_adi = @OdaDurumu))";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@OdaNo", odaNo);
                    cmd.Parameters.AddWithValue("@OdaTipi", odaTipi);
                    cmd.Parameters.AddWithValue("@Fiyat", odaFiyati);
                    cmd.Parameters.AddWithValue("@OdaDurumu", odaDurumu);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Oda başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtOdaNo.Clear();
                txtOdaTipi.Clear();
                txtOdaFiyati.Clear();
                cmbOdaDrm.SelectedIndex = -1;

                TabloyuGuncelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Odalar_Load(object sender, EventArgs e)
        {
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);

            TabloyuGuncelle(); 
        }

        private void TabloyuGuncelle()
        {
            try
            {
                dataGridView1.DataSource = odaService.GetDataTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    int odaId = Convert.ToInt32(row.Cells["oda_id"].Value);

                   
                    DialogResult dialogResult = MessageBox.Show($"Seçili oda silinecek. Emin misiniz?\nOda ID: {odaId}", "Oda Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dialogResult == DialogResult.Yes)
                    {
                        using (MySqlConnection conn = new MySqlConnection("Server = 172.21.54.253; Database = 25_132330001; Uid = 25_132330001; Pwd = !nif.ogr01ER"))
                        {
                            conn.Open();

                            string query = "DELETE FROM TblOda WHERE oda_id = @OdaId";
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@OdaId", odaId);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Oda başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                TabloyuGuncelle(); 
                            }
                            else
                            {
                                MessageBox.Show("Oda silinemedi. Lütfen tekrar deneyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show();
            this.Hide();
        }
    }
}
