using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRezervasyonSistemi.DOMAIN
{
    public class Duyuru
    {
        public int DuyuruId { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public DateTime Tarih { get; set; }
    }
}
