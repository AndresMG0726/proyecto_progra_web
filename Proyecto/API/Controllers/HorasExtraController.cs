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
    public class HorasExtraController : Controller
    {
            private readonly NDbContext _context;
            private readonly IMapper _mapper;

            public HorasExtraController(NDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            // GET: api/HorasExtra
            [HttpGet]
            public async Task<ActionResult<IEnumerable<models.HorasExtra>>> GetHorasExtra()
            {
                var res = new BE.HorasExtra(_context).GetAll();
                List<models.HorasExtra> mapaAux = _mapper.Map<IEnumerable<data.HorasExtra>, IEnumerable<models.HorasExtra>>(res).ToList();
                return mapaAux;
            }

            // GET: api/HorasExtra/5
            [HttpGet("{id}")]
            public async Task<ActionResult<models.HorasExtra>> GetHorasExtra(int id)
            {
                var horasExtra = await new BE.HorasExtra(_context).GetOneByIdAsync(id);

                if (horasExtra == null)
                {
                    return NotFound();
                }
                models.HorasExtra mapaAux = _mapper.Map<data.HorasExtra, models.HorasExtra>(horasExtra);
                return mapaAux;
            }


            // PUT: api/HorasExtra/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPut("{id}")]
            public async Task<IActionResult> PutHorasExtra(int id, models.HorasExtra horasExtra)
            {
                if (id != horasExtra.IdUsuario)
                {
                    return BadRequest();
                }

                try
                {
                    data.HorasExtra mapaAux = _mapper.Map<models.HorasExtra, data.HorasExtra>(horasExtra);
                    new BE.HorasExtra(_context).Update(mapaAux);
                }
                catch (Exception ee)
                {
                    if (!Exists(id))
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
            public async Task<ActionResult<models.HorasExtra>> PostHorasExtra(models.HorasExtra horasExtra)
            {
                try
                {
                    data.HorasExtra mapaAux = _mapper.Map<models.HorasExtra, data.HorasExtra>(horasExtra);
                    new BE.HorasExtra(_context).Inset(mapaAux);
                }
                catch (Exception ee)
                {
                    BadRequest();
                }

                return CreatedAtAction("GetHorasExtra", new { id = horasExtra.IdUsuario }, horasExtra);
            }

            // DELETE: api/HorasExtra/5
            [HttpDelete("{id}")]
            public async Task<ActionResult<models.HorasExtra>> DeleteHorasExtra(int id)
            {
                var horasExtra = await new BE.HorasExtra(_context).GetOneByIdAsync(id);
                if (horasExtra == null)
                {
                    return NotFound();
                }

                try
                {
                    new BE.HorasExtra(_context).Delete(horasExtra);
                }
                catch (Exception)
                {
                    BadRequest();
                }
                models.HorasExtra mapaAux = _mapper.Map<data.HorasExtra, models.HorasExtra>(horasExtra);

                return mapaAux;
            }

            private bool Exists(int id)
            {
                return (new BE.HorasExtra(_context).GetOneById(id) != null);
            }
        
    }
}
