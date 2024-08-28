using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Entidades.Entidades
{
    public class ProveedorTelefono
    {
        public int ProveedorId { get; set; }
        public int TelefonoId { get; set; }
        public int TipoTelefonoId { get; set; }

        // Relaciones
        public Proveedor proveedor { get; set; } = null!;
        public Telefono Telefono { get; set; } = null!;
        public TipoTelefono TipoTelefono { get; set; } = null!;
    }
}
