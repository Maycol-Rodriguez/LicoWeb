using System;
using System.Collections.Generic;

namespace webFinal.Models
{
    public partial class DetalleVentum
    {
        public string Iddetalle { get; set; } = null!;
        public TimeSpan? Hora { get; set; }
        public string? Idventa { get; set; }
        public string? Idproducto { get; set; }
        public int Cantidad { get; set; }

        public virtual Producto? IdproductoNavigation { get; set; }
        public virtual Ventum? IdventaNavigation { get; set; }
    }
}
