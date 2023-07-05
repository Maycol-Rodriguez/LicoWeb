using System;
using System.Collections.Generic;

namespace webFinal.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleVenta = new HashSet<DetalleVentum>();
        }

        public string Idproducto { get; set; } = null!;
        public string NombreProd { get; set; } = null!;
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public string? Imagen { get; set; }

        public string? ImagenUrl1
        {
            get
            {
                if (string.IsNullOrEmpty(Imagen))
                    return null;

                // Asegurarse de que la URL esté completa y sea válida
                if (Uri.TryCreate(Imagen, UriKind.Absolute, out Uri? imageUrl) && (imageUrl.Scheme == Uri.UriSchemeHttp || imageUrl.Scheme == Uri.UriSchemeHttps))
                {
                    return imageUrl.ToString();
                }

                return null;
            }
        }
        public string? Ruc { get; set; }
        public string? Idcategoria { get; set; }

        public virtual Categorium? IdcategoriaNavigation { get; set; }
        public virtual Proveedor? RucNavigation { get; set; }
        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }
    }
}
