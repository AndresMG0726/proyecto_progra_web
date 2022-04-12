namespace FE.Servicios
{
    using FE.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IJobService
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
