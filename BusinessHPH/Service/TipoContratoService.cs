using HPHBusiness.Model;
using HPHDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPHBusiness.Service;

public class TipoContratoService
{
    private BaseDatos DB = null;

    public TipoContratoService()
    {
        DB = new BaseDatos();
    }

    public List<TipoContrato> Obtener(int idTipoContrato = 0)
    {
        List<TipoContrato> tiposContrato = new List<TipoContrato>();
        try
        {
            DB.Conectar();
            string sSql = "TipoContratoSelProc @IdTipoContrato";
            DB.CrearComando(sSql);
            DB.AsignarParametroEntero("@IdTipoContrato", idTipoContrato);
            
            var reader = DB.EjecutarConsulta();
            while (reader.Read())
            {
                var tipoContrato = new TipoContrato
                {
                    IdTipoContrato = reader.GetInt32(reader.GetOrdinal("IdTipoContrato")),
                    Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                    Estado = reader.GetBoolean(reader.GetOrdinal("Estado"))
                };
                tiposContrato.Add(tipoContrato);
            }
        }
        catch (Exception ex)
        {
            throw new BaseDatosException($"Error al obtener tipos de contrato\r{ex.Message}");
        }
        finally
        {
            DB.Desconectar();
        }
        return tiposContrato;
    }
}
