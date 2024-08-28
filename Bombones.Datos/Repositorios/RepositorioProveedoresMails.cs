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
    public class RepositorioProveedoresMails : IRepositorioProveedoresMails
    {

        public void Agregar(ProveedorMail proveedorMail, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = @"
                INSERT INTO ProveedorMails (ProveedorId, MailId, TipoDireccionId)
                VALUES (@ProveedorId, @MailId, @TipoDireccionId);";
            conn.Execute(query, proveedorMail, tran);
        }


        public void BorrarPorproveedorId(int proveedorId, SqlConnection conn, SqlTransaction? tran = null)
        {
            throw new NotImplementedException();
        }

        public List<ProveedorMail> GetDireccionesPorProveedorId(int proveedorId, SqlConnection conn, SqlTransaction? tran = null)
        {
            throw new NotImplementedException();
        }
    }
}
