using OtelRezervasyonSistemi.DAL;
using OtelRezervasyonSistemi.DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelRezervasyonSistemi.SERVICE
{
    public class DurumService
    {
        private DurumDAO durumDAO = new DurumDAO();

        public List<Durum> GetAllDurum()
        {
            try
            {
                return durumDAO.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Durumlar alınırken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Durum>();
            }
        }

        public string AddDurum(Durum durum)
        {
            if (string.IsNullOrWhiteSpace(durum.DurumAdi))
            {
                return "Durum adı boş olamaz.";
            }

            try
            {
                durumDAO.AddDurum(durum);
                return "Durum başarıyla eklendi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

        public string UpdateDurum(Durum durum)
        {
            if (durum.DurumId <= 0)
            {
                return "Geçerli bir durum ID'si belirtilmeli.";
            }
            if (string.IsNullOrWhiteSpace(durum.DurumAdi))
            {
                return "Durum adı boş olamaz.";
            }

            try
            {
                durumDAO.UpdateDurum(durum);
                return "Durum başarıyla güncellendi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

        public string DeleteDurum(int durumId)
        {
            if (durumId <= 0)
            {
                return "Geçerli bir durum ID'si belirtilmeli.";
            }

            try
            {
                durumDAO.DeleteDurum(durumId);
                return "Durum başarıyla silindi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }
    }
}
