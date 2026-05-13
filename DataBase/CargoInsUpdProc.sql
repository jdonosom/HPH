USE [CHPH]
GO

-- ========================================================
-- CargoInsProc - Insertar nuevo cargo
-- ========================================================
CREATE OR ALTER PROCEDURE [dbo].[CargoInsProc]
    @Descripcion VARCHAR(150),
    @Estado BIT
AS
BEGIN
    SET NOCOUNT ON;
    
    INSERT INTO Cargo (Descripcion, Estado)
    VALUES (@Descripcion, @Estado);
    
    SELECT SCOPE_IDENTITY() AS IdCargo;
END
GO

-- ========================================================
-- CargoUpdProc - Actualizar cargo existente
-- ========================================================
CREATE OR ALTER PROCEDURE [dbo].[CargoUpdProc]
    @IdCargo INT,
    @Descripcion VARCHAR(150),
    @Estado BIT
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE Cargo
    SET 
        Descripcion = @Descripcion,
        Estado = @Estado
    WHERE IdCargo = @IdCargo;
END
GO
