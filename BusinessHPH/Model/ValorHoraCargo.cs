using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPHBusiness.Model;

public class ValorHoraCargo
{
    public string Periodo { get; set; } = string.Empty;
    public int IdCargo { get; set; }
    public int IdValorHora { get; set; }
    
    // Propiedades auxiliares para visualización
    public string? CargoDescripcion { get; set; }
    public string? ValorHoraDescripcion { get; set; }
    public decimal? ValorHoraMonto { get; set; }
}
