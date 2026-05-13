using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPHBusiness.Model;

public class Dependencia
{
    public int IdDependencia { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public bool Estado { get; set; }
}
