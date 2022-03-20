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
    public class RolContactoController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;
        public RolContactoController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.RolContacto>>> GetRolContacto()
        {
            // return null;
            //return new BE.BS.RolContacto(_context).GetAll().ToList();
            var res = new BE.RolContacto(_context).GetAll();
            List<models.RolContacto> mapaAux = _mapper.Map<IEnumerable<data.RolContacto>, IEnumerable<models.RolContacto>>(res).ToList();
            return mapaAux;
        }

        // GET: api/RolContacto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.RolContacto>> GetRolContacto(int id)
        {
            var rolContacto = new BE.RolContacto(_context).GetOneById(id);

            if (rolContacto == null)
            {
                return NotFound();
            }

            models.RolContacto mapaAux = _mapper.Map<data.RolContacto, models.RolContacto>(rolContacto);

            return mapaAux;
        }

        // PUT: api/RolContacto/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRolContacto(int id, models.RolContacto rolContacto)
        {
            if (id != rolContacto.IdRolCont)
            {
                return BadRequest();
            }

            try
            {
                data.RolContacto mapaAux = _mapper.Map<models.RolContacto, data.RolContacto>(rolContacto);
                new BE.RolContacto(_context).Update(mapaAux);
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


        // POST: api/RolContacto
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.RolContacto>> PostRolContacto(models.RolContacto rolContacto)
        {
            try
            {
                data.RolContacto mapaAux = _mapper.Map<models.RolContacto, data.RolContacto>(rolContacto);
                new BE.RolContacto(_context).Inset(mapaAux);
            }
            catch (Exception)
            {
                BadRequest();
            }
            return CreatedAtAction("GetRolContacto", new { id = rolContacto.IdRolCont }, rolContacto);
        }


        // DELETE: api/RolContacto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.RolContacto>> DeleteRolContacto(int id)
        {
            var rolContacto = new BE.RolContacto(_context).GetOneById(id);
            if (rolContacto == null)
            {
                return NotFound();
            }

            try
            {
                new BE.RolContacto(_context).Delete(rolContacto);
            }
            catch (Exception)
            {
                BadRequest();
            }
            models.RolContacto mapaAux = _mapper.Map<data.RolContacto, models.RolContacto>(rolContacto);

            return mapaAux;
        }

        private bool Exist(int id)
        {

            return (new BE.RolContacto(_context).GetOneById(id) != null);
        }
    }
}
