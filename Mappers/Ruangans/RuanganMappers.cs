using BorrowIt.Dtos.Ruangans;
using BorrowIt.Models;
using Microsoft.Identity.Client;

namespace BorrowIt.Mappers.Ruangans;

public static class RuanganMappers
{
    public static RuanganReadDto ResponseRuanganReadDto(this Ruangan ruangan)
    {
        return new RuanganReadDto
        {
            Id = ruangan.Id,
            NamaRuangan = ruangan.NamaRuangan,
            Kapasitas = ruangan.Kapasitas,
            JenisRuangan = ruangan.JenisRuangan,
            IsTersedia = ruangan.IsTersedia
        };
    }

    public static Ruangan RequestRuanganCreateDto(this RuanganCreateDto dto)
    {
        return new Ruangan
        {
            NamaRuangan = dto.NamaRuangan,
            Kapasitas = dto.Kapasitas,
            JenisRuangan = dto.JenisRuangan
        };
    }
}