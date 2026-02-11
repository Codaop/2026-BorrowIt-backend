using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BorrowIt.Models;

public class RiwayatPinjam
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Ruangan")]
    public int IdRuangan { get; set; }
    public virtual Ruangan? Ruangan { get; set; } // Untuk akses data ruangan terkait dan menambahkan lazy loading
    public string TrackingToken { get; set; } = string.Empty;

    [Required]
    public required string NamaPeminjam { get; set; } // Nama lengkap peminjam (penting)

    [Required]
    [EmailAddress]
    [StringLength(100)]
    public required string Email { get; set; } // Email peminjam (penting)
    public DateTime TanggalPinjam { get; set; }
    public DateTime TanggalKembali { get; set; }
    
    [Required]
    public required string TujuanPinjam { get; set; }
    public string? Status { get; set; } = "Pending"; // pending, approved, rejected
    public bool IsDeleted { get; set; } = false; // true = dihapus, false = tidak dihapus
}