USE [CHPH]
GO

-- ========================================================
-- CargoSelProc - Obtener cargo(s) por ID
-- ========================================================
-- Si @IdCargo = 0, devuelve todos los cargos
-- Si @IdCargo > 0, devuelve solo ese cargo
CREATE OR ALTER PROCEDURE [dbo].[CargoSelProc]
    @IdCargo INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        IdCargo,
        Descripcion,
        Estado
    FROM 
        Cargo
    WHERE 
        (@IdCargo = 0 OR IdCargo = @IdCargo)
    ORDER BY 
        Descripcion;
END
GO
