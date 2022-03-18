using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIW.Models;

namespace APIW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorasExtraController : ControllerBase
    {
        private readonly PRUEBA1Context _context;

        public HorasExtraController(PRUEBA1Context context)
        {
            _context = context;
        }

        // GET: api/HorasExtra
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HorasExtra>>> GetHorasExtra()
        {
            return await _context.HorasExtra.ToListAsync();
        }

        // GET: api/HorasExtra/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HorasExtra>> GetHorasExtra(int id)
        {
            var horasExtra = await _context.HorasExtra.FindAsync(id);

            if (horasExtra == null)
            {
                return NotFound();
            }

            return horasExtra;
        }

        // PUT: api/HorasExtra/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHorasExtra(int id, HorasExtra horasExtra)
        {
            if (id != horasExtra.IdHE)
            {
                return BadRequest();
            }

            _context.Entry(horasExtra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorasExtraExists(id))
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

        // POST: api/HorasExtra
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HorasExtra>> PostHorasExtra(HorasExtra horasExtra)
        {
            _context.HorasExtra.Add(horasExtra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHorasExtra", new { id = horasExtra.IdHE }, horasExtra);
        }

        // DELETE: api/HorasExtra/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HorasExtra>> DeleteHorasExtra(int id)
        {
            var horasExtra = await _context.HorasExtra.FindAsync(id);
            if (horasExtra == null)
            {
                return NotFound();
            }

            _context.HorasExtra.Remove(horasExtra);
            await _context.SaveChangesAsync();

            return horasExtra;
        }

        private bool HorasExtraExists(int id)
        {
            return _context.HorasExtra.Any(e => e.IdHE == id);
        }
    }
}
