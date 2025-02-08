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
    public class RezervasyonService
    {
        private dbBaglanti db = new dbBaglanti();
        private RezervasyonDAO rezervasyonDAO = new RezervasyonDAO();
        public DataTable GetDataTable()
        {
            return rezervasyonDAO.GetDataTable();
        }

        public List<Rezervasyon> GetAllRezervasyon()
        {
            try
            {
                return rezervasyonDAO.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Rezervasyonlar alınırken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Rezervasyon>();
            }
        }

       
        public string AddRezervasyon(Rezervasyon rezervasyon)
        {
           

            try
            {
                rezervasyonDAO.Add(rezervasyon);
                return "Rezervasyon başarıyla eklendi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

        
        public string UpdateRezervasyon(Rezervasyon rezervasyon)
        {
            if (rezervasyon.RezervasyonId <= 0)
            {
                return "Geçerli bir rezervasyon ID'si belirtilmeli.";
            }

            try
            {
                rezervasyonDAO.Update(rezervasyon);
                return "Rezervasyon başarıyla güncellendi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }


        public string DeleteRezervasyon(int rezervasyonId)
        {
            if (rezervasyonId <= 0)
            {
                return "Geçerli bir rezervasyon ID'si belirtilmeli.";
            }

            try
            {
                rezervasyonDAO.Delete(rezervasyonId);
                return "Rezervasyon başarıyla silindi.";
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }
        
    }
}
