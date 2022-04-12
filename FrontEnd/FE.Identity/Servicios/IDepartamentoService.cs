namespace FE.Identity.Servicios
{
    using FE.Identity.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDepartamentoService
    {
        void Insert(Departamento t);
        void Update(Departamento t);
        void Delete(Departamento t);
        IEnumerable<Departamento> GetAll();
        Departamento GetOneById(int id);
        Task<IEnumerable<Departamento>> GetAllAsync();
        Task<Departamento> GetOneByIdAsync(int id);
    }
}
