using BorrowIt.Models;
using Microsoft.EntityFrameworkCore;

public static class RiwayatPinjamSeeder
{
    public static void SeedRiwayat(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RiwayatPinjam>().HasData(
            new RiwayatPinjam
            {
                Id = 1,
                IdRuangan = 2,
                TrackingToken = Guid.NewGuid().ToString(),
                NamaPeminjam = "Syauqy Arrayyan",
                Email = "syauqy@it.student.pens.ac.id",
                TanggalPinjam = new DateTime(2024, 7, 1, 9, 0, 0),
                TanggalKembali = new DateTime(2024, 7, 1, 11, 0, 0),
                TujuanPinjam = "Kegiatan welcome party anggota baru ENT 2026.",
            },
            new RiwayatPinjam
            {
                Id = 2,
                IdRuangan = 3,
                TrackingToken = Guid.NewGuid().ToString(),
                NamaPeminjam = "Nabila Azzahra",
                Email = "nabila@it.student.pens.ac.id",
                TanggalPinjam = new DateTime(2024, 7, 1, 9, 0, 0),
                TanggalKembali = new DateTime(2024, 7, 1, 11, 0, 0),
                TujuanPinjam = "Forum komunal mahasiswa teknik elektro.",
            },
            new RiwayatPinjam
            {
                Id = 3,
                IdRuangan = 4,
                TrackingToken = Guid.NewGuid().ToString(),
                NamaPeminjam = "Yayan Maulana",
                Email = "yayan@it.student.pens.ac.id",
                TanggalPinjam = new DateTime(2024, 7, 1, 9, 0, 0),
                TanggalKembali = new DateTime(2024, 7, 1, 11, 0, 0),
                TujuanPinjam = "Rapat kerja kelompok praktikum Rangkaian Listrik.",
            }
        );
    }
}