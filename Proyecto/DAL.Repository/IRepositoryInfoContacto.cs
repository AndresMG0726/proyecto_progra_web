using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;


namespace DAL.Repository 
{
    interface IRepositoryInfoContacto : IRepository<data.InfoContactoUsuario>
    {
        Task<IEnumerable<data.InfoContactoUsuario>> GetAllAsync();
        Task<data.InfoContactoUsuario> GetOneByIdAsinc(int id_usuario);
    }
}
