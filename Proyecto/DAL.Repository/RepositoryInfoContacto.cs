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

        public Task<InfoContactoUsuario> GetOneByIdAsinc(int id_usuario)
        {
            return _db.InfoContactoUsuario.SingleOrDefaultAsync(n => n.IdInfo == id_usuario);
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
