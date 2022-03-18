using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.DO.Objects
{
    public partial class Solicitud
    {
        public int IdSolicitud { get; set; }
        public int IdUsuario { get; set; }
        public int IdEstado { get; set; }
        public int IdTipo { get; set; }
        public string ComentarioSolicitante { get; set; }
        public string ComentarioEncargado { get; set; }
        public DateTime? FechaEmicion { get; set; }

        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual Tipo IdTipoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
