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

    }
}
