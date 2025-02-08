using MySql.Data.MySqlClient;
using OtelRezervasyonSistemi.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelRezervasyonSistemi
{
    public partial class AnaSayfa : Form
    {
        private int currentImageIndex = 0; 
        private string[] imagePaths;
        private dbBaglanti db = new dbBaglanti();
        public AnaSayfa()
        {
            InitializeComponent();
            this.Click += AnaSayfa_Click;
            txtIcerik.Click += (s, e) => { /* İçerik görünmeye devam edecek */ };
            lstDuyurular.Click += (s, e) => { /* Başlığa tıklama */ };
            
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            LoadDuyurular();
            GuncelleHakkimizda();
            timerSaat.Start();
            txtIcerik.Visible = false;
            LoadImages();
            timer1.Start();
            webBrowser1.ScriptErrorsSuppressed = true;
        }


        public void GuncelleHakkimizda()
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    string query = "SELECT telefon, adres FROM TblOtelAyarlari LIMIT 1";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtHakkimizda.Text = "     " +
                              "  HAKKIMIZDA\n" +
                              "    Luna Hotel, konfor, kalite ve müşteri memnuniyetini ön planda tutan bir otel olarak misafirlerine hizmet vermektedir.\n" +
                              "    Her detayda misafirlerimizin ihtiyaçlarını karşılamayı hedefleyen modern odalarımız, profesyonel kadromuz ve\n" +
                              "    sunduğumuz özel hizmetlerle unutulmaz bir konaklama deneyimi sunuyoruz.\n\n" +
                              "    Şehrin merkezinde yer alan Luna Hotel, hem iş seyahatleriniz hem de tatil planlarınız için ideal bir konaklama\n" +
                              "     imkanı sağlar. Ayrıca, otelimizde düzenlenen çeşitli etkinlikler ve sağladığımız hizmetlerle kendinizi\n" +
                              "     evinizde gibi hissedeceksiniz.\n\n" +
                              "         Otel Bilgileri\n" +
                              $"    - Telefon: {reader["telefon"]}\n" +
                              $"    - Adres: {reader["adres"]}\n";




                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void timerSaat_Tick(object sender, EventArgs e)
        {
            lblTarihSaat.Text = DateTime.Now.ToString("dd MMMM yyyy, HH:mm:ss");
        }

        private void LoadDuyurular()
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {

                    string query = "SELECT baslik FROM TblDuyuru ORDER BY tarih DESC LIMIT 10";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    lstDuyurular.Items.Clear();
                    while (reader.Read())
                    {
                        lstDuyurular.Items.Add(reader["baslik"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblDuyurular_Click(object sender, EventArgs e)
        {
            DuyuruForm duyurularForm = new DuyuruForm();
            this.Hide();
            duyurularForm.ShowDialog();
            this.Show();
        }

        private void lstDuyurular_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDuyurular.SelectedItem != null) 
            {
                string secilenBaslik = lstDuyurular.SelectedItem.ToString();

                try
                {
                    using (MySqlConnection conn = db.baglantiGetir())
                    {
                        string query = "SELECT icerik FROM TblDuyuru WHERE baslik = @Baslik";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@Baslik", secilenBaslik);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                               
                                txtIcerik.Text = reader["icerik"].ToString();
                                txtIcerik.Visible = true; 
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Duyuru içeriği yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                
                txtIcerik.Visible = false;
            }
        }
        private void AnaSayfa_Click(object sender, EventArgs e)
        {
           
            Point mousePosition = PointToClient(Cursor.Position);

            if (!txtIcerik.Bounds.Contains(mousePosition) && !lstDuyurular.Bounds.Contains(mousePosition))
            {
                txtIcerik.Visible = false; 
            }
        }

        private void LoadImages()
        {
            string folderPath = Application.StartupPath + "\\Resources1";

           
            if (!System.IO.Directory.Exists(folderPath))
            {
                MessageBox.Show("Resources1 klasörü bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
            imagePaths = System.IO.Directory.GetFiles(folderPath, "*.jpg");

            if (imagePaths.Length > 0)
            {
                currentImageIndex = 0;
                pbSlider.Image = Image.FromFile(imagePaths[currentImageIndex]); 
            }
            else
            {
                MessageBox.Show("Resources1 klasöründe resim bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGetir_Click(object sender, EventArgs e)
        {
            string sehir = txtSehir.Text.Trim();
            if (string.IsNullOrWhiteSpace(sehir))
            {
                MessageBox.Show("Lütfen bir şehir adı giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string url = $"https://www.google.com/search?q={sehir}+hava+durumu&hl=tr";
            webBrowser1.Navigate(url);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (imagePaths == null || imagePaths.Length == 0) return;


            currentImageIndex++;
            if (currentImageIndex >= imagePaths.Length)
            {
                currentImageIndex = 0;
            }

            pbSlider.Image = Image.FromFile(imagePaths[currentImageIndex]);
        }
        public void DuyurulariGetir()
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                   
                    string query = "SELECT baslik FROM TblDuyuru"; 
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    lstDuyurular.Items.Clear();
                    while (reader.Read())
                    {
                        lstDuyurular.Items.Add(reader["baslik"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void DuyurulariGuncelle()
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                   
                    string query = "SELECT baslik FROM TblDuyuru"; 
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    lstDuyurular.Items.Clear();
                    while (reader.Read())
                    {
                        lstDuyurular.Items.Add(reader["baslik"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOdalar_Click(object sender, EventArgs e)
        {
            Odalar odalarForm = new Odalar(); 
            odalarForm.Show(); 
            this.Hide();
        }

        private void btnKonukKaydi_Click(object sender, EventArgs e)
        {
            KonukKaydi konukKayitForm = new KonukKaydi(); 
            konukKayitForm.Show(); 
            this.Hide();
        }

        private void btnRezervasyon_Click(object sender, EventArgs e)
        {
            RezervasyonForm rezervasyonForm = new RezervasyonForm(); 
            rezervasyonForm.Show(); 
            this.Hide();
        }

        private void btnAyarlar_Click_1(object sender, EventArgs e)
        {
            OtelAyarlari otelAyarlari = new OtelAyarlari(this); 
            otelAyarlari.Show(); 
            this.Hide();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            AdminGiris adminGiris = new AdminGiris();
            adminGiris.Show();
            this.Hide();
        }
    }
}
