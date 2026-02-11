namespace BorrowIt.Dtos.RiwayatPinjams;

public class RiwayatUpdateDto
{
    public string? NamaPeminjam { get; set; }
    public string? Email { get; set; }
    public DateTime? TanggalPinjam { get; set; }
    public DateTime? TanggalKembali { get; set; }
    public string? TujuanPinjam { get; set; }
    public string? Status { get; set; }
}