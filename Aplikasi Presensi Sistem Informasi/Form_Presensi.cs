using System;
using System.Data;
using System.Windows.Forms;
using Aplikasi_Presensi_Sistem_Informasi.Config;

namespace Aplikasi_Presensi_Sistem_Informasi
{
    public partial class Form_Presensi : Form
    {
        private DatabaseConnection dbConnection;

        public Form_Presensi()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
            InitializeComboBoxAngkatan();
        }

        private void InitializeComboBoxAngkatan()
        {
            comboBox1.Items.AddRange(new string[] { "2023", "2022", "2021", "2020", "2019", "2018", "2017" });
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nim = textBox1.Text;
            string nama = textBox2.Text;
            string mataKuliah = textBox3.Text;
            string angkatan = comboBox1.SelectedItem.ToString();
            DateTime tanggal = DateTime.Now.Date;
            TimeSpan waktu = DateTime.Now.TimeOfDay;

            dbConnection.InsertPresensi(nim, nama, mataKuliah, angkatan, tanggal, waktu);
            RefreshPresensiData();
            ClearForm();

            FormSubmit formSubmit = new FormSubmit();
            formSubmit.Show();
        }

        private void RefreshPresensiData()
        {
            DataTable presensi = dbConnection.GetPresensi();

            foreach (DataRow row in presensi.Rows)
            {
                Console.WriteLine($"{row["NIM"]}, {row["Nama"]}, {row["MataKuliah"]}, {row["Angkatan"]}, {row["Tanggal"]}, {row["Waktu"]}");
            }
        }

        private void ClearForm()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Kosongkan karena tidak ada aksi yang perlu dilakukan pada label ini
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Logika tambahan jika ada perubahan yang ingin dilakukan
        }
    }
}

