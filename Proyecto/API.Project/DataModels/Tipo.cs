using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.DataModels
{
    public partial class Tipo
    {
        public Tipo()
        {
            Solicitud = new HashSet<Solicitud>();
        }

        public int IdTipo { get; set; }
        public string DescripcionTipo { get; set; }

        public virtual ICollection<Solicitud> Solicitud { get; set; }
    }
}
