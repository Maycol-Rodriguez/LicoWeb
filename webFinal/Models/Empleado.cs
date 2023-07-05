using System;
using System.Collections.Generic;

namespace webFinal.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Venta = new HashSet<Ventum>();
        }

        public string Idempleado { get; set; } = null!;
        public string NombresE { get; set; } = null!;
        public string ApellidosE { get; set; } = null!;
        public decimal Sueldo { get; set; }

        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
