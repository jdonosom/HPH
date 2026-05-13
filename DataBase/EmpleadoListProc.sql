USE [CHPH]
GO

-- Stored Procedure para listar empleados con filtro por nombre
CREATE OR ALTER PROCEDURE [dbo].[EmpleadoListProc]
(
    @Filtro VARCHAR(150) = NULL
) 
-- WITH ENCRYPTION
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        e.Rut,
        e.Dv,
        e.NombreCompleto,
        e.IdCargo,
        c.Descripcion AS Cargo
    FROM 
        Empleado e
        INNER JOIN Cargo c ON e.IdCargo = c.IdCargo
    WHERE 
        (@Filtro IS NULL OR e.NombreCompleto LIKE '%' + @Filtro + '%')
    ORDER BY 
        e.NombreCompleto;
END
GO
