using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPHBusiness.Model;

public class Proceso
{
    public string Periodo { get; set; } = string.Empty;
    public int Año { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public DateTime Apertura { get; set; }
    public DateTime? Cierre { get; set; }
    public bool Cerrado { get; set; }
    public int Estado { get; set; }

    /// <summary>
    /// Periodo formateado como MM/AAAA
    /// </summary>
    public string PeriodoFormateado
    {
        get
        {
            if (string.IsNullOrEmpty(Periodo) || Periodo.Length != 6)
                return Periodo;

            string año = Periodo.Substring(0, 4);
            string mes = Periodo.Substring(4, 2);
            return $"{mes}/{año}";
        }
    }

    /// <summary>
    /// Descripción completa del período
    /// </summary>
    public string DescripcionCompleta => $"{PeriodoFormateado} - {Descripcion}";

    /// <summary>
    /// Estado del período como texto
    /// </summary>
    public string EstadoTexto
    {
        get
        {
            return Estado switch
            {
                0 => "Inactivo",
                1 => "En Curso",
                2 => "Cerrado",
                _ => "Desconocido"
            };
        }
    }

    /// <summary>
    /// Indica si el período está activo (En Curso)
    /// </summary>
    public bool EstaActivo => Estado == 1;

    /// <summary>
    /// Indica si el período puede ser modificado
    /// </summary>
    public bool PuedeModificar => !Cerrado && Estado != 2;
}
