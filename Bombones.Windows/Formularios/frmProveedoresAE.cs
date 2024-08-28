using Bombones.Entidades.Entidades;
using Bombones.Entidades.ViewModels;

namespace Bombones.Windows.Formularios
{
    public partial class frmProveedoresAE : Form
    {

        private readonly IServiceProvider? _serviceProvider;

        private List<DireccionConTipoVm> direcciones = new();
        private List<TelefonoConTipoVm> telefonos = new();
        private Proveedor? proveedor;

        public frmProveedoresAE(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        public Proveedor? GetProveedor()
        {
            return proveedor;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (proveedor is null)
                {
                    proveedor = new Proveedor();
                }
                proveedor.Nombre = txtProveedor.Text;
                proveedor.Telefono = txtTelefono.Text;
                proveedor.Mail = txtMail.Text;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtProveedor.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtTelefono, "Nombre es requerido");
            }
            if (string.IsNullOrEmpty(txtTelefono.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtTelefono, "Telefono es requerido");
            }
            if (string.IsNullOrEmpty(txtMail.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtMail, "Mail es requerido");
            }
            return valido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
