using System;
using System.Collections.Generic;
using System.Text;

namespace HPHBusiness.Model;

// Clase para representar los datos de un empleado
public class Empleado
{
    public int Rut { get; set; } 
    public string Dv { get; set; } = string.Empty;
    public string NombreCompleto { get; set; } = string.Empty;
    public string Cargo { get; set; } = string.Empty;
    public int CodigoCargo { get; set; }

    // Propiedad calculada para mostrar RUT completo
    public string RutCompleto => $"{Rut:N0}-{Dv}".Replace(",", ".");
}
