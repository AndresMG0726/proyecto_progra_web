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
    public class Solicitud : ICRUD<data.Solicitud>
    {
        private dal.Solicitud _dal;
        public Solicitud(NDbContext dbContext)
        {
            _dal = new dal.Solicitud(dbContext);
        }

        public void Delete(data.Solicitud t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Solicitud> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Solicitud>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Solicitud GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Solicitud> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Inset(data.Solicitud t)
        {
            _dal.Inset(t);
        }

        public void Update(data.Solicitud t)
        {
            _dal.Update(t);
        }
    }
}
