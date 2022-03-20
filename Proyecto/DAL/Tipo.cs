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
    public class Tipo : ICRUD<data.Tipo>
    {
        private Repository<data.Tipo> repo;
        public Tipo(NDbContext dbContext)
        {
            repo = new Repository<data.Tipo>(dbContext);
        }
        public void Delete(data.Tipo t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Tipo> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Tipo>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Tipo GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Tipo> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Inset(data.Tipo t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Tipo t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
