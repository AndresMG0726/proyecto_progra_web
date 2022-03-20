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
    public class Job : ICRUD<data.Job>
    {
        private Repository<data.Job> repo;
        public Job(NDbContext dbContext)
        {
            repo = new Repository<data.Job>(dbContext);
        }
        public void Delete(data.Job t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Job> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Job>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Job GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Job> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Inset(data.Job t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Job t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
