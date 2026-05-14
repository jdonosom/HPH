USE [CHPH]
GO

-- ========================================================
-- ValorHoraCargoSelProc - Obtener asignaciones por cargo
-- ========================================================
CREATE OR ALTER PROCEDURE [dbo].[ValorHoraCargoSelProc]
    @Periodo VARCHAR(6),
    @IdCargo INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        vhc.Periodo,
        vhc.IdCargo,
        vhc.IdValorHra AS IdValorHora,
        c.Descripcion AS CargoDescripcion,
        vh.Descripcion AS ValorHoraDescripcion,
        vh.ValorHora AS ValorHoraMonto
    FROM 
        ValorHoraCargo vhc
        INNER JOIN Cargo c ON vhc.IdCargo = c.IdCargo
        INNER JOIN ValorHora vh ON vhc.Periodo = vh.Periodo AND CAST(vhc.IdValorHra AS INT) = vh.IdValorHora
    WHERE 
        vhc.Periodo = @Periodo
        AND vhc.IdCargo = @IdCargo
    ORDER BY 
        vh.IdValorHora;
END
GO

-- ========================================================
-- ValorHoraCargoInsProc - Insertar asignación
-- ========================================================
CREATE OR ALTER PROCEDURE [dbo].[ValorHoraCargoInsProc]
    @Periodo VARCHAR(6),
    @IdCargo INT,
    @IdValorHora INT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Verificar que no exista la asignación
    IF NOT EXISTS (
        SELECT 1 FROM ValorHoraCargo 
        WHERE Periodo = @Periodo 
        AND IdCargo = @IdCargo 
        AND CAST(IdValorHra AS INT) = @IdValorHora
    )
    BEGIN
        INSERT INTO ValorHoraCargo (Periodo, IdCargo, IdValorHra)
        VALUES (@Periodo, @IdCargo, CAST(@IdValorHora AS NCHAR(10)));
    END
END
GO

-- ========================================================
-- ValorHoraCargoDelProc - Eliminar una asignación específica
-- ========================================================
CREATE OR ALTER PROCEDURE [dbo].[ValorHoraCargoDelProc]
    @Periodo VARCHAR(6),
    @IdCargo INT,
    @IdValorHora INT
AS
BEGIN
    SET NOCOUNT ON;
    
    DELETE FROM ValorHoraCargo
    WHERE Periodo = @Periodo
        AND IdCargo = @IdCargo
        AND CAST(IdValorHra AS INT) = @IdValorHora;
END
GO

-- ========================================================
-- ValorHoraCargoDelAllProc - Eliminar todas las asignaciones de un cargo
-- ========================================================
CREATE OR ALTER PROCEDURE [dbo].[ValorHoraCargoDelAllProc]
    @Periodo VARCHAR(6),
    @IdCargo INT
AS
BEGIN
    SET NOCOUNT ON;
    
    DELETE FROM ValorHoraCargo
    WHERE Periodo = @Periodo
        AND IdCargo = @IdCargo;
END
GO
