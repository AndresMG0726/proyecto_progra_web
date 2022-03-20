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
    public class JobController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;
        public JobController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Job>>> GetJob()
        {
            // return null;
            //return new BE.BS.Job(_context).GetAll().ToList();
            var res = new BE.Job(_context).GetAll();
            List<models.Job> mapaAux = _mapper.Map<IEnumerable<data.Job>, IEnumerable<models.Job>>(res).ToList();
            return mapaAux;
        }

        // GET: api/Job/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Job>> GetJob(int id)
        {
            var job = new BE.Job(_context).GetOneById(id);

            if (job == null)
            {
                return NotFound();
            }

            models.Job mapaAux = _mapper.Map<data.Job, models.Job>(job);

            return mapaAux;
        }

        // PUT: api/Job/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJob(int id, models.Job job)
        {
            if (id != job.IdJob)
            {
                return BadRequest();
            }

            try
            {
                data.Job mapaAux = _mapper.Map<models.Job, data.Job>(job);
                new BE.Job(_context).Update(mapaAux);
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


        // POST: api/Job
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Job>> PostJob(models.Job job)
        {
            try
            {
                data.Job mapaAux = _mapper.Map<models.Job, data.Job>(job);
                new BE.Job(_context).Inset(mapaAux);
            }
            catch (Exception)
            {
                BadRequest();
            }
            return CreatedAtAction("GetJob", new { id = job.IdJob }, job);
        }


        // DELETE: api/Job/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Job>> DeleteJob(int id)
        {
            var job = new BE.Job(_context).GetOneById(id);
            if (job == null)
            {
                return NotFound();
            }

            try
            {
                new BE.Job(_context).Delete(job);
            }
            catch (Exception)
            {
                BadRequest();
            }
            models.Job mapaAux = _mapper.Map<data.Job, models.Job>(job);

            return mapaAux;
        }

        private bool Exist(int id)
        {

            return (new BE.Job(_context).GetOneById(id) != null);
        }
    }
}
