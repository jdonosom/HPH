using HPHBusiness.Model;
using HPHDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPHBusiness.Service;

public class ValorHoraService
{
    private BaseDatos DB = null;

    public ValorHoraService()
    {
        DB = new BaseDatos();
    }

    public List<ValorHora> Obtener(string periodo, int idValorHora = 0)
    {
        List<ValorHora> valoresHora = new List<ValorHora>();
        try
        {
            DB.Conectar();
            string sSql = "ValorHoraSelProc @Periodo, @IdValorHora";
            DB.CrearComando(sSql);
            DB.AsignarParametroCadena("@Periodo", periodo);
            DB.AsignarParametroEntero("@IdValorHora", idValorHora);
            
            var reader = DB.EjecutarConsulta();
            while (reader.Read())
            {
                var valorHora = new ValorHora
                {
                    Periodo = reader.GetString(reader.GetOrdinal("Periodo")),
                    IdValorHora = reader.GetInt32(reader.GetOrdinal("IdValorHora")),
                    Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                    ValorHoraPago = reader.GetDecimal(reader.GetOrdinal("ValorHora")),
                    Estado = reader.GetByte(reader.GetOrdinal("Estado"))
                };
                valoresHora.Add(valorHora);
            }
        }
        catch (Exception ex)
        {
            throw new BaseDatosException($"Error al obtener valores hora\r{ex.Message}");
        }
        finally
        {
            DB.Desconectar();
        }
        return valoresHora;
    }

    public List<ValorHora> ObtenerTodos(string? filtro = null)
    {
        List<ValorHora> valoresHora = new List<ValorHora>();

        try
        {
            DB.Conectar();

            string sSql = "ValorHoraListProc @Filtro";
            DB.CrearComando(sSql);

            if (string.IsNullOrWhiteSpace(filtro))
                DB.AsignarParametroNulo("@Filtro", System.Data.DbType.String);
            else
                DB.AsignarParametroCadena("@Filtro", filtro);

            var reader = DB.EjecutarConsulta();

            while (reader.Read())
            {
                ValorHora valorHora = new ValorHora
                {
                    Periodo = reader.GetString(reader.GetOrdinal("Periodo")),
                    IdValorHora = reader.GetInt32(reader.GetOrdinal("IdValorHora")),
                    Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                    ValorHoraPago = reader.GetDecimal(reader.GetOrdinal("ValorHora")),
                    Estado = reader.GetByte(reader.GetOrdinal("Estado"))
                };

                valoresHora.Add(valorHora);
            }

            reader.Close();
        }
        catch (Exception ex)
        {
            throw new BaseDatosException($"Error al obtener valores hora\r{ex.Message}");
        }
        finally
        {
            DB.Desconectar();
        }

        return valoresHora;
    }

    public bool GuardarValorHora(ValorHora valorHora)
    {
        bool resultado = false;
        try
        {
            DB.Conectar();

            string sSql = "ValorHoraInsProc @Periodo, @IdValorHora, @Descripcion, @ValorHora, @Estado";
            DB.CrearComando(sSql);
            DB.AsignarParametroCadena("@Periodo", valorHora.Periodo);
            DB.AsignarParametroEntero("@IdValorHora", valorHora.IdValorHora);
            DB.AsignarParametroCadena("@Descripcion", valorHora.Descripcion);
            DB.AsignarParametroDouble("@ValorHora", (double)valorHora.ValorHoraPago);
            DB.AsignarParametroEntero("@Estado", valorHora.Estado);
            DB.EjecutarComando();
            resultado = true;
        }
        catch (Exception ex)
        {
            throw new BaseDatosException($"Error al guardar valor hora: ValorHoraInsProc\r{ex.Message}");
        }
        finally
        {
            DB.Desconectar();
        }
        return resultado;
    }

    public bool ActualizarValorHora(ValorHora valorHora)
    {
        bool resultado = false;
        try
        {
            DB.Conectar();

            string sSql = "ValorHoraUpdProc @Periodo, @IdValorHora, @Descripcion, @ValorHora, @Estado";
            DB.CrearComando(sSql);
            DB.AsignarParametroCadena("@Periodo", valorHora.Periodo);
            DB.AsignarParametroEntero("@IdValorHora", valorHora.IdValorHora);
            DB.AsignarParametroCadena("@Descripcion", valorHora.Descripcion);
            DB.AsignarParametroDouble("@ValorHora", (double)valorHora.ValorHoraPago);
            DB.AsignarParametroEntero("@Estado", valorHora.Estado);
            DB.EjecutarComando();
            resultado = true;
        }
        catch (Exception ex)
        {
            throw new BaseDatosException($"Error al actualizar valor hora: ValorHoraUpdProc\r{ex.Message}");
        }
        finally
        {
            DB.Desconectar();
        }
        return resultado;
    }
}
