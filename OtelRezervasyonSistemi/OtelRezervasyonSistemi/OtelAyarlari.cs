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
    public partial class OtelAyarlari : Form
    {
        private AnaSayfa anaSayfa;
        private dbBaglanti db = new dbBaglanti();
        public OtelAyarlari(AnaSayfa form)
        {
            InitializeComponent();
            anaSayfa = form;
        }


        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
               
               
                string telefon = txtTelefon.Text.Trim();
                string adres = txtAdres.Text.Trim();

               
                if (string.IsNullOrWhiteSpace(telefon) || string.IsNullOrWhiteSpace(adres))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (MySqlConnection conn = db.baglantiGetir())
                {
                 
                    string query = @"
                        UPDATE TblOtelAyarlari 
                        SET telefon = @Telefon, 
                            adres = @Adres";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Telefon", telefon);
                    cmd.Parameters.AddWithValue("@Adres", adres);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Otel bilgileri başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                       
                        anaSayfa.GuncelleHakkimizda();
                    }
                    else
                    {
                        MessageBox.Show("Otel bilgileri güncellenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            this.Hide();
            anaSayfa.Show();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string yeniAd = txtYeniKullaniciAdi.Text.Trim();
            string yeniSifre = txtYeniSifre.Text.Trim();

            if (string.IsNullOrWhiteSpace(yeniAd) || string.IsNullOrWhiteSpace(yeniSifre))
            {
                MessageBox.Show("Yeni kullanıcı adı ve şifre alanlarını doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    string query = "UPDATE TblYonetici SET kullanici_adi = @KullaniciAdi, sifre = @Sifre WHERE yonetici_id = 1";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@KullaniciAdi", yeniAd);
                    cmd.Parameters.AddWithValue("@Sifre", yeniSifre);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Kullanıcı bilgileri başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtYeniKullaniciAdi.Clear();
                        txtYeniSifre.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı bilgileri güncellenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
