using Bombones.Entidades.Entidades;
using System.Data.SqlClient;

namespace Bombones.Datos.Interfaces
{
    public interface IRepositorioMails
    {
        int GetDireccionIdIfExists(Mail mail, SqlConnection conn,
            SqlTransaction? tran = null);

        void Agregar(Mail mail, SqlConnection conn,
            SqlTransaction? tran = null);
        Direccion? GetMailPorId(int mailId, SqlConnection conn,
            SqlTransaction? tran = null);
        List<Mail> GetMailsPorProveedorId(int proveedorId,
            SqlConnection conn, SqlTransaction? tran = null);
    }
}
