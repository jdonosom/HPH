# Modelo de Datos - Base de Datos CHPH

## Tabla: Boleta

### Estructura Real (según esquema de BD):

```sql
CREATE TABLE [dbo].[Boleta] (
    [Periodo]        CHAR (6)        NOT NULL,  -- Formato: YYYYMM (ej: 202605)
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
    PRIMARY KEY (Periodo, IdBoleta)
);
```

### Campos:

| Campo | Tipo | Descripción |
|-------|------|-------------|
| `Periodo` | CHAR(6) | Periodo de la boleta (YYYYMM) |
| `IdBoleta` | INT | Identificador único de boleta en el periodo |
| `IdDependencia` | INT | Referencia a tabla Dependencia |
| `IdTipoContrato` | INT | Referencia a tabla TipoContrato |
| `IdTipo` | INT | Tipo de boleta (requiere tabla catálogo) |
| `DP` | INT | Campo numérico (significado por definir) |
| `Bruto` | NUMERIC(18,4) | Monto bruto de la boleta |
| `JR` | INT | Campo numérico (significado por definir) |
| `Retencion` | NUMERIC(18,4) | Monto de retención |
| `Descuentos` | NUMERIC(18,4) | Monto de descuentos |
| `Liquido` | NUMERIC(18,4) | Monto líquido final |

## Notas Importantes:

### 1. Clave Primaria Compuesta
La tabla usa una clave primaria compuesta de `Periodo` + `IdBoleta`, lo que significa que:
- Los ID de boletas se reinician cada periodo
- Para identificar una boleta única necesitas ambos campos

### 2. Relación con Empleado
⚠️ **PENDIENTE**: El modelo actual NO incluye relación directa con la tabla `Empleado`.
Opciones posibles:
- Existe una tabla intermedia no documentada
- El campo `DP` podría ser el RUT del empleado
- Se requiere crear una tabla de relación

### 3. Tablas Requeridas (no incluidas en el modelo base):
- `Dependencia` (IdDependencia, Descripcion, Estado)
- `TipoContrato` (IdTipoContrato, Descripcion, Estado)
- `TipoBoleta` o catálogo para `IdTipo`

## Stored Procedures Implementados:

### `BoletaListProc`
```sql
EXEC BoletaListProc @Filtro = '202605'  -- Filtra por periodo
```
Lista boletas con filtro opcional por periodo.

### `BoletaSelPorPeriodoProc`
```sql
EXEC BoletaSelPorPeriodoProc @Periodo = '202605'
```
Obtiene todas las boletas de un periodo específico.

### `BoletaSelProc`
```sql
EXEC BoletaSelProc @Periodo = '202605', @IdBoleta = 123
```
Obtiene una boleta específica por periodo e ID.

## Formato de Periodo:

El campo `Periodo` usa formato `YYYYMM`:
- `202605` = Mayo 2026
- `202612` = Diciembre 2026

La propiedad `PeriodoFormateado` en el modelo C# convierte:
- `202605` → `05/2026`

## TODO - Pendientes:

1. ✅ Modelo Boleta actualizado
2. ✅ Stored Procedures básicos creados
3. ⚠️ Definir relación Boleta ↔ Empleado
4. ⚠️ Crear tablas catálogo (Dependencia, TipoContrato, TipoBoleta)
5. ⚠️ Documentar significado de campos DP y JR
6. ⚠️ Implementar búsqueda de boletas por empleado (cuando se defina la relación)
