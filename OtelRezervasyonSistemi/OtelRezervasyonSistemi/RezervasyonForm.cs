using MySql.Data.MySqlClient;
using OtelRezervasyonSistemi.DAL;
using OtelRezervasyonSistemi.DOMAIN;
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
    public partial class RezervasyonForm : Form
    {
        RezervasyonService rezervasyonService = new RezervasyonService();
        private OdaService odaService = new OdaService();
        private dbBaglanti db = new dbBaglanti();

        public RezervasyonForm()
        {
            InitializeComponent();
        }
      
        private void RezervasyonForm_Load(object sender, EventArgs e)
        {
           
            dtpGirisTarihi.Value = DateTime.Now;
            dtpCikisTarihi.Value = DateTime.Now.AddDays(1);
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;


            TabloyuGuncelle();
            LoadAdSoyadToComboBox();
            LoadOdaBilgileriToComboBox();
           
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

            try
            {
                string adSoyad = cmbBxAdSoyad.Text.Trim();
                string odaNo = cmbBxOdaNo.SelectedItem?.ToString();
                DateTime girisTarihi = dtpGirisTarihi.Value;
                DateTime cikisTarihi = dtpCikisTarihi.Value;
                decimal ucret;

                if (string.IsNullOrWhiteSpace(adSoyad) || string.IsNullOrWhiteSpace(odaNo) || !decimal.TryParse(txtUcret.Text.Trim(), out ucret) || ucret <= 0)
                {
                    MessageBox.Show("Lütfen tüm alanları doğru şekilde doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int konukId = GetKonukId(adSoyad);
                if (konukId == 0)
                {
                    MessageBox.Show("Seçilen konuk bulunamadı! Lütfen geçerli bir konuk seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int odaId = GetOdaId(odaNo);
                if (odaId == 0)
                {
                    MessageBox.Show("Seçilen oda bulunamadı! Lütfen geçerli bir oda seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!IsOdaMusait(odaId, girisTarihi, cikisTarihi))
                {
                    MessageBox.Show("Seçilen tarihlerde bu oda doludur. Lütfen başka bir tarih seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (MySqlConnection conn = db.baglantiGetir())
                {
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            
                            string rezervasyonQuery = "INSERT INTO TblRezervasyon (konuk_id, oda_id, giris_tarihi, cikis_tarihi, ucret) VALUES (@KonukId, @OdaId, @GirisTarihi, @CikisTarihi, @Ucret)";
                            MySqlCommand rezervasyonCmd = new MySqlCommand(rezervasyonQuery, conn, transaction);
                            rezervasyonCmd.Parameters.AddWithValue("@KonukId", konukId);
                            rezervasyonCmd.Parameters.AddWithValue("@OdaId", odaId);
                            rezervasyonCmd.Parameters.AddWithValue("@GirisTarihi", girisTarihi);
                            rezervasyonCmd.Parameters.AddWithValue("@CikisTarihi", cikisTarihi);
                            rezervasyonCmd.Parameters.AddWithValue("@Ucret", ucret);
                            rezervasyonCmd.ExecuteNonQuery();

                           
                            string odaDurumuQuery = "UPDATE TblOda SET durum_id = 2 WHERE oda_id = @OdaId"; 
                            MySqlCommand odaDurumuCmd = new MySqlCommand(odaDurumuQuery, conn, transaction);
                            odaDurumuCmd.Parameters.AddWithValue("@OdaId", odaId);
                            odaDurumuCmd.ExecuteNonQuery();

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }

                }

                MessageBox.Show("Rezervasyon başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsOdaMusait(int odaId, DateTime girisTarihi, DateTime cikisTarihi)
        {
            bool musait = true;
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    string query = @"
                        SELECT COUNT(*) 
                        FROM TblRezervasyon 
                        WHERE oda_id = @OdaId 
                          AND ((@GirisTarihi BETWEEN giris_tarihi AND cikis_tarihi) 
                          OR (@CikisTarihi BETWEEN giris_tarihi AND cikis_tarihi) 
                          OR (giris_tarihi BETWEEN @GirisTarihi AND @CikisTarihi))";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@OdaId", odaId);
                    cmd.Parameters.AddWithValue("@GirisTarihi", girisTarihi);
                    cmd.Parameters.AddWithValue("@CikisTarihi", cikisTarihi);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    musait = count == 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return musait;
        }

        private void ResetForm()
        {
            cmbBxAdSoyad.SelectedIndex = -1;
            cmbBxOdaNo.SelectedIndex = -1;
            dtpGirisTarihi.Value = DateTime.Now;
            dtpCikisTarihi.Value = DateTime.Now.AddDays(1);
            txtUcret.Clear();
            TabloyuGuncelle();
        }

        private void TabloyuGuncelle()
        {
            try
            {
                dataGridView1.DataSource = rezervasyonService.GetDataTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAdSoyadToComboBox()
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    string query = "SELECT adi, soyadi FROM TblKonuk";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    cmbBxAdSoyad.Items.Clear();

                    while (reader.Read())
                    {
                        string adSoyad = $"{reader["adi"]} {reader["soyadi"]}";
                        cmbBxAdSoyad.Items.Add(adSoyad);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOdaBilgileriToComboBox()
        {
            try
            {
                List<string> odaBilgileri = odaService.GetOdaBilgileri();
                cmbBxOdaNo.Items.Clear();
                cmbBxOdaNo.Items.AddRange(odaBilgileri.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HesaplaUcret()
        {
            try
            {
                DateTime girisTarihi = dtpGirisTarihi.Value;
                DateTime cikisTarihi = dtpCikisTarihi.Value;

                if (cikisTarihi <= girisTarihi)
                {
                    MessageBox.Show("Çıkış tarihi, giriş tarihinden önce olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int gunFarki = (cikisTarihi - girisTarihi).Days;

                if (cmbBxOdaNo.SelectedItem != null && gunFarki > 0)
                {
                    string odaNo = cmbBxOdaNo.SelectedItem.ToString();
                    decimal odaFiyati = GetOdaFiyati(odaNo);

                    decimal toplamUcret = odaFiyati * gunFarki;
                    txtUcret.Text = toplamUcret.ToString("F2");
                }
                else
                {
                    txtUcret.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal GetOdaFiyati(string odaNo)
        {
            decimal fiyat = 0;
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    string query = "SELECT fiyat FROM TblOda WHERE oda_no= @OdaNo";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@OdaNo", odaNo);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        fiyat = Convert.ToDecimal(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return fiyat;
        }

        private void dtpGirisTarihi_ValueChanged(object sender, EventArgs e)
        {
            if (dtpCikisTarihi.Value <= dtpGirisTarihi.Value)
            {
                dtpCikisTarihi.Value = dtpGirisTarihi.Value.AddDays(1); 
            }
            HesaplaUcret();
        }

        private void dtpCikisTarihi_ValueChanged(object sender, EventArgs e)
        {
            if (dtpCikisTarihi.Value <= dtpGirisTarihi.Value)
            {
                MessageBox.Show("Çıkış tarihi, giriş tarihinden önce olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpCikisTarihi.Value = dtpGirisTarihi.Value.AddDays(1);
            }
            HesaplaUcret();
        }

        private void cmbBxOdaNo_SelectedIndexChanged(object sender, EventArgs e)
        { 
            HesaplaUcret();
        }
        private int GetKonukId(string adSoyad)
        {
            int konukId = 0;
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    string query = "SELECT konuk_id FROM TblKonuk WHERE CONCAT(adi, ' ', soyadi) = @AdSoyad";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AdSoyad", adSoyad);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        konukId = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return konukId;
        }
        private int GetOdaId(string odaNo)
        {

            int odaId = 0;
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    string query = "SELECT oda_id FROM TblOda WHERE oda_no = @OdaNo";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@OdaNo", odaNo);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        odaId = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return odaId;
        }

       
       
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                int rezervasyonId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["rezervasyon_id"].Value);

                DialogResult result = MessageBox.Show("Seçili rezervasyonu silmek istediğinizden emin misiniz?",
                                                      "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    RezervasyonSil(rezervasyonId);
                }
            }
        }

        private void RezervasyonSil(int rezervasyonId)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                   
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                           
                            string getOdaIdQuery = "SELECT oda_id FROM TblRezervasyon WHERE rezervasyon_id = @RezervasyonId";
                            MySqlCommand getOdaIdCmd = new MySqlCommand(getOdaIdQuery, conn, transaction);
                            getOdaIdCmd.Parameters.AddWithValue("@RezervasyonId", rezervasyonId);

                            object result = getOdaIdCmd.ExecuteScalar();

                            if (result != null)
                            {
                                int odaId = Convert.ToInt32(result);

                                
                                string deleteQuery = "DELETE FROM TblRezervasyon WHERE rezervasyon_id = @RezervasyonId";
                                MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn, transaction);
                                deleteCmd.Parameters.AddWithValue("@RezervasyonId", rezervasyonId);
                                deleteCmd.ExecuteNonQuery();

                               
                                string updateOdaDurumQuery = "UPDATE TblOda SET durum_id = 1 WHERE oda_id = @OdaId"; 
                                MySqlCommand updateOdaDurumCmd = new MySqlCommand(updateOdaDurumQuery, conn, transaction);
                                updateOdaDurumCmd.Parameters.AddWithValue("@OdaId", odaId);
                                updateOdaDurumCmd.ExecuteNonQuery();

                               
                                transaction.Commit();
                                MessageBox.Show("Rezervasyon başarıyla silindi ve oda durumu güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                TabloyuGuncelle();
                            }
                            else
                            {
                                transaction.Rollback();
                                MessageBox.Show("Rezervasyon ID'sine ait oda bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
