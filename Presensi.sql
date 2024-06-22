create database PresensimhsDB; 
use PresensimhsDB;
CREATE TABLE Presensi (
    NIM VARCHAR(20) NOT NULL,
    Nama VARCHAR(100) NOT NULL,
    MataKuliah VARCHAR(100) NOT NULL,
    Tanggal DATE NOT NULL,
    Waktu TIME NOT NULL,
    PRIMARY KEY (NIM, MataKuliah, Tanggal, Waktu)
);
show tables;
DESCRIBE Presensi;
-- Menambahkan data ke tabel Presensi
INSERT INTO Presensi (NIM, Nama, MataKuliah, Tanggal, Waktu) VALUES ('F1E122065', 'Evlyn Shinta MS', 'Pemograman Visual', '2024-06-14', '13:00:00');
INSERT INTO Presensi (NIM, Nama, MataKuliah, Tanggal, Waktu) VALUES ('F1E122186', 'Okta Sparingga', 'Pemograman Visual', '2024-06-14', '13:00:00');
