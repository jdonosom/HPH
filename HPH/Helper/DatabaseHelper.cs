using HPHBusiness.Model;
using HPHBusiness.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace HPH.Helper;

public static class DatabaseHelper
{

    public static bool GrabarEmpleado(Empleado empleado)
    {
        // Aquí iría la lógica para grabar el empleado en la base de datos
        // Por ejemplo, podrías usar ADO.NET, Entity Framework, Dapper, etc.
        // Este es un ejemplo simplificado que simula una inserción exitosa
        Console.WriteLine($"Empleado {empleado.NombreCompleto} grabado en la base de datos.");


        EmpleadoService employe = new();

        employe.GrabarEmpleado(empleado);



        return true;
    }

}
