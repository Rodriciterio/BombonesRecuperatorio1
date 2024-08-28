using Bombones.Datos.Interfaces;
using Bombones.Entidades.Dtos;
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
    public class RepositorioProveedores : IRepositorioProveedores
    {
        public void Agregar(Proveedor proveedor, SqlConnection conn, SqlTransaction? tran = null)
        {
            string insertQuery = @"INSERT INTO Proveedores 
                (Nombre, TelefonoId, MailId) 
                VALUES (@Nombre, @Telefonoid, @Mailid); 
                SELECT CAST(SCOPE_IDENTITY() as int)";

            int primaryKey = conn.QuerySingle<int>(insertQuery, proveedor, tran);
            if (primaryKey > 0)
            {
                proveedor.ProveedorId = primaryKey;
                return;
            }
            throw new Exception("No se pudo agregar Proveedor");
        }

        public void Borrar(int proveedorId, SqlConnection conn, SqlTransaction? tran = null)
        {
            throw new NotImplementedException();
        }

        public void Editar(Proveedor proveedor, SqlConnection conn, SqlTransaction? tran = null)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Proveedor proveedor, SqlConnection conn, SqlTransaction? tran = null)
        {
            throw new NotImplementedException();
        }

        public int GetCantidad(SqlConnection conn)
        {
            throw new NotImplementedException();
        }

        public List<ProveedorListDto> GetLista(SqlConnection conn, SqlTransaction? tran = null)
        {
            if (conn == null)
            {
                throw new ArgumentNullException(nameof(conn), "La conexión a la base de datos no puede ser nula.");
            }

            try
            {
                string selectQuery = @"SELECT 
                    ProveedorId,
                    NombreProveedor,
                    Telefono,
                    Email
                FROM Proveedores";
                var lista = conn.Query<ProveedorListDto>(selectQuery, transaction: tran).ToList();


                if (lista == null)
                {
                    throw new InvalidOperationException("La consulta devolvió una lista nula.");
                }

                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public Cliente? GetProveedorPorId(int proveedorId, SqlConnection conn)
        {
            throw new NotImplementedException();
        }
    }
}
