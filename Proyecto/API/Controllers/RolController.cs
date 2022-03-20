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
    public class RolController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;
        public RolController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Rol>>> GetRol()
        {
            // return null;
            //return new BE.BS.Rol(_context).GetAll().ToList();
            var res = new BE.Rol(_context).GetAll();
            List<models.Rol> mapaAux = _mapper.Map<IEnumerable<data.Rol>, IEnumerable<models.Rol>>(res).ToList();
            return mapaAux;
        }

        // GET: api/Rol/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Rol>> GetRol(int id)
        {
            var rol = new BE.Rol(_context).GetOneById(id);

            if (rol == null)
            {
                return NotFound();
            }

            models.Rol mapaAux = _mapper.Map<data.Rol, models.Rol>(rol);

            return mapaAux;
        }

        // PUT: api/Rol/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRol(int id, models.Rol rol)
        {
            if (id != rol.IdRol)
            {
                return BadRequest();
            }

            try
            {
                data.Rol mapaAux = _mapper.Map<models.Rol, data.Rol>(rol);
                new BE.Rol(_context).Update(mapaAux);
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


        // POST: api/Rol
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Rol>> PostRol(models.Rol rol)
        {
            try
            {
                data.Rol mapaAux = _mapper.Map<models.Rol, data.Rol>(rol);
                new BE.Rol(_context).Inset(mapaAux);
            }
            catch (Exception)
            {
                BadRequest();
            }
            return CreatedAtAction("GetRol", new { id = rol.IdRol }, rol);
        }


        // DELETE: api/Rol/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Rol>> DeleteRol(int id)
        {
            var rol = new BE.Rol(_context).GetOneById(id);
            if (rol == null)
            {
                return NotFound();
            }

            try
            {
                new BE.Rol(_context).Delete(rol);
            }
            catch (Exception)
            {
                BadRequest();
            }
            models.Rol mapaAux = _mapper.Map<data.Rol, models.Rol>(rol);

            return mapaAux;
        }

        private bool Exist(int id)
        {

            return (new BE.Rol(_context).GetOneById(id) != null);
        }
    }
}
