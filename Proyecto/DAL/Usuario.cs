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
    public class Usuario : ICRUD<data.Usuario>
    {
        private RepositoryUsuario repo;
        public Usuario(NDbContext dbContext)
        {
            repo = new RepositoryUsuario(dbContext);
        }
        public void Delete(data.Usuario t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Usuario> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Usuario>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.Usuario GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Usuario> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<data.Usuario> GetOneByIdAsync(int id_job,int id_departamento,int id_rol)
        {
            return repo.GetOneByIdAsinc(id_job, id_departamento, id_rol);
        }

        public void Inset(data.Usuario t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Usuario t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
