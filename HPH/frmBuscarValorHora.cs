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
    public partial class frmBuscarValorHora : Form
    {
        public ValorHora? ValorHoraSeleccionado { get; private set; }
        private ValorHoraService valorHoraService;
        private List<ValorHora> valoresHora;

        public frmBuscarValorHora()
        {
            InitializeComponent();
            valorHoraService = new ValorHoraService();
            ConfigurarDataGridView();
            CargarValoresHora();
        }

        private void ConfigurarDataGridView()
        {
            dgvValoresHora.AutoGenerateColumns = false;
            dgvValoresHora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvValoresHora.MultiSelect = false;
            dgvValoresHora.ReadOnly = true;
            dgvValoresHora.AllowUserToAddRows = false;
            
            dgvValoresHora.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPeriodo",
                HeaderText = "Periodo",
                DataPropertyName = "PeriodoFormateado",
                Width = 80,
                Visible = false,
                
            });
            
            dgvValoresHora.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "ID",
                DataPropertyName = "IdValorHora",
                Width = 60,
                Visible = false,
            });
            
            dgvValoresHora.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDescripcion",
                HeaderText = "Descripción",
                DataPropertyName = "Descripcion",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            
            dgvValoresHora.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colValorHora",
                HeaderText = "Valor Hora",
                DataPropertyName = "ValorHoraPago",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            
            dgvValoresHora.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "colEstado",
                HeaderText = "Activo",
                DataPropertyName = "Estado",
                Width = 60,
                TrueValue = (byte)1,
                FalseValue = (byte)0
            });
        }

        private void CargarValoresHora(string? filtro = null)
        {
            try
            {
                valoresHora = valorHoraService.ObtenerTodos(filtro);
                dgvValoresHora.DataSource = null;
                dgvValoresHora.DataSource = valoresHora;
                
                lblTotal.Text = $"Total: {valoresHora.Count} valor(es) hora";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar valores hora: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            CargarValoresHora(txtFiltro.Text);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvValoresHora.SelectedRows.Count > 0)
            {
                ValorHoraSeleccionado = dgvValoresHora.SelectedRows[0].DataBoundItem as ValorHora;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un valor hora.", 
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dgvValoresHora_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnSeleccionar_Click(sender, e);
            }
        }
    }
}
