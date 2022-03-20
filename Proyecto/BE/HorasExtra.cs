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
    public class HorasExtra : ICRUD<data.HorasExtra>
    {
        private dal.HorasExtra _dal;
        public HorasExtra(NDbContext dbContext)
        {
            _dal = new dal.HorasExtra(dbContext);
        }

        public void Delete(data.HorasExtra t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.HorasExtra> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.HorasExtra>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.HorasExtra GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.HorasExtra> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Inset(data.HorasExtra t)
        {
            _dal.Inset(t);
        }

        public void Update(data.HorasExtra t)
        {
            _dal.Update(t);
        }
    }
}
