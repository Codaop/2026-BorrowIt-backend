using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BorrowIt.Data;
using BorrowIt.Models;
using BorrowIt.Dtos.Ruangans;
using BorrowIt.Mappers.Ruangans;

namespace BorrowIt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RuangansController : ControllerBase
    {
        private readonly BorrowItContext _context;

        public RuangansController(BorrowItContext context)
        {
            _context = context;
        }

        // GET: api/Ruangans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RuanganReadDto>>> GetRuangans()
        {
            var ruangans = await _context.Ruangans.ToListAsync();
            return Ok(ruangans.Select(s => s.ResponseRuanganReadDto()));
        }

        // GET: api/Ruangans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RuanganReadDto>> GetRuangan(int id)
        {
            var ruangan = await _context.Ruangans.FindAsync(id);

            if (ruangan == null)
            {
                return NotFound();
            }

            return Ok(ruangan.ResponseRuanganReadDto());
        }

        // PUT: api/Ruangans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRuangan(int id, RuanganUpdateDto dto)
        {
            var existingRuangan = await _context.Ruangans.FindAsync(id);

            if (existingRuangan == null)
            {
                return BadRequest();
            }

            // Current value for NamaRuangan if not changed
            if (!string.IsNullOrWhiteSpace(dto.NamaRuangan))
            {
                existingRuangan.NamaRuangan = dto.NamaRuangan;
            }

            // Current value for Kapasitas if not changed
            if (dto.Kapasitas.HasValue)
            {
                existingRuangan.Kapasitas = dto.Kapasitas.Value;
            }

            // Current value for JenisRuangan if not changed
            if (!string.IsNullOrWhiteSpace(dto.JenisRuangan))
            {
                existingRuangan.JenisRuangan = dto.JenisRuangan;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RuanganExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(existingRuangan.ResponseRuanganReadDto());
        }

        // POST: api/Ruangans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RuanganCreateDto>> PostRuangan(RuanganCreateDto dto)
        {
            bool isDuplicateNama = await _context.Ruangans.AnyAsync(r => r.NamaRuangan == dto.NamaRuangan);

            if (isDuplicateNama)
            {
                return BadRequest("Nama ruangan sudah terdaftar.");
            }

            var ruangan = dto.RequestRuanganCreateDto();
            _context.Ruangans.Add(ruangan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRuangan", new { id = ruangan.Id }, ruangan.ResponseRuanganReadDto());
        }

        // DELETE: api/Ruangans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRuangan(int id)
        {
            var ruangan = await _context.Ruangans.FindAsync(id);
            if (ruangan == null)
            {
                return NotFound();
            }

            _context.Ruangans.Remove(ruangan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RuanganExists(int id)
        {
            return _context.Ruangans.Any(e => e.Id == id);
        }
    }
}
