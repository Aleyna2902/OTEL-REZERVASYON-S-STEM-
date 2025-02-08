using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRezervasyonSistemi.DOMAIN
{
    public class Oda
    {
        public int OdaId { get; set; }             
        public int OdaNo { get; set; }            
        public string OdaTipi { get; set; }       
        public decimal Fiyat { get; set; }        
        public int DurumId { get; set; }           
    }
}
