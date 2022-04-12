namespace FE.Servicios
{
    using FE.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEstadoService
    {
        void Insert(Estado t);
        void Update(Estado t);
        void Delete(Estado t);
        IEnumerable<Estado> GetAll();
        Estado GetOneById(int id);
        Task<IEnumerable<Estado>> GetAllAsync();
        Task<Estado> GetOneByIdAsync(int id);
    }
}
