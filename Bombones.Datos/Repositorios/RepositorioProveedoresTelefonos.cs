using Bombones.Datos.Interfaces;
using Bombones.Entidades.Entidades;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioProveedoresTelefonos : IRepositorioProveedoresTelefonos
    {
        public void Agregar(ProveedorTelefono proveedorTelefono, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = @"INSERT INTO ProveedoresTelefonos (ProveedorId, TelefonoId, TipoTelefonoId)
            VALUES (@ClienteId, @TelefonoId, @TipoTelefonoId);
        ";
            conn.Execute(query, proveedorTelefono, tran);
        }

        public void BorrarPorProveedorId(int proveedorId, SqlConnection conn, SqlTransaction? tran = null)
        {
            throw new NotImplementedException();
        }

        public List<ProveedorTelefono> GetTelefonosPorProveedorId(int proveedorId, SqlConnection conn, SqlTransaction? tran = null)
        {
            throw new NotImplementedException();
        }
    }
}
