using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.Models
{
    public partial class InfoContactoUsuario
    {
        public int IdInfo { get; set; }
        public int IdUsuario { get; set; }
        public string NombreCompletoContacto { get; set; }
        public int IdRolCont { get; set; }
        public int TelefonoContacto { get; set; }

        public virtual RolContacto IdRolContNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
