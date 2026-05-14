using HPH.Properties;
using HPHBusiness.Model;
using HPHBusiness.Service;

namespace HPH
{
    public partial class frmAsignacionHorasCargo : Form
    {
        private const string PERIODO_ACTUAL = "2025";
        private int cargoActual = 0;
        private List<ValorHora> valoresHoraDisponibles;
        private List<ValorHoraCargo> asignacionesActuales;

        public frmAsignacionHorasCargo()
        {
            InitializeComponent();
            CargarCombos();
            ConfigurarListBoxes();
        }

        private void CargarCombos()
        {
            try
            {
                CargoService cargoService = new CargoService();
                var cargos = cargoService.Obtener(0);

                cmbCargo.ValueMember = "IdCargo";
                cmbCargo.DisplayMember = "Descripcion";
                cmbCargo.DataSource = cargos;
                cmbCargo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar cargos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarListBoxes()
        {
            lstValoresDisponibles.SelectionMode = SelectionMode.MultiExtended;
            lstValoresAsignados.SelectionMode = SelectionMode.MultiExtended;
        }

        private void cmbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCargo.SelectedIndex == -1)
                return;

            // SelectedValue can sometimes be the bound object if binding wasn't applied yet.
            // Handle possible types safely to avoid InvalidCastException.
            if (cmbCargo.SelectedValue is int id)
            {
                cargoActual = id;
            }
            else if (cmbCargo.SelectedItem is HPHBusiness.Model.Cargo c)
            {
                cargoActual = c.IdCargo;
            }
            else
            {
                try
                {
                    cargoActual = Convert.ToInt32(cmbCargo.SelectedValue);
                }
                catch
                {
                    // Fallback: do not change cargoActual if we cannot determine an id
                    return;
                }
            }

            CargarValoresHora();
        }

        private void CargarValoresHora()
        {
            try
            {
                ValorHoraService valorHoraService = new ValorHoraService();
                ValorHoraCargoService valorHoraCargoService = new ValorHoraCargoService();

                // Obtener todos los valores hora del periodo
                valoresHoraDisponibles = valorHoraService.Obtener(PERIODO_ACTUAL, 0);

                // Obtener asignaciones actuales del cargo
                asignacionesActuales = valorHoraCargoService.ObtenerPorCargo(PERIODO_ACTUAL, cargoActual);

                // Llenar listbox de disponibles (los que NO están asignados)
                lstValoresDisponibles.Items.Clear();
                foreach (var vh in valoresHoraDisponibles)
                {
                    if (!asignacionesActuales.Any(a => a.IdValorHora == vh.IdValorHora))
                    {
                        lstValoresDisponibles.Items.Add(new ValorHoraItem
                        {
                            Id = vh.IdValorHora,
                            Descripcion = $"{vh.IdValorHora:000} - {vh.Descripcion} (${vh.ValorHoraPago:N0})"
                        });
                    }
                }

                // Llenar listbox de asignados
                lstValoresAsignados.Items.Clear();
                foreach (var asignacion in asignacionesActuales)
                {
                    lstValoresAsignados.Items.Add(new ValorHoraItem
                    {
                        Id = asignacion.IdValorHora,
                        Descripcion = $"{asignacion.IdValorHora:000} - {asignacion.ValorHoraDescripcion} (${asignacion.ValorHoraMonto:N0})"
                    });
                }

                lblDisponibles.Text = $"Disponibles ({lstValoresDisponibles.Items.Count})";
                lblAsignados.Text = $"Asignados ({lstValoresAsignados.Items.Count})";

                // If we obtained asignaciones for a cargo but the combo isn't showing it,
                // synchronize the combo selection with the current cargoActual.
                try
                {
                    // If there are asignaciones but cargoActual is not set, infer it from the data
                    if ((asignacionesActuales != null && asignacionesActuales.Count > 0) && cargoActual == 0)
                    {
                        cargoActual = asignacionesActuales[0].IdCargo;
                    }

                    // Try to set the combo to the cargoActual if possible by finding the matching item
                    if (cargoActual != 0 && cmbCargo.Items.Count > 0)
                    {
                        cmbCargo.SelectedIndexChanged -= cmbCargo_SelectedIndexChanged;

                        int indexToSelect = -1;
                        for (int i = 0; i < cmbCargo.Items.Count; i++)
                        {
                            if (cmbCargo.Items[i] is HPHBusiness.Model.Cargo itemCargo)
                            {
                                if (itemCargo.IdCargo == cargoActual)
                                {
                                    indexToSelect = i;
                                    break;
                                }
                            }
                            else
                            {
                                // If binding creates other item types (e.g., DataRowView), try using SelectedValue approach
                                try
                                {
                                    cmbCargo.SelectedIndex = i;
                                    if (cmbCargo.SelectedValue is int v && v == cargoActual)
                                    {
                                        indexToSelect = i;
                                        break;
                                    }
                                }
                                catch
                                {
                                    // ignore
                                }
                            }
                        }

                        if (indexToSelect >= 0)
                            cmbCargo.SelectedIndex = indexToSelect;

                        cmbCargo.SelectedIndexChanged += cmbCargo_SelectedIndexChanged;
                    }
                }
                catch
                {
                    // Ignore sync errors; UI will remain as-is
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar valores hora: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (lstValoresDisponibles.SelectedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un valor hora para agregar.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ValorHoraCargoService service = new ValorHoraCargoService();

                foreach (ValorHoraItem item in lstValoresDisponibles.SelectedItems)
                {
                    ValorHoraCargo asignacion = new ValorHoraCargo
                    {
                        Periodo = PERIODO_ACTUAL,
                        IdCargo = cargoActual,
                        IdValorHora = item.Id
                    };

                    service.GuardarAsignacion(asignacion);
                }

                MessageBox.Show("Valores hora asignados correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarValoresHora(); // Recargar listas
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al asignar valores hora: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (lstValoresAsignados.SelectedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un valor hora para quitar.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("¿Está seguro de quitar los valores hora seleccionados?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            try
            {
                ValorHoraCargoService service = new ValorHoraCargoService();

                foreach (ValorHoraItem item in lstValoresAsignados.SelectedItems)
                {
                    service.EliminarAsignacion(PERIODO_ACTUAL, cargoActual, item.Id);
                }

                MessageBox.Show("Valores hora eliminados correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarValoresHora(); // Recargar listas
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar valores hora: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarTodos_Click(object sender, EventArgs e)
        {
            if (lstValoresDisponibles.Items.Count == 0)
            {
                MessageBox.Show("No hay valores hora disponibles para agregar.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show($"¿Está seguro de asignar todos los {lstValoresDisponibles.Items.Count} valores hora?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            try
            {
                ValorHoraCargoService service = new ValorHoraCargoService();

                foreach (ValorHoraItem item in lstValoresDisponibles.Items)
                {
                    ValorHoraCargo asignacion = new ValorHoraCargo
                    {
                        Periodo = PERIODO_ACTUAL,
                        IdCargo = cargoActual,
                        IdValorHora = item.Id
                    };

                    service.GuardarAsignacion(asignacion);
                }

                MessageBox.Show("Todos los valores hora han sido asignados correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarValoresHora();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al asignar todos los valores hora: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuitarTodos_Click(object sender, EventArgs e)
        {
            if (lstValoresAsignados.Items.Count == 0)
            {
                MessageBox.Show("No hay valores hora asignados para quitar.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show($"¿Está seguro de quitar TODAS las asignaciones ({lstValoresAsignados.Items.Count})?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.No)
                return;

            try
            {
                ValorHoraCargoService service = new ValorHoraCargoService();
                service.EliminarTodasAsignaciones(PERIODO_ACTUAL, cargoActual);

                MessageBox.Show("Todas las asignaciones han sido eliminadas.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarValoresHora();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar todas las asignaciones: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Clase auxiliar para mostrar items en el ListBox
        private class ValorHoraItem
        {
            public int Id { get; set; }
            public string Descripcion { get; set; } = string.Empty;

            public override string ToString()
            {
                return Descripcion;
            }
        }

        private void frmAsignacionHorasCargo_Load(object sender, EventArgs e)
        {

            pictureBox1.Image = Resources.Asignacion;

            if (cmbCargo.Items.Count > 0 )
                cmbCargo.SelectedIndex = 0;

        }
    }
}
