using HPHBusiness.Model;
using HPHDataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace HPHBusiness.Service;

public class EmpleadoService
{

    private BaseDatos DB = null;

    public EmpleadoService()
    {
        DB = new BaseDatos();

    }

    public Empleado Obtener(int Rut, char Dv)
    {
        Empleado empleado = null;
        try
        {
            DB.Conectar();
            string sSql = "EmpleadoSelProc @Rut";
            DB.CrearComando(sSql);
            DB.AsignarParametroEntero("@Rut", Rut);

            var reader = DB.EjecutarConsulta();
            if (reader.Read())
            {
                empleado = new Empleado
                {
                    Rut = reader.GetInt32(reader.GetOrdinal("Rut")),
                    Dv = reader.GetString(reader.GetOrdinal("Dv")),
                    NombreCompleto = reader.GetString(reader.GetOrdinal("NombreCompleto")),
                    CodigoCargo = reader.GetInt32(reader.GetOrdinal("IdCargo"))
                };
            }
        }
        catch (Exception ex)
        {
            throw new BaseDatosException($"Error al obtener datos: EmpleadoGetProc\r{ex.Message}");
        }
        finally
        {
            DB.Desconectar();
        }
        return empleado;
    }


    public bool GrabarEmpleado(Empleado empleado)
    {
        bool lflag = false;
        try
        {
            DB.Conectar();

            string sSql = "EmpleadoInsProc @Rut, @Dv, @NombreCompleto, @IdCargo";
            DB.CrearComando(sSql);
            DB.AsignarParametroEntero("@Rut", empleado.Rut);
            DB.AsignarParametroCadena("@Dv", empleado.Dv);
            DB.AsignarParametroCadena("@NombreCompleto", empleado.NombreCompleto);
            DB.AsignarParametroEntero("@IdCargo", empleado.CodigoCargo);
            DB.EjecutarComando();
            lflag = true;
        }
        catch (Exception ex)
        {
            throw new BaseDatosException($"Error al grabar datos: EmpleadoInsProc\r{ex.Message}");
        }
        finally
        {
            DB.Desconectar();
        }
        return lflag;
    }

    public bool ActualizarEmpleado(Empleado empleado)
    {
        bool lflag = false;
        try
        {
            DB.Conectar();

            string sSql = "EmpleadoUpdProc @Rut, @Dv, @NombreCompleto, @IdCargo";
            DB.CrearComando(sSql);
            DB.AsignarParametroEntero("@Rut", empleado.Rut);
            DB.AsignarParametroCadena("@Dv", empleado.Dv);
            DB.AsignarParametroCadena("@NombreCompleto", empleado.NombreCompleto);
            DB.AsignarParametroEntero("@IdCargo", empleado.CodigoCargo);
            DB.EjecutarComando();
            lflag = true;
        }
        catch (Exception ex)
        {
            throw new BaseDatosException($"Error al actualizar datos: EmpleadoUpdProc\r{ex.Message}");
        }
        finally
        {
            DB.Desconectar();
        }
        return lflag;
    }

    public List<Empleado> ObtenerTodos(string? filtro = null)
    {
        List<Empleado> empleados = new List<Empleado>();

        try
        {
            DB.Conectar();

            string sSql = "EmpleadoListProc @Filtro";
            DB.CrearComando(sSql);

            if (string.IsNullOrWhiteSpace(filtro))
                DB.AsignarParametroNulo("@Filtro", System.Data.DbType.String);
            else
                DB.AsignarParametroCadena("@Filtro", filtro);

            var reader = DB.EjecutarConsulta();

            while (reader.Read())
            {
                Empleado empleado = new Empleado
                {
                    Rut = reader.GetInt32(reader.GetOrdinal("Rut")),
                    Dv = reader.GetString(reader.GetOrdinal("Dv")),
                    NombreCompleto = reader.GetString(reader.GetOrdinal("NombreCompleto")),
                    CodigoCargo = reader.GetInt32(reader.GetOrdinal("IdCargo")),
                    Cargo = reader.GetString(reader.GetOrdinal("Cargo"))
                };
                empleados.Add(empleado);
            }

            reader.Close();
        }
        catch (Exception ex)
        {
            throw new BaseDatosException($"Error al obtener empleados\r{ex.Message}");
        }
        finally
        {
            DB.Desconectar();
        }

        return empleados;
    }
}
