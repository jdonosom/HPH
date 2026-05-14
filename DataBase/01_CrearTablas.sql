-- ========================================================
-- Script de Creación de Tablas - Base de Datos CHPH
-- ========================================================

USE [CHPH]
GO

-- ========================================================
-- Tabla: Empleado
-- Descripción: Almacena información básica de empleados
-- ========================================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Empleado]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Empleado] (
        [Rut]            INT           NOT NULL,
        [Dv]             CHAR (1)      NULL,
        [NombreCompleto] VARCHAR (150) NULL,
        [IdCargo]        INT           NOT NULL,
        CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED ([Rut] ASC),
        CONSTRAINT [FK_Empleado_Cargo] FOREIGN KEY ([IdCargo]) REFERENCES [dbo].[Cargo]([IdCargo])
    );
    
    PRINT 'Tabla Empleado creada correctamente.';
END
ELSE
BEGIN
    PRINT 'La tabla Empleado ya existe.';
END
GO

-- ========================================================
-- Tabla: Cargo
-- Descripción: Catálogo de cargos/puestos de trabajo
-- ========================================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cargo]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Cargo] (
        [IdCargo]     INT           IDENTITY(1,1) NOT NULL,
        [Descripcion] VARCHAR(150)  NOT NULL,
        [Estado]      BIT           NOT NULL DEFAULT(1),
        CONSTRAINT [PK_Cargo] PRIMARY KEY CLUSTERED ([IdCargo] ASC)
    );
    
    PRINT 'Tabla Cargo creada correctamente.';
END
ELSE
BEGIN
    PRINT 'La tabla Cargo ya existe.';
END
GO

-- ========================================================
-- Tabla: Boleta
-- Descripción: Registros de boletas de honorarios
-- ========================================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Boleta]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Boleta] (
        [Periodo]        CHAR (6)        NOT NULL,
        [IdBoleta]       INT             NOT NULL,
        [IdDependencia]  INT             NOT NULL,
        [IdTipoContrato] INT             NOT NULL,
        [IdTipo]         INT             NOT NULL,
        [DP]             INT             NULL,
        [Bruto]          NUMERIC (18, 4) NULL,
        [JR]             INT             NULL,
        [Retencion]      NUMERIC (18, 4) NULL,
        [Descuentos]     NUMERIC (18, 4) NULL,
        [Liquido]        NUMERIC (18, 4) NULL,
        CONSTRAINT [PK_Boleta] PRIMARY KEY CLUSTERED ([Periodo] ASC, [IdBoleta] ASC)
    );

    PRINT 'Tabla Boleta creada correctamente.';
END
ELSE
BEGIN
    PRINT 'La tabla Boleta ya existe.';
END
GO

-- ========================================================
-- Tabla: Dependencia (Opcional)
-- Descripción: Catálogo de dependencias organizacionales
-- ========================================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Dependencia]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Dependencia] (
        [IdDependencia] INT           IDENTITY(1,1) NOT NULL,
        [Descripcion]   VARCHAR(200)  NULL,
        [Estado]        BIT           NULL DEFAULT(1),
        CONSTRAINT [PK_Dependencia] PRIMARY KEY CLUSTERED ([IdDependencia] ASC)
    );

    PRINT 'Tabla Dependencia creada correctamente.';
END
ELSE
BEGIN
    PRINT 'La tabla Dependencia ya existe.';
END
GO

-- ========================================================
-- Tabla: TipoContrato (Opcional)
-- Descripción: Catálogo de tipos de contrato
-- ========================================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TipoContrato]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[TipoContrato] (
        [IdTipoContrato] INT       IDENTITY(1,1) NOT NULL,
        [Descripcion]    CHAR(10)  NULL,
        [Estado]         BIT       NULL DEFAULT(1),
        CONSTRAINT [PK_TipoContrato] PRIMARY KEY CLUSTERED ([IdTipoContrato] ASC)
    );

    PRINT 'Tabla TipoContrato creada correctamente.';
END
ELSE
BEGIN
    PRINT 'La tabla TipoContrato ya existe.';
END
GO

PRINT '========================================='
PRINT 'Creación de tablas completada'
PRINT '========================================='
GO

-- ========================================================
-- Tabla: ValorHora
-- Descripción: Catálogo de valores hora por periodo
-- ========================================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ValorHora]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[ValorHora](
        [Periodo] [char](6) NOT NULL,
        [IdValorHora] [int] NOT NULL,
        [Descripcion] [varchar](300) NOT NULL,
        [ValorHora] [decimal](18, 4) NOT NULL,
        [Estado] [tinyint] NOT NULL DEFAULT(1),
        CONSTRAINT [PK4] PRIMARY KEY NONCLUSTERED 
        (
            [Periodo] ASC,
            [IdValorHora] ASC
        )
    );

    PRINT 'Tabla ValorHora creada correctamente.';
END
ELSE
BEGIN
    PRINT 'La tabla ValorHora ya existe.';
END
GO
