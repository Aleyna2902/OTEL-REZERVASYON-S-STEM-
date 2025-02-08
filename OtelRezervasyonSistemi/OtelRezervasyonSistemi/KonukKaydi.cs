using MySql.Data.MySqlClient;
using OtelRezervasyonSistemi.DAL;
using OtelRezervasyonSistemi.SERVICE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelRezervasyonSistemi
{
    public partial class KonukKaydi : Form
    {
        private dbBaglanti db = new dbBaglanti();
        KonukService konukService = new KonukService();
        public KonukKaydi()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string adi = txtAd.Text.Trim();
                string soyadi = txtSoyad.Text.Trim();
                string tcKimlikNo = txtTcNo.Text.Trim();
                string cinsiyet = cmbBxCinsiyet.SelectedItem?.ToString();
                string telefon = mskTxtTelefon.Text.Trim();
                string mail = txtMail.Text.Trim();

                if (string.IsNullOrWhiteSpace(adi) || string.IsNullOrWhiteSpace(soyadi) || string.IsNullOrWhiteSpace(tcKimlikNo) ||
                    string.IsNullOrWhiteSpace(cinsiyet) || string.IsNullOrWhiteSpace(telefon) || string.IsNullOrWhiteSpace(mail))
                {
                    MessageBox.Show("Lütfen tüm alanları doğru şekilde doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (MySqlConnection conn = new MySqlConnection("Server = 172.21.54.253; Database = 25_132330001; Uid = 25_132330001; Pwd = !nif.ogr01ER"))
                {
                    conn.Open();

                    string query = "INSERT INTO TblKonuk (adi, soyadi, tc_kimlik_no, cinsiyet, telefon, mail) " +
                                   "VALUES (@Adi, @Soyadi, @TcKimlikNo, @Cinsiyet, @Telefon, @Mail)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Adi", adi);
                    cmd.Parameters.AddWithValue("@Soyadi", soyadi);
                    cmd.Parameters.AddWithValue("@TcKimlikNo", tcKimlikNo);
                    cmd.Parameters.AddWithValue("@Cinsiyet", cinsiyet);
                    cmd.Parameters.AddWithValue("@Telefon", telefon);
                    cmd.Parameters.AddWithValue("@Mail", mail);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Konuk başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtAd.Clear();
                txtSoyad.Clear();
                txtTcNo.Clear();
                cmbBxCinsiyet.SelectedIndex = -1;
                mskTxtTelefon.Clear();
                txtMail.Clear();

                TabloyuGuncelle();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KonukKaydi_Load(object sender, EventArgs e)
        {
            TabloyuGuncelle();
            VerileriGetir();
        }

        private void TabloyuGuncelle()
        {
            try
            {
                dataGridView1.DataSource = konukService.GetDataTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show();
            this.Hide();
        }

        private void cmsSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int konukId = Convert.ToInt32(selectedRow.Cells["konuk_id"].Value);

                DialogResult dialogResult = MessageBox.Show(
                    "Seçili konuğu silmek istediğinizden emin misiniz?",
                    "Onay",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (dialogResult == DialogResult.Yes)
                {
                    SilKonuk(konukId);
                    VerileriGetir();
                }
            }
            else
            {
                MessageBox.Show("Silmek için bir satır seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void SilKonuk(int konukId)
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                   
                    string query = "DELETE FROM TblKonuk WHERE konuk_id = @KonukId";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@KonukId", konukId);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Konuk başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void VerileriGetir()
        {
            try
            {
                using (MySqlConnection conn = db.baglantiGetir())
                {
                    string query = "SELECT * FROM TblKonuk";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
               
                var hitTestInfo = dataGridView1.HitTest(e.X, e.Y);
                if (hitTestInfo.RowIndex >= 0 && hitTestInfo.ColumnIndex >= 0)
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[hitTestInfo.RowIndex].Selected = true;

                    
                    cmsKonukSil.Show(dataGridView1, new Point(e.X, e.Y));
                }
            }
        }
    }
}
