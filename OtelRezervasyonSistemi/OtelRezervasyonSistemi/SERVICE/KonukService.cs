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
    public class KonukService
    {
        private KonukDAO konukDAO = new KonukDAO();

        public DataTable GetDataTable() 
        {
            return konukDAO.GetDataTable();
        }
        public List<Konuk> GetAllKonuk()
        {
            try
            {
                return konukDAO.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Konuklar alınırken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Konuk>();
            }
        }

        public string AddKonuk(Konuk konuk)
        {
            if (!ValidateKonuk(konuk, out string errorMessage))
            {
                return errorMessage;
            }

            try
            {
                konukDAO.AddKonuk(konuk);
                return "Konuk başarıyla eklendi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }


        public string UpdateKonuk(Konuk konuk)
        {
            if (konuk.KonukId <= 0)
            {
                return "Geçerli bir konuk ID'si belirtilmeli.";
            }

            if (!ValidateKonuk(konuk, out string errorMessage))
            {
                return errorMessage;
            }

            try
            {
                konukDAO.UpdateKonuk(konuk);
                return "Konuk başarıyla güncellendi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

        public string DeleteKonuk(int konukID)
        {
            if (konukID <= 0)
            {
                return "Geçerli bir konuk ID'si belirtilmeli.";
            }

            try
            {
                konukDAO.DeleteKonuk(konukID);
                return "Konuk başarıyla silindi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

        private bool ValidateKonuk(Konuk konuk, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(konuk.Adi))
            {
                errorMessage = "Konuk adı boş olamaz.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(konuk.Soyadi))
            {
                errorMessage = "Konuk soyadı boş olamaz.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(konuk.Cinsiyet) || (konuk.Cinsiyet.ToLower() != "erkek" && konuk.Cinsiyet.ToLower() != "kadın"))
            {
                errorMessage = "Cinsiyet 'Erkek' veya 'Kadın' olmalıdır.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(konuk.Telefon) || konuk.Telefon.Length < 10)
            {
                errorMessage = "Geçerli bir telefon numarası belirtilmelidir.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(konuk.Mail) || !konuk.Mail.Contains("@"))
            {
                errorMessage = "Geçerli bir e-posta adresi belirtilmelidir.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(konuk.TcKimlikNo) || konuk.TcKimlikNo.Length != 11 || !long.TryParse(konuk.TcKimlikNo, out _))
            {
                errorMessage = "Geçerli bir TC kimlik numarası belirtilmelidir.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }


    }
}
