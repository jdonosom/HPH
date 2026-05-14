-- ========================================================
-- Stored Procedures para Dependencia
-- Base de Datos: CHPH
-- ========================================================

USE [CHPH]
GO

-- ========================================================
-- DependenciaListProc - Lista todas las dependencias con filtro
-- ========================================================
PRINT 'Compilando: DependenciaListProc...'
GO

CREATE OR ALTER PROCEDURE [dbo].[DependenciaListProc]
    @Filtro VARCHAR(200) = NULL
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
        (@Filtro IS NULL OR Descripcion LIKE '%' + @Filtro + '%')
    ORDER BY 
        Descripcion;
END
GO

PRINT 'DependenciaListProc compilado correctamente.'
PRINT ''

-- ========================================================
-- DependenciaInsProc - Insertar nueva dependencia
-- ========================================================
PRINT 'Compilando: DependenciaInsProc...'
GO

CREATE OR ALTER PROCEDURE [dbo].[DependenciaInsProc]
    @Descripcion VARCHAR(200),
    @Estado BIT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Dependencia (Descripcion, Estado)
    VALUES (@Descripcion, @Estado);
END
GO

PRINT 'DependenciaInsProc compilado correctamente.'
PRINT ''

-- ========================================================
-- DependenciaUpdProc - Actualizar dependencia existente
-- ========================================================
PRINT 'Compilando: DependenciaUpdProc...'
GO

CREATE OR ALTER PROCEDURE [dbo].[DependenciaUpdProc]
    @IdDependencia INT,
    @Descripcion VARCHAR(200),
    @Estado BIT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Dependencia
    SET 
        Descripcion = @Descripcion,
        Estado = @Estado
    WHERE 
        IdDependencia = @IdDependencia;
END
GO

PRINT 'DependenciaUpdProc compilado correctamente.'
PRINT ''

PRINT 'Stored procedures de Dependencia compilados exitosamente.'
GO
