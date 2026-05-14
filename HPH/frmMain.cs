using HPH.Helper;
using HPHBusiness.Service;
using Microsoft.Win32;
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
    public partial class frmMain : Form
    {

        private Image iconLight;
        private Image iconDark;

        public frmMain()
        {
            InitializeComponent();

            // Cargar inconos para ambos temas
            iconLight = Image.FromFile("Imagenes/LogoCtrlBlack.ico"); // Asegúrate de tener este archivo
            iconDark = Image.FromFile("Imagenes/LogoCtrlWhite.ico");   // Asegúrate de tener este archivo

            // Aplicar temainicial
            // ApplyTheme();

            // Escuchar cambios de tema
            SystemEvents.UserPreferenceChanged += OnThemeChanged;

            this.IsMdiContainer = true;

            // Cargar período actual
            ActualizarPeriodoActual();
        }

        /// <summary>
        /// Actualiza el label del período actual en la ventana principal
        /// </summary>
        public void ActualizarPeriodoActual()
        {
            try
            {
                ProcesoService procesoService = new ProcesoService();
                var periodoActual = procesoService.ObtenerPeriodoActual();

                if (periodoActual != null)
                {
                    lblPeriodo.Text = periodoActual.PeriodoFormateado;
                    lblPeriodo.ForeColor = Color.Green;
                }
                else
                {
                    lblPeriodo.Text = "Sin período";
                    lblPeriodo.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblPeriodo.Text = "Error";
                lblPeriodo.ForeColor = Color.Red;
                // Log the error but don't show message box to avoid blocking app start
                Console.WriteLine($"Error al cargar período actual: {ex.Message}");
            }
        }


        private void ApplyTheme()
        {
            bool isDark = ThemeHelper.IsDarkMode();

            // Aplicar íconos a botones
            //btnFuncionarios.Image = isDark ? iconDark : iconLight;

            // Opcional: Cambiar colores del formulario
            if (isDark)
            {
                this.BackColor = Color.FromArgb(32, 32, 32);
                this.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = SystemColors.Control;
                this.ForeColor = SystemColors.ControlText;
            }
        }

        private void OnThemeChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            if (e.Category == UserPreferenceCategory.General)
            {
                ApplyTheme();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SystemEvents.UserPreferenceChanged -= OnThemeChanged;
            base.OnFormClosing(e);
        }

        #region Menu
        private void funcionariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmMntEmpleado frm = new frmMntEmpleado();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }
        #endregion

        private void cargosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMntCargo frm = new frmMntCargo();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }

        private void nominaDeHonorariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ingresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMntBoleta frm = new frmMntBoleta();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }

        private void valorHoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMntValorHora frm = new frmMntValorHora();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }

        private void asignaciónHorasPorCargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAsignacionHorasCargo frm = new frmAsignacionHorasCargo();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }

        private void dependenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMntDependencia frm = new frmMntDependencia();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }

        private void periodoDeProcesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMntPeriodo frm = new frmMntPeriodo();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show();
        }
    }
}
