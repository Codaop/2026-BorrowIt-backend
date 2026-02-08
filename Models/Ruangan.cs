using System.ComponentModel.DataAnnotations;

namespace BorrowIt.Models;

public class Ruangan
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public required string NamaRuangan { get; set; }
    public int Kapasitas { get; set; }
    public string? JenisRuangan { get; set; }
    public bool IsTersedia { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}