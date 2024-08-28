using Bombones.Entidades.Entidades;
using System.Data.SqlClient;

namespace Bombones.Datos.Interfaces
{
    public interface IRepositorioProveedoresMails 
    {
        void Agregar(ProveedorMail proveedorMail, SqlConnection conn, SqlTransaction? tran = null);
        void BorrarPorproveedorId(int proveedorId, SqlConnection conn, SqlTransaction? tran = null);
        List<ProveedorMail> GetDireccionesPorProveedorId(int proveedorId, SqlConnection conn, SqlTransaction? tran = null);
    }
}
