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
    public class Rol : ICRUD<data.Rol>
    {
        private Repository<data.Rol> repo;
        public Rol(NDbContext dbContext)
        {
            repo = new Repository<data.Rol>(dbContext);
        }
        public void Delete(data.Rol t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Rol> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Rol>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Rol GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Rol> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Inset(data.Rol t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Rol t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
