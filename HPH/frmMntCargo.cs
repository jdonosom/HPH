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
    public partial class frmMntCargo : Form
    {
        public frmMntCargo()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CargarDatosCargo(Cargo cargo)
        {
            // Cargar datos en los controles
            txtIdCargo.Text = cargo.IdCargo.ToString();
            txtDescripcion.Text = cargo.Descripcion;
            chkActivo.Checked = cargo.Estado;

            // Deshabilitar ID y habilitar descripción para edición
            txtIdCargo.Enabled = false;
            txtDescripcion.Enabled = true;
            chkActivo.Enabled = true;

            // Poner foco en descripción
            txtDescripcion.Focus();
            txtDescripcion.SelectAll();
        }

        private void LimpiarFormulario()
        {
            txtIdCargo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            chkActivo.Checked = false;

            txtIdCargo.Enabled = true;
            txtDescripcion.Enabled = false;
            chkActivo.Enabled = false;

            txtIdCargo.Focus();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmBuscarCargo frm = new frmBuscarCargo();

            if (frm.ShowDialog(this) == DialogResult.OK && frm.CargoSeleccionado != null)
            {
                var cargo = frm.CargoSeleccionado;
                CargarDatosCargo(cargo);
            }
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
                CargoService cargoService = new CargoService();

                Cargo cargo = new Cargo
                {
                    Descripcion = txtDescripcion.Text.Trim(),
                    Estado = chkActivo.Checked
                };

                bool resultado;
                string mensaje;

                // Si txtIdCargo está deshabilitado, es una actualización
                if (!txtIdCargo.Enabled && !string.IsNullOrWhiteSpace(txtIdCargo.Text))
                {
                    cargo.IdCargo = int.Parse(txtIdCargo.Text);
                    resultado = cargoService.ActualizarCargo(cargo);
                    mensaje = resultado ? "Cargo actualizado correctamente." : "No se pudo actualizar el cargo.";
                }
                else // Si está habilitado, es una inserción
                {
                    resultado = cargoService.GuardarCargo(cargo);
                    mensaje = resultado ? "Cargo guardado correctamente." : "No se pudo guardar el cargo.";
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
                MessageBox.Show($"Error al procesar el cargo: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarFormulario()
        {
            return !string.IsNullOrWhiteSpace(txtDescripcion.Text);
        }
    }
}
