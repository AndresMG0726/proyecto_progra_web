namespace FE.Identity.Servicios
{
    using FE.Identity.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRolContactoService
    {
        void Insert(RolContacto t);
        void Update(RolContacto t);
        void Delete(RolContacto t);
        IEnumerable<RolContacto> GetAll();
        RolContacto GetOneById(int id);
        Task<IEnumerable<RolContacto>> GetAllAsync();
        Task<RolContacto> GetOneByIdAsync(int id);
    }
}
