using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRezervasyonSistemi.DOMAIN
{
    public class Konuk
    {
        public int KonukId { get; set; }      
        public string Adi { get; set; }        
        public string Soyadi { get; set; }    
        public string Cinsiyet { get; set; }   
        public string Telefon { get; set; }   
        public string Mail { get; set; }       
        public string TcKimlikNo { get; set; } 



    }
}
