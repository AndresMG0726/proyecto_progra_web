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
    public class RolContactoController : ControllerBase
    {
        private readonly PRUEBA1Context _context;

        public RolContactoController(PRUEBA1Context context)
        {
            _context = context;
        }

        // GET: api/RolContactoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolContacto>>> GetRolContacto()
        {
            return await _context.RolContacto.ToListAsync();
        }

        // GET: api/RolContactoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RolContacto>> GetRolContacto(int id)
        {
            var rolContacto = await _context.RolContacto.FindAsync(id);

            if (rolContacto == null)
            {
                return NotFound();
            }

            return rolContacto;
        }

        // PUT: api/RolContactoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRolContacto(int id, RolContacto rolContacto)
        {
            if (id != rolContacto.IdRolCont)
            {
                return BadRequest();
            }

            _context.Entry(rolContacto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolContactoExists(id))
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

        // POST: api/RolContactoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RolContacto>> PostRolContacto(RolContacto rolContacto)
        {
            _context.RolContacto.Add(rolContacto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRolContacto", new { id = rolContacto.IdRolCont }, rolContacto);
        }

        // DELETE: api/RolContactoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RolContacto>> DeleteRolContacto(int id)
        {
            var rolContacto = await _context.RolContacto.FindAsync(id);
            if (rolContacto == null)
            {
                return NotFound();
            }

            _context.RolContacto.Remove(rolContacto);
            await _context.SaveChangesAsync();

            return rolContacto;
        }

        private bool RolContactoExists(int id)
        {
            return _context.RolContacto.Any(e => e.IdRolCont == id);
        }
    }
}
