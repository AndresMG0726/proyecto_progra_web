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
    public class Departamento : ICRUD<data.Departamento>
    {
        private dal.Departamento _dal;
        public Departamento(NDbContext dbContext)
        {
            _dal = new dal.Departamento(dbContext);
        }

        public void Delete(data.Departamento t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Departamento> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Departamento>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Departamento GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Departamento> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Inset(data.Departamento t)
        {
            _dal.Inset(t);
        }

        public void Update(data.Departamento t)
        {
            _dal.Update(t);
        }
    }
}
