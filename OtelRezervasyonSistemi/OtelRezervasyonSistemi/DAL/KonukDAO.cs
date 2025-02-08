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
    public class KonukDAO
    {

        dbBaglanti db = new dbBaglanti();
       
        public DataTable GetDataTable() 
        {
            string query = "SELECT * FROM TblKonuk";
            MySqlCommand cmd = new MySqlCommand(query, db.baglantiGetir());
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
       
        public List<Konuk> GetAll()
        {
            List<Konuk> konuklar = new List<Konuk>();
            using (MySqlConnection conn = db.baglantiGetir())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM TblKonuk";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        konuklar.Add(new Konuk
                        {
                            KonukId = int.Parse(reader["konuk_id"].ToString()),
                            Adi = reader["adi"].ToString(),
                            Soyadi = reader["soyadi"].ToString(),
                            Cinsiyet = reader["cinsiyet"].ToString(),
                            Telefon = reader["telefon"].ToString(),
                            Mail = reader["mail"].ToString(),
                            TcKimlikNo = reader["tc_kimlik_no"].ToString()
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return konuklar;
        }

        public void AddKonuk(Konuk konuk)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = "INSERT INTO TblKonuk (adi, soyadi, cinsiyet, telefon, mail, tc_kimlik_no) " +
                                   "VALUES (@Adi, @Soyadi, @Cinsiyet, @Telefon, @Mail, @TcKimlikNo)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Adi", konuk.Adi);
                    cmd.Parameters.AddWithValue("@Soyadi", konuk.Soyadi);
                    cmd.Parameters.AddWithValue("@Cinsiyet", konuk.Cinsiyet);
                    cmd.Parameters.AddWithValue("@Telefon", konuk.Telefon);
                    cmd.Parameters.AddWithValue("@Mail", konuk.Mail);
                    cmd.Parameters.AddWithValue("@TcKimlikNo", konuk.TcKimlikNo);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateKonuk(Konuk konuk)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = "UPDATE TblKonuk SET adi = @Adi, soyadi = @Soyadi, cinsiyet = @Cinsiyet, telefon = @Telefon, " +
                                   "mail = @Mail, tc_kimlik_no = @TcKimlikNo WHERE konuk_id = @KonukId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@KonukId", konuk.KonukId);
                    cmd.Parameters.AddWithValue("@Adi", konuk.Adi);
                    cmd.Parameters.AddWithValue("@Soyadi", konuk.Soyadi);
                    cmd.Parameters.AddWithValue("@Cinsiyet", konuk.Cinsiyet);
                    cmd.Parameters.AddWithValue("@Telefon", konuk.Telefon);
                    cmd.Parameters.AddWithValue("@Mail", konuk.Mail);
                    cmd.Parameters.AddWithValue("@TcKimlikNo", konuk.TcKimlikNo);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "SQL Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        public void DeleteKonuk(int konukID)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    conn.Open();
                    string query = "DELETE FROM TblKonuk WHERE konuk_id = @KonukId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@KonukId", konukID);
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
