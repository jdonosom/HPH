using HPH.Tools;

namespace HPH
{
    public partial class frmUnloadEmpleados : Form
    {
        public frmUnloadEmpleados()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Archivos CSV (*.csv)|*.csv|Todos los archivos (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.InitialDirectory = ExportData.LastUsedDirectory; // Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string filePath = openFileDialog1.FileName;

                ExportData.LastUsedDirectory = filePath;
                ExportData.UpdateLastUsedDirectory();
                ExportData.FileExportPath = filePath;
                textBox1.Text = ObtenerRutaCompacta(filePath, 60);

            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ExportData.FileExportPath))
                {
                    MessageBox.Show("Debe seleccionar un archivo CSV primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!File.Exists(ExportData.FileExportPath))
                {
                    MessageBox.Show("El archivo seleccionado no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var empleados = ExportData.CargarDatosCSV();
                if (empleados != null && empleados.Count > 0)
                {
                    MessageBox.Show($"Se cargaron {empleados.Count} empleados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se encontraron empleados en el archivo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                btnCancelar.PerformClick();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el archivo: {ex.Message}\n\nDetalles: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Compacta la ruta del archivo para mostrarla en formato abreviado
        /// Muestra los primeros 3 directorios y el último directorio antes del archivo
        /// </summary>
        /// <param name="rutaCompleta">Ruta completa del archivo</param>
        /// <param name="longitudMaxima">Longitud máxima deseada</param>
        /// <returns>Ruta compactada en formato: C:\Dir1\Dir2\Dir3\...\UltimoDir\archivo.csv</returns>
        private string ObtenerRutaCompacta(string rutaCompleta, int longitudMaxima = 50)
        {
            if (string.IsNullOrEmpty(rutaCompleta))
                return string.Empty;

            if (rutaCompleta.Length <= longitudMaxima)
                return rutaCompleta;

            try
            {
                string nombreArchivo = Path.GetFileName(rutaCompleta);
                string directorio = Path.GetDirectoryName(rutaCompleta) ?? string.Empty;

                if (string.IsNullOrEmpty(directorio))
                    return nombreArchivo;

                // Separar la ruta en partes
                string[] partes = directorio.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

                if (partes.Length <= 4)
                {
                    return rutaCompleta;
                }

                // Obtener los primeros 3 directorios (incluyendo la unidad)
                List<string> partesIniciales = new List<string>();
                for (int i = 0; i < Math.Min(3, partes.Length); i++)
                {
                    if (!string.IsNullOrEmpty(partes[i]))
                    {
                        partesIniciales.Add(partes[i]);
                    }
                }

                // Obtener el último directorio
                string ultimoDirectorio = partes[^1];

                // Construir la ruta compactada
                string rutaCompacta = string.Join("\\", partesIniciales) + "\\...\\";

                if (!string.IsNullOrEmpty(ultimoDirectorio))
                {
                    rutaCompacta += ultimoDirectorio + "\\";
                }

                rutaCompacta += nombreArchivo;

                // Si la ruta compactada sigue siendo muy larga, reducir más
                if (rutaCompacta.Length > longitudMaxima)
                {
                    string unidad = Path.GetPathRoot(directorio) ?? string.Empty;
                    return $"{unidad}...\\{ultimoDirectorio}\\{nombreArchivo}";
                }

                return rutaCompacta;
            }
            catch
            {
                return rutaCompleta.Length > longitudMaxima
                    ? rutaCompleta.Substring(0, longitudMaxima - 3) + "..."
                    : rutaCompleta;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
