USE [CHPH]
GO

-- ========================================================
-- DependenciaSelProc - Obtener dependencia(s) por ID
-- ========================================================
CREATE OR ALTER PROCEDURE [dbo].[DependenciaSelProc]
    @IdDependencia INT = 0
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        IdDependencia,
        Descripcion,
        Estado
    FROM 
        Dependencia
    WHERE 
        (@IdDependencia = 0 OR IdDependencia = @IdDependencia)
        AND Estado = 1  -- Solo activas
    ORDER BY 
        Descripcion;
END
GO

-- ========================================================
-- TipoContratoSelProc - Obtener tipo(s) de contrato por ID
-- ========================================================
CREATE OR ALTER PROCEDURE [dbo].[TipoContratoSelProc]
    @IdTipoContrato INT = 0
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        IdTipoContrato,
        Descripcion,
        Estado
    FROM 
        TipoContrato
    WHERE 
        (@IdTipoContrato = 0 OR IdTipoContrato = @IdTipoContrato)
        AND Estado = 1  -- Solo activos
    ORDER BY 
        Descripcion;
END
GO
