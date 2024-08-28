using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Entidades.Entidades
{
    public class ProveedorMail
    {
        public int ProveedorId { get; set; }
        public int MailId { get; set; }
        public int TipoDeMailid { get; set; }

        // Relaciones
        public Proveedor proveedor { get; set; } = null!;
        public Mail Direccion { get; set; } = null!;
        public TipoDeMail TipoDireccion { get; set; } = null!;
    }
}
