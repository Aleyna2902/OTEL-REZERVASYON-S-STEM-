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
    public class DuyuruDAO
    {
        private dbBaglanti db = new dbBaglanti();
        public DataTable GetDataTable()
        {
            string query = "SELECT * FROM TblDuyuru";
            MySqlCommand cmd = new MySqlCommand(query, db.baglantiGetir());
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public List<Duyuru> GetAll()
        {
            List<Duyuru> duyurular = new List<Duyuru>();
            using (MySqlConnection conn = db.baglantiGetir())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM TblDuyuru";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        duyurular.Add(new Duyuru
                        {
                            DuyuruId = Convert.ToInt32(reader["duyuru_id"]),
                            Baslik = reader["baslik"].ToString(),
                            Icerik = reader["icerik"].ToString(),
                            Tarih = Convert.ToDateTime(reader["tarih"])
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return duyurular;
        }

       
        public void AddDuyuru(Duyuru duyuru)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = "INSERT INTO TblDuyuru (baslik, icerik, tarih) VALUES (@Baslik, @Icerik, @Tarih)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Baslik", duyuru.Baslik);
                    cmd.Parameters.AddWithValue("@Icerik", duyuru.Icerik);
                    cmd.Parameters.AddWithValue("@Tarih", duyuru.Tarih);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        public void UpdateDuyuru(Duyuru duyuru)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = "UPDATE TblDuyuru SET baslik = @Baslik, icerik = @Icerik, tarih = @Tarih WHERE duyuru_id = @DuyuruId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@DuyuruId", duyuru.DuyuruId);
                    cmd.Parameters.AddWithValue("@Baslik", duyuru.Baslik);
                    cmd.Parameters.AddWithValue("@Icerik", duyuru.Icerik);
                    cmd.Parameters.AddWithValue("@Tarih", duyuru.Tarih);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        public void DeleteDuyuru(int duyuruId)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = "DELETE FROM TblDuyuru WHERE duyuru_id = @DuyuruId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@DuyuruId", duyuruId);
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
