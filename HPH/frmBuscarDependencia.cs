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
    public partial class frmBuscarDependencia : Form
    {
        public Dependencia? DependenciaSeleccionada { get; private set; }
        private DependenciaService dependenciaService;
        private List<Dependencia> dependencias;

        public frmBuscarDependencia()
        {
            InitializeComponent();
            dependenciaService = new DependenciaService();
            ConfigurarDataGridView();
            CargarDependencias();
        }

        private void ConfigurarDataGridView()
        {
            dgvDependencias.AutoGenerateColumns = false;
            dgvDependencias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDependencias.MultiSelect = false;
            dgvDependencias.ReadOnly = true;
            dgvDependencias.AllowUserToAddRows = false;
            dgvDependencias.AllowUserToResizeRows = false;
            
            dgvDependencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "ID",
                DataPropertyName = "IdDependencia",
                Width = 80,
                Visible = false,
            });
            
            dgvDependencias.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDescripcion",
                HeaderText = "Descripción",
                DataPropertyName = "Descripcion",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            
            dgvDependencias.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "colEstado",
                HeaderText = "Activo",
                DataPropertyName = "Estado",
                Width = 80
            });
        }

        private void CargarDependencias(string? filtro = null)
        {
            try
            {
                dependencias = dependenciaService.ObtenerTodas(filtro);
                dgvDependencias.DataSource = null;
                dgvDependencias.DataSource = dependencias;
                
                lblTotal.Text = $"Total: {dependencias.Count} dependencia(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar dependencias: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            CargarDependencias(txtFiltro.Text);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvDependencias.SelectedRows.Count > 0)
            {
                DependenciaSeleccionada = dgvDependencias.SelectedRows[0].DataBoundItem as Dependencia;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una dependencia.", 
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dgvDependencias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnSeleccionar_Click(sender, e);
            }
        }
    }
}
