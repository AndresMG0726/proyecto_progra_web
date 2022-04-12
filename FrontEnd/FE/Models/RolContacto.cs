using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.Models
{
    public partial class RolContacto
    {
        public RolContacto()
        {
            InfoContactoUsuario = new HashSet<InfoContactoUsuario>();
        }

        public int IdRolCont { get; set; }
        public string DescRolCont { get; set; }

        public virtual ICollection<InfoContactoUsuario> InfoContactoUsuario { get; set; }
    }
}
