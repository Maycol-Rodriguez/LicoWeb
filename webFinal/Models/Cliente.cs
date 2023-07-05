using System;
using System.Collections.Generic;

namespace webFinal.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venta = new HashSet<Ventum>();
        }

        public string Dni { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public DateTime? FechaNacimiento { get; set; } // Cambio de tipo a DateTime?

        public string? ImagenC { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }

        public string? ImagenUrl 
        {
            get 
            {
                if (string.IsNullOrEmpty(ImagenC))
                    return null;
                
                // Asegurarse de que la URL esté completa y sea válida
                if (Uri.TryCreate(ImagenC, UriKind.Absolute, out Uri? imageUrl) && (imageUrl.Scheme == Uri.UriSchemeHttp || imageUrl.Scheme == Uri.UriSchemeHttps))
                {
                    return imageUrl.ToString();
                }

                return null;
            }
        }

        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
