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
    public class DuyuruService
    {
        private DuyuruDAO duyuruDAO = new DuyuruDAO();

        public DataTable GetDataTable()
        {
            return duyuruDAO.GetDataTable();
        }
        public List<Duyuru> GetAllDuyuru()
        {
            try
            {
                return duyuruDAO.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Duyurular alınırken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Duyuru>();
            }
        }

       
        public string AddDuyuru(Duyuru duyuru)
        {
            if (string.IsNullOrWhiteSpace(duyuru.Baslik))
            {
                return "Duyuru başlığı boş olamaz.";
            }

            if (string.IsNullOrWhiteSpace(duyuru.Icerik))
            {
                return "Duyuru içeriği boş olamaz.";
            }

            try
            {
                duyuruDAO.AddDuyuru(duyuru);
                return "Duyuru başarıyla eklendi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

      
        public string UpdateDuyuru(Duyuru duyuru)
        {
            if (duyuru.DuyuruId <= 0)
            {
                return "Geçerli bir duyuru ID'si belirtilmeli.";
            }
            if (string.IsNullOrWhiteSpace(duyuru.Baslik))
            {
                return "Duyuru başlığı boş olamaz.";
            }
            if (string.IsNullOrWhiteSpace(duyuru.Icerik))
            {
                return "Duyuru içeriği boş olamaz.";
            }

            try
            {
                duyuruDAO.UpdateDuyuru(duyuru);
                return "Duyuru başarıyla güncellendi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

       
        public string DeleteDuyuru(int duyuruId)
        {
            if (duyuruId <= 0)
            {
                return "Geçerli bir duyuru ID'si belirtilmeli.";
            }

            try
            {
                duyuruDAO.DeleteDuyuru(duyuruId);
                return "Duyuru başarıyla silindi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }
    }
}
