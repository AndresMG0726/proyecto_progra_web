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
    public class RolContacto : ICRUD<data.RolContacto>
    {
        private dal.RolContacto _dal;
        public RolContacto(NDbContext dbContext)
        {
            _dal = new dal.RolContacto(dbContext);
        }

        public void Delete(data.RolContacto t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.RolContacto> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.RolContacto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.RolContacto GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.RolContacto> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Inset(data.RolContacto t)
        {
            _dal.Inset(t);
        }

        public void Update(data.RolContacto t)
        {
            _dal.Update(t);
        }
    }
}
