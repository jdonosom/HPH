using HPH.Helper;
using HPHBusiness.Model;

namespace HPH.Tools;

public static class ExportData
{
    public static string? FileExportPath { get; set; }

    /// <summary>
    /// Obtiene o establece el último directorio utilizado (persistente)
    /// </summary>
    public static string? LastUsedDirectory
    {
        get
        {
            string? saved = Properties.Settings.Default.LastUsedDirectory;
            return !string.IsNullOrEmpty(saved) && Directory.Exists(saved)
                ? saved
                : Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
        set
        {
            Properties.Settings.Default.LastUsedDirectory = value;
            Properties.Settings.Default.Save();
        }
    }

    /// <summary>
    /// Actualiza el último directorio basado en la ruta del archivo actual
    /// </summary>
    public static void UpdateLastUsedDirectory()
    {
        if (!string.IsNullOrEmpty(FileExportPath))
        {
            LastUsedDirectory = Path.GetDirectoryName(FileExportPath);
        }
    }

    // Función para cargar datos del CSV sin bloquear el archivo
    public static List<Empleado> CargarDatosCSV()
    {
        if (string.IsNullOrEmpty(FileExportPath))
            throw new ArgumentException("La ruta del archivo no puede estar vacía.", nameof(FileExportPath));

        string rutaArchivo = FileExportPath;

        List<Empleado> empleados = new List<Empleado>();

        try
        {
            // Usar FileShare.ReadWrite para permitir que otros procesos accedan al archivo
            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader sr = new StreamReader(fs))
            {
                // Leer y omitir la primera línea (encabezados)
                string? lineaEncabezado = sr.ReadLine();

                // Leer el resto de las líneas
                while (!sr.EndOfStream)
                {
                    string? linea = sr.ReadLine();
                    if (string.IsNullOrWhiteSpace(linea))
                        continue;

                    // Separar por tabulaciones
                    string[] campos = linea.Split('\t');

                    if (campos.Length >= 5)
                    {
                        Empleado empleado = new Empleado
                        {
                            Rut = int.Parse(campos[0]),
                            Dv = campos[1].Trim(),
                            NombreCompleto = campos[2].Trim(),
                            Cargo = campos[3].Trim(),
                            CodigoCargo = int.Parse(campos[4])
                        };

                        // Almacenar el empleado en la lista
                        empleados.Add(empleado);

                        // Grabar datos a la base de datos
                        DatabaseHelper.GrabarEmpleado(empleado);

                    }
                }
            }

            // Actualizar el último directorio después de cargar exitosamente
            UpdateLastUsedDirectory();
        }
        catch (FileNotFoundException)
        {
            MessageBox.Show("El archivo no fue encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (IOException ex)
        {
            MessageBox.Show($"Error al leer el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        return empleados;
    }
}