using System;
using System.Collections.Generic;

namespace webFinal.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Productos = new HashSet<Producto>();
        }

        public string Ruc { get; set; } = null!;
        public string NombreEmpresa { get; set; } = null!;
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
