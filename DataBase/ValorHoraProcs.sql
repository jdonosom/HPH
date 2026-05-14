USE [CHPH]
GO

-- ========================================================
-- ValorHoraSelProc - Obtener valor(es) hora por periodo e ID
-- ========================================================
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

-- ========================================================
-- ValorHoraListProc - Lista valores hora con filtro
-- ========================================================
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

-- ========================================================
-- ValorHoraInsProc - Insertar nuevo valor hora
-- ========================================================
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

-- ========================================================
-- ValorHoraUpdProc - Actualizar valor hora existente
-- ========================================================
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
