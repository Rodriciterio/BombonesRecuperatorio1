using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Servicios.Intefaces;
using Bombones.Windows.Helpers;

namespace Bombones.Windows.Formularios
{
    public partial class frmProveedores : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        private readonly IServiciosProveedores? _servicio;
        private List<ProveedorListDto>? lista;

        public frmProveedores(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            if (serviceProvider == null)
            {
                throw new ApplicationException("Dependencias no cargadas");
            }
            _serviceProvider = serviceProvider;
            //_servicio = serviceProvider?.GetService<IServiciosProveedores>()
            //    ?? throw new ApplicationException("Dependencias no cargadas!!!");          
            //No pude llegar a acomodar este error, me faltaba probarlo solamente
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmProveedoresAE frm = new frmProveedoresAE(_serviceProvider) { Text = "Agregar Proveedor" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            Proveedor? proveedor = frm.GetProveedor();
            if (proveedor is null) return;
            try
            {
                if (_servicio is null)
                {
                    throw new ApplicationException("Dependencias no cargadas");
                }
                _servicio.Guardar(proveedor);
            }
            catch (Exception)
            {

                throw;
            }


        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            try
            {
                lista = _servicio!.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            if (lista is not null)
            {
                foreach (var item in lista)
                {
                    var r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, item);
                    GridHelper.AgregarFila(r, dgvDatos);
                }

            }
        }

        //private void tsbBorrar_Click(object sender, EventArgs e)
        //{
        //    if (dgvDatos.SelectedRows.Count == 0)
        //    {
        //        MessageBox.Show("Seleccione un registro para eliminar.",
        //                        "Error",
        //                        MessageBoxButtons.OK,
        //                        MessageBoxIcon.Warning);
        //        return;
        //    }

        //    var r = dgvDatos.SelectedRows[0];
        //    Rol rol = (r.Tag as Rol) ?? new Rol();

        //    // Verificar si RolId es válido
        //    if (rol.RolId <= 0)
        //    {
        //        MessageBox.Show("ID de rol inválido.",
        //                        "Error",
        //                        MessageBoxButtons.OK,
        //                        MessageBoxIcon.Error);
        //        return;
        //    }

        //    try
        //    {
        //        DialogResult dr = MessageBox.Show($@"¿Desea dar de baja el rol {rol.NombreRol}?",
        //                "Confirmar Baja",
        //                MessageBoxButtons.YesNo,
        //                MessageBoxIcon.Question,
        //                MessageBoxDefaultButton.Button2);
        //        if (dr == DialogResult.No)
        //        {
        //            return;
        //        }

        //        if (!_servicio.EstaRelacionado(rol.RolId))
        //        {
        //            _servicio.Borrar(rol.RolId);

        //            // Recargar la lista de roles y actualizar el DataGridView
        //            lista = _servicio.GetLista();
        //            MostrarDatosEnGrilla(); // Actualizar el DataGridView

        //            MessageBox.Show("Registro eliminado",
        //                "Mensaje",
        //                MessageBoxButtons.OK,
        //                MessageBoxIcon.Information);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Registro relacionado\nBaja Denegada",
        //                "Error",
        //                MessageBoxButtons.OK,
        //                MessageBoxIcon.Error);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error al eliminar el registro: {ex.Message}",
        //                    "Error",
        //                    MessageBoxButtons.OK,
        //                    MessageBoxIcon.Error);
        //    }
        //}
    }
}
