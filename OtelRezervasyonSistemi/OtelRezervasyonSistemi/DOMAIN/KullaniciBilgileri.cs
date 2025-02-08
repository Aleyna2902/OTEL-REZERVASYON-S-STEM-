using MySql.Data.MySqlClient;
using OtelRezervasyonSistemi.DOMAIN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelRezervasyonSistemi.DOMAIN
{
    public class KullaniciBilgileri
    {
        public int Id { get; set; }
        public string YeniAd { get; set; }
        public string YeniSifre { get; set; }
    }
}
