using MySql.Data.MySqlClient;
using OtelRezervasyonSistemi.DAL;
using OtelRezervasyonSistemi.DOMAIN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelRezervasyonSistemi.SERVICE
{
    public class OdaService
    {
        private dbBaglanti db = new dbBaglanti();
        private OdaDAO odaDAO = new OdaDAO();

       
        public DataTable GetDataTable()
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    string query = "SELECT * FROM TblOda"; 
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataTable;
        }
        public List<string> GetOdaBilgileri()
        {
            List<string> odaBilgileri = new List<string>();
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                   
                    string query = "SELECT oda_no, oda_tipi FROM TblOda"; // Oda numarası ve tipi alınır
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string odaBilgi = $"{reader["oda_no"]} - {reader["oda_tipi"]}"; // Oda bilgilerini birleştir
                        odaBilgileri.Add(odaBilgi);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return odaBilgileri;
        }


        public List<Oda> GetAllOda()
        {
            try
            {
                return odaDAO.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Odalar alınırken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Oda>();
            }
        }

      
        public string AddOda(Oda oda)
        {
            if (oda.OdaNo <= 0)
                return "Geçerli bir oda numarası belirtilmelidir.";

            if (string.IsNullOrWhiteSpace(oda.OdaTipi))
                return "Oda tipi boş olamaz.";

            if (oda.Fiyat <= 0)
                return "Oda fiyatı sıfırdan büyük olmalıdır.";

            try
            {
                odaDAO.AddOda(oda);
                return "Oda başarıyla eklendi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

      
        public string UpdateOda(Oda oda)
        {
            if (oda.OdaId <= 0)
                return "Geçerli bir oda ID'si belirtilmeli.";

            if (oda.OdaNo <= 0)
                return "Geçerli bir oda numarası belirtilmelidir.";

            if (string.IsNullOrWhiteSpace(oda.OdaTipi))
                return "Oda tipi boş olamaz.";

            if (oda.Fiyat <= 0)
                return "Oda fiyatı sıfırdan büyük olmalıdır.";

            try
            {
                odaDAO.UpdateOda(oda);
                return "Oda başarıyla güncellendi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

      
        public string DeleteOda(int odaId)
        {
            if (odaId <= 0)
                return "Geçerli bir oda ID'si belirtilmeli.";

            try
            {
                odaDAO.DeleteOda(odaId);
                return "Oda başarıyla silindi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }


    }
}
