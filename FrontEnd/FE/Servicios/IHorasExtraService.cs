using FE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FE.Servicios
{
    public interface IHorasExtraService
    {
        void Insert(HorasExtra t);
        void Update(HorasExtra t);
        void Delete(HorasExtra t);
        IEnumerable<HorasExtra> GetAll();
        HorasExtra GetOneById(int id);
        Task<IEnumerable<HorasExtra>> GetAllAsync();
        Task<HorasExtra> GetOneByIdAsync(int id);
    }
}
