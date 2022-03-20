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
    public class Rol : ICRUD<data.Rol>
    {
        private dal.Rol _dal;
        public Rol(NDbContext dbContext)
        {
            _dal = new dal.Rol(dbContext);
        }

        public void Delete(data.Rol t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Rol> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Rol>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Rol GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Rol> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Inset(data.Rol t)
        {
            _dal.Inset(t);
        }

        public void Update(data.Rol t)
        {
            _dal.Update(t);
        }
    }
}
