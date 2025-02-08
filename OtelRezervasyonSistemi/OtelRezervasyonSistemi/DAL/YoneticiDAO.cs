using MySql.Data.MySqlClient;
using OtelRezervasyonSistemi.DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelRezervasyonSistemi.DAL
{
    public class YoneticiDAO
    {
        dbBaglanti db = new dbBaglanti();

        public List<Yonetici> GetAll()
        {
            List<Yonetici> yoneticiler = new List<Yonetici>();
            using (MySqlConnection conn = db.baglantiGetir())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM TblYonetici";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        yoneticiler.Add(new Yonetici
                        {
                            YoneticiId = int.Parse(reader["yonetici_id"].ToString()),
                            KullaniciAdi = reader["kullanici_adi"].ToString(),
                            Sifre = reader["sifre"].ToString()
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return yoneticiler;
        }

        public void AddYonetici(Yonetici yonetici)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = "INSERT INTO TblYonetici (kullanici_adi, sifre) VALUES (@KullaniciAdi, @Sifre)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@KullaniciAdi", yonetici.KullaniciAdi);
                    cmd.Parameters.AddWithValue("@Sifre", yonetici.Sifre);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateYonetici(Yonetici yonetici)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = "UPDATE TblYonetici SET kullanici_adi = @KullaniciAdi, sifre = @Sifre WHERE yonetici_id = @YoneticiId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@YoneticiId", yonetici.YoneticiId);
                    cmd.Parameters.AddWithValue("@KullaniciAdi", yonetici.KullaniciAdi);
                    cmd.Parameters.AddWithValue("@Sifre", yonetici.Sifre);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteYonetici(int yoneticiID)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = "DELETE FROM TblYonetici WHERE yonetici_id = @YoneticiId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@YoneticiId", yoneticiID);
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
