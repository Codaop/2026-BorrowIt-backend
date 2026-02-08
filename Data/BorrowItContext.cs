using Microsoft.EntityFrameworkCore;
using BorrowIt.Models;

namespace BorrowIt.Data;

public class BorrowItContext : DbContext
{
    public BorrowItContext(DbContextOptions<BorrowItContext> options) : base(options)
    {
    }
    DbSet<Ruangan> Ruangans { get; set; } = null!;
    DbSet<RiwayatPinjam> RiwayatPinjams { get; set; } = null!;
    DbSet<User> Users { get; set; } = null!;
}