using System;
using System.Collections.Generic;

namespace webFinal.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Productos = new HashSet<Producto>();
        }

        public string Idcategoria { get; set; } = null!;
        public string NombreCat { get; set; } = null!;

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
