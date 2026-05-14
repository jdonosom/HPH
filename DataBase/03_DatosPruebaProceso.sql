-- ========================================================
-- Datos de Prueba para Proceso (Períodos)
-- Base de Datos: CHPH
-- ========================================================

USE [CHPH]
GO

PRINT '========================================='
PRINT 'Insertando datos de prueba para Proceso'
PRINT '========================================='
PRINT ''

-- Verificar que no existan períodos antes de insertar
IF NOT EXISTS (SELECT 1 FROM Proceso WHERE Periodo = '202501')
BEGIN
    INSERT INTO Proceso (Periodo, Año, Descripcion, Apertura, Cierre, Cerrado, Estado)
    VALUES ('202501', 2025, 'Período Enero 2025', '2025-01-01', NULL, 0, 1);
    PRINT 'Período 202501 (Enero 2025) insertado - ACTIVO'
END
ELSE
    PRINT 'Período 202501 ya existe'

IF NOT EXISTS (SELECT 1 FROM Proceso WHERE Periodo = '202412')
BEGIN
    INSERT INTO Proceso (Periodo, Año, Descripcion, Apertura, Cierre, Cerrado, Estado)
    VALUES ('202412', 2024, 'Período Diciembre 2024', '2024-12-01', '2024-12-31', 1, 2);
    PRINT 'Período 202412 (Diciembre 2024) insertado - CERRADO'
END
ELSE
    PRINT 'Período 202412 ya existe'

IF NOT EXISTS (SELECT 1 FROM Proceso WHERE Periodo = '202411')
BEGIN
    INSERT INTO Proceso (Periodo, Año, Descripcion, Apertura, Cierre, Cerrado, Estado)
    VALUES ('202411', 2024, 'Período Noviembre 2024', '2024-11-01', '2024-11-30', 1, 2);
    PRINT 'Período 202411 (Noviembre 2024) insertado - CERRADO'
END
ELSE
    PRINT 'Período 202411 ya existe'

IF NOT EXISTS (SELECT 1 FROM Proceso WHERE Periodo = '202410')
BEGIN
    INSERT INTO Proceso (Periodo, Año, Descripcion, Apertura, Cierre, Cerrado, Estado)
    VALUES ('202410', 2024, 'Período Octubre 2024', '2024-10-01', '2024-10-31', 1, 2);
    PRINT 'Período 202410 (Octubre 2024) insertado - CERRADO'
END
ELSE
    PRINT 'Período 202410 ya existe'

PRINT ''
PRINT '========================================='
PRINT 'Datos de prueba insertados exitosamente'
PRINT '========================================='
GO
