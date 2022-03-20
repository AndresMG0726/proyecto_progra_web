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
    public class Tipo : ICRUD<data.Tipo>
    {
        private dal.Tipo _dal;
        public Tipo(NDbContext dbContext)
        {
            _dal = new dal.Tipo(dbContext);
        }

        public void Delete(data.Tipo t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Tipo> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Tipo>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Tipo GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Tipo> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Inset(data.Tipo t)
        {
            _dal.Inset(t);
        }

        public void Update(data.Tipo t)
        {
            _dal.Update(t);
        }
    }
}
