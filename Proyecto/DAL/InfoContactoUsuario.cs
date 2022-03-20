using System;
using System.Collections.Generic;
using System.Text;
using data = DAL.DO.Objects;
using DAL.EF;
using DAL.Repository;
using System.Threading.Tasks;
using DAL.DO.Interfaces;

namespace DAL
{
    public class InfoContactoUsuario : ICRUD<data.InfoContactoUsuario>
    {
        private RepositoryInfoContacto repo;
        public InfoContactoUsuario(NDbContext dbContext)
        {
            repo = new RepositoryInfoContacto(dbContext);
        }
        public void Delete(data.InfoContactoUsuario t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.InfoContactoUsuario> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.InfoContactoUsuario>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.InfoContactoUsuario GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }
        public Task<data.InfoContactoUsuario> GetOneByIdAsync(int id)
        {
            return null;
        }
        public Task<data.InfoContactoUsuario> GetOneByIdAsync(int id_usuario,int rol_cont)
        {
            return repo.GetOneByIdAsinc(id_usuario, rol_cont);
        }

        public void Inset(data.InfoContactoUsuario t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.InfoContactoUsuario t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
