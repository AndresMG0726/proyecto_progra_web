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
    public class InfoContactoUsuarioController : ControllerBase
    {
        private readonly PRUEBA1Context _context;

        public InfoContactoUsuarioController(PRUEBA1Context context)
        {
            _context = context;
        }

        // GET: api/InfoContactoUsuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfoContactoUsuario>>> GetInfoContactoUsuario()
        {
            return await _context.InfoContactoUsuario.ToListAsync();
        }

        // GET: api/InfoContactoUsuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InfoContactoUsuario>> GetInfoContactoUsuario(int id)
        {
            var infoContactoUsuario = await _context.InfoContactoUsuario.FindAsync(id);

            if (infoContactoUsuario == null)
            {
                return NotFound();
            }

            return infoContactoUsuario;
        }

        // PUT: api/InfoContactoUsuario/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfoContactoUsuario(int id, InfoContactoUsuario infoContactoUsuario)
        {
            if (id != infoContactoUsuario.IdInfo)
            {
                return BadRequest();
            }

            _context.Entry(infoContactoUsuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfoContactoUsuarioExists(id))
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

        // POST: api/InfoContactoUsuario
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InfoContactoUsuario>> PostInfoContactoUsuario(InfoContactoUsuario infoContactoUsuario)
        {
            _context.InfoContactoUsuario.Add(infoContactoUsuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInfoContactoUsuario", new { id = infoContactoUsuario.IdInfo }, infoContactoUsuario);
        }

        // DELETE: api/InfoContactoUsuario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InfoContactoUsuario>> DeleteInfoContactoUsuario(int id)
        {
            var infoContactoUsuario = await _context.InfoContactoUsuario.FindAsync(id);
            if (infoContactoUsuario == null)
            {
                return NotFound();
            }

            _context.InfoContactoUsuario.Remove(infoContactoUsuario);
            await _context.SaveChangesAsync();

            return infoContactoUsuario;
        }

        private bool InfoContactoUsuarioExists(int id)
        {
            return _context.InfoContactoUsuario.Any(e => e.IdInfo == id);
        }
    }
}
