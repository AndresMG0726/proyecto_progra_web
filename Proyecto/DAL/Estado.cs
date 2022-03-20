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
    public class Estado : ICRUD<data.Estado>
    {
        private Repository<data.Estado> repo;
        public Estado(NDbContext dbContext)
        {
            repo = new Repository<data.Estado>(dbContext);
        }
        public void Delete(data.Estado t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Estado> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Estado>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Estado GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Estado> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Inset(data.Estado t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Estado t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
