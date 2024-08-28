using Bombones.Entidades.Entidades;
using System.Data.SqlClient;

namespace Bombones.Datos.Interfaces
{
    public interface IRepositorioProveedoresTelefonos
    {
        void Agregar(ProveedorTelefono proveedorTelefono, SqlConnection conn, SqlTransaction? tran = null);
        void BorrarPorProveedorId(int proveedorId, SqlConnection conn, SqlTransaction? tran = null);
        List<ProveedorTelefono> GetTelefonosPorProveedorId(int proveedorId, SqlConnection conn, SqlTransaction? tran = null);

    }
}
