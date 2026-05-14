using HPHBusiness.Model;
using HPHBusiness.Service;

namespace HPH
{
    public partial class frmMntPeriodo : Form
    {
        private ProcesoService procesoService;

        public frmMntPeriodo()
        {
            InitializeComponent();
            procesoService = new ProcesoService();
        }

        private void frmMntPeriodo_Load(object sender, EventArgs e)
        {
            ConfigurarControles();
            CargarPeriodos();
            CargarPeriodoActual();
        }

        private void ConfigurarControles()
        {
            // Configurar ComboBox de Estado
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add(new ComboItem { Value = 0, Text = "Inactivo" });
            cmbEstado.Items.Add(new ComboItem { Value = 1, Text = "En Curso" });
            cmbEstado.Items.Add(new ComboItem { Value = 2, Text = "Cerrado" });
            cmbEstado.DisplayMember = "Text";
            cmbEstado.ValueMember = "Value";
            cmbEstado.SelectedIndex = -1;

            // Configurar DateTimePicker
            dtpApertura.Format = DateTimePickerFormat.Short;
            dtpCierre.Format = DateTimePickerFormat.Short;

            // Deshabilitar controles inicialmente
            DeshabilitarControles();
        }

        private void CargarPeriodos()
        {
            try
            {
                var periodos = procesoService.ObtenerTodos();
                dgvPeriodos.DataSource = null;
                dgvPeriodos.DataSource = periodos;

                // Configurar columnas
                ConfigurarDataGridView();

                lblTotal.Text = $"Total: {periodos.Count} período(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar períodos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridView()
        {
            if (dgvPeriodos.Columns.Count == 0) return;

            dgvPeriodos.Columns["Periodo"].HeaderText = "Período";
            dgvPeriodos.Columns["Periodo"].Width = 80;

            dgvPeriodos.Columns["Año"].HeaderText = "Año";
            dgvPeriodos.Columns["Año"].Width = 60;

            dgvPeriodos.Columns["Descripcion"].HeaderText = "Descripción";
            dgvPeriodos.Columns["Descripcion"].Width = 200;

            dgvPeriodos.Columns["Apertura"].HeaderText = "Apertura";
            dgvPeriodos.Columns["Apertura"].Width = 100;
            dgvPeriodos.Columns["Apertura"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvPeriodos.Columns["Cierre"].HeaderText = "Cierre";
            dgvPeriodos.Columns["Cierre"].Width = 100;
            dgvPeriodos.Columns["Cierre"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvPeriodos.Columns["Cerrado"].HeaderText = "Cerrado";
            dgvPeriodos.Columns["Cerrado"].Width = 70;

            dgvPeriodos.Columns["Estado"].HeaderText = "Estado";
            dgvPeriodos.Columns["Estado"].Width = 80;

            // Ocultar columnas auxiliares
            if (dgvPeriodos.Columns.Contains("PeriodoFormateado"))
                dgvPeriodos.Columns["PeriodoFormateado"].Visible = false;
            if (dgvPeriodos.Columns.Contains("DescripcionCompleta"))
                dgvPeriodos.Columns["DescripcionCompleta"].Visible = false;
            if (dgvPeriodos.Columns.Contains("EstadoTexto"))
                dgvPeriodos.Columns["EstadoTexto"].Visible = false;
            if (dgvPeriodos.Columns.Contains("EstaActivo"))
                dgvPeriodos.Columns["EstaActivo"].Visible = false;
            if (dgvPeriodos.Columns.Contains("PuedeModificar"))
                dgvPeriodos.Columns["PuedeModificar"].Visible = false;
        }

        private void CargarPeriodoActual()
        {
            try
            {
                var periodoActual = procesoService.ObtenerPeriodoActual();
                if (periodoActual != null)
                {
                    lblPeriodoActual.Text = $"Período Actual: {periodoActual.PeriodoFormateado} - {periodoActual.Descripcion}";
                    lblPeriodoActual.ForeColor = Color.Green;
                }
                else
                {
                    lblPeriodoActual.Text = "No hay período activo";
                    lblPeriodoActual.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblPeriodoActual.Text = $"Error: {ex.Message}";
                lblPeriodoActual.ForeColor = Color.Red;
            }
        }

        private void dgvPeriodos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPeriodos.SelectedRows.Count > 0)
            {
                var proceso = dgvPeriodos.SelectedRows[0].DataBoundItem as Proceso;
                if (proceso != null)
                {
                    CargarDatosPeriodo(proceso);
                }
            }
        }

        private void CargarDatosPeriodo(Proceso proceso)
        {
            txtPeriodo.Text = proceso.Periodo;
            txtAño.Text = proceso.Año.ToString();
            txtDescripcion.Text = proceso.Descripcion;
            dtpApertura.Value = proceso.Apertura;
            
            if (proceso.Cierre.HasValue)
            {
                chkCierre.Checked = true;
                dtpCierre.Enabled = true;
                dtpCierre.Value = proceso.Cierre.Value;
            }
            else
            {
                chkCierre.Checked = false;
                dtpCierre.Enabled = false;
            }

            chkCerrado.Checked = proceso.Cerrado;
            cmbEstado.SelectedValue = proceso.Estado;

            HabilitarControles();
            txtPeriodo.Enabled = false; // El período no se puede modificar
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            HabilitarControles();
            txtPeriodo.Enabled = true;
            txtPeriodo.Focus();

            // Sugerir el siguiente período
            SugerirSiguientePeriodo();
        }

        private void SugerirSiguientePeriodo()
        {
            try
            {
                var periodoActual = procesoService.ObtenerPeriodoActual();
                if (periodoActual != null && periodoActual.Periodo.Length == 6)
                {
                    int año = int.Parse(periodoActual.Periodo.Substring(0, 4));
                    int mes = int.Parse(periodoActual.Periodo.Substring(4, 2));

                    mes++;
                    if (mes > 12)
                    {
                        mes = 1;
                        año++;
                    }

                    txtPeriodo.Text = $"{año}{mes:00}";
                    txtAño.Text = año.ToString();
                    txtDescripcion.Text = $"Período {ObtenerNombreMes(mes)} {año}";
                    dtpApertura.Value = new DateTime(año, mes, 1);
                }
            }
            catch
            {
                // Si hay error, sugerir el período actual
                DateTime hoy = DateTime.Now;
                txtPeriodo.Text = $"{hoy.Year}{hoy.Month:00}";
                txtAño.Text = hoy.Year.ToString();
                txtDescripcion.Text = $"Período {ObtenerNombreMes(hoy.Month)} {hoy.Year}";
                dtpApertura.Value = new DateTime(hoy.Year, hoy.Month, 1);
            }
        }

        private string ObtenerNombreMes(int mes)
        {
            return mes switch
            {
                1 => "Enero",
                2 => "Febrero",
                3 => "Marzo",
                4 => "Abril",
                5 => "Mayo",
                6 => "Junio",
                7 => "Julio",
                8 => "Agosto",
                9 => "Septiembre",
                10 => "Octubre",
                11 => "Noviembre",
                12 => "Diciembre",
                _ => ""
            };
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            try
            {
                Proceso proceso = new Proceso
                {
                    Periodo = txtPeriodo.Text.Trim(),
                    Año = int.Parse(txtAño.Text),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Apertura = dtpApertura.Value,
                    Cierre = chkCierre.Checked ? dtpCierre.Value : null,
                    Cerrado = chkCerrado.Checked,
                    Estado = (int)cmbEstado.SelectedValue
                };

                bool resultado;
                string mensaje;

                // Verificar si es nuevo o actualización
                if (txtPeriodo.Enabled)
                {
                    resultado = procesoService.GuardarProceso(proceso);
                    mensaje = resultado ? "Período guardado correctamente." : "No se pudo guardar el período.";
                }
                else
                {
                    resultado = procesoService.ActualizarProceso(proceso);
                    mensaje = resultado ? "Período actualizado correctamente." : "No se pudo actualizar el período.";
                }

                if (resultado)
                {
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarPeriodos();
                    CargarPeriodoActual();
                    LimpiarFormulario();
                    DeshabilitarControles();

                    // Notificar al formulario principal para que actualice el label
                    NotificarCambioPeriodo();
                }
                else
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el período: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEstablecerActual_Click(object sender, EventArgs e)
        {
            if (dgvPeriodos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un período de la lista.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var proceso = dgvPeriodos.SelectedRows[0].DataBoundItem as Proceso;
            if (proceso == null) return;

            if (proceso.Cerrado)
            {
                MessageBox.Show("No se puede establecer como actual un período cerrado.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"¿Está seguro de establecer el período {proceso.PeriodoFormateado} como actual?\n\nEsto desactivará el período actual.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool resultado = procesoService.EstablecerPeriodoActual(proceso.Periodo);
                    if (resultado)
                    {
                        MessageBox.Show("Período establecido correctamente.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarPeriodos();
                        CargarPeriodoActual();
                        NotificarCambioPeriodo();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al establecer período actual: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCerrarPeriodo_Click(object sender, EventArgs e)
        {
            if (dgvPeriodos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un período de la lista.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var proceso = dgvPeriodos.SelectedRows[0].DataBoundItem as Proceso;
            if (proceso == null) return;

            if (proceso.Cerrado)
            {
                MessageBox.Show("El período ya está cerrado.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(
                $"¿Está seguro de cerrar el período {proceso.PeriodoFormateado}?\n\n" +
                "ADVERTENCIA: Esta acción no se puede deshacer. Un período cerrado no puede ser modificado.",
                "Confirmar Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool resultado = procesoService.CerrarPeriodo(proceso.Periodo);
                    if (resultado)
                    {
                        MessageBox.Show("Período cerrado correctamente.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarPeriodos();
                        CargarPeriodoActual();
                        LimpiarFormulario();
                        DeshabilitarControles();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cerrar período: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            DeshabilitarControles();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkCierre_CheckedChanged(object sender, EventArgs e)
        {
            dtpCierre.Enabled = chkCierre.Checked;
        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtPeriodo.Text) || txtPeriodo.Text.Length != 6)
            {
                MessageBox.Show("El período debe tener exactamente 6 caracteres (AAAAMM).",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPeriodo.Focus();
                return false;
            }

            if (!int.TryParse(txtPeriodo.Text, out _))
            {
                MessageBox.Show("El período debe ser numérico.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPeriodo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAño.Text) || !int.TryParse(txtAño.Text, out int año))
            {
                MessageBox.Show("Debe ingresar un año válido.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAño.Focus();
                return false;
            }

            if (año < 2020 || año > 2100)
            {
                MessageBox.Show("El año debe estar entre 2020 y 2100.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAño.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Debe ingresar una descripción.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }

            if (cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un estado.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEstado.Focus();
                return false;
            }

            if (chkCierre.Checked && dtpCierre.Value < dtpApertura.Value)
            {
                MessageBox.Show("La fecha de cierre no puede ser anterior a la fecha de apertura.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpCierre.Focus();
                return false;
            }

            return true;
        }

        private void LimpiarFormulario()
        {
            txtPeriodo.Text = string.Empty;
            txtAño.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            dtpApertura.Value = DateTime.Now;
            dtpCierre.Value = DateTime.Now;
            chkCierre.Checked = false;
            chkCerrado.Checked = false;
            cmbEstado.SelectedIndex = -1;
        }

        private void HabilitarControles()
        {
            txtPeriodo.Enabled = true;
            txtAño.Enabled = true;
            txtDescripcion.Enabled = true;
            dtpApertura.Enabled = true;
            chkCierre.Enabled = true;
            chkCerrado.Enabled = true;
            cmbEstado.Enabled = true;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void DeshabilitarControles()
        {
            txtPeriodo.Enabled = false;
            txtAño.Enabled = false;
            txtDescripcion.Enabled = false;
            dtpApertura.Enabled = false;
            chkCierre.Enabled = false;
            dtpCierre.Enabled = false;
            chkCerrado.Enabled = false;
            cmbEstado.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void NotificarCambioPeriodo()
        {
            // Notificar al formulario principal que actualice el label de período
            if (this.MdiParent is frmMain mainForm)
            {
                mainForm.ActualizarPeriodoActual();
            }
        }

        // Clase auxiliar para ComboBox
        private class ComboItem
        {
            public int Value { get; set; }
            public string Text { get; set; } = string.Empty;
        }
    }
}
