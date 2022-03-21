using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.NE.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            HorasExtra = new HashSet<HorasExtra>();
            InfoContactoUsuario = new HashSet<InfoContactoUsuario>();
            Solicitud = new HashSet<Solicitud>();
        }

        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public string Usuario1 { get; set; }
        public string Contrasenna { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public string NombreUsuario { get; set; }
        public string PrimerApellidoUsuario { get; set; }
        public string SegundoApellidoUsuario { get; set; }
        public int? IdJob { get; set; }
        public int? IdDepartamento { get; set; }
        public DateTime? FechaContratacion { get; set; }

        public virtual Departamento IdDepartamentoNavigation { get; set; }
        public virtual Job IdJobNavigation { get; set; }
        public virtual Rol IdRolNavigation { get; set; }
        public virtual ICollection<HorasExtra> HorasExtra { get; set; }
        public virtual ICollection<InfoContactoUsuario> InfoContactoUsuario { get; set; }
        public virtual ICollection<Solicitud> Solicitud { get; set; }
    }
}
