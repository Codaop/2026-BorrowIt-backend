namespace BorrowIt.Dtos.RiwayatPinjams;

public class RiwayatReadDto
{
    public int Id { get; set; }
    public int IdRuangan { get; set; }
    public required string NamaPeminjam { get; set; }
    public required string Email { get; set; }
    public required string TanggalPinjam { get; set; }
    public required string TanggalKembali { get; set; }
    public required string TujuanPinjam { get; set; }
    public string? Status { get; set; }
}