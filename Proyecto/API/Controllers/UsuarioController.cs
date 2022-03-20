using AutoMapper;
using DAL.DO.Objects;
using DAL.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
using models = API.DataModels;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
            private readonly NDbContext _context;
            private readonly IMapper _mapper;

            public UsuarioController(NDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            // GET: api/Usuario
            [HttpGet]
            public async Task<ActionResult<IEnumerable<models.Usuario>>> GetUsuario()
            {
                var res = new BE.Usuario(_context).GetAll();
                List<models.Usuario> mapaAux = _mapper.Map<IEnumerable<data.Usuario>, IEnumerable<models.Usuario>>(res).ToList();
                return mapaAux;
            }

            // GET: api/Usuario/5
            [HttpGet("{id}")]
            public async Task<ActionResult<models.Usuario>> GetUsuario(int id)
            {
                var usuario = await new BE.Usuario(_context).GetOneByIdAsync(id);

                if (usuario == null)
                {
                    return NotFound();
                }
                models.Usuario mapaAux = _mapper.Map<data.Usuario, models.Usuario>(usuario);
                return mapaAux;
            }


            // PUT: api/Usuario/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPut("{id}")]
            public async Task<IActionResult> PutUsuario(int id, models.Usuario usuario)
            {
                if (id != usuario.IdUsuario)
                {
                    return BadRequest();
                }

                try
                {
                    data.Usuario mapaAux = _mapper.Map<models.Usuario, data.Usuario>(usuario);
                    new BE.Usuario(_context).Update(mapaAux);
                }
                catch (Exception ee)
                {
                    if (!ProductsExists(id))
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

            // POST: api/Usuario
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPost]
            public async Task<ActionResult<models.Usuario>> PostUsuario(models.Usuario usuario)
            {
                try
                {
                    data.Usuario mapaAux = _mapper.Map<models.Usuario, data.Usuario>(usuario);
                    new BE.Usuario(_context).Inset(mapaAux);
                }
                catch (Exception ee)
                {
                    BadRequest();
                }

                return CreatedAtAction("GetUsuario", new { id = usuario.IdUsuario }, usuario);
            }

            // DELETE: api/Usuario/5
            [HttpDelete("{id}")]
            public async Task<ActionResult<models.Usuario>> DeleteUsuario(int id)
            {
                var usuario = await new BE.Usuario(_context).GetOneByIdAsync(id);
                if (usuario == null)
                {
                    return NotFound();
                }

                try
                {
                    new BE.Usuario(_context).Delete(usuario);
                }
                catch (Exception)
                {
                    BadRequest();
                }
                models.Usuario mapaAux = _mapper.Map<data.Usuario, models.Usuario>(usuario);

                return mapaAux;
            }

            private bool ProductsExists(int id)
            {
                return (new BE.Usuario(_context).GetOneById(id) != null);
            }
     }
   
}
