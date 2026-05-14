using HPHBusiness.Model;
using HPHDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPHBusiness.Service;

public class DependenciaService
{
    private BaseDatos DB = null;

    public DependenciaService()
    {
        DB = new BaseDatos();
    }

    public List<Dependencia> Obtener(int idDependencia = 0)
    {
        List<Dependencia> dependencias = new List<Dependencia>();
        try
        {
            DB.Conectar();
            string sSql = "DependenciaSelProc @IdDependencia";
            DB.CrearComando(sSql);
            DB.AsignarParametroEntero("@IdDependencia", idDependencia);

            var reader = DB.EjecutarConsulta();
            while (reader.Read())
            {
                var dependencia = new Dependencia
                {
                    IdDependencia = reader.GetInt32(reader.GetOrdinal("IdDependencia")),
                    Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                    Estado = reader.GetBoolean(reader.GetOrdinal("Estado"))
                };
                dependencias.Add(dependencia);
            }
        }
        catch (Exception ex)
        {
            throw new BaseDatosException($"Error al obtener dependencias\r{ex.Message}");
        }
        finally
        {
            DB.Desconectar();
        }
        return dependencias;
    }

    public List<Dependencia> ObtenerTodas(string filtro = "")
    {
        List<Dependencia> dependencias = new List<Dependencia>();
        try
        {
            DB.Conectar();
            string sSql = "DependenciaListProc @Filtro";
            DB.CrearComando(sSql);

            if (string.IsNullOrWhiteSpace(filtro))
                DB.AsignarParametroNulo("@Filtro");
            else
                DB.AsignarParametroCadena("@Filtro", filtro);

            var reader = DB.EjecutarConsulta();
            while (reader.Read())
            {
                var dependencia = new Dependencia
                {
                    IdDependencia = reader.GetInt32(reader.GetOrdinal("IdDependencia")),
                    Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                    Estado = reader.GetBoolean(reader.GetOrdinal("Estado"))
                };
                dependencias.Add(dependencia);
            }
        }
        catch (Exception ex)
        {
            throw new BaseDatosException($"Error al obtener lista de dependencias\r{ex.Message}");
        }
        finally
        {
            DB.Desconectar();
        }
        return dependencias;
    }

    public bool GuardarDependencia(Dependencia dependencia)
    {
        bool resultado = false;
        try
        {
            DB.Conectar();
            string sSql = "DependenciaInsProc @Descripcion, @Estado";
            DB.CrearComando(sSql);
            DB.AsignarParametroCadena("@Descripcion", dependencia.Descripcion);
            DB.AsignarParametroBoolean("@Estado", dependencia.Estado);
            DB.EjecutarComando();
            resultado = true;
        }
        catch (Exception ex)
        {
            throw new BaseDatosException($"Error al guardar dependencia\r{ex.Message}");
        }
        finally
        {
            DB.Desconectar();
        }
        return resultado;
    }

    public bool ActualizarDependencia(Dependencia dependencia)
    {
        bool resultado = false;
        try
        {
            DB.Conectar();
            string sSql = "DependenciaUpdProc @IdDependencia, @Descripcion, @Estado";
            DB.CrearComando(sSql);
            DB.AsignarParametroEntero("@IdDependencia", dependencia.IdDependencia);
            DB.AsignarParametroCadena("@Descripcion", dependencia.Descripcion);
            DB.AsignarParametroBoolean("@Estado", dependencia.Estado);
            DB.EjecutarComando();
            resultado = true;
        }
        catch (Exception ex)
        {
            throw new BaseDatosException($"Error al actualizar dependencia\r{ex.Message}");
        }
        finally
        {
            DB.Desconectar();
        }
        return resultado;
    }
}
