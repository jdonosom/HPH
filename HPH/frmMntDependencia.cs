using HPHBusiness.Model;
using HPHBusiness.Service;
using HPH.Properties;
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
    public partial class frmMntDependencia : Form
    {
        public frmMntDependencia()
        {
            InitializeComponent();
        }

        private void frmMntDependencia_Load(object sender, EventArgs e)
        {
            // TODO: Add Dependencia image to Resources
            // pictureBox1.Image = Resources.Dependencia;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CargarDatosDependencia(Dependencia dependencia)
        {
            txtIdDependencia.Text = dependencia.IdDependencia.ToString();
            txtDescripcion.Text = dependencia.Descripcion;
            chkActivo.Checked = dependencia.Estado;

            txtIdDependencia.Enabled = false;
            txtDescripcion.Enabled = true;
            chkActivo.Enabled = true;

            txtDescripcion.Focus();
            txtDescripcion.SelectAll();
        }

        private void LimpiarFormulario()
        {
            txtIdDependencia.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            chkActivo.Checked = false;

            txtIdDependencia.Enabled = true;
            txtDescripcion.Enabled = false;
            chkActivo.Enabled = false;

            txtIdDependencia.Focus();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmBuscarDependencia frm = new frmBuscarDependencia();

            if (frm.ShowDialog(this) == DialogResult.OK && frm.DependenciaSeleccionada != null)
            {
                var dependencia = frm.DependenciaSeleccionada;
                CargarDatosDependencia(dependencia);
            }
        }

        private void txtIdDependencia_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdDependencia.Text))
                return;

            if (!int.TryParse(txtIdDependencia.Text, out int idDependencia))
            {
                MessageBox.Show("El ID de dependencia debe ser numérico.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIdDependencia.Focus();
                return;
            }

            try
            {
                DependenciaService service = new DependenciaService();
                var dependencias = service.Obtener(idDependencia);

                if (dependencias.Count > 0)
                {
                    CargarDatosDependencia(dependencias[0]);
                }
                else
                {
                    txtDescripcion.Enabled = true;
                    chkActivo.Enabled = true;
                    chkActivo.Checked = true;
                    txtDescripcion.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar dependencia: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                DependenciaService dependenciaService = new DependenciaService();

                Dependencia dependencia = new Dependencia
                {
                    Descripcion = txtDescripcion.Text.Trim(),
                    Estado = chkActivo.Checked
                };

                bool resultado;
                string mensaje;

                if (!txtIdDependencia.Enabled && !string.IsNullOrWhiteSpace(txtIdDependencia.Text))
                {
                    dependencia.IdDependencia = int.Parse(txtIdDependencia.Text);
                    resultado = dependenciaService.ActualizarDependencia(dependencia);
                    mensaje = resultado ? "Dependencia actualizada correctamente." : "No se pudo actualizar la dependencia.";
                }
                else
                {
                    resultado = dependenciaService.GuardarDependencia(dependencia);
                    mensaje = resultado ? "Dependencia guardada correctamente." : "No se pudo guardar la dependencia.";
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
                MessageBox.Show($"Error al procesar la dependencia: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarFormulario()
        {
            return !string.IsNullOrWhiteSpace(txtDescripcion.Text);
        }
    }
}

