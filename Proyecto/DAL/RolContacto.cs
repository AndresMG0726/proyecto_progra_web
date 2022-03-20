using System;
using System.Collections.Generic;
using System.Text;
using data = DAL.DO.Objects;
using DAL.EF;
using DAL.Repository;
using System.Threading.Tasks;
using DAL.DO.Interfaces;

namespace DAL
{
    public class RolContacto : ICRUD<data.RolContacto>
    {
        private Repository<data.RolContacto> repo;
        public RolContacto(NDbContext dbContext)
        {
            repo = new Repository<data.RolContacto>(dbContext);
        }
        public void Delete(data.RolContacto t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.RolContacto> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.RolContacto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.RolContacto GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.RolContacto> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Inset(data.RolContacto t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.RolContacto t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
