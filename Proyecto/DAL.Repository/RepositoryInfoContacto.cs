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
    class RepositoryInfoContacto : Repository<data.InfoContactoUsuario>, IRepositoryInfoContacto
    {
        public RepositoryInfoContacto(NDbContext _dbContext) : base(_dbContext)
        {

        }

        public Task<IEnumerable<Solicitud>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Solicitud> GetOneByIdAsinc(int id_rol)
        {
            throw new NotImplementedException();
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
