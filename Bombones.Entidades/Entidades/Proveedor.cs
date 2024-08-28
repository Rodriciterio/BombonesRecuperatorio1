using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Entidades.Entidades
{
    public class Proveedor
    {
        public int ProveedorId { get; set; }
        public string Nombre { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Mail { get; set; } = null!;

        // Relaciones
        public List<ProveedorTelefono> ProveedorTelefonos { get; set; } = new List<ProveedorTelefono>();
        public List<ProveedorMail> ProveedorMails { get; set; } = new List<ProveedorMail>();
    }
}
