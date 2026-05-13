USE [CHPH]
GO

-- ========================================================
-- EmpleadoUpdProc - Actualizar empleado existente
-- ========================================================
CREATE OR ALTER PROCEDURE [dbo].[EmpleadoUpdProc]
    @Rut INT,
    @Dv CHAR(1),
    @NombreCompleto VARCHAR(150),
    @IdCargo INT
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE Empleado
    SET 
        Dv = @Dv,
        NombreCompleto = @NombreCompleto,
        IdCargo = @IdCargo
    WHERE Rut = @Rut;
END
GO
