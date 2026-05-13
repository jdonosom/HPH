USE [CHPH]
GO

-- ========================================================
-- EmpleadoSelProc - Obtener empleado por RUT
-- ========================================================
CREATE OR ALTER PROCEDURE [dbo].[EmpleadoSelProc]
    @Rut INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        Rut,
        Dv,
        NombreCompleto,
        IdCargo
    FROM 
        Empleado
    WHERE 
        Rut = @Rut;
END
GO

-- ========================================================
-- EmpleadoInsProc - Insertar nuevo empleado
-- ========================================================
CREATE OR ALTER PROCEDURE [dbo].[EmpleadoInsProc]
    @Rut INT,
    @Dv CHAR(1),
    @NombreCompleto VARCHAR(150),
    @IdCargo INT
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO Empleado (Rut, Dv, NombreCompleto, IdCargo)
    VALUES (@Rut, @Dv, @NombreCompleto, @IdCargo);
END
GO
