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
    public partial class frmBuscarBoleta : Form
    {
        public Boleta? BoletaSeleccionada { get; private set; }
        private BoletaService boletaService;
        private List<Boleta> boletas;

        public frmBuscarBoleta()
        {
            InitializeComponent();
            boletaService = new BoletaService();
            ConfigurarDataGridView();
            CargarBoletas();
        }

        private void ConfigurarDataGridView()
        {
            dgvBoletas.AutoGenerateColumns = false;
            dgvBoletas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBoletas.MultiSelect = false;
            dgvBoletas.ReadOnly = true;
            dgvBoletas.AllowUserToAddRows = false;

            dgvBoletas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPeriodo",
                HeaderText = "Periodo",
                DataPropertyName = "PeriodoFormateado",
                Width = 80
            });

            dgvBoletas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colIdBoleta",
                HeaderText = "ID Boleta",
                DataPropertyName = "IdBoleta",
                Width = 80
            });

            dgvBoletas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colBruto",
                HeaderText = "Bruto",
                DataPropertyName = "Bruto",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });

            dgvBoletas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colRetencion",
                HeaderText = "Retención",
                DataPropertyName = "Retencion",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });

            dgvBoletas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDescuentos",
                HeaderText = "Descuentos",
                DataPropertyName = "Descuentos",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });

            dgvBoletas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colLiquido",
                HeaderText = "Líquido",
                DataPropertyName = "Liquido",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });
        }

        private void CargarBoletas(string? filtro = null)
        {
            try
            {
                boletas = boletaService.ObtenerTodas(filtro);
                dgvBoletas.DataSource = null;
                dgvBoletas.DataSource = boletas;

                lblTotal.Text = $"Total: {boletas.Count} boleta(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar boletas: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            CargarBoletas(txtFiltro.Text);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvBoletas.SelectedRows.Count > 0)
            {
                BoletaSeleccionada = dgvBoletas.SelectedRows[0].DataBoundItem as Boleta;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una boleta.", 
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dgvBoletas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnSeleccionar_Click(sender, e);
            }
        }
    }
}
