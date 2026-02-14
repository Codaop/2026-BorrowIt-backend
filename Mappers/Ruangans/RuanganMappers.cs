using System.Runtime.CompilerServices;
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

    public static void RequestRuanganUpdateDto(this Ruangan ruangan, RuanganUpdateDto dto)
    {
        ruangan.NamaRuangan = !string.IsNullOrWhiteSpace(dto.NamaRuangan) ? dto.NamaRuangan : ruangan.NamaRuangan;
        ruangan.Kapasitas = dto.Kapasitas ?? ruangan.Kapasitas;
        ruangan.JenisRuangan = !string.IsNullOrWhiteSpace(dto.JenisRuangan) ? dto.JenisRuangan : ruangan.JenisRuangan;
        if (dto.IsTersedia.HasValue) ruangan.IsTersedia = dto.IsTersedia.Value;
    }
}