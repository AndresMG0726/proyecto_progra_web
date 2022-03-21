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
    public class InfoContactoUsuarioController : Controller
    {

            private readonly NDbContext _context;
            private readonly IMapper _mapper;

            public InfoContactoUsuarioController(NDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            // GET: api/InfoContactoUsuario
            [HttpGet]
            public async Task<ActionResult<IEnumerable<models.InfoContactoUsuario>>> GetInfoContactoUsuario()
            {
                var res = new BE.InfoContactoUsuario(_context).GetAll();
                List<models.InfoContactoUsuario> mapaAux = _mapper.Map<IEnumerable<data.InfoContactoUsuario>, IEnumerable<models.InfoContactoUsuario>>(res).ToList();
                return mapaAux;
            }

            // GET: api/InfoContactoUsuario/5
            [HttpGet("{id}")]
            public async Task<ActionResult<models.InfoContactoUsuario>> GetInfoContactoUsuario(int id)
            {
                var infoContactoUsuario = await new BE.InfoContactoUsuario(_context).GetOneByIdAsync(id);

                if (infoContactoUsuario == null)
                {
                    return NotFound();
                }
                models.InfoContactoUsuario mapaAux = _mapper.Map<data.InfoContactoUsuario, models.InfoContactoUsuario>(infoContactoUsuario);
                return mapaAux;
            }


            // PUT: api/InfoContactoUsuario/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPut("{id}")]
            public async Task<IActionResult> PutInfoContactoUsuario(int id, models.InfoContactoUsuario infoContactoUsuario)
            {
                if (id != infoContactoUsuario.IdInfo)
                {
                    return BadRequest();
                }

                try
                {
                    data.InfoContactoUsuario mapaAux = _mapper.Map<models.InfoContactoUsuario, data.InfoContactoUsuario>(infoContactoUsuario);
                    new BE.InfoContactoUsuario(_context).Update(mapaAux);
                }
                catch (Exception ee)
                {
                    if (!Exist(id))
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
            public async Task<ActionResult<models.InfoContactoUsuario>> PostInfoContactoUsuario(models.InfoContactoUsuario infoContactoUsuario)
            {
                try
                {
                    data.InfoContactoUsuario mapaAux = _mapper.Map<models.InfoContactoUsuario, data.InfoContactoUsuario>(infoContactoUsuario);
                    new BE.InfoContactoUsuario(_context).Inset(mapaAux);
                }
                catch (Exception ee)
                {
                    BadRequest();
                }

                return CreatedAtAction("GetProducts", new { id = infoContactoUsuario.IdInfo }, infoContactoUsuario);
            }

            // DELETE: api/InfoContactoUsuario/5
            [HttpDelete("{id}")]
            public async Task<ActionResult<models.InfoContactoUsuario>> DeleteInfoContactoUsuario(int id)
            {
                var infoContactoUsuario = await new BE.InfoContactoUsuario(_context).GetOneByIdAsync(id);
                if (infoContactoUsuario == null)
                {
                    return NotFound();
                }

                try
                {
                    new BE.InfoContactoUsuario(_context).Delete(infoContactoUsuario);
                }
                catch (Exception)
                {
                    BadRequest();
                }
                models.InfoContactoUsuario mapaAux = _mapper.Map<data.InfoContactoUsuario, models.InfoContactoUsuario>(infoContactoUsuario);

                return mapaAux;
            }

            private bool Exist(int id)
            {
                return (new BE.InfoContactoUsuario(_context).GetOneById(id) != null);
            }
        
    }
}
