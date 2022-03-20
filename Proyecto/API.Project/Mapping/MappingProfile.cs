using AutoMapper;
using data = DAL.DO.Objects;


namespace API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<data.Departamento, DataModels.Departamento>().ReverseMap();
            CreateMap<data.Estado, DataModels.Estado>().ReverseMap();
            CreateMap<data.HorasExtra, DataModels.HorasExtra>().ReverseMap();
            CreateMap<data.InfoContactoUsuario, DataModels.InfoContactoUsuario>().ReverseMap();
            CreateMap<data.Job, DataModels.Job>().ReverseMap();
            CreateMap<data.Rol, DataModels.Rol>().ReverseMap();
            CreateMap<data.RolContacto, DataModels.RolContacto>().ReverseMap();
            CreateMap<data.Solicitud, DataModels.Solicitud>().ReverseMap();
            CreateMap<data.Tipo, DataModels.Tipo>().ReverseMap();
            CreateMap<data.Usuario, DataModels.Usuario>().ReverseMap();
        }
    }
}
