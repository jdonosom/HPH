using HPHBusiness.Model;
using HPHDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPHBusiness.Service;

public class ProcesoService
{
    private BaseDatos DB = null;

    public ProcesoService()
    {
        DB = new BaseDatos();
    }

    /// <summary>
    /// Obtiene un período específico o todos los períodos
    /// </summary>
    public List<Proceso> Obtener(string periodo = "")
    {
        List<Proceso> procesos = new List<Proceso>();
        try
        {
            DB.Conectar();
            string sSql = "ProcesoSelProc @Periodo";
            DB.CrearComando(sSql);
            
            if (string.IsNullOrWhiteSpace(periodo))
                DB.AsignarParametroNulo("@Periodo");
            else
                DB.AsignarParametroCadena("@Periodo", periodo);

            var reader = DB.EjecutarConsulta();
            while (reader.Read())
            {
                var proceso = new Proceso
                {
                    Periodo = reader.GetString(reader.GetOrdinal("Periodo")).Trim(),
                    Año = reader.GetInt32(reader.GetOrdinal("Anio")),
                    Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                    Apertura = reader.GetDateTime(reader.GetOrdinal("Apertura")),
                    Cierre = reader.IsDBNull(reader.GetOrdinal("Cierre")) ? null : reader.GetDateTime(reader.GetOrdinal("Cierre")),
                    Cerrado = reader.GetBoolean(reader.GetOrdinal("Cerrado")),
                    Estado = reader.GetInt32(reader.GetOrdinal("Estado"))
                };
                procesos.Add(proceso);
            }
        }
        catch (Exception ex)
        {
            throw new BaseDatosException($"Error al obtener períodos\r{ex.Message}");
        }
        finally
        {
            DB.Desconectar();
        }
        return procesos;
    }

    /// <summary>
    /// Obtiene el período actualmente en curso
    /// </summary>
    public Proceso? ObtenerPeriodoActual()
    {
        try
        {
            DB.Conectar();
            string sSql = "ProcesoSelActualProc";
            DB.CrearComando(sSql);
            
            var reader = DB.EjecutarConsulta();
            if (reader.Read())
            {
                return new Proceso
                {
                    Periodo = reader.GetString(reader.GetOrdinal("Periodo")).Trim(),
                    Año = reader.GetInt32(reader.GetOrdinal("Anio")),
                    Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                    Apertura = reader.GetDateTime(reader.GetOrdinal("Apertura")),
                    Cierre = reader.IsDBNull(reader.GetOrdinal("Cierre")) ? null : reader.GetDateTime(reader.GetOrdinal("Cierre")),
                    Cerrado = reader.GetBoolean(reader.GetOrdinal("Cerrado")),
                    Estado = reader.GetInt32(reader.GetOrdinal("Estado"))
                };
            }
        }
        catch (Exception ex)
        {
            throw new BaseDatosException($"Error al obtener período actual\r{ex.Message}");
        }
        finally
        {
            DB.Desconectar();
        }
        return null;
    }

    /// <summary>
    /// Lista todos los períodos con filtro opcional
    /// </summary>
    public List<Proceso> ObtenerTodos(string filtro = "")
    {
        List<Proceso> procesos = new List<Proceso>();
        try
        {
            DB.Conectar();
            string sSql = "ProcesoListProc @Filtro";
            DB.CrearComando(sSql);
            
            if (string.IsNullOrWhiteSpace(filtro))
                DB.AsignarParametroNulo("@Filtro");
            else
                DB.AsignarParametroCadena("@Filtro", filtro);

            var reader = DB.EjecutarConsulta();
            while (reader.Read())
            {
                var proceso = new Proceso
                {
                    Periodo = reader.GetString(reader.GetOrdinal("Periodo")).Trim(),
                    Año = reader.GetInt32(reader.GetOrdinal("Anio")),
                    Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                    Apertura = reader.GetDateTime(reader.GetOrdinal("Apertura")),
                    Cierre = reader.IsDBNull(reader.GetOrdinal("Cierre")) ? null : reader.GetDateTime(reader.GetOrdinal("Cierre")),
                    Cerrado = reader.GetBoolean(reader.GetOrdinal("Cerrado")),
                    Estado = reader.GetInt32(reader.GetOrdinal("Estado"))
                };
                procesos.Add(proceso);
            }
        }
        catch (Exception ex)
        {
            throw new BaseDatosException($"Error al obtener lista de períodos\r{ex.Message}");
        }
        finally
        {
            DB.Desconectar();
        }
        return procesos;
    }

    /// <summary>
    /// Guarda un nuevo período
    /// </summary>
    public bool GuardarProceso(Proceso proceso)
    {
        bool resultado = false;
        try
        {
            DB.Conectar();
            string sSql = "ProcesoInsProc @Periodo, @Anio, @Descripcion, @Apertura, @Cierre, @Cerrado, @Estado";
            DB.CrearComando(sSql);
            DB.AsignarParametroCadena("@Periodo", proceso.Periodo);
            DB.AsignarParametroEntero("@Anio", proceso.Año);
            DB.AsignarParametroCadena("@Descripcion", proceso.Descripcion);
            DB.AsignarParametroFecha("@Apertura", proceso.Apertura);
            
            if (proceso.Cierre.HasValue)
                DB.AsignarParametroFecha("@Cierre", proceso.Cierre.Value);
            else
                DB.AsignarParametroNulo("@Cierre");
            
            DB.AsignarParametroBoolean("@Cerrado", proceso.Cerrado);
            DB.AsignarParametroEntero("@Estado", proceso.Estado);
            
            DB.EjecutarComando();
            resultado = true;
        }
        catch (Exception ex)
        {
            throw new BaseDatosException($"Error al guardar período\r{ex.Message}");
        }
        finally
        {
            DB.Desconectar();
        }
        return resultado;
    }

    /// <summary>
    /// Actualiza un período existente
    /// </summary>
    public bool ActualizarProceso(Proceso proceso)
    {
        bool resultado = false;
        try
        {
            DB.Conectar();
            string sSql = "ProcesoUpdProc @Periodo, @Anio, @Descripcion, @Apertura, @Cierre, @Cerrado, @Estado";
            DB.CrearComando(sSql);
            DB.AsignarParametroCadena("@Periodo", proceso.Periodo);
            DB.AsignarParametroEntero("@Anio", proceso.Año);
            DB.AsignarParametroCadena("@Descripcion", proceso.Descripcion);
            DB.AsignarParametroFecha("@Apertura", proceso.Apertura);
            
            if (proceso.Cierre.HasValue)
                DB.AsignarParametroFecha("@Cierre", proceso.Cierre.Value);
            else
                DB.AsignarParametroNulo("@Cierre");
            
            DB.AsignarParametroBoolean("@Cerrado", proceso.Cerrado);
            DB.AsignarParametroEntero("@Estado", proceso.Estado);
            
            DB.EjecutarComando();
            resultado = true;
        }
        catch (Exception ex)
        {
            throw new BaseDatosException($"Error al actualizar período\r{ex.Message}");
        }
        finally
        {
            DB.Desconectar();
        }
        return resultado;
    }

    /// <summary>
    /// Establece un período como el actual (en curso)
    /// </summary>
    public bool EstablecerPeriodoActual(string periodo)
    {
        bool resultado = false;
        try
        {
            DB.Conectar();
            string sSql = "ProcesoSetActualProc @Periodo";
            DB.CrearComando(sSql);
            DB.AsignarParametroCadena("@Periodo", periodo);
            
            DB.EjecutarComando();
            resultado = true;
        }
        catch (Exception ex)
        {
            throw new BaseDatosException($"Error al establecer período actual\r{ex.Message}");
        }
        finally
        {
            DB.Desconectar();
        }
        return resultado;
    }

    /// <summary>
    /// Cierra un período
    /// </summary>
    public bool CerrarPeriodo(string periodo)
    {
        bool resultado = false;
        try
        {
            DB.Conectar();
            string sSql = "ProcesoCerrarProc @Periodo";
            DB.CrearComando(sSql);
            DB.AsignarParametroCadena("@Periodo", periodo);
            
            DB.EjecutarComando();
            resultado = true;
        }
        catch (Exception ex)
        {
            throw new BaseDatosException($"Error al cerrar período\r{ex.Message}");
        }
        finally
        {
            DB.Desconectar();
        }
        return resultado;
    }
}
