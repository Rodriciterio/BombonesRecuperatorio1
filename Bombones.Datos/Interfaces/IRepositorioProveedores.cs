using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using System.Data.SqlClient;

namespace Bombones.Datos.Interfaces
{
    public interface IRepositorioProveedores
    {
        void Borrar(int proveedorId, SqlConnection conn, SqlTransaction? tran = null);

        void Agregar(Proveedor proveedor, SqlConnection conn, SqlTransaction? tran = null);

        bool Existe(Proveedor proveedor, SqlConnection conn, SqlTransaction? tran = null);

        void Editar(Proveedor proveedor, SqlConnection conn, SqlTransaction? tran = null);
        Cliente? GetProveedorPorId(int proveedorId, SqlConnection conn);
        List<ProveedorListDto> GetLista(SqlConnection conn, SqlTransaction? tran = null);
        int GetCantidad(SqlConnection conn);
    }
}
