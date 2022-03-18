using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    public interface IRepositorySolicitud : IRepository<data.Solicitud>
    {
        Task<IEnumerable<data.Solicitud>> GetAllAsync();
        Task<data.Solicitud> GetOneByIdAsinc(int id_usuario, int id_tipo, int id_estado);
    }
}
