using FE.Identity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FE.Identity.Servicios
{
    public interface ISolicitudService
    {
        void Insert(Solicitud t);
        void Update(Solicitud t);
        void Delete(Solicitud t);
        IEnumerable<Solicitud> GetAll();
        Solicitud GetOneById(int id);
        Task<IEnumerable<Solicitud>> GetAllAsync();
        Task<Solicitud> GetOneByIdAsync(int id);
    }
}
