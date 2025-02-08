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
    public class KullaniciBilgileriService
    {
        private KullaniciBilgileriDAO kullaniciBilgileriDAO = new KullaniciBilgileriDAO();
        private dbBaglanti db = new dbBaglanti();

        public List<KullaniciBilgileri> GetAllKullaniciBilgileri()
        {
            try
            {
                return kullaniciBilgileriDAO.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kullanıcı bilgileri alınırken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<KullaniciBilgileri>();
            }
        }

        public string AddKullaniciBilgileri(KullaniciBilgileri kullanici)
        {
            if (string.IsNullOrWhiteSpace(kullanici.YeniAd))
            {
                return "Yeni ad boş olamaz.";
            }
            if (string.IsNullOrWhiteSpace(kullanici.YeniSifre))
            {
                return "Yeni şifre boş olamaz.";
            }

            try
            {
                kullaniciBilgileriDAO.AddKullanici(kullanici);
                return "Kullanıcı bilgileri başarıyla eklendi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }
        public string UpdateKullaniciBilgileri(KullaniciBilgileri kullanici)
        {
            if (kullanici.Id <= 0)
            {
                return "Geçerli bir kullanıcı ID'si belirtilmeli.";
            }
            if (string.IsNullOrWhiteSpace(kullanici.YeniAd))
            {
                return "Yeni ad boş olamaz.";
            }
            if (string.IsNullOrWhiteSpace(kullanici.YeniSifre))
            {
                return "Yeni şifre boş olamaz.";
            }

            try
            {
                kullaniciBilgileriDAO.UpdateKullanici(kullanici);
                return "Kullanıcı bilgileri başarıyla güncellendi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }
        public string DeleteKullaniciBilgileri(int id)
        {
            if (id <= 0)
            {
                return "Geçerli bir kullanıcı ID'si belirtilmeli.";
            }

            try
            {
                kullaniciBilgileriDAO.DeleteKullanici(id);
                return "Kullanıcı bilgileri başarıyla silindi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }
    }
}
