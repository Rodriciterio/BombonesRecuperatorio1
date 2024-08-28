using Bombones.Datos.Interfaces;
using Bombones.Datos.Repositorios;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Servicios.Intefaces;
using System.Data.SqlClient;

namespace Bombones.Servicios.Servicios
{
    public class ServiciosProveedores : IServiciosProveedores
    {

        private readonly IRepositorioProveedores _repositorioProveedores;
        private readonly IRepositorioTelefonos _repositorioTelefonos;
        private readonly IRepositorioMails _repositorioMails;
        private readonly IRepositorioProveedoresTelefonos _repositorioProveedoresTelefonos;
        private readonly IRepositorioProveedoresMails _repositorioProveedoresMails;
        private readonly string _cadena;

        public ServiciosProveedores(
            IRepositorioProveedores repositorioProveedores,
            IRepositorioMails repositorioMails,
            IRepositorioTelefonos repositorioTelefonos,
            IRepositorioProveedoresMails repositorioProveedoresMails,
            IRepositorioProveedoresTelefonos repositorioProveedoresTelefonos,
            string cadena)
        {
            _repositorioProveedores = repositorioProveedores;
            _repositorioMails = repositorioMails;
            _repositorioTelefonos = repositorioTelefonos;
            _repositorioProveedoresMails = repositorioProveedoresMails;
            _repositorioProveedoresTelefonos = repositorioProveedoresTelefonos;
            _cadena = cadena;
        }

        public void Borrar(int proveedorId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        _repositorioProveedoresMails.BorrarPorproveedorId(proveedorId, conn, tran);
                        _repositorioProveedoresTelefonos.BorrarPorProveedorId(proveedorId, conn, tran);
                        _repositorioProveedores.Borrar(proveedorId, conn, tran);

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool Existe(Proveedor proveedor)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorioProveedores.Existe(proveedor, conn);
            }
        }

        public int GetCantidad()
        {
            using (var conn = new SqlConnection(_cadena))
            {
                return _repositorioProveedores.GetCantidad(conn);
            }
        }

        public List<ProveedorListDto> GetLista()
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorioProveedores.GetLista(conn);
            }
        }

        public Proveedor? GetProveedorPorId(int proveedorId)
        {
            throw new NotImplementedException();
        }

        public void Guardar(Proveedor proveedor)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (proveedor.ProveedorId == 0)
                        {
                            _repositorioProveedores.Agregar(proveedor, conn, tran);
                        }
                        else
                        {
                            _repositorioProveedores.Editar(proveedor, conn, tran);
                            _repositorioProveedoresMails.BorrarPorproveedorId(proveedor.ProveedorId, conn, tran);
                            _repositorioProveedoresTelefonos.BorrarPorProveedorId(proveedor.ProveedorId, conn, tran);
                        }

                        foreach (var proveedorMail in proveedor.ProveedorMails)
                        {
                            int mailIdExistente = _repositorioMails
                                .GetDireccionIdIfExists(proveedorMail.Direccion, conn, tran);
                            if (mailIdExistente == 0)
                            {
                                _repositorioMails.Agregar(proveedorMail.Direccion, conn, tran);
                                proveedorMail.MailId = proveedorMail.Direccion.MailId;

                            }
                            else
                            {
                                proveedorMail.MailId = mailIdExistente;
                            }

                            proveedorMail.ProveedorId = proveedor.ProveedorId;
                            _repositorioProveedoresMails.Agregar(proveedorMail, conn, tran);
                        }

                        foreach (var proveedorTelefono in proveedor.ProveedorTelefonos)
                        {
                            int telefonoIdExistente = _repositorioTelefonos
                                .GetTelefonoIdIfExist(proveedorTelefono.Telefono, conn, tran);
                            if (proveedorTelefono.Telefono.TelefonoId == 0)
                            {
                                _repositorioTelefonos.Agregar(proveedorTelefono.Telefono, conn, tran);
                            }
                            proveedorTelefono.ProveedorId = proveedor.ProveedorId;
                            proveedorTelefono.TelefonoId = proveedorTelefono.Telefono.TelefonoId;
                            _repositorioProveedoresTelefonos.Agregar(proveedorTelefono, conn, tran);
                        }

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
