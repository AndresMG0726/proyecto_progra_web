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
    public class Departamento : ICRUD<data.Departamento>
    {
        private Repository<data.Departamento> repo;
        public Departamento(NDbContext dbContext)
        {
            repo = new Repository<data.Departamento>(dbContext);
        }
        public void Delete(data.Departamento t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Departamento> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Departamento>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Departamento GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Departamento> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Inset(data.Departamento t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Departamento t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
