namespace BorrowIt.Dtos.RiwayatPinjams;

public class RiwayatCreateDto
{
    public required int IdRuangan { get; set; }
    public required string NamaPeminjam { get; set; }
    public required string Email { get; set; }
    public required DateTime TanggalPinjam { get; set; }
    public required DateTime TanggalKembali { get; set; }
    public required string TujuanPinjam { get; set; }
}