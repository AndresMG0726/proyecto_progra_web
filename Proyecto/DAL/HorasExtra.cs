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
    public class HorasExtra : ICRUD<data.HorasExtra>
    {
        private RepositoryHorasExtra repo;
        public HorasExtra(NDbContext dbContext)
        {
            repo = new RepositoryHorasExtra(dbContext);
        }
        public void Delete(data.HorasExtra t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.HorasExtra> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.HorasExtra>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.HorasExtra GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.HorasExtra> GetOneByIdAsync(int id)
        {
            return repo.GetOneByIdAsinc(id);
        }

        public void Inset(data.HorasExtra t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.HorasExtra t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
