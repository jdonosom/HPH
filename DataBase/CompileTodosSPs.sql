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
-- ValorHoraSelProc - Obtener valores hora por periodo e ID
-- ========================================================
PRINT 'Compilando: ValorHoraSelProc...'
GO

CREATE OR ALTER PROCEDURE [dbo].[ValorHoraSelProc]
    @Periodo CHAR(6),
    @IdValorHora INT = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Periodo,
        IdValorHora,
        Descripcion,
        ValorHora,
        Estado
    FROM 
        ValorHora
    WHERE 
        Periodo = @Periodo
        AND (@IdValorHora = 0 OR IdValorHora = @IdValorHora)
    ORDER BY 
        IdValorHora;
END
GO

PRINT 'ValorHoraSelProc compilado correctamente.'
PRINT ''

-- ========================================================
-- ValorHoraListProc - Lista valores hora con filtro
-- ========================================================
PRINT 'Compilando: ValorHoraListProc...'
GO

CREATE OR ALTER PROCEDURE [dbo].[ValorHoraListProc]
    @Filtro VARCHAR(300) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Periodo,
        IdValorHora,
        Descripcion,
        ValorHora,
        Estado
    FROM 
        ValorHora
    WHERE 
        (@Filtro IS NULL OR Descripcion LIKE '%' + @Filtro + '%')
    ORDER BY 
        Periodo DESC, IdValorHora;
END
GO

PRINT 'ValorHoraListProc compilado correctamente.'
PRINT ''

-- ========================================================
-- ValorHoraInsProc - Insertar valor hora
-- ========================================================
PRINT 'Compilando: ValorHoraInsProc...'
GO

CREATE OR ALTER PROCEDURE [dbo].[ValorHoraInsProc]
    @Periodo CHAR(6),
    @IdValorHora INT,
    @Descripcion VARCHAR(300),
    @ValorHora DECIMAL(18,4),
    @Estado TINYINT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO ValorHora (Periodo, IdValorHora, Descripcion, ValorHora, Estado)
    VALUES (@Periodo, @IdValorHora, @Descripcion, @ValorHora, @Estado);
END
GO

PRINT 'ValorHoraInsProc compilado correctamente.'
PRINT ''

-- ========================================================
-- ValorHoraUpdProc - Actualizar valor hora
-- ========================================================
PRINT 'Compilando: ValorHoraUpdProc...'
GO

CREATE OR ALTER PROCEDURE [dbo].[ValorHoraUpdProc]
    @Periodo CHAR(6),
    @IdValorHora INT,
    @Descripcion VARCHAR(300),
    @ValorHora DECIMAL(18,4),
    @Estado TINYINT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE ValorHora
    SET 
        Descripcion = @Descripcion,
        ValorHora = @ValorHora,
        Estado = @Estado
    WHERE 
        Periodo = @Periodo
        AND IdValorHora = @IdValorHora;
END
GO

PRINT 'ValorHoraUpdProc compilado correctamente.'
PRINT ''

-- ========================================================
-- ValorHoraCargoSelProc - Obtener asignaciones por cargo
-- ========================================================
PRINT 'Compilando: ValorHoraCargoSelProc...'
GO

CREATE OR ALTER PROCEDURE [dbo].[ValorHoraCargoSelProc]
    @Periodo VARCHAR(6),
    @IdCargo INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        vhc.Periodo,
        vhc.IdCargo,
        CAST(vhc.IdValorHra AS INT) AS IdValorHora,
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

PRINT 'ValorHoraCargoSelProc compilado correctamente.'
PRINT ''

-- ========================================================
-- ValorHoraCargoInsProc - Insertar asignación
-- ========================================================
PRINT 'Compilando: ValorHoraCargoInsProc...'
GO

CREATE OR ALTER PROCEDURE [dbo].[ValorHoraCargoInsProc]
    @Periodo VARCHAR(6),
    @IdCargo INT,
    @IdValorHora INT
AS
BEGIN
    SET NOCOUNT ON;

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

PRINT 'ValorHoraCargoInsProc compilado correctamente.'
PRINT ''

-- ========================================================
-- ValorHoraCargoDelProc - Eliminar asignación específica
-- ========================================================
PRINT 'Compilando: ValorHoraCargoDelProc...'
GO

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

PRINT 'ValorHoraCargoDelProc compilado correctamente.'
PRINT ''

-- ========================================================
-- ValorHoraCargoDelAllProc - Eliminar todas las asignaciones
-- ========================================================
PRINT 'Compilando: ValorHoraCargoDelAllProc...'
GO

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

PRINT 'ValorHoraCargoDelAllProc compilado correctamente.'
PRINT ''

-- ========================================================
-- ProcesoSelProc - Obtener períodos
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
        Año,
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
-- ProcesoSelActualProc - Obtener período actual (en curso)
-- ========================================================
PRINT 'Compilando: ProcesoSelActualProc...'
GO

CREATE OR ALTER PROCEDURE [dbo].[ProcesoSelActualProc]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1
        Periodo,
        Año,
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
-- ProcesoListProc - Lista todos los períodos con filtro
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
        Año,
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
-- ProcesoInsProc - Insertar nuevo período
-- ========================================================
PRINT 'Compilando: ProcesoInsProc...'
GO

CREATE OR ALTER PROCEDURE [dbo].[ProcesoInsProc]
    @Periodo CHAR(6),
    @Año INT,
    @Descripcion VARCHAR(250),
    @Apertura DATETIME,
    @Cierre DATETIME = NULL,
    @Cerrado BIT,
    @Estado INT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM Proceso WHERE Periodo = @Periodo)
    BEGIN
        RAISERROR('El período %s ya existe', 16, 1, @Periodo);
        RETURN;
    END

    IF @Estado = 1
    BEGIN
        UPDATE Proceso SET Estado = 0 WHERE Estado = 1;
    END

    INSERT INTO Proceso (Periodo, Año, Descripcion, Apertura, Cierre, Cerrado, Estado)
    VALUES (@Periodo, @Año, @Descripcion, @Apertura, @Cierre, @Cerrado, @Estado);
END
GO

PRINT 'ProcesoInsProc compilado correctamente.'
PRINT ''

-- ========================================================
-- ProcesoUpdProc - Actualizar período existente
-- ========================================================
PRINT 'Compilando: ProcesoUpdProc...'
GO

CREATE OR ALTER PROCEDURE [dbo].[ProcesoUpdProc]
    @Periodo CHAR(6),
    @Año INT,
    @Descripcion VARCHAR(250),
    @Apertura DATETIME,
    @Cierre DATETIME = NULL,
    @Cerrado BIT,
    @Estado INT
AS
BEGIN
    SET NOCOUNT ON;

    IF @Estado = 1
    BEGIN
        UPDATE Proceso SET Estado = 0 WHERE Estado = 1 AND Periodo <> @Periodo;
    END

    UPDATE Proceso
    SET 
        Año = @Año,
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
-- ProcesoSetActualProc - Establecer período como actual
-- ========================================================
PRINT 'Compilando: ProcesoSetActualProc...'
GO

CREATE OR ALTER PROCEDURE [dbo].[ProcesoSetActualProc]
    @Periodo CHAR(6)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Proceso WHERE Periodo = @Periodo)
    BEGIN
        RAISERROR('El período %s no existe', 16, 1, @Periodo);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM Proceso WHERE Periodo = @Periodo AND Cerrado = 1)
    BEGIN
        RAISERROR('El período %s está cerrado y no puede ser activado', 16, 1, @Periodo);
        RETURN;
    END

    UPDATE Proceso SET Estado = 0 WHERE Estado = 1;
    UPDATE Proceso SET Estado = 1 WHERE Periodo = @Periodo;
END
GO

PRINT 'ProcesoSetActualProc compilado correctamente.'
PRINT ''

-- ========================================================
-- ProcesoCerrarProc - Cerrar un período
-- ========================================================
PRINT 'Compilando: ProcesoCerrarProc...'
GO

CREATE OR ALTER PROCEDURE [dbo].[ProcesoCerrarProc]
    @Periodo CHAR(6)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Proceso WHERE Periodo = @Periodo)
    BEGIN
        RAISERROR('El período %s no existe', 16, 1, @Periodo);
        RETURN;
    END

    IF EXISTS (SELECT 1 FROM Proceso WHERE Periodo = @Periodo AND Cerrado = 1)
    BEGIN
        RAISERROR('El período %s ya está cerrado', 16, 1, @Periodo);
        RETURN;
    END

    UPDATE Proceso 
    SET 
        Cerrado = 1,
        Cierre = GETDATE(),
        Estado = 2
    WHERE 
        Periodo = @Periodo;
END
GO

PRINT 'ProcesoCerrarProc compilado correctamente.'
PRINT ''

-- ========================================================
-- Aquí puedes agregar más SPs en el futuro
-- ========================================================

PRINT '========================================='
PRINT 'Compilación completada exitosamente'
PRINT '========================================='
GO
