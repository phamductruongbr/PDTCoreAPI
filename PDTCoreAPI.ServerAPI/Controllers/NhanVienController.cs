using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDTCoreAPI.ServerData;
using PDTCoreAPI.ServerData.Models;

namespace PDTCoreAPI.ServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly NVCoreDbContext _context;

        public NhanVienController(NVCoreDbContext context)
        {
            _context = context;
        }

        // GET: api/NhanVien
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhanVien>>> GetNhanVien()
        {
            return await _context.NhanVien.ToListAsync();
        }

        // GET: api/NhanVien/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhanVien>> GetNhanVien(Guid id)
        {
            var nhanVien = await _context.NhanVien.FindAsync(id);

            if (nhanVien == null)
            {
                return NotFound();
            }

            return nhanVien;
        }

        // PUT: api/NhanVien/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNhanVien(Guid id, NhanVien nhanVien)
        {
            if (id != nhanVien.ID)
            {
                return BadRequest();
            }

            _context.Entry(nhanVien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhanVienExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(NoContent());
        }

        // POST: api/NhanVien
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NhanVien>> PostNhanVien(NhanVien nhanVien)
        {
            _context.NhanVien.Add(nhanVien);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNhanVien", new { id = nhanVien.ID }, nhanVien);
        }

        // DELETE: api/NhanVien/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NhanVien>> DeleteNhanVien(Guid id)
        {
            var nhanVien = await _context.NhanVien.FindAsync(id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            _context.NhanVien.Remove(nhanVien);
            await _context.SaveChangesAsync();

            return nhanVien;
        }

        private bool NhanVienExists(Guid id)
        {
            return _context.NhanVien.Any(e => e.ID == id);
        }
    }
}
