using Aplikasi_Presensi_Sistem_Informasi.Config;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Aplikasi_Presensi_Sistem_Informasi
{
    public partial class FormSubmit : Form
    {
        public FormSubmit()
        {
            InitializeComponent();
        }

        private void FormSubmit_Load(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }

        private void PopulateDataGridView()
        {
            DatabaseConnection dbConnection = new DatabaseConnection();
            var presensiData = dbConnection.GetPresensi();
            dataGridView1.DataSource = presensiData;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Event handler untuk aksi klik pada sel DataGridView
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string nim = selectedRow.Cells["NIM"].Value.ToString();
                string nama = selectedRow.Cells["Nama"].Value.ToString();
                string mataKuliah = selectedRow.Cells["MataKuliah"].Value.ToString();
                string angkatan = selectedRow.Cells["Angkatan"].Value.ToString();
                DateTime tanggal = Convert.ToDateTime(selectedRow.Cells["Tanggal"].Value);
                TimeSpan waktu = TimeSpan.Parse(selectedRow.Cells["Waktu"].Value.ToString());

                // Load data to the form controls
                textBox1.Text = nim;
                textBox2.Text = nama;
                textBox3.Text = mataKuliah;
                comboBox1.SelectedItem = angkatan;
                dateTimePicker1.Value = tanggal;
                timePicker.Value = new DateTime(waktu.Ticks); // Assuming you have a TimePicker control
            }
            else
            {
                MessageBox.Show("Pilih baris data yang ingin diupdate.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string nim = selectedRow.Cells["NIM"].Value.ToString();

                DatabaseConnection dbConnection = new DatabaseConnection();
                dbConnection.DeletePresensi(nim);

                // Refresh DataGridView after delete
                PopulateDataGridView();
            }
            else
            {
                MessageBox.Show("Pilih baris data yang ingin dihapus.");
            }
        }
    }
}
