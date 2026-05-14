-- ========================================================
-- Stored Procedures para Proceso (Periodo)
-- Base de Datos: CHPH
-- ========================================================

USE [CHPH]
GO

-- ========================================================
-- ProcesoSelProc - Obtener periodos
-- ========================================================
PRINT 'Compilando: ProcesoSelProc...'
GO

CREATE OR ALTER PROCEDURE [dbo].[ProcesoSelProc]
    @Periodo CHAR(6) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Periodo,
        Año AS Anio,
        Descripcion,
        Apertura,
        Cierre,
        Cerrado,
        Estado
    FROM 
        Proceso
    WHERE 
        (@Periodo IS NULL OR Periodo = @Periodo)
    ORDER BY 
        Periodo DESC;
END
GO

PRINT 'ProcesoSelProc compilado correctamente.'
PRINT ''

-- ========================================================
-- ProcesoSelActualProc - Obtener periodo actual (en curso)
-- ========================================================
PRINT 'Compilando: ProcesoSelActualProc...'
GO

CREATE OR ALTER PROCEDURE [dbo].[ProcesoSelActualProc]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1
        Periodo,
        Año AS Anio,
        Descripcion,
        Apertura,
        Cierre,
        Cerrado,
        Estado
    FROM 
        Proceso
    WHERE 
        Estado = 1  -- En Curso
    ORDER BY 
        Periodo DESC;
END
GO

PRINT 'ProcesoSelActualProc compilado correctamente.'
PRINT ''

-- ========================================================
-- ProcesoListProc - Lista todos los periodos con filtro
-- ========================================================
PRINT 'Compilando: ProcesoListProc...'
GO

CREATE OR ALTER PROCEDURE [dbo].[ProcesoListProc]
    @Filtro VARCHAR(250) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Periodo,
        Año AS Anio,
        Descripcion,
        Apertura,
        Cierre,
        Cerrado,
        Estado
    FROM 
        Proceso
    WHERE 
        (@Filtro IS NULL OR 
         Descripcion LIKE '%' + @Filtro + '%' OR
         Periodo LIKE '%' + @Filtro + '%')
    ORDER BY 
        Periodo DESC;
END
GO

PRINT 'ProcesoListProc compilado correctamente.'
PRINT ''

-- ========================================================
-- ProcesoInsProc - Insertar nuevo periodo
-- ========================================================
PRINT 'Compilando: ProcesoInsProc...'
GO

CREATE OR ALTER PROCEDURE [dbo].[ProcesoInsProc]
    @Periodo CHAR(6),
    @Anio INT,
    @Descripcion VARCHAR(250),
    @Apertura DATETIME,
    @Cierre DATETIME = NULL,
    @Cerrado BIT,
    @Estado INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Validar que el periodo no exista
    IF EXISTS (SELECT 1 FROM Proceso WHERE Periodo = @Periodo)
    BEGIN
        RAISERROR('El periodo %s ya existe', 16, 1, @Periodo);
        RETURN;
    END

    -- Si el nuevo periodo es Estado = 1 (En Curso), desactivar los demas
    IF @Estado = 1
    BEGIN
        UPDATE Proceso SET Estado = 0 WHERE Estado = 1;
    END

    INSERT INTO Proceso (Periodo, Año, Descripcion, Apertura, Cierre, Cerrado, Estado)
    VALUES (@Periodo, @Anio, @Descripcion, @Apertura, @Cierre, @Cerrado, @Estado);
END
GO

PRINT 'ProcesoInsProc compilado correctamente.'
PRINT ''

-- ========================================================
-- ProcesoUpdProc - Actualizar periodo existente
-- ========================================================
PRINT 'Compilando: ProcesoUpdProc...'
GO

CREATE OR ALTER PROCEDURE [dbo].[ProcesoUpdProc]
    @Periodo CHAR(6),
    @Anio INT,
    @Descripcion VARCHAR(250),
    @Apertura DATETIME,
    @Cierre DATETIME = NULL,
    @Cerrado BIT,
    @Estado INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Si se establece Estado = 1 (En Curso), desactivar los demas
    IF @Estado = 1
    BEGIN
        UPDATE Proceso SET Estado = 0 WHERE Estado = 1 AND Periodo <> @Periodo;
    END

    UPDATE Proceso
    SET 
        Año = @Anio,
        Descripcion = @Descripcion,
        Apertura = @Apertura,
        Cierre = @Cierre,
        Cerrado = @Cerrado,
        Estado = @Estado
    WHERE 
        Periodo = @Periodo;
END
GO

PRINT 'ProcesoUpdProc compilado correctamente.'
PRINT ''

-- ========================================================
-- ProcesoSetActualProc - Establecer periodo como actual
-- ========================================================
PRINT 'Compilando: ProcesoSetActualProc...'
GO

CREATE OR ALTER PROCEDURE [dbo].[ProcesoSetActualProc]
    @Periodo CHAR(6)
AS
BEGIN
    SET NOCOUNT ON;

    -- Validar que el periodo exista
    IF NOT EXISTS (SELECT 1 FROM Proceso WHERE Periodo = @Periodo)
    BEGIN
        RAISERROR('El periodo %s no existe', 16, 1, @Periodo);
        RETURN;
    END

    -- Validar que el periodo no este cerrado
    IF EXISTS (SELECT 1 FROM Proceso WHERE Periodo = @Periodo AND Cerrado = 1)
    BEGIN
        RAISERROR('El periodo %s esta cerrado y no puede ser activado', 16, 1, @Periodo);
        RETURN;
    END

    -- Desactivar todos los periodos
    UPDATE Proceso SET Estado = 0 WHERE Estado = 1;

    -- Activar el periodo seleccionado
    UPDATE Proceso SET Estado = 1 WHERE Periodo = @Periodo;
END
GO

PRINT 'ProcesoSetActualProc compilado correctamente.'
PRINT ''

-- ========================================================
-- ProcesoCerrarProc - Cerrar un periodo
-- ========================================================
PRINT 'Compilando: ProcesoCerrarProc...'
GO

CREATE OR ALTER PROCEDURE [dbo].[ProcesoCerrarProc]
    @Periodo CHAR(6)
AS
BEGIN
    SET NOCOUNT ON;

    -- Validar que el periodo exista
    IF NOT EXISTS (SELECT 1 FROM Proceso WHERE Periodo = @Periodo)
    BEGIN
        RAISERROR('El periodo %s no existe', 16, 1, @Periodo);
        RETURN;
    END

    -- Validar que el periodo no este ya cerrado
    IF EXISTS (SELECT 1 FROM Proceso WHERE Periodo = @Periodo AND Cerrado = 1)
    BEGIN
        RAISERROR('El periodo %s ya esta cerrado', 16, 1, @Periodo);
        RETURN;
    END

    -- Cerrar el periodo
    UPDATE Proceso 
    SET 
        Cerrado = 1,
        Cierre = GETDATE(),
        Estado = 2  -- Estado Cerrado
    WHERE 
        Periodo = @Periodo;
END
GO

PRINT 'ProcesoCerrarProc compilado correctamente.'
PRINT ''

PRINT 'Stored procedures de Proceso compilados exitosamente.'
GO
