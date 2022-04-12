namespace FE.Identity.Servicios
{
    using FE.Identity.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITipoService
    {
        void Insert(Tipo t);
        void Update(Tipo t);
        void Delete(Tipo t);
        IEnumerable<Tipo> GetAll();
        Tipo GetOneById(int id);
        Task<IEnumerable<Tipo>> GetAllAsync();
        Task<Tipo> GetOneByIdAsync(int id);
    }
}
