using MySql.Data.MySqlClient;
using OtelRezervasyonSistemi.DOMAIN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OtelRezervasyonSistemi.DAL
{
    public class KullaniciBilgileriDAO
    {
        private dbBaglanti db = new dbBaglanti();
        public List<KullaniciBilgileri> GetAll()
        {
            List<KullaniciBilgileri> kullanicilar = new List<KullaniciBilgileri>();
            using (MySqlConnection conn = db.baglantiGetir())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM KullaniciBilgileri";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        kullanicilar.Add(new KullaniciBilgileri
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            YeniAd = reader["yeni_ad"].ToString(),
                            YeniSifre = reader["yeni_sifre"].ToString()
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return kullanicilar;
        }

        
        public void AddKullanici(KullaniciBilgileri kullanici)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = "INSERT INTO KullaniciBilgileri (yeni_ad, yeni_sifre) VALUES (@YeniAd, @YeniSifre)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@YeniAd", kullanici.YeniAd);
                    cmd.Parameters.AddWithValue("@YeniSifre", kullanici.YeniSifre);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        public void UpdateKullanici(KullaniciBilgileri kullanici)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = "UPDATE KullaniciBilgileri SET yeni_ad = @YeniAd, yeni_sifre = @YeniSifre WHERE id = @Id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Id", kullanici.Id);
                    cmd.Parameters.AddWithValue("@YeniAd", kullanici.YeniAd);
                    cmd.Parameters.AddWithValue("@YeniSifre", kullanici.YeniSifre);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        public void DeleteKullanici(int id)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = "DELETE FROM KullaniciBilgileri WHERE id = @Id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
