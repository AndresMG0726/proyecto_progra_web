using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DAL.DO.Objects
{
    public partial class Departamento
    {
        public Departamento()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdDepartamento { get; set; }
        public string DescripcionDepartamento { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
