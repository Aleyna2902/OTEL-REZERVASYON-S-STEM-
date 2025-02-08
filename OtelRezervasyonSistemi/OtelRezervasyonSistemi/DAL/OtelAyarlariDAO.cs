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
    public class OtelAyarlariDAO
    {
        dbBaglanti db = new dbBaglanti();

        public List<DOMAIN.OtelAyarlari> GetAll()
        {
            List<DOMAIN.OtelAyarlari> otelAyarları = new List<DOMAIN.OtelAyarlari>();
            using (MySqlConnection conn = db.baglantiGetir())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM TblOtelAyarlari";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        otelAyarları.Add(new DOMAIN.OtelAyarlari
                        {
                            OtelId = int.Parse(reader["otel_id"].ToString()),
                            Telefon = reader["telefon"].ToString(),
                            Adres = reader["adres"].ToString()
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return otelAyarları;
        }

        public void AddOtelAyari(DOMAIN.OtelAyarlari otelAyari)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = "INSERT INTO TblOtelAyarlari ( telefon, adres) VALUES (@Telefon, @Adres)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Telefon", otelAyari.Telefon);
                    cmd.Parameters.AddWithValue("@Adres", otelAyari.Adres);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateOtelAyari(DOMAIN.OtelAyarlari otelAyari)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = "UPDATE TblOtelAyarlari SET telefon = @Telefon, adres = @Adres WHERE otel_id = @OtelId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@OtelId", otelAyari.OtelId);
                    cmd.Parameters.AddWithValue("@Telefon", otelAyari.Telefon);
                    cmd.Parameters.AddWithValue("@Adres", otelAyari.Adres);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteOtelAyari(int otelId)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = "DELETE FROM TblOtelAyarlari WHERE otel_id = @OtelId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@OtelId", otelId);
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
