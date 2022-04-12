using FE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FE.Servicios
{
    public interface IUsuarioService
    {
        void Insert(Usuario t);
        void Update(Usuario t);
        void Delete(Usuario t);
        IEnumerable<Usuario> GetAll();
        Usuario GetOneById(int id);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario> GetOneByIdAsync(int id);
    }
}
