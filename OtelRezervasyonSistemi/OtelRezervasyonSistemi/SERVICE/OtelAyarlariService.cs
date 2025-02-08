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
    public class OtelAyarlariService
    {
        private OtelAyarlariDAO otelAyarlariDAO = new OtelAyarlariDAO();

      
        public List<DOMAIN.OtelAyarlari> GetAllOtelAyarlari()
        {
            try
            {
                return otelAyarlariDAO.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Otel ayarları alınırken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<DOMAIN.OtelAyarlari>();
            }
        }

       
        public string AddOtelAyari(DOMAIN.OtelAyarlari otelAyari)
        {
            
            if (string.IsNullOrWhiteSpace(otelAyari.Telefon))
            {
                return "Telefon bilgisi boş olamaz.";
            }
            if (string.IsNullOrWhiteSpace(otelAyari.Adres))
            {
                return "Adres bilgisi boş olamaz.";
            }

            try
            {
                otelAyarlariDAO.AddOtelAyari(otelAyari);
                return "Otel bilgisi başarıyla eklendi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

       
        public string UpdateOtelAyari(DOMAIN.OtelAyarlari otelAyari)
        {
            if (otelAyari.OtelId <= 0)
            {
                return "Geçerli bir otel ID'si belirtilmeli.";
            }
            if (string.IsNullOrWhiteSpace(otelAyari.Telefon))
            {
                return "Telefon bilgisi boş olamaz.";
            }
            if (string.IsNullOrWhiteSpace(otelAyari.Adres))
            {
                return "Adres bilgisi boş olamaz.";
            }

            try
            {
                otelAyarlariDAO.UpdateOtelAyari(otelAyari);
                return "Otel bilgisi başarıyla güncellendi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

       
        public string DeleteOtelAyari(int otelId)
        {
            if (otelId <= 0)
            {
                return "Geçerli bir otel ID'si belirtilmeli.";
            }

            try
            {
                otelAyarlariDAO.DeleteOtelAyari(otelId);
                return "Otel bilgisi başarıyla silindi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }
    }
}
