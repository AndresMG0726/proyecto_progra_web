using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.Wi.Models
{
    public partial class Job
    {
        public Job()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdJob { get; set; }
        public string DescripcionJob { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
