using HPHBusiness.Model;
using HPHBusiness.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HPH
{
    public partial class frmBuscarEmpleado : Form
    {
        public Empleado? EmpleadoSeleccionado { get; private set; }
        private EmpleadoService empleadoService;
        private List<Empleado> empleados;

        public frmBuscarEmpleado()
        {
            InitializeComponent();
            empleadoService = new EmpleadoService();
            ConfigurarDataGridView();
            CargarEmpleados();
        }

        private void ConfigurarDataGridView()
        {
            dgvEmpleados.AutoGenerateColumns = false;
            dgvEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmpleados.MultiSelect = false;
            dgvEmpleados.ReadOnly = true;
            dgvEmpleados.AllowUserToAddRows = false;
            dgvEmpleados.AllowUserToResizeRows = false;

            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colRut",
                HeaderText = "RUT",
                DataPropertyName = "RutCompleto",
                Width = 120
            });
            
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNombre",
                HeaderText = "Nombre Completo",
                DataPropertyName = "NombreCompleto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCargo",
                HeaderText = "Cargo",
                DataPropertyName = "Cargo",
                Width = 180
            });
        }

        private void CargarEmpleados(string? filtro = null)
        {
            try
            {
                empleados = empleadoService.ObtenerTodos(filtro);
                dgvEmpleados.DataSource = null;
                dgvEmpleados.DataSource = empleados;
                
                lblTotal.Text = $"Total: {empleados.Count} empleado(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleados: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            CargarEmpleados(txtFiltro.Text);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                EmpleadoSeleccionado = dgvEmpleados.SelectedRows[0].DataBoundItem as Empleado;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un empleado.", 
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dgvEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnSeleccionar_Click(sender, e);
            }
        }
    }
}
