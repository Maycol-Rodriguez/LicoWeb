using System;
using System.Collections.Generic;

namespace webFinal.Models
{
    public partial class Ventum
    {
        public Ventum()
        {
            DetalleVenta = new HashSet<DetalleVentum>();
        }

        public string Idventa { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public string? Dni { get; set; }
        public string? Idempleado { get; set; }

        public virtual Cliente? DniNavigation { get; set; }
        public virtual Empleado? IdempleadoNavigation { get; set; }
        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }
    }
}
