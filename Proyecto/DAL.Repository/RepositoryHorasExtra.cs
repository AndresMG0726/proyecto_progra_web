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
    public class RepositoryHorasExtra : Repository<data.HorasExtra>, IRepositoryHorasExtra
    {
        public RepositoryHorasExtra(NDbContext _dbContext) : base(_dbContext)
        {

        }

        public Task<IEnumerable<HorasExtra>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<HorasExtra> GetOneByIdAsinc(int IdUsuario)
        {

            return await _db.HorasExtra.SingleOrDefaultAsync(n => n.IdHE == IdUsuario);
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
