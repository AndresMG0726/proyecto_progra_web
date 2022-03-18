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
    public class RepositoryUsuario : Repository<data.Usuario>, IRepositoryUsuario
    {
        public RepositoryUsuario(NDbContext _dbContext) : base(_dbContext)
        {
        }

        public Task<IEnumerable<Usuario>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetOneByIdAsinc(int id_job, int id_departamento, int id_rol)
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
