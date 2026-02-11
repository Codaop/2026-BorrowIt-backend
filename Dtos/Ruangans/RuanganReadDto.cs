namespace BorrowIt.Dtos.Ruangans;

public class RuanganReadDto
{
    public int Id { get; set; }
    public required string NamaRuangan { get; set; }
    public int Kapasitas { get; set; }
    public string? JenisRuangan { get; set; }
    public bool IsTersedia { get; set; } = true;
}