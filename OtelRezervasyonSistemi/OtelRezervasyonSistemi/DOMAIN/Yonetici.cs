using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRezervasyonSistemi.DOMAIN
{
    public class Yonetici
    {
        public int YoneticiId { get; set; }         
        public string KullaniciAdi { get; set; }  
        public string Sifre { get; set; }
    }
}
