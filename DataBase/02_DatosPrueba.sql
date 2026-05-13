USE [CHPH]
GO

-- ========================================================
-- Script de Datos de Prueba - Dependencias y Tipos de Contrato
-- ========================================================

-- Insertar datos reales en Dependencia
PRINT 'Insertando datos en Dependencia...';

SET IDENTITY_INSERT Dependencia ON;

-- Eliminar datos existentes si es necesario (opcional)
-- DELETE FROM Dependencia;

MERGE Dependencia AS Target
USING (VALUES
    (1, 'SAPU LA GRANJA', 1),
    (2, 'SAPU GRANJA SUR', 1),
    (3, 'SAPU PEG', 1),
    (4, 'SAPU MCONCHA', 1),
    (5, 'CONST. PADRE ESTEBAN GUMUCIO', 1),
    (6, 'CESFAM GRANJA SUR', 1),
    (7, 'AMBULANCIAS Y CONSULTORIOS', 1),
    (8, 'CESFAM MALAQUIAS CONCHA', 1),
    (9, 'CENTRO DE DIALISIS', 1),
    (10, 'SAPU DENTAL', 1),
    (11, 'HIPOTERAPIA', 1),
    (12, 'CESFAM LA GRANJA', 1),
    (13, 'D.A.S.M.', 1),
    (14, 'CENTRO DE ESTERILIZACION', 1),
    (15, 'PROMOCION DE SALUD', 1),
    (16, 'CAID', 1),
    (17, 'MEJOR E INFRA', 1),
    (18, 'Dental Comunitario', 1),
    (19, 'CENTRO PODOLOGICO', 1),
    (20, 'CECOSF YUNGAY', 1),
    (21, 'COSAM', 1),
    (22, 'UAPO', 1),
    (23, 'CCR SAN GREGORIO', 1),
    (24, 'PODOLOGICO GRANJA', 1),
    (25, 'CECOSF MILLALEMU', 1)
) AS Source (IdDependencia, Descripcion, Estado)
ON Target.IdDependencia = Source.IdDependencia
WHEN MATCHED THEN
    UPDATE SET 
        Descripcion = Source.Descripcion,
        Estado = Source.Estado
WHEN NOT MATCHED BY TARGET THEN
    INSERT (IdDependencia, Descripcion, Estado)
    VALUES (Source.IdDependencia, Source.Descripcion, Source.Estado);

SET IDENTITY_INSERT Dependencia OFF;

PRINT '25 dependencias insertadas/actualizadas correctamente.';
GO

-- Insertar datos de prueba en TipoContrato
IF NOT EXISTS (SELECT * FROM TipoContrato WHERE IdTipoContrato = 1)
BEGIN
    SET IDENTITY_INSERT TipoContrato ON;
    
    INSERT INTO TipoContrato (IdTipoContrato, Descripcion, Estado) VALUES
    (1, 'Honorarios', 1),
    (2, 'Planta', 1),
    (3, 'Contrata', 1),
    (4, 'Código Trabajo', 1),
    (5, 'Reemplazo', 1);
    
    SET IDENTITY_INSERT TipoContrato OFF;
    
    PRINT 'Datos de prueba insertados en TipoContrato.';
END
ELSE
BEGIN
    PRINT 'TipoContrato ya contiene datos.';
END
GO

PRINT '========================================='
PRINT 'Datos de prueba cargados correctamente'
PRINT '========================================='
GO
