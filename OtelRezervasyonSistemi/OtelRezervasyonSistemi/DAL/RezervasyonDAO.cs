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
    public class RezervasyonDAO
    {
         private dbBaglanti db = new dbBaglanti();
        public DataTable GetDataTable()
        {
            string query = "SELECT * FROM TblRezervasyon";
            MySqlCommand cmd = new MySqlCommand(query, db.baglantiGetir());
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public List<Rezervasyon> GetAll()
        {
            List<Rezervasyon> rezervasyonlar = new List<Rezervasyon>();
            using (MySqlConnection conn = db.baglantiGetir())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM TblRezervasyon";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        rezervasyonlar.Add(new Rezervasyon
                        {
                            RezervasyonId = int.Parse(reader["rezervasyon_id"].ToString()),
                            KonukId = reader["konuk_id"].ToString(),
                            OdaId = reader["oda_id"].ToString(),
                            GirisTarihi = DateTime.Parse(reader["giris_tarihi"].ToString()),
                            CikisTarihi = DateTime.Parse(reader["cikis_tarihi"].ToString()),
                            Ucret = decimal.Parse(reader["ucret"].ToString())
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return rezervasyonlar;
        }

        public void Add(Rezervasyon rezervasyon)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = "INSERT INTO TblRezervasyon (konuk_id,  oda_id, giris_tarihi, cikis_tarihi, ucret) " +
                                   "VALUES (@KonukId, , @OdaId, @GirisTarihi, @CikisTarihi, @Ucret)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@KonukId", rezervasyon.KonukId);
                    cmd.Parameters.AddWithValue("@OdaId", rezervasyon.OdaId);
                    cmd.Parameters.AddWithValue("@GirisTarihi", rezervasyon.GirisTarihi);
                    cmd.Parameters.AddWithValue("@CikisTarihi", rezervasyon.CikisTarihi);
                    cmd.Parameters.AddWithValue("@Ucret", rezervasyon.Ucret);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Update(Rezervasyon rezervasyon)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = "UPDATE TblRezervasyon SET konuk_id = @KonukId,  oda_id = @OdaId, " +
                                   "giris_tarihi = @GirisTarihi, cikis_tarihi = @CikisTarihi, ucret = @Ucret WHERE rezervasyon_id = @RezervasyonId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@RezervasyonId", rezervasyon.RezervasyonId);
                    cmd.Parameters.AddWithValue("@KonukId", rezervasyon.KonukId);
                    cmd.Parameters.AddWithValue("@OdaId", rezervasyon.OdaId);
                    cmd.Parameters.AddWithValue("@GirisTarihi", rezervasyon.GirisTarihi);
                    cmd.Parameters.AddWithValue("@CikisTarihi", rezervasyon.CikisTarihi);
                    cmd.Parameters.AddWithValue("@Ucret", rezervasyon.Ucret);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Delete(int rezervasyonId)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = "DELETE FROM TblRezervasyon WHERE rezervasyon_id = @RezervasyonId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@RezervasyonId", rezervasyonId);
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
