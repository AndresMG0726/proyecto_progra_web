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
    public class InfoContactoUsuario : ICRUD<data.InfoContactoUsuario>
    {
        private dal.InfoContactoUsuario _dal;
        public InfoContactoUsuario(NDbContext dbContext)
        {
            _dal = new dal.InfoContactoUsuario(dbContext);
        }

        public void Delete(data.InfoContactoUsuario t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.InfoContactoUsuario> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.InfoContactoUsuario>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.InfoContactoUsuario GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public async Task<data.InfoContactoUsuario> GetOneByIdAsync(int id)
        {
            return await _dal.GetOneByIdAsync(id);
        }

        public void Inset(data.InfoContactoUsuario t)
        {
            _dal.Inset(t);
        }

        public void Update(data.InfoContactoUsuario t)
        {
            _dal.Update(t);
        }
    }
}
