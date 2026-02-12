using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BorrowIt.Data;
using BorrowIt.Models;
using BorrowIt.Dtos.RiwayatPinjams;
using BorrowIt.Mappers.RiwayatPinjams;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.CompilerServices;

namespace Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiwayatPinjamsController : ControllerBase
    {
        private readonly BorrowItContext _context;

        public RiwayatPinjamsController(BorrowItContext context)
        {
            _context = context;
        }

        // GET: api/RiwayatPinjams
        // Fitur searching juga diterapkan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RiwayatReadDto>>> GetRiwayatPinjams([FromQuery] string? search, [FromQuery] string? status, [FromQuery] string? namaRuangan, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var query = _context.RiwayatPinjams.Where(r => r.IsDeleted == false).Include(r => r.Ruangan).AsQueryable();

            // Searching berdasarkan nama peminjam dan tujuan pinjam
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(r => r.NamaPeminjam.Contains(search) || r.TujuanPinjam.Contains(search));
            }

            // Searching berdasarkan status
            if (!string.IsNullOrWhiteSpace(status))
            {
                query = query.Where(r => r.Status == status);
            }

            // Searching berdasarkan idRuangan
            if (!string.IsNullOrWhiteSpace(namaRuangan))
            {
                query = query.Where(r => r.Ruangan != null && r.Ruangan.NamaRuangan.Contains(namaRuangan));
            }

            // Untuk pagination agar list tidak terlalu panjang
            var skipNumber = (page - 1) * pageSize;
            var riwayat = await query.Skip(skipNumber).Take(pageSize).ToListAsync();
            return Ok(riwayat.Select(r => r.ResponseRiwayatReadDto()));
        }

        // GET: api/RiwayatPinjams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RiwayatReadDto>> GetRiwayatPinjam(int id)
        {
            var riwayatPinjam = await _context.RiwayatPinjams.FindAsync(id);

            if (riwayatPinjam == null)
            {
                return NotFound();
            }

            return Ok(riwayatPinjam.ResponseRiwayatReadDto());
        }

        // PUT: api/RiwayatPinjams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRiwayatPinjam(int id, RiwayatUpdateDto dto)
        {
            var existingRiwayat = await _context.RiwayatPinjams.FindAsync(id);

            if (existingRiwayat == null)
            {
                return BadRequest("Riwayat tidak ditemukan.");
            }

            existingRiwayat.RequestRiwayatUpdateDto(dto);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RiwayatPinjamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // PUT: api/RiwayatPinjams/5/status-update
        // For status update logic, admin only
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/status-update")]
        public async Task<IActionResult> PutStatusRiwayatPinjam(int id, RiwayatStatusDto dto)
        {
            var existingRiwayat = await _context.RiwayatPinjams.FindAsync(id);

            if (existingRiwayat == null)
            {
                return BadRequest("Riwayat tidak ditemukan.");
            }

            existingRiwayat.MapStatusUpdate(dto);
            existingRiwayat.WhenStatusChanged = DateTime.UtcNow.AddHours(7);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RiwayatPinjamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RiwayatPinjams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RiwayatCreateDto>> PostRiwayatPinjam(RiwayatCreateDto dto)
        {
            var isRoomBooked = await _context.RiwayatPinjams.AnyAsync(r => r.IdRuangan == dto.IdRuangan && r.Status == "Approved" && dto.TanggalPinjam < r.TanggalKembali && dto.TanggalKembali > r.TanggalPinjam && r.IsDeleted == false);

            if (isRoomBooked) // isRoomBooked harus false agar bisa menambahkan peminjaman
            {
                return BadRequest("Sudah ada peminjam pada tanggal dan jam tersebut.");
            }

            var riwayat = dto.RequestRiwayatCreateDto();
            riwayat.TrackingToken = Guid.NewGuid().ToString();

            _context.RiwayatPinjams.Add(riwayat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRiwayatPinjam", new { id = riwayat.Id }, riwayat.ResponseRiwayatReadDto());
        }

        // DELETE: api/RiwayatPinjams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRiwayatPinjam(int id)
        {
            var riwayatPinjam = await _context.RiwayatPinjams.FindAsync(id);
            if (riwayatPinjam == null)
            {
                return NotFound();
            }

            riwayatPinjam.IsDeleted = true;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool RiwayatPinjamExists(int id)
        {
            return _context.RiwayatPinjams.Any(e => e.Id == id);
        }
    }
}
