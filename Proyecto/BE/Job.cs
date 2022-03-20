using System;
using System.Collections.Generic;
using System.Text;
using data = DAL.DO.Objects;
using dal = DAL;
using System.Threading.Tasks;
using DAL.EF;
using DAL.DO.Interfaces;

namespace BE
{
    public class Job : ICRUD<data.Job>
    {
        private dal.Job _dal;
        public Job(NDbContext dbContext)
        {
            _dal = new dal.Job(dbContext);
        }

        public void Delete(data.Job t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Job> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Job>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Job GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Job> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Inset(data.Job t)
        {
            _dal.Inset(t);
        }

        public void Update(data.Job t)
        {
            _dal.Update(t);
        }
    }
}
