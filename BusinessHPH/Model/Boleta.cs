using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPHBusiness.Model;

public class Boleta
{
    public string Periodo { get; set; } = string.Empty;
    public int IdBoleta { get; set; }
    public int IdDependencia { get; set; }
    public int IdTipoContrato { get; set; }
    public int IdTipo { get; set; }
    public int? DP { get; set; }
    public decimal? Bruto { get; set; }
    public int? JR { get; set; }
    public decimal? Retencion { get; set; }
    public decimal? Descuentos { get; set; }
    public decimal? Liquido { get; set; }

    // Propiedades calculadas/auxiliares para la interfaz (si son necesarias)
    public string PeriodoFormateado => 
        Periodo.Length == 6 ? $"{Periodo.Substring(4, 2)}/{Periodo.Substring(0, 4)}" : Periodo;
}
