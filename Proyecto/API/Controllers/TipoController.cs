using AutoMapper;
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
    public class TipoController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;
        public TipoController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Tipo>>> GetTipo()
        {
            // return null;
            //return new BE.BS.Tipo(_context).GetAll().ToList();
            var res = new BE.Tipo(_context).GetAll();
            List<models.Tipo> mapaAux = _mapper.Map<IEnumerable<data.Tipo>, IEnumerable<models.Tipo>>(res).ToList();
            return mapaAux;
        }

        // GET: api/Tipo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Tipo>> GetTipo(int id)
        {
            var tipo = new BE.Tipo(_context).GetOneById(id);

            if (tipo == null)
            {
                return NotFound();
            }

            models.Tipo mapaAux = _mapper.Map<data.Tipo, models.Tipo>(tipo);

            return mapaAux;
        }

        // PUT: api/Tipo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipo(int id, models.Tipo tipo)
        {
            if (id != tipo.IdTipo)
            {
                return BadRequest();
            }

            try
            {
                data.Tipo mapaAux = _mapper.Map<models.Tipo, data.Tipo>(tipo);
                new BE.Tipo(_context).Update(mapaAux);
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


        // POST: api/Tipo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Tipo>> PostTipo(models.Tipo tipo)
        {
            try
            {
                data.Tipo mapaAux = _mapper.Map<models.Tipo, data.Tipo>(tipo);
                new BE.Tipo(_context).Inset(mapaAux);
            }
            catch (Exception)
            {
                BadRequest();
            }
            return CreatedAtAction("GetTipo", new { id = tipo.IdTipo }, tipo);
        }


        // DELETE: api/Tipo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Tipo>> DeleteTipo(int id)
        {
            var tipo = new BE.Tipo(_context).GetOneById(id);
            if (tipo == null)
            {
                return NotFound();
            }

            try
            {
                new BE.Tipo(_context).Delete(tipo);
            }
            catch (Exception)
            {
                BadRequest();
            }
            models.Tipo mapaAux = _mapper.Map<data.Tipo, models.Tipo>(tipo);

            return mapaAux;
        }

        private bool Exist(int id)
        {

            return (new BE.Tipo(_context).GetOneById(id) != null);
        }

    }
}
