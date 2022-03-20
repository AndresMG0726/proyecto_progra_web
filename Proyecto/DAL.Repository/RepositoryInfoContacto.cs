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
    public class RepositoryInfoContacto : Repository<data.InfoContactoUsuario>, IRepositoryInfoContacto
    {
        public RepositoryInfoContacto(NDbContext _dbContext) : base(_dbContext)
        {

        }

        public Task<IEnumerable<InfoContactoUsuario>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<InfoContactoUsuario> GetOneByIdAsinc(int id_usuario, int id_rol_cont)
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
