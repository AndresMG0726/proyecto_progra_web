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
    public class SolicitudController : Controller
    {
            private readonly NDbContext _context;
            private readonly IMapper _mapper;

            public SolicitudController(NDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            // GET: api/Solicitud
            [HttpGet]
            public async Task<ActionResult<IEnumerable<models.Solicitud>>> GetSolicitud()
            {
                var res = new BE.Solicitud(_context).GetAll();
                List<models.Solicitud> mapaAux = _mapper.Map<IEnumerable<data.Solicitud>, IEnumerable<models.Solicitud>>(res).ToList();
                return mapaAux;
            }

            // GET: api/Solicitud/5
            [HttpGet("{id}")]
            public async Task<ActionResult<models.Solicitud>> GetSolicitud(int id)
            {
                var solicitud = await new BE.Solicitud(_context).GetOneByIdAsync(id);

                if (solicitud == null)
                {
                    return NotFound();
                }
                models.Solicitud mapaAux = _mapper.Map<data.Solicitud, models.Solicitud>(solicitud);
                return mapaAux;
            }


            // PUT: api/Solicitud/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPut("{id}")]
            public async Task<IActionResult> PutSolicitud(int id, models.Solicitud solicitud)
            {
                if (id != solicitud.id_solicitud)
                {
                    return BadRequest();
                }

                try
                {
                    data.Solicitud mapaAux = _mapper.Map<models.Solicitud, data.Solicitud>(solicitud);
                    new BE.Solicitud(_context).Update(mapaAux);
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

            // POST: api/Solicitud
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPost]
            public async Task<ActionResult<models.Solicitud>> PostSolicitud(models.Solicitud solicitud)
            {
                try
                {
                    data.Solicitud mapaAux = _mapper.Map<models.Solicitud, data.Solicitud>(solicitud);
                    new BE.Solicitud(_context).Inset(mapaAux);
                }
                catch (Exception ee)
                {
                    BadRequest();
                }

                return CreatedAtAction("GetSolicitud", new { id = solicitud.id_solicitud }, solicitud);
            }

            // DELETE: api/Solicitud/5
            [HttpDelete("{id}")]
            public async Task<ActionResult<models.Solicitud>> DeleteSolicitud(int id)
            {
                var solicitud = await new BE.Solicitud(_context).GetOneByIdAsync(id);
                if (solicitud == null)
                {
                    return NotFound();
                }

                try
                {
                    new BE.Solicitud(_context).Delete(solicitud);
                }
                catch (Exception)
                {
                    BadRequest();
                }
                models.Solicitud mapaAux = _mapper.Map<data.Solicitud, models.Solicitud>(solicitud);

                return mapaAux;
            }

            private bool Exists(int id)
            {
                return (new BE.Solicitud(_context).GetOneById(id) != null);
            }
    }

}
