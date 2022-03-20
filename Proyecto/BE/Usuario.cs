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
    public class Usuario : ICRUD<data.Usuario>
    {
        private dal.Usuario _dal;
        public Usuario(NDbContext dbContext)
        {
            _dal = new dal.Usuario(dbContext);
        }

        public void Delete(data.Usuario t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Usuario> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Usuario>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Usuario GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Usuario> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Inset(data.Usuario t)
        {
            _dal.Inset(t);
        }

        public void Update(data.Usuario t)
        {
            _dal.Update(t);
        }
    }
}
