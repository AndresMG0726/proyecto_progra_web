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
    public class Estado : ICRUD<data.Estado>
    {
        private dal.Estado _dal;
        public Estado(NDbContext dbContext)
        {
            _dal = new dal.Estado(dbContext);
        }

        public void Delete(data.Estado t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Estado> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Estado>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Estado GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Estado> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Inset(data.Estado t)
        {
            _dal.Inset(t);
        }

        public void Update(data.Estado t)
        {
            _dal.Update(t);
        }
    }
}
