using BorrowIt.Dtos.RiwayatPinjams;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NuGet.Packaging.Signing;
using BorrowIt.Models;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

namespace BorrowIt.Mappers.RiwayatPinjams;

public static class RiwayatPinjamsMappers
{
    public static RiwayatReadDto ResponseRiwayatReadDto(this RiwayatPinjam riwayatPinjam)
    {
        return new RiwayatReadDto
        {
            Id = riwayatPinjam.Id,
            IdRuangan = riwayatPinjam.IdRuangan,
            NamaPeminjam = riwayatPinjam.NamaPeminjam,
            Email = riwayatPinjam.Email,
            TanggalPinjam = riwayatPinjam.TanggalPinjam.ToString("yyyy-MM-dd, HH:mm:ss"),
            TanggalKembali = riwayatPinjam.TanggalKembali.ToString("yyyy-MM-dd, HH:mm:ss"),
            TujuanPinjam = riwayatPinjam.TujuanPinjam,
            Status = riwayatPinjam.Status,
            WhenStatusChanged = riwayatPinjam.WhenStatusChanged?.ToString("dd-MM-yyyy, HH:mm") ?? "-"
        };
    }

    public static RiwayatCreateTokenDto ResponseTokenDto(this RiwayatPinjam riwayatPinjam)
    {
        return new RiwayatCreateTokenDto
        {
            Id = riwayatPinjam.Id,
            IdRuangan = riwayatPinjam.IdRuangan,
            NamaPeminjam = riwayatPinjam.NamaPeminjam,
            Email = riwayatPinjam.Email,
            TanggalPinjam = riwayatPinjam.TanggalPinjam.ToString("yyyy-MM-dd, HH:mm:ss"),
            TanggalKembali = riwayatPinjam.TanggalKembali.ToString("yyyy-MM-dd, HH:mm:ss"),
            TujuanPinjam = riwayatPinjam.TujuanPinjam,
            Status = riwayatPinjam.Status,
            WhenStatusChanged = riwayatPinjam.WhenStatusChanged?.ToString("dd-MM-yyyy, HH:mm") ?? "-",
            TrackingToken = riwayatPinjam.TrackingToken
        };
    }

    public static RiwayatPinjam RequestRiwayatCreateDto(this RiwayatCreateDto dto)
    {
        return new RiwayatPinjam
        {
            IdRuangan = dto.IdRuangan,
            NamaPeminjam = dto.NamaPeminjam,
            Email = dto.Email,
            TanggalPinjam = dto.TanggalPinjam,
            TanggalKembali = dto.TanggalKembali,
            TujuanPinjam = dto.TujuanPinjam
        };
    }

    public static void RequestRiwayatUpdateDto(this RiwayatPinjam riwayatPinjam, RiwayatUpdateDto dto)
    {
        riwayatPinjam.NamaPeminjam = !string.IsNullOrWhiteSpace(dto.NamaPeminjam) ? dto.NamaPeminjam : riwayatPinjam.NamaPeminjam;
        riwayatPinjam.Email = !string.IsNullOrWhiteSpace(dto.Email) ? dto.Email : riwayatPinjam.Email;
        riwayatPinjam.TanggalPinjam = dto.TanggalPinjam ?? riwayatPinjam.TanggalPinjam;
        riwayatPinjam.TanggalKembali = dto.TanggalKembali ?? riwayatPinjam.TanggalKembali;
        riwayatPinjam.TujuanPinjam = !string.IsNullOrWhiteSpace(dto.TujuanPinjam) ? dto.TujuanPinjam : riwayatPinjam.TujuanPinjam;
    }

    public static void MapStatusUpdate(this RiwayatPinjam riwayatPinjam, RiwayatStatusDto dto)
    {
        riwayatPinjam.Status = !string.IsNullOrWhiteSpace(dto.Status) ? dto.Status : riwayatPinjam.Status;
    }
}