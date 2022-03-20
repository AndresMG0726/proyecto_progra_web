using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.DataModels
{
    public partial class HorasExtra
    {
        public int IdHE { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Dia { get; set; }
        public int HoraInicio { get; set; }
        public int HoraFin { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
