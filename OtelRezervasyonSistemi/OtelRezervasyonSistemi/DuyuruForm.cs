using MySql.Data.MySqlClient;
using OtelRezervasyonSistemi.DAL;
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
    public partial class DuyuruForm : Form
    {
        private dbBaglanti db = new dbBaglanti();
        DuyuruService duyuruService = new DuyuruService();
        private int? seciliDuyuruId = null;
        public DuyuruForm()
        {
            InitializeComponent();
        }

        private void VerileriGetir()
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    string query = "SELECT duyuru_id, baslik AS 'Başlık', icerik AS 'İçerik', tarih AS 'Tarih' FROM TblDuyuru";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvDuyurular.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                string baslik = txtBaslik.Text.Trim();
                string icerik = txtIcerik.Text.Trim();
                DateTime tarih = dtpTarih.Value; 

                if (string.IsNullOrWhiteSpace(baslik) || string.IsNullOrWhiteSpace(icerik))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (seciliDuyuruId > 0)
                {
                    
                    using (MySqlConnection conn = db.baglantiGetir())
                    {
                        string query = "UPDATE TblDuyuru SET baslik = @Baslik, icerik = @Icerik, tarih = @Tarih WHERE duyuru_id = @DuyuruId";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Baslik", baslik);
                        cmd.Parameters.AddWithValue("@Icerik", icerik);
                        cmd.Parameters.AddWithValue("@Tarih", tarih);
                        cmd.Parameters.AddWithValue("@DuyuruId", seciliDuyuruId);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Duyuru başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                   
                    using (MySqlConnection conn = db.baglantiGetir())
                    {
                        string query = "INSERT INTO TblDuyuru (baslik, icerik, tarih) VALUES (@Baslik, @Icerik, @Tarih)";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Baslik", baslik);
                        cmd.Parameters.AddWithValue("@Icerik", icerik);
                        cmd.Parameters.AddWithValue("@Tarih", tarih);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Duyuru başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                
                txtBaslik.Clear();
                txtIcerik.Clear();
                dtpTarih.Value = DateTime.Now;
                seciliDuyuruId = 0;
                btnEkle.Text = "Ekle";

                TabloyuGuncelle();
                AnaSayfaFormuGuncelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AnaSayfaFormuGuncelle()
        {
           
            AnaSayfa anaSayfa = Application.OpenForms["AnaSayfa"] as AnaSayfa;
            if (anaSayfa != null)
            {
                anaSayfa.DuyurulariGetir(); 
            }
        }
        private void TabloyuGuncelle()
        {
            try
            {
                dgvDuyurular.DataSource = duyuruService.GetDataTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DuyuruForm_Load_1(object sender, EventArgs e)
        {
            TabloyuGuncelle();
            VerileriGetir();
        }

        private void dgvDuyurular_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDuyurular.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvDuyurular.Rows[e.RowIndex];

                seciliDuyuruId = Convert.ToInt32(selectedRow.Cells["duyuru_id"].Value);
                txtBaslik.Text = selectedRow.Cells["Başlık"].Value?.ToString() ?? string.Empty;
                txtIcerik.Text = selectedRow.Cells["İçerik"].Value?.ToString() ?? string.Empty;

                
                if (DateTime.TryParse(selectedRow.Cells["Tarih"].Value?.ToString(), out DateTime tarih))
                {
                    dtpTarih.Value = tarih;
                }
                else
                {
                    dtpTarih.Value = DateTime.Now; 
                }

                btnEkle.Text = "Güncelle"; 
                if (selectedRow.Cells["duyuru_id"].Value == null || selectedRow.Cells["duyuru_id"].Value == DBNull.Value)
                {
                    MessageBox.Show("Seçilen satırda duyuru ID'si bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
        }

        private void SilDuyuru(int duyuruId)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    string query = "DELETE FROM TblDuyuru WHERE duyuru_id = @DuyuruId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@DuyuruId", duyuruId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Duyuru başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Silme işlemi başarısız oldu. Bu ID'ye sahip bir duyuru bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                AnaSayfaFormuGuncelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Silme işlemi sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDuyurular_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                
                var hitTestInfo = dgvDuyurular.HitTest(e.X, e.Y);
                if (hitTestInfo.RowIndex >= 0 && hitTestInfo.ColumnIndex >= 0)
                {
                    dgvDuyurular.ClearSelection();
                    dgvDuyurular.Rows[hitTestInfo.RowIndex].Selected = true;

                    
                    ContextMenuStrip.Show(dgvDuyurular, new Point(e.X, e.Y));
                }
            }
        }

        private void cmsSil_Click_1(object sender, EventArgs e)
        {
            if (dgvDuyurular.SelectedRows.Count > 0)
            {
               
                DataGridViewRow selectedRow = dgvDuyurular.SelectedRows[0];
                int duyuruId = Convert.ToInt32(selectedRow.Cells["duyuru_id"].Value);

               
                DialogResult dialogResult = MessageBox.Show(
                    "Seçili duyuruyu silmek istediğinizden emin misiniz?",
                    "Onay",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (dialogResult == DialogResult.Yes)
                {
                    SilDuyuru(duyuruId); 
                    VerileriGetir(); 
                }
            }
            else
            {
                MessageBox.Show("Silmek için bir satır seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
