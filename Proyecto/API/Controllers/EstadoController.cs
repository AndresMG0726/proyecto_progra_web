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
    public class EstadoController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;
        public EstadoController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Estado>>> GetEstado()
        {
            // return null;
            //return new BE.BS.Estado(_context).GetAll().ToList();
            var res = new BE.Estado(_context).GetAll();
            List<models.Estado> mapaAux = _mapper.Map<IEnumerable<data.Estado>, IEnumerable<models.Estado>>(res).ToList();
            return mapaAux;
        }

        // GET: api/Estado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Estado>> GetEstado(int id)
        {
            var estado = new BE.Estado(_context).GetOneById(id);

            if (estado == null)
            {
                return NotFound();
            }

            models.Estado mapaAux = _mapper.Map<data.Estado, models.Estado>(estado);

            return mapaAux;
        }

        // PUT: api/Estado/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstado(int id, models.Estado estado)
        {
            if (id != estado.IdEstado)
            {
                return BadRequest();
            }

            try
            {
                data.Estado mapaAux = _mapper.Map<models.Estado, data.Estado>(estado);
                new BE.Estado(_context).Update(mapaAux);
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


        // POST: api/Estado
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Estado>> PostEstado(models.Estado estado)
        {
            try
            {
                data.Estado mapaAux = _mapper.Map<models.Estado, data.Estado>(estado);
                new BE.Estado(_context).Inset(mapaAux);
            }
            catch (Exception)
            {
                BadRequest();
            }
            return CreatedAtAction("GetEstado", new { id = estado.IdEstado }, estado);
        }


        // DELETE: api/Estado/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Estado>> DeleteEstado(int id)
        {
            var estado = new BE.Estado(_context).GetOneById(id);
            if (estado == null)
            {
                return NotFound();
            }

            try
            {
                new BE.Estado(_context).Delete(estado);
            }
            catch (Exception)
            {
                BadRequest();
            }
            models.Estado mapaAux = _mapper.Map<data.Estado, models.Estado>(estado);

            return mapaAux;
        }

        private bool Exist(int id)
        {

            return (new BE.Estado(_context).GetOneById(id) != null);
        }
    }
}
