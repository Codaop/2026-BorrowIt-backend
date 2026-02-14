namespace BorrowIt.Dtos.Ruangans;

public class RuanganUpdateDto
{
    public string? NamaRuangan { get; set; }
    public int? Kapasitas { get; set; }
    public string? JenisRuangan { get; set; }
    public bool? IsTersedia { get; set; }
}