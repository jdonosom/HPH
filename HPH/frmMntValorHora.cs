using HPHBusiness.Model;
using HPHBusiness.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HPH
{
    public partial class frmMntValorHora : Form
    {
        private const string PERIODO_ACTUAL = "2025"; // Periodo fijo

        public frmMntValorHora()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmBuscarValorHora frm = new frmBuscarValorHora();

            if (frm.ShowDialog(this) == DialogResult.OK && frm.ValorHoraSeleccionado != null)
            {
                var valorHora = frm.ValorHoraSeleccionado;
                CargarDatosValorHora(valorHora);
            }
        }

        private void CargarDatosValorHora(ValorHora valorHora)
        {
            // Cargar datos en los controles
            txtPeriodo.Text = valorHora.Año.ToString();
            txtIdValorHora.Text = valorHora.IdValorHora.ToString();
            txtDescripcion.Text = valorHora.Descripcion;
            txtValorHora.Text = valorHora.ValorHoraPago.ToString("N0");
            chkActivo.Checked = valorHora.Estado == 1;

            // Deshabilitar campos de identificación
            txtPeriodo.Enabled = false;
            txtIdValorHora.Enabled = false;
            txtDescripcion.Enabled = true;
            txtValorHora.Enabled = true;
            chkActivo.Enabled = true;

            // Poner foco en descripción
            txtDescripcion.Focus();
            txtDescripcion.SelectAll();
        }

        private void LimpiarFormulario()
        {

            // txtPeriodo.Text = $"{PERIODO_ACTUAL.Substring(4, 2)}/{PERIODO_ACTUAL.Substring(0, 4)}";
            txtPeriodo.Text = $"{PERIODO_ACTUAL}";
            txtIdValorHora.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtValorHora.Text = string.Empty;
            chkActivo.Checked = true;

            txtPeriodo.Enabled = false;
            txtIdValorHora.Enabled = true;
            txtDescripcion.Enabled = false;
            txtValorHora.Enabled = false;
            chkActivo.Enabled = false;

            txtIdValorHora.Focus();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
            {
                MessageBox.Show("Debe completar todos los campos obligatorios.",
                    "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ValorHoraService valorHoraService = new ValorHoraService();

                ValorHora valorHora = new ValorHora
                {
                    Periodo = PERIODO_ACTUAL,
                    IdValorHora = int.Parse(txtIdValorHora.Text),
                    Descripcion = txtDescripcion.Text.Trim(),
                    ValorHoraPago = decimal.Parse(txtValorHora.Text.Replace(".", "").Replace(",", "")),
                    Estado = (byte)(chkActivo.Checked ? 1 : 0)
                };

                bool resultado;
                string mensaje;

                // Verificar si el valor hora ya existe
                var existente = valorHoraService.Obtener(PERIODO_ACTUAL, valorHora.IdValorHora);

                if (existente != null && existente.Count > 0)
                {
                    // Actualizar
                    resultado = valorHoraService.ActualizarValorHora(valorHora);
                    mensaje = resultado ? "Valor hora actualizado correctamente." : "No se pudo actualizar el valor hora.";
                }
                else
                {
                    // Insertar
                    resultado = valorHoraService.GuardarValorHora(valorHora);
                    mensaje = resultado ? "Valor hora guardado correctamente." : "No se pudo guardar el valor hora.";
                }

                if (resultado)
                {
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el valor hora: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtIdValorHora.Text))
                return false;

            if (!int.TryParse(txtIdValorHora.Text, out _))
                return false;

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                return false;

            if (string.IsNullOrWhiteSpace(txtValorHora.Text))
                return false;

            if (!decimal.TryParse(txtValorHora.Text.Replace(".", "").Replace(",", ""), out _))
                return false;

            return true;
        }

        private void txtIdValorHora_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdValorHora.Text))
                return;

            if (!int.TryParse(txtIdValorHora.Text, out int idValorHora))
            {
                MessageBox.Show("El ID debe ser un número entero válido.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdValorHora.Focus();
                return;
            }

            try
            {
                ValorHoraService valorHoraService = new ValorHoraService();
                var datos = valorHoraService.Obtener(PERIODO_ACTUAL, idValorHora);

                if (datos != null && datos.Count > 0)
                {
                    CargarDatosValorHora(datos[0]);
                }
                else
                {
                    // Nuevo valor hora
                    txtDescripcion.Enabled = true;
                    txtValorHora.Enabled = true;
                    chkActivo.Enabled = true;
                    chkActivo.Checked = true;
                    txtDescripcion.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar el ID: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtValorHora_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo números y backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtValorHora_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtValorHora.Text))
                return;

            // Formatear como moneda chilena
            if (decimal.TryParse(txtValorHora.Text.Replace(".", ""), out decimal valor))
            {
                txtValorHora.Text = valor.ToString("N0");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
