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
    public class YoneticiService
    {
        private YoneticiDAO yoneticiDAO = new YoneticiDAO();

        public List<Yonetici> GetAllYonetici()
        {
            try
            {
                return yoneticiDAO.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yöneticiler alınırken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Yonetici>();
            }
        }

        public string AddYonetici(Yonetici yonetici)
        {
            if (string.IsNullOrWhiteSpace(yonetici.KullaniciAdi))
            {
                return "Kullanıcı adı boş olamaz.";
            }
            if (string.IsNullOrWhiteSpace(yonetici.Sifre))
            {
                return "Geçerli bir şifre belirtilmelidir.";
            }

            try
            {
                yoneticiDAO.AddYonetici(yonetici);
                return "Yönetici başarıyla eklendi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

        public string UpdateYonetici(Yonetici yonetici)
        {
            if (yonetici.YoneticiId <= 0)
            {
                return "Geçerli bir yönetici ID'si belirtilmeli.";
            }
            if (string.IsNullOrWhiteSpace(yonetici.KullaniciAdi))
            {
                return "Kullanıcı adı boş olamaz.";
            }
            if (string.IsNullOrWhiteSpace(yonetici.Sifre))
            {
                return "Geçerli bir şifre belirtilmelidir.";
            }

            try
            {
                yoneticiDAO.UpdateYonetici(yonetici);
                return "Yönetici başarıyla güncellendi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

        public string DeleteYonetici(int yoneticiId)
        {
            if (yoneticiId <= 0)
            {
                return "Geçerli bir yönetici ID'si belirtilmeli.";
            }

            try
            {
                yoneticiDAO.DeleteYonetici(yoneticiId);
                return "Yönetici başarıyla silindi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }
    }
}
