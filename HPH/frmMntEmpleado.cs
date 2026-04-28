using HPHBusiness.Model;
using HPHBusiness.Service;

namespace HPH
{
    public partial class frmMntEmpleado : Form
    {
        public frmMntEmpleado()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            // cargar datos de cargos en el combo box
            CargoService cargo = new CargoService();

            var cargos = cargo.Obtener(0); // obtiene todos los cargos
            cmbCargo.DataSource = cargos;
            cmbCargo.ValueMember = "IdCargo";
            cmbCargo.DisplayMember = "Descripcion";
            cmbCargo.SelectedIndex = -1;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUploadEmpleado_Click(object sender, EventArgs e)
        {
            frmUnloadEmpleados frm = new frmUnloadEmpleados();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void txtRut_Leave(object sender, EventArgs e)
        {
            // Al dejar de ser el control activo se valida que el dato rut este correcto
            int rut;
            char digito;

            if (txtRut.Text.Length <= 0)
            {
                return;
            }
            rut = 0;
            digito = ' ';
            if (txtRut.Text.IndexOf('-') >= 1)
            {
                var pos = txtRut.Text.IndexOf('-');
                var len = txtRut.Text.Length - 1;
                var dig = txtRut.Text.ToString().Substring(len, 1);

                rut = Convert.ToInt32(txtRut.Text.ToString().Substring(0, pos));
                digito = Convert.ToChar(dig);
            }

            if (!ValidaRut(rut, digito))
            {
                MessageBox.Show("El rut ingresado es invalido!!", "Diálogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRut.Focus();
                return;
            }
            try
            {
                // Validar si el rut ya existe en la base de datos
                // Si existe mostrar los datos, sino limpiar los campos para ingresar un nuevo empleado
                //
                EmpleadoService empleado = new EmpleadoService();
                var datos = empleado.Obtener(rut, digito);

                HabilitarIngreso(datos);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar el RUT: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HabilitarIngreso(Empleado empleado)
        {
            cmbCargo.SelectedIndex = -1;
            txtRut.Enabled = false;
            txtNombre.Focus();


            if (empleado is null)
            {
                // Si el empleado no existe, habilitar campos para ingreso de nuevo empleado
                txtNombre.Text = string.Empty;
                txtNombre.Enabled = true;
                cmbCargo.Enabled = true;
                cmbCargo.SelectedIndex = -1;
                txtNombre.Focus();
            }
            else
            {
                // Si el empleado existe, mostrar datos y habilitar campos para edición
                txtNombre.Text = empleado.NombreCompleto;
                txtNombre.Enabled = true;
                cmbCargo.Enabled = true;
                cmbCargo.SelectedValue = empleado.CodigoCargo;
                txtNombre.Focus();
            }
            //cmbCargo.Validated += (s, e) =>
            //{
            //    if (cmbCargo.SelectedIndex == -1)
            //    {
            //        MessageBox.Show("Debe seleccionar un cargo válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        cmbCargo.Focus();
            //    }
            //};
        }


        #region Validador Rut
        private bool ValidaRut(int rut, char digito)
        {
            // Validar que el RUT sea positivo
            if (rut <= 0)
                return false;

            // Calcular el dígito verificador esperado
            char digitoEsperado = CalcularDigitoVerificador(rut);

            // Comparar el dígito ingresado con el esperado (case insensitive)
            return char.ToUpper(digito) == char.ToUpper(digitoEsperado);
        }

        private char CalcularDigitoVerificador(int rut)
        {
            int suma = 0;
            int multiplicador = 2;

            // Calcular suma de productos
            while (rut > 0)
            {
                suma += (rut % 10) * multiplicador;
                rut /= 10;
                multiplicador = multiplicador == 7 ? 2 : multiplicador + 1;
            }

            // Calcular dígito verificador
            int resto = suma % 11;
            int resultado = 11 - resto;

            return resultado switch
            {
                11 => '0',
                10 => 'K',
                _ => resultado.ToString()[0]
            };
        }
        #endregion

        private void txtRut_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo numeros
            if (!(char.IsNumber(e.KeyChar) || (char)Keys.Back == e.KeyChar || (char)Keys.K == e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtRut_KeyUp(object sender, KeyEventArgs e)
        {

            TextBox txt = (TextBox)sender;
            txt.Text = txt.Text.Replace("-", "");
            string sRut = txt.Text;
            string sDig = string.Empty;

            int nLen = txt.Text.Length;
            if (nLen > 1)
            {
                sRut = SauroClases.StringExtensions.Left(txt.Text, nLen - 1);
                sDig = SauroClases.StringExtensions.Right(txt.Text, 1);
                txt.Text = string.Format("{0}-{1}", sRut, sDig);
            }
            txtRut.Select(txtRut.Text.Length, 0);
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if(!ValicionesFormulario())
            {
                MessageBox.Show("Debe completar todos los campos obligatorios.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private bool ValicionesFormulario()
        {
            var gui = Guid.NewGuid().ToString();
            bool lflag = false;
            return ((string.IsNullOrWhiteSpace(txtRut.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || cmbCargo.SelectedIndex == -1) ? false: true);
            
        }
    }
}
