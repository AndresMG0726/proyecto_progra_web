using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.Identity.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Solicitud = new HashSet<Solicitud>();
        }

        public int IdEstado { get; set; }
        public string DescripcionEstado { get; set; }

        public virtual ICollection<Solicitud> Solicitud { get; set; }
    }
}
