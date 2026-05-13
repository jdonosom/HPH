USE [CHPH]
GO

-- Stored Procedure para listar cargos con filtro por descripción
CREATE OR ALTER PROCEDURE [dbo].[CargoListProc]
    @Filtro VARCHAR(150) = NULL
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
        (@Filtro IS NULL OR Descripcion LIKE '%' + @Filtro + '%')
    ORDER BY 
        Descripcion;
END
GO
