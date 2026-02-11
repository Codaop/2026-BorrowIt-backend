namespace BorrowIt.Dtos.Ruangans
{
    public class RuanganCreateDto
    {
        public required string NamaRuangan { get; set; }
        public required int Kapasitas { get; set; }
        public required string? JenisRuangan { get; set; }
    }
}