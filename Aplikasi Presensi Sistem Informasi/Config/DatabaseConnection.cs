using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Aplikasi_Presensi_Sistem_Informasi.Config
{
    public class DatabaseConnection
    {
        private string connectionString = "Server=localhost;Database=PresensimhsDB;Uid=root;Pwd=;";

        public DataTable GetPresensi()
        {
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Presensi";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            return dt;
        }

        public void InsertPresensi(string nim, string nama, string mataKuliah, string angkatan, DateTime tanggal, TimeSpan waktu)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Presensi (NIM, Nama, MataKuliah, Angkatan, Tanggal, Waktu) VALUES (@nim, @nama, @mataKuliah, @angkatan, @tanggal, @waktu)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@nim", nim);
                    cmd.Parameters.AddWithValue("@nama", nama);
                    cmd.Parameters.AddWithValue("@mataKuliah", mataKuliah);
                    cmd.Parameters.AddWithValue("@angkatan", angkatan);
                    cmd.Parameters.AddWithValue("@tanggal", tanggal.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@waktu", waktu.ToString(@"hh\:mm\:ss"));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data presensi berhasil ditambahkan!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }
        }

        public void UpdatePresensi(string nim, string nama, string mataKuliah, string angkatan, DateTime tanggal, TimeSpan waktu)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Presensi SET Nama = @nama, MataKuliah = @mataKuliah, Angkatan = @angkatan, Tanggal = @tanggal, Waktu = @waktu WHERE NIM = @nim";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@nim", nim);
                    cmd.Parameters.AddWithValue("@nama", nama);
                    cmd.Parameters.AddWithValue("@mataKuliah", mataKuliah);
                    cmd.Parameters.AddWithValue("@angkatan", angkatan);
                    cmd.Parameters.AddWithValue("@tanggal", tanggal.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@waktu", waktu.ToString(@"hh\:mm\:ss"));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data presensi berhasil diupdate!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }
        }

        public void DeletePresensi(string nim)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Presensi WHERE NIM = @nim";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@nim", nim);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Data presensi berhasil dihapus!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }
        }
    }
}
