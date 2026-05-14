using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPHBusiness.Model;

public class ValorHora
{
    public int Año
    {
        get
        {
            var lflag = int.TryParse(Periodo.Substring(0, 4), out int valor);
            if (lflag)
                return valor;
            else 
                return 0;
        }
    }
    public string Periodo { get; set; } = string.Empty;
    public int IdValorHora { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public decimal ValorHoraPago { get; set; }
    public byte Estado { get; set; }
    
    // Propiedad calculada para mostrar periodo formateado
    public string PeriodoFormateado => 
        Periodo.Length == 6 ? $"{Periodo.Substring(4, 2)}/{Periodo.Substring(0, 4)}" : Periodo;
    
    // Propiedad calculada para mostrar descripción completa
    public string DescripcionCompleta => 
        $"{IdValorHora:000} - {Descripcion} (${ValorHoraPago:N0})";
}
