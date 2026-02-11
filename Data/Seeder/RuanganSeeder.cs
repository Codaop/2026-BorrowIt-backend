using BorrowIt.Models;
using Microsoft.EntityFrameworkCore;

public static class RuanganSeeder
{
    public static void SeedRuangan(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ruangan>().HasData(
            new Ruangan
            {
              Id = 1,
              NamaRuangan = "B302",
              Kapasitas = 30,
              JenisRuangan = "Laboratorium Praktek"
            },
            new Ruangan
            {
              Id = 2,
              NamaRuangan = "SAW 10.08",
              Kapasitas = 140,
              JenisRuangan = "Kelas Besar"
            },
            new Ruangan
            {
              Id = 3,
              NamaRuangan = "A302",
              Kapasitas = 40,
              JenisRuangan = "Kelas Reguler"
            },
            new Ruangan
            {
              Id = 4,
              NamaRuangan = "A303",
              Kapasitas = 60,
              JenisRuangan = "Kelas Reguler"
            }
        );
    }
}