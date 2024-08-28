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
    public class RepositorioMails : IRepositorioMails
    {
        public void Agregar(Mail mail, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = @"INSERT INTO Mails (MailId, DireccionMail)
            VALUES (@MailId, @DireccionMail);
            SELECT CAST(SCOPE_IDENTITY() as int);
        ";
            mail.DireccionMail = conn.Query<string>(query, mail, tran).Single();
        }

        public int GetDireccionIdIfExists(Mail mail, SqlConnection conn, SqlTransaction? tran = null)
        {
            throw new NotImplementedException();
        }

        public Direccion? GetMailPorId(int mailId, SqlConnection conn, SqlTransaction? tran = null)
        {
            throw new NotImplementedException();
        }

        public List<Mail> GetMailsPorProveedorId(int proveedorId, SqlConnection conn, SqlTransaction? tran = null)
        {
            throw new NotImplementedException();
        }
    }
}
