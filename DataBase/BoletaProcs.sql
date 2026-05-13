USE [CHPH]
GO

-- ========================================================
-- BoletaListProc - Lista todas las boletas con filtro por periodo
-- ========================================================
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

-- ========================================================
-- BoletaSelPorEmpleadoYPeriodoProc - Obtiene boletas de un empleado en un periodo
-- ========================================================
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

-- ========================================================
-- BoletaSelPorPeriodoProc - Obtiene boletas de un periodo específico
-- ========================================================
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

-- ========================================================
-- BoletaSelProc - Obtiene una boleta específica
-- ========================================================
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

-- ========================================================
-- BoletaInsProc - Insertar nueva boleta
-- ========================================================
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

-- ========================================================
-- BoletaUpdProc - Actualizar boleta
-- ========================================================
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

