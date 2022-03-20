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
    public class DepartamentoController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;
        public DepartamentoController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Departamento>>> GetDepartamento()
        {
            // return null;
            //return new BE.BS.Departamento(_context).GetAll().ToList();
            var res = new BE.Departamento(_context).GetAll();
            List<models.Departamento> mapaAux = _mapper.Map<IEnumerable<data.Departamento>, IEnumerable<models.Departamento>>(res).ToList();
            return mapaAux;
        }

        // GET: api/Departamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Departamento>> GetDepartamento(int id)
        {
            var departamento = new BE.Departamento(_context).GetOneById(id);

            if (departamento == null)
            {
                return NotFound();
            }

            models.Departamento mapaAux = _mapper.Map<data.Departamento, models.Departamento>(departamento);

            return mapaAux;
        }

        // PUT: api/Departamento/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartamento(int id, models.Departamento departamento)
        {
            if (id != departamento.IdDepartamento)
            {
                return BadRequest();
            }

            try
            {
                data.Departamento mapaAux = _mapper.Map<models.Departamento, data.Departamento>(departamento);
                new BE.Departamento(_context).Update(mapaAux);
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


        // POST: api/Departamento
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Departamento>> PostDepartamento(models.Departamento departamento)
        {
            try
            {
                data.Departamento mapaAux = _mapper.Map<models.Departamento, data.Departamento>(departamento);
                new BE.Departamento(_context).Inset(mapaAux);
            }
            catch (Exception)
            {
                BadRequest();
            }
            return CreatedAtAction("GetDepartamento", new { id = departamento.IdDepartamento }, departamento);
        }


        // DELETE: api/Departamento/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Departamento>> DeleteDepartamento(int id)
        {
            var departamento = new BE.Departamento(_context).GetOneById(id);
            if (departamento == null)
            {
                return NotFound();
            }

            try
            {
                new BE.Departamento(_context).Delete(departamento);
            }
            catch (Exception)
            {
                BadRequest();
            }
            models.Departamento mapaAux = _mapper.Map<data.Departamento, models.Departamento>(departamento);

            return mapaAux;
        }

        private bool Exist(int id)
        {

            return (new BE.Departamento(_context).GetOneById(id) != null);
        }
    }
}
