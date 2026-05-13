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
    public partial class frmBuscarCargo : Form
    {
        public Cargo? CargoSeleccionado { get; private set; }
        private CargoService cargoService;
        private List<Cargo> cargos;

        public frmBuscarCargo()
        {
            InitializeComponent();
            cargoService = new CargoService();
            ConfigurarDataGridView();
            CargarCargos();
        }

        private void ConfigurarDataGridView()
        {
            dgvCargos.AutoGenerateColumns = false;
            dgvCargos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCargos.MultiSelect = false;
            dgvCargos.ReadOnly = true;
            dgvCargos.AllowUserToAddRows = false;
            dgvCargos.AllowUserToResizeRows = false;
            
            dgvCargos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "ID",
                DataPropertyName = "IdCargo",
                Width = 80,
                Visible = false,
            });
            
            dgvCargos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDescripcion",
                HeaderText = "Descripción",
                DataPropertyName = "Descripcion",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            
            dgvCargos.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "colEstado",
                HeaderText = "Activo",
                DataPropertyName = "Estado",
                Width = 80
            });
        }

        private void CargarCargos(string? filtro = null)
        {
            try
            {
                cargos = cargoService.ObtenerTodos(filtro);
                dgvCargos.DataSource = null;
                dgvCargos.DataSource = cargos;
                
                lblTotal.Text = $"Total: {cargos.Count} cargo(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar cargos: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            CargarCargos(txtFiltro.Text);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvCargos.SelectedRows.Count > 0)
            {
                CargoSeleccionado = dgvCargos.SelectedRows[0].DataBoundItem as Cargo;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un cargo.", 
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dgvCargos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnSeleccionar_Click(sender, e);
            }
        }
    }
}
