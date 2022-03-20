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
    public class Solicitud : ICRUD<data.Solicitud>
    {
        private RepositorySolicitud repo;
        public Solicitud(NDbContext dbContext)
        {
            repo = new RepositorySolicitud(dbContext);
        }
        public void Delete(data.Solicitud t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Solicitud> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Solicitud>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.Solicitud GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Solicitud> GetOneByIdAsync(int id)
        {
            return null;
        }
        public Task<data.Solicitud> GetOneByIdAsync(int id_usuario, int id_tipo,int id)
        {
            return repo.GetOneByIdAsinc(id_usuario, id_tipo, id);
        }

        public void Inset(data.Solicitud t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Solicitud t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
