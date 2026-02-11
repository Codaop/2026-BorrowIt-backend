using Microsoft.EntityFrameworkCore;
using BorrowIt.Models;

namespace BorrowIt.Data;

public class BorrowItContext : DbContext
{
    public BorrowItContext(DbContextOptions<BorrowItContext> options) : base(options)
    {
    }
    public DbSet<Ruangan> Ruangans { get; set; } = null!;
    public DbSet<RiwayatPinjam> RiwayatPinjams { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<RiwayatPinjam>().HasQueryFilter(r => !r.IsDeleted);
        modelBuilder.SeedRuangan();
        modelBuilder.SeedUser();
        modelBuilder.SeedRiwayat();
    }
}