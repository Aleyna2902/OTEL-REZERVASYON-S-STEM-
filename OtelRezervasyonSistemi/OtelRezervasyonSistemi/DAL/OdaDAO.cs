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
    public class OdaDAO
    {
        private dbBaglanti db = new dbBaglanti();

        public DataTable GetDataTable()
        {
            string query = "SELECT * FROM TblOda";
            MySqlCommand cmd = new MySqlCommand(query, db.baglantiGetir());
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
        public List<Oda> GetAll()
        {
            List<Oda> odalar = new List<Oda>();
            using (MySqlConnection conn = db.baglantiGetir())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM TblOda";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        odalar.Add(new Oda
                        {
                            OdaId = int.Parse(reader["oda_id"].ToString()),
                            OdaNo = int.Parse(reader["oda_no"].ToString()),
                            OdaTipi = reader["oda_tipi"].ToString(),
                            Fiyat = decimal.Parse(reader["fiyat"].ToString()),
                            DurumId = int.Parse(reader["durum_id"].ToString()),
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return odalar;
        }

        public void AddOda(Oda oda)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = "INSERT INTO TblOda (oda_no, oda_tipi, fiyat, durum_id) " +
                                   "VALUES (@OdaNo, @OdaTipi, @Fiyat, @DurumId)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@OdaNo", oda.OdaNo);
                    cmd.Parameters.AddWithValue("@OdaTipi", oda.OdaTipi);
                    cmd.Parameters.AddWithValue("@Fiyat", oda.Fiyat);
                    cmd.Parameters.AddWithValue("@DurumId", oda.DurumId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateOda(Oda oda)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = "UPDATE TblOda SET oda_no = @OdaNo, oda_tipi = @OdaTipi, fiyat = @Fiyat, durum_id = @DurumId " +
                                   "WHERE oda_id = @OdaId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@OdaId", oda.OdaId);
                    cmd.Parameters.AddWithValue("@OdaNo", oda.OdaNo);
                    cmd.Parameters.AddWithValue("@OdaTipi", oda.OdaTipi);
                    cmd.Parameters.AddWithValue("@Fiyat", oda.Fiyat);
                    cmd.Parameters.AddWithValue("@DurumId", oda.DurumId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteOda(int odaID)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = "DELETE FROM TblOda WHERE oda_id = @OdaId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@OdaId", odaID);
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
