using HPHBusiness.Model;
using HPHDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPHBusiness.Service;

public class ValorHoraCargoService
{
    private BaseDatos DB = null;

    public ValorHoraCargoService()
    {
        DB = new BaseDatos();
    }

    public List<ValorHoraCargo> ObtenerPorCargo(string periodo, int idCargo)
    {
        List<ValorHoraCargo> asignaciones = new List<ValorHoraCargo>();
        try
        {
            DB.Conectar();
            string sSql = "ValorHoraCargoSelProc @Periodo, @IdCargo";
            DB.CrearComando(sSql);
            DB.AsignarParametroCadena("@Periodo", periodo);
            DB.AsignarParametroEntero("@IdCargo", idCargo);
            
            var reader = DB.EjecutarConsulta();
            while (reader.Read())
            {
                var asignacion = new ValorHoraCargo
                {
                    Periodo = reader.GetString(reader.GetOrdinal("Periodo")),
                    IdCargo = reader.GetInt32(reader.GetOrdinal("IdCargo")),
                    IdValorHora = reader.GetInt32(reader.GetOrdinal("IdValorHora")),
                    CargoDescripcion = reader.IsDBNull(reader.GetOrdinal("CargoDescripcion")) ? null : reader.GetString(reader.GetOrdinal("CargoDescripcion")),
                    ValorHoraDescripcion = reader.IsDBNull(reader.GetOrdinal("ValorHoraDescripcion")) ? null : reader.GetString(reader.GetOrdinal("ValorHoraDescripcion")),
                    ValorHoraMonto = reader.IsDBNull(reader.GetOrdinal("ValorHoraMonto")) ? null : reader.GetDecimal(reader.GetOrdinal("ValorHoraMonto"))
                };
                asignaciones.Add(asignacion);
            }
        }
        catch (Exception ex)
        {
            throw new BaseDatosException($"Error al obtener asignaciones de valor hora por cargo\r{ex.Message}");
        }
        finally
        {
            DB.Desconectar();
        }
        return asignaciones;
    }

    public bool GuardarAsignacion(ValorHoraCargo asignacion)
    {
        bool resultado = false;
        try
        {
            DB.Conectar();

            string sSql = "ValorHoraCargoInsProc @Periodo, @IdCargo, @IdValorHora";
            DB.CrearComando(sSql);
            DB.AsignarParametroCadena("@Periodo", asignacion.Periodo);
            DB.AsignarParametroEntero("@IdCargo", asignacion.IdCargo);
            DB.AsignarParametroEntero("@IdValorHora", asignacion.IdValorHora);
            DB.EjecutarComando();
            resultado = true;
        }
        catch (Exception ex)
        {
            throw new BaseDatosException($"Error al guardar asignación: ValorHoraCargoInsProc\r{ex.Message}");
        }
        finally
        {
            DB.Desconectar();
        }
        return resultado;
    }

    public bool EliminarAsignacion(string periodo, int idCargo, int idValorHora)
    {
        bool resultado = false;
        try
        {
            DB.Conectar();

            string sSql = "ValorHoraCargoDelProc @Periodo, @IdCargo, @IdValorHora";
            DB.CrearComando(sSql);
            DB.AsignarParametroCadena("@Periodo", periodo);
            DB.AsignarParametroEntero("@IdCargo", idCargo);
            DB.AsignarParametroEntero("@IdValorHora", idValorHora);
            DB.EjecutarComando();
            resultado = true;
        }
        catch (Exception ex)
        {
            throw new BaseDatosException($"Error al eliminar asignación: ValorHoraCargoDelProc\r{ex.Message}");
        }
        finally
        {
            DB.Desconectar();
        }
        return resultado;
    }

    public bool EliminarTodasAsignaciones(string periodo, int idCargo)
    {
        bool resultado = false;
        try
        {
            DB.Conectar();

            string sSql = "ValorHoraCargoDelAllProc @Periodo, @IdCargo";
            DB.CrearComando(sSql);
            DB.AsignarParametroCadena("@Periodo", periodo);
            DB.AsignarParametroEntero("@IdCargo", idCargo);
            DB.EjecutarComando();
            resultado = true;
        }
        catch (Exception ex)
        {
            throw new BaseDatosException($"Error al eliminar todas las asignaciones: ValorHoraCargoDelAllProc\r{ex.Message}");
        }
        finally
        {
            DB.Desconectar();
        }
        return resultado;
    }
}
