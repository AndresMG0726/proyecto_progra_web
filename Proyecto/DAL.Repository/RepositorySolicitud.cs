using DAL.DO.Objects;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public class RepositorySolicitud : Repository<data.Solicitud>, IRepositorySolicitud
    {
        public RepositorySolicitud(NDbContext _dbContext) : base(_dbContext)
        {
        }

        public Task<IEnumerable<Solicitud>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Solicitud> GetOneByIdAsinc(int id)
        {
            return await _db.Solicitud.SingleOrDefaultAsync(n => n.IdSolicitud == id);
        }

        private NDbContext _db
        {
            get
            {
                return dbContext as NDbContext;
            }
        }
    }
}
