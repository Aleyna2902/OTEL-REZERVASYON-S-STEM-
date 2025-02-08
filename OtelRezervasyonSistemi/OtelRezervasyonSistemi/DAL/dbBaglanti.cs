using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRezervasyonSistemi.DAL
{
    public class dbBaglanti
    {
        private string connectionString = "Server= 172.21.54.253; Database= 25_132330001; Uid= 25_132330001 ; Pwd=!nif.ogr01ER";
      
        
        public MySqlConnection baglantiGetir()
        {
            MySqlConnection baglanti = new MySqlConnection(connectionString);
            if (baglanti.State == System.Data.ConnectionState.Closed)
            {
                baglanti.Open();
            }
            return baglanti;
        }

        public void BaglantiKapat(MySqlConnection baglanti)
        {
            if (baglanti.State == System.Data.ConnectionState.Open)
            {
                baglanti.Close();
            }
        }
    }
}
