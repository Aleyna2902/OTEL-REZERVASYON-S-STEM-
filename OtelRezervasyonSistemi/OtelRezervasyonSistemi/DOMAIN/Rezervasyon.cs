using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRezervasyonSistemi.DOMAIN
{
    public class Rezervasyon
    {

        public int RezervasyonId { get; set; }
        public string KonukId { get; set; }        
        public string OdaId { get; set; }
        public DateTime GirisTarihi { get; set; }  
        public DateTime CikisTarihi { get; set; }  
        public decimal Ucret { get; set; }
    }
}
