using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{
    interface IRepositoryHorasExtra : IRepository<data.HorasExtra>
    {
        Task<IEnumerable<data.HorasExtra>> GetAllAsync();

        Task<data.HorasExtra> GetOneByIdAsinc(int IdUsuario);
    }
}
