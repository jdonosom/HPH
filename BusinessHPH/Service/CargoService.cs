using HPHBusiness.Model;
using HPHDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPHBusiness.Service
{
    public class CargoService
    {
        private BaseDatos DB = null;

        public CargoService()
        {
            DB = new BaseDatos();
        }

        // Cambiar Cargo Obtener por List<Cargo> Obtener() para obtener todos los cargos
        public List<Cargo>? Obtener(int IdCargo)
        {
            List<Cargo> cargos = new List<Cargo>();
            try
            {
                DB.Conectar();
                string sSql = "CargoSelProc @IdCargo";
                DB.CrearComando(sSql);
                DB.AsignarParametroEntero("@IdCargo", IdCargo);
                var reader = DB.EjecutarConsulta();
                while (reader.Read())
                {
                    var cargo = new Cargo
                    {
                        IdCargo = reader.GetInt32(reader.GetOrdinal("IdCargo")),
                        Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                        Estado = reader.GetBoolean(reader.GetOrdinal("Estado"))
                    };
                    cargos.Add(cargo);

                }
            }
            catch (Exception ex)
            {
                throw new BaseDatosException($"Error al obtener datos: CargoGetProc\r{ex.Message}");
            }
            finally
            {
                DB.Desconectar();
            }
            return cargos;
        }

        public List<Cargo> ObtenerTodos(string? filtro = null)
        {
            List<Cargo> cargos = new List<Cargo>();

            try
            {
                DB.Conectar();

                string sSql = "CargoListProc @Filtro";
                DB.CrearComando(sSql);

                if (string.IsNullOrWhiteSpace(filtro))
                    DB.AsignarParametroNulo("@Filtro", System.Data.DbType.String);
                else
                    DB.AsignarParametroCadena("@Filtro", filtro);

                var reader = DB.EjecutarConsulta();

                while (reader.Read())
                {
                    Cargo cargo = new Cargo
                    {
                        IdCargo = reader.GetInt32(reader.GetOrdinal("IdCargo")),
                        Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                        Estado = reader.GetBoolean(reader.GetOrdinal("Estado"))
                    };

                    cargos.Add(cargo);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new BaseDatosException($"Error al obtener cargos\r{ex.Message}");
            }
            finally
            {
                DB.Desconectar();
            }

            return cargos;
        }

        public bool GuardarCargo(Cargo cargo)
        {
            bool resultado = false;
            try
            {
                DB.Conectar();

                string sSql = "CargoInsProc @Descripcion, @Estado";
                DB.CrearComando(sSql);
                DB.AsignarParametroCadena("@Descripcion", cargo.Descripcion);
                DB.AsignarParametroBoolean("@Estado", cargo.Estado);
                DB.EjecutarComando();
                resultado = true;
            }
            catch (Exception ex)
            {
                throw new BaseDatosException($"Error al guardar cargo: CargoInsProc\r{ex.Message}");
            }
            finally
            {
                DB.Desconectar();
            }
            return resultado;
        }

        public bool ActualizarCargo(Cargo cargo)
        {
            bool resultado = false;
            try
            {
                DB.Conectar();

                string sSql = "CargoUpdProc @IdCargo, @Descripcion, @Estado";
                DB.CrearComando(sSql);
                DB.AsignarParametroEntero("@IdCargo", cargo.IdCargo);
                DB.AsignarParametroCadena("@Descripcion", cargo.Descripcion);
                DB.AsignarParametroBoolean("@Estado", cargo.Estado);
                DB.EjecutarComando();
                resultado = true;
            }
            catch (Exception ex)
            {
                throw new BaseDatosException($"Error al actualizar cargo: CargoUpdProc\r{ex.Message}");
            }
            finally
            {
                DB.Desconectar();
            }
            return resultado;
        }

    }
}
