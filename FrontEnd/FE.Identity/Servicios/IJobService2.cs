namespace FE.Identity.Servicios
{
    using FE.Identity.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IJobService2
    {
        void Insert(Job t);
        void Update(Job t);
        void Delete(Job t);
        IEnumerable<Job> GetAll();
        Job GetOneById(int id);
        Task<IEnumerable<Job>> GetAllAsync();
        Task<Job> GetOneByIdAsync(int id);
    }
}
