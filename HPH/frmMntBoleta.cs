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
    public partial class frmMntBoleta : Form
    {
        private const string PERIODO_ACTUAL = "202501"; // Periodo fijo
        private int rutEmpleadoActual = 0;

        public frmMntBoleta()
        {
            InitializeComponent();
            CargarDatos();
            ConfigurarDataGridView();
        }

        private void CargarDatos()
        {
            // Cargar datos de cargos en el combo box
            CargoService cargo = new CargoService();
            var cargos = cargo.Obtener(0);
            cmbCargo.DataSource = cargos;
            cmbCargo.ValueMember = "IdCargo";
            cmbCargo.DisplayMember = "Descripcion";
            cmbCargo.SelectedIndex = -1;
        }

        private void ConfigurarDataGridView()
        {
            // Configurar DataGridView para permitir edición
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.ReadOnly = false;

            // Configurar columnas como editables
            if (dataGridView1.Columns["colId"] != null)
                dataGridView1.Columns["colId"].ReadOnly = true; // ID no editable

            if (dataGridView1.Columns["colDependencia"] != null)
                dataGridView1.Columns["colDependencia"].ReadOnly = false;

            if (dataGridView1.Columns["colTipoContrato"] != null)
                dataGridView1.Columns["colTipoContrato"].ReadOnly = false;

            // Configurar columnas numéricas como editables
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (col.Name.StartsWith("colMnt") || col.Name == "colNroBoleta")
                {
                    col.ReadOnly = false;
                }
            }

            // Cargar datos en los ComboBox columns
            CargarCombosDependencia();
            CargarCombosTipoContrato();
        }

        private void CargarCombosDependencia()
        {
            try
            {
                DependenciaService dependenciaService = new DependenciaService();
                var dependencias = dependenciaService.Obtener(0); // Obtener todas las dependencias activas

                if (dataGridView1.Columns["colDependencia"] is DataGridViewComboBoxColumn comboCol)
                {
                    comboCol.DataSource = dependencias;
                    comboCol.ValueMember = "IdDependencia";
                    comboCol.DisplayMember = "Descripcion";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar dependencias: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCombosTipoContrato()
        {
            try
            {
                TipoContratoService tipoContratoService = new TipoContratoService();
                var tiposContrato = tipoContratoService.Obtener(0); // Obtener todos los tipos de contrato activos

                if (dataGridView1.Columns["colTipoContrato"] is DataGridViewComboBoxColumn comboCol)
                {
                    comboCol.DataSource = tiposContrato;
                    comboCol.ValueMember = "IdTipoContrato";
                    comboCol.DisplayMember = "Descripcion";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar tipos de contrato: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            // Abrir búsqueda de EMPLEADO (no boleta)
            frmBuscarEmpleado frm = new frmBuscarEmpleado();

            if (frm.ShowDialog(this) == DialogResult.OK && frm.EmpleadoSeleccionado != null)
            {
                var empleado = frm.EmpleadoSeleccionado;
                CargarDatosEmpleado(empleado);
            }
        }

        private void CargarDatosEmpleado(Empleado empleado)
        {
            try
            {
                // Guardar RUT del empleado
                rutEmpleadoActual = empleado.Rut;

                // Cargar datos del empleado en los controles
                txtRut.Text = $"{empleado.Rut}-{empleado.Dv}";
                txtNombre.Text = empleado.NombreCompleto;
                cmbCargo.SelectedValue = empleado.CodigoCargo;

                // Deshabilitar controles de empleado
                txtRut.Enabled = false;
                txtNombre.Enabled = false;
                cmbCargo.Enabled = false;

                // Cargar las boletas del empleado para el periodo actual
                CargarBoletasEmpleado(empleado.Rut, PERIODO_ACTUAL);

                MessageBox.Show($"Se cargaron las boletas del periodo {PERIODO_ACTUAL.Substring(4)}/{PERIODO_ACTUAL.Substring(0, 4)}",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos del empleado: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarBoletasEmpleado(int rut, string periodo)
        {
            try
            {
                BoletaService boletaService = new BoletaService();
                var boletas = boletaService.ObtenerPorEmpleadoYPeriodo(rut, periodo);

                // Limpiar el DataGridView
                dataGridView1.Rows.Clear();

                // Cargar las boletas del empleado en el periodo
                foreach (var boleta in boletas)
                {
                    int rowIndex = dataGridView1.Rows.Add();
                    var row = dataGridView1.Rows[rowIndex];

                    row.Cells["colId"].Value = boleta.IdBoleta;
                    row.Cells["colDependencia"].Value = boleta.IdDependencia;
                    row.Cells["colTipoContrato"].Value = boleta.IdTipoContrato;
                    row.Cells["colNroBoleta"].Value = boleta.IdBoleta; // Usar IdBoleta como número
                    row.Cells["colMntBruto"].Value = boleta.Bruto;
                    row.Cells["colMntRetencion"].Value = boleta.Retencion;
                    row.Cells["colMntDescuento"].Value = boleta.Descuentos;
                    row.Cells["colMntLiquido"].Value = boleta.Liquido;
                    row.Cells["colTipo"].Value = boleta.IdTipo;
                    row.Cells["colPeriodo"].Value = boleta.PeriodoFormateado;
                    // row.Cells["colDecreto"].Value = boleta.JR; // JR podría ser decreto
                    // row.Cells["colJornada"].Value = boleta.DP; // DP es el RUT, no jornada
                }

                // Agregar una fila vacía para permitir ingreso de nuevas boletas
                if (dataGridView1.AllowUserToAddRows)
                {
                    dataGridView1.Rows.Add();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar boletas del empleado: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtRut.Text = string.Empty;
            txtNombre.Text = string.Empty;
            cmbCargo.SelectedIndex = -1;
            dataGridView1.Rows.Clear();
            rutEmpleadoActual = 0;

            txtRut.Enabled = true;
            txtNombre.Enabled = false;
            cmbCargo.Enabled = false;

            txtRut.Focus();
        }

        // Evento para validar y guardar cambios en el DataGridView
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || rutEmpleadoActual == 0)
                return;

            // Aquí puedes implementar la lógica de guardado automático o validación
            // TODO: Implementar guardado de boleta cuando se modifique una celda
        }

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Validar datos antes de guardar
            var row = dataGridView1.Rows[e.RowIndex];

            // Si la fila está vacía, no validar
            bool isEmptyRow = true;
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                {
                    isEmptyRow = false;
                    break;
                }
            }

            if (isEmptyRow)
                return;

            // Validar campos requeridos
            // TODO: Implementar validaciones específicas
        }
    }
}
