using MySql.Data.MySqlClient;
using OtelRezervasyonSistemi.DAL;
using OtelRezervasyonSistemi.DOMAIN;
using OtelRezervasyonSistemi.SERVICE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelRezervasyonSistemi
{
    public partial class AdminGiris : Form
    {
        private dbBaglanti db = new dbBaglanti();
        public AdminGiris()
        {
            InitializeComponent();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text.Trim();

            if (string.IsNullOrWhiteSpace(kullaniciAdi) || string.IsNullOrWhiteSpace(sifre))
            {
                MessageBox.Show("Kullanıcı adı ve şifre alanlarını doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    string query = "SELECT * FROM TblYonetici WHERE kullanici_adi = @KullaniciAdi AND sifre = @Sifre";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@Sifre", sifre);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        MessageBox.Show("Giriş başarılı! Ana sayfaya yönlendiriliyorsunuz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        AnaSayfa anaSayfa = new AnaSayfa();
                        anaSayfa.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
