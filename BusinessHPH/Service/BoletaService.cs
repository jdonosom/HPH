using HPHBusiness.Model;
using HPHDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPHBusiness.Service;

public class BoletaService
{
    private BaseDatos DB = null;

    public BoletaService()
    {
        DB = new BaseDatos();
    }

    public List<Boleta> ObtenerPorEmpleadoYPeriodo(int rutEmpleado, string periodo)
    {
        List<Boleta> boletas = new List<Boleta>();
        try
        {
            DB.Conectar();
            string sSql = "BoletaSelPorEmpleadoYPeriodoProc @RutEmpleado, @Periodo";
            DB.CrearComando(sSql);
            DB.AsignarParametroEntero("@RutEmpleado", rutEmpleado);
            DB.AsignarParametroCadena("@Periodo", periodo);

            var reader = DB.EjecutarConsulta();
            while (reader.Read())
            {
                var boleta = new Boleta
                {
                    Periodo = reader.GetString(reader.GetOrdinal("Periodo")),
                    IdBoleta = reader.GetInt32(reader.GetOrdinal("IdBoleta")),
                    IdDependencia = reader.GetInt32(reader.GetOrdinal("IdDependencia")),
                    IdTipoContrato = reader.GetInt32(reader.GetOrdinal("IdTipoContrato")),
                    IdTipo = reader.GetInt32(reader.GetOrdinal("IdTipo")),
                    DP = reader.IsDBNull(reader.GetOrdinal("DP")) ? null : reader.GetInt32(reader.GetOrdinal("DP")),
                    Bruto = reader.IsDBNull(reader.GetOrdinal("Bruto")) ? null : reader.GetDecimal(reader.GetOrdinal("Bruto")),
                    JR = reader.IsDBNull(reader.GetOrdinal("JR")) ? null : reader.GetInt32(reader.GetOrdinal("JR")),
                    Retencion = reader.IsDBNull(reader.GetOrdinal("Retencion")) ? null : reader.GetDecimal(reader.GetOrdinal("Retencion")),
                    Descuentos = reader.IsDBNull(reader.GetOrdinal("Descuentos")) ? null : reader.GetDecimal(reader.GetOrdinal("Descuentos")),
                    Liquido = reader.IsDBNull(reader.GetOrdinal("Liquido")) ? null : reader.GetDecimal(reader.GetOrdinal("Liquido"))
                };
                boletas.Add(boleta);
            }
        }
        catch (Exception ex)
        {
            throw new BaseDatosException($"Error al obtener boletas del empleado\r{ex.Message}");
        }
        finally
        {
            DB.Desconectar();
        }
        return boletas;
    }

    public List<Boleta> ObtenerPorPeriodo(string periodo)
    {
        List<Boleta> boletas = new List<Boleta>();
        try
        {
            DB.Conectar();
            string sSql = "BoletaSelPorPeriodoProc @Periodo";
            DB.CrearComando(sSql);
            DB.AsignarParametroCadena("@Periodo", periodo);

            var reader = DB.EjecutarConsulta();
            while (reader.Read())
            {
                var boleta = new Boleta
                {
                    Periodo = reader.GetString(reader.GetOrdinal("Periodo")),
                    IdBoleta = reader.GetInt32(reader.GetOrdinal("IdBoleta")),
                    IdDependencia = reader.GetInt32(reader.GetOrdinal("IdDependencia")),
                    IdTipoContrato = reader.GetInt32(reader.GetOrdinal("IdTipoContrato")),
                    IdTipo = reader.GetInt32(reader.GetOrdinal("IdTipo")),
                    DP = reader.IsDBNull(reader.GetOrdinal("DP")) ? null : reader.GetInt32(reader.GetOrdinal("DP")),
                    Bruto = reader.IsDBNull(reader.GetOrdinal("Bruto")) ? null : reader.GetDecimal(reader.GetOrdinal("Bruto")),
                    JR = reader.IsDBNull(reader.GetOrdinal("JR")) ? null : reader.GetInt32(reader.GetOrdinal("JR")),
                    Retencion = reader.IsDBNull(reader.GetOrdinal("Retencion")) ? null : reader.GetDecimal(reader.GetOrdinal("Retencion")),
                    Descuentos = reader.IsDBNull(reader.GetOrdinal("Descuentos")) ? null : reader.GetDecimal(reader.GetOrdinal("Descuentos")),
                    Liquido = reader.IsDBNull(reader.GetOrdinal("Liquido")) ? null : reader.GetDecimal(reader.GetOrdinal("Liquido"))
                };
                boletas.Add(boleta);
            }
        }
        catch (Exception ex)
        {
            throw new BaseDatosException($"Error al obtener boletas del periodo\r{ex.Message}");
        }
        finally
        {
            DB.Desconectar();
        }
        return boletas;
    }

    public Boleta ObtenerBoleta(string periodo, int idBoleta)
    {
        Boleta boleta = null;
        try
        {
            DB.Conectar();
            string sSql = "BoletaSelProc @Periodo, @IdBoleta";
            DB.CrearComando(sSql);
            DB.AsignarParametroCadena("@Periodo", periodo);
            DB.AsignarParametroEntero("@IdBoleta", idBoleta);

            var reader = DB.EjecutarConsulta();
            if (reader.Read())
            {
                boleta = new Boleta
                {
                    Periodo = reader.GetString(reader.GetOrdinal("Periodo")),
                    IdBoleta = reader.GetInt32(reader.GetOrdinal("IdBoleta")),
                    IdDependencia = reader.GetInt32(reader.GetOrdinal("IdDependencia")),
                    IdTipoContrato = reader.GetInt32(reader.GetOrdinal("IdTipoContrato")),
                    IdTipo = reader.GetInt32(reader.GetOrdinal("IdTipo")),
                    DP = reader.IsDBNull(reader.GetOrdinal("DP")) ? null : reader.GetInt32(reader.GetOrdinal("DP")),
                    Bruto = reader.IsDBNull(reader.GetOrdinal("Bruto")) ? null : reader.GetDecimal(reader.GetOrdinal("Bruto")),
                    JR = reader.IsDBNull(reader.GetOrdinal("JR")) ? null : reader.GetInt32(reader.GetOrdinal("JR")),
                    Retencion = reader.IsDBNull(reader.GetOrdinal("Retencion")) ? null : reader.GetDecimal(reader.GetOrdinal("Retencion")),
                    Descuentos = reader.IsDBNull(reader.GetOrdinal("Descuentos")) ? null : reader.GetDecimal(reader.GetOrdinal("Descuentos")),
                    Liquido = reader.IsDBNull(reader.GetOrdinal("Liquido")) ? null : reader.GetDecimal(reader.GetOrdinal("Liquido"))
                };
            }
        }
        catch (Exception ex)
        {
            throw new BaseDatosException($"Error al obtener boleta\r{ex.Message}");
        }
        finally
        {
            DB.Desconectar();
        }
        return boleta;
    }

    public List<Boleta> ObtenerTodas(string? filtro = null)
    {
        List<Boleta> boletas = new List<Boleta>();

        try
        {
            DB.Conectar();

            string sSql = "BoletaListProc @Filtro";
            DB.CrearComando(sSql);

            if (string.IsNullOrWhiteSpace(filtro))
                DB.AsignarParametroNulo("@Filtro", System.Data.DbType.String);
            else
                DB.AsignarParametroCadena("@Filtro", filtro);

            var reader = DB.EjecutarConsulta();

            while (reader.Read())
            {
                Boleta boleta = new Boleta
                {
                    Periodo = reader.GetString(reader.GetOrdinal("Periodo")),
                    IdBoleta = reader.GetInt32(reader.GetOrdinal("IdBoleta")),
                    IdDependencia = reader.GetInt32(reader.GetOrdinal("IdDependencia")),
                    IdTipoContrato = reader.GetInt32(reader.GetOrdinal("IdTipoContrato")),
                    IdTipo = reader.GetInt32(reader.GetOrdinal("IdTipo")),
                    DP = reader.IsDBNull(reader.GetOrdinal("DP")) ? null : reader.GetInt32(reader.GetOrdinal("DP")),
                    Bruto = reader.IsDBNull(reader.GetOrdinal("Bruto")) ? null : reader.GetDecimal(reader.GetOrdinal("Bruto")),
                    JR = reader.IsDBNull(reader.GetOrdinal("JR")) ? null : reader.GetInt32(reader.GetOrdinal("JR")),
                    Retencion = reader.IsDBNull(reader.GetOrdinal("Retencion")) ? null : reader.GetDecimal(reader.GetOrdinal("Retencion")),
                    Descuentos = reader.IsDBNull(reader.GetOrdinal("Descuentos")) ? null : reader.GetDecimal(reader.GetOrdinal("Descuentos")),
                    Liquido = reader.IsDBNull(reader.GetOrdinal("Liquido")) ? null : reader.GetDecimal(reader.GetOrdinal("Liquido"))
                };

                boletas.Add(boleta);
            }

            reader.Close();
        }
        catch (Exception ex)
        {
            throw new BaseDatosException($"Error al obtener boletas\r{ex.Message}");
        }
        finally
        {
            DB.Desconectar();
        }

        return boletas;
    }
}
