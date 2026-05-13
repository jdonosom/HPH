-- ========================================================
-- Script Maestro para Compilar Todos los Stored Procedures
-- Base de Datos: CHPH
-- ========================================================

USE [CHPH]
GO

PRINT '========================================='
PRINT 'Iniciando compilación de Stored Procedures'
PRINT '========================================='
PRINT ''

-- ========================================================
-- EmpleadoListProc - Lista empleados con filtro
-- ========================================================
PRINT 'Compilando: EmpleadoListProc...'
GO

CREATE OR ALTER PROCEDURE [dbo].[EmpleadoListProc]
    @Filtro VARCHAR(150) = NULL
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

PRINT 'EmpleadoListProc compilado correctamente.'
PRINT ''

-- ========================================================
-- EmpleadoSelProc - Obtener empleado por RUT
-- ========================================================
PRINT 'Compilando: EmpleadoSelProc...'
GO

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

PRINT 'EmpleadoSelProc compilado correctamente.'
PRINT ''

-- ========================================================
-- EmpleadoInsProc - Insertar nuevo empleado
-- ========================================================
PRINT 'Compilando: EmpleadoInsProc...'
GO

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

PRINT 'EmpleadoInsProc compilado correctamente.'
PRINT ''

-- ========================================================
-- CargoListProc - Lista cargos con filtro
-- ========================================================
PRINT 'Compilando: CargoListProc...'
GO

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

PRINT 'CargoListProc compilado correctamente.'
PRINT ''

-- ========================================================
-- CargoSelProc - Obtener cargo(s) por ID
-- ========================================================
PRINT 'Compilando: CargoSelProc...'
GO

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

PRINT 'CargoSelProc compilado correctamente.'
PRINT ''

-- ========================================================
-- EmpleadoUpdProc - Actualizar empleado
-- ========================================================
PRINT 'Compilando: EmpleadoUpdProc...'
GO

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

PRINT 'EmpleadoUpdProc compilado correctamente.'
PRINT ''

-- ========================================================
-- CargoInsProc - Insertar cargo
-- ========================================================
PRINT 'Compilando: CargoInsProc...'
GO

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

PRINT 'CargoInsProc compilado correctamente.'
PRINT ''

-- ========================================================
-- CargoUpdProc - Actualizar cargo
-- ========================================================
PRINT 'Compilando: CargoUpdProc...'
GO

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

PRINT 'CargoUpdProc compilado correctamente.'
PRINT ''

-- ========================================================
-- BoletaListProc - Lista boletas con filtro por periodo
-- ========================================================
PRINT 'Compilando: BoletaListProc...'
GO

CREATE OR ALTER PROCEDURE [dbo].[BoletaListProc]
    @Filtro VARCHAR(6) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        b.Periodo,
        b.IdBoleta,
        b.IdDependencia,
        b.IdTipoContrato,
        b.IdTipo,
        b.DP,
        b.Bruto,
        b.JR,
        b.Retencion,
        b.Descuentos,
        b.Liquido
    FROM 
        Boleta b
    WHERE 
        (@Filtro IS NULL OR b.Periodo LIKE @Filtro + '%')
    ORDER BY 
        b.Periodo DESC, b.IdBoleta;
END
GO

PRINT 'BoletaListProc compilado correctamente.'
PRINT ''

-- ========================================================
-- BoletaSelPorEmpleadoYPeriodoProc - Boletas por empleado y periodo
-- ========================================================
PRINT 'Compilando: BoletaSelPorEmpleadoYPeriodoProc...'
GO

CREATE OR ALTER PROCEDURE [dbo].[BoletaSelPorEmpleadoYPeriodoProc]
    @RutEmpleado INT,
    @Periodo CHAR(6)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        b.Periodo,
        b.IdBoleta,
        b.IdDependencia,
        b.IdTipoContrato,
        b.IdTipo,
        b.DP,
        b.Bruto,
        b.JR,
        b.Retencion,
        b.Descuentos,
        b.Liquido
    FROM 
        Boleta b
    WHERE 
        b.DP = @RutEmpleado
        AND b.Periodo = @Periodo
    ORDER BY 
        b.IdBoleta;
END
GO

PRINT 'BoletaSelPorEmpleadoYPeriodoProc compilado correctamente.'
PRINT ''

-- ========================================================
-- BoletaSelPorPeriodoProc - Boletas por periodo
-- ========================================================
PRINT 'Compilando: BoletaSelPorPeriodoProc...'
GO

CREATE OR ALTER PROCEDURE [dbo].[BoletaSelPorPeriodoProc]
    @Periodo CHAR(6)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        b.Periodo,
        b.IdBoleta,
        b.IdDependencia,
        b.IdTipoContrato,
        b.IdTipo,
        b.DP,
        b.Bruto,
        b.JR,
        b.Retencion,
        b.Descuentos,
        b.Liquido
    FROM 
        Boleta b
    WHERE 
        b.Periodo = @Periodo
    ORDER BY 
        b.IdBoleta;
END
GO

PRINT 'BoletaSelPorPeriodoProc compilado correctamente.'
PRINT ''

-- ========================================================
-- BoletaSelProc - Obtiene una boleta específica
-- ========================================================
PRINT 'Compilando: BoletaSelProc...'
GO

CREATE OR ALTER PROCEDURE [dbo].[BoletaSelProc]
    @Periodo CHAR(6),
    @IdBoleta INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Periodo,
        IdBoleta,
        IdDependencia,
        IdTipoContrato,
        IdTipo,
        DP,
        Bruto,
        JR,
        Retencion,
        Descuentos,
        Liquido
    FROM 
        Boleta
    WHERE 
        Periodo = @Periodo
        AND IdBoleta = @IdBoleta;
END
GO

PRINT 'BoletaSelProc compilado correctamente.'
PRINT ''

-- ========================================================
-- BoletaInsProc - Insertar boleta
-- ========================================================
PRINT 'Compilando: BoletaInsProc...'
GO

CREATE OR ALTER PROCEDURE [dbo].[BoletaInsProc]
    @Periodo CHAR(6),
    @IdBoleta INT,
    @IdDependencia INT,
    @IdTipoContrato INT,
    @IdTipo INT,
    @DP INT,
    @Bruto NUMERIC(18,4),
    @JR INT,
    @Retencion NUMERIC(18,4),
    @Descuentos NUMERIC(18,4),
    @Liquido NUMERIC(18,4)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Boleta (
        Periodo, IdBoleta, IdDependencia, IdTipoContrato, IdTipo,
        DP, Bruto, JR, Retencion, Descuentos, Liquido
    )
    VALUES (
        @Periodo, @IdBoleta, @IdDependencia, @IdTipoContrato, @IdTipo,
        @DP, @Bruto, @JR, @Retencion, @Descuentos, @Liquido
    );
END
GO

PRINT 'BoletaInsProc compilado correctamente.'
PRINT ''

-- ========================================================
-- BoletaUpdProc - Actualizar boleta
-- ========================================================
PRINT 'Compilando: BoletaUpdProc...'
GO

CREATE OR ALTER PROCEDURE [dbo].[BoletaUpdProc]
    @Periodo CHAR(6),
    @IdBoleta INT,
    @IdDependencia INT,
    @IdTipoContrato INT,
    @IdTipo INT,
    @DP INT,
    @Bruto NUMERIC(18,4),
    @JR INT,
    @Retencion NUMERIC(18,4),
    @Descuentos NUMERIC(18,4),
    @Liquido NUMERIC(18,4)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Boleta
    SET 
        IdDependencia = @IdDependencia,
        IdTipoContrato = @IdTipoContrato,
        IdTipo = @IdTipo,
        DP = @DP,
        Bruto = @Bruto,
        JR = @JR,
        Retencion = @Retencion,
        Descuentos = @Descuentos,
        Liquido = @Liquido
    WHERE 
        Periodo = @Periodo
        AND IdBoleta = @IdBoleta;
END
GO

PRINT 'BoletaUpdProc compilado correctamente.'
PRINT ''

-- ========================================================
-- DependenciaSelProc - Obtener dependencias
-- ========================================================
PRINT 'Compilando: DependenciaSelProc...'
GO

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

PRINT 'DependenciaSelProc compilado correctamente.'
PRINT ''

-- ========================================================
-- TipoContratoSelProc - Obtener tipos de contrato
-- ========================================================
PRINT 'Compilando: TipoContratoSelProc...'
GO

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

PRINT 'TipoContratoSelProc compilado correctamente.'
PRINT ''

-- ========================================================
-- Aquí puedes agregar más SPs en el futuro
-- ========================================================

PRINT '========================================='
PRINT 'Compilación completada exitosamente'
PRINT '========================================='
GO
