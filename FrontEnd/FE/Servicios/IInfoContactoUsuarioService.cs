using FE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FE.Servicios
{
    public interface IInfoContactoUsuarioService
    {
        void Insert(InfoContactoUsuario t);
        void Update(InfoContactoUsuario t);
        void Delete(InfoContactoUsuario t);
        IEnumerable<InfoContactoUsuario> GetAll();
        InfoContactoUsuario GetOneById(int id);
        Task<IEnumerable<InfoContactoUsuario>> GetAllAsync();
        Task<InfoContactoUsuario> GetOneByIdAsync(int id);
    }
}
