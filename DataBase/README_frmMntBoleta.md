# Implementación frmMntBoleta - Búsqueda por Empleado

## ✅ Cambios Implementados

### 1. **Stored Procedures Actualizados**

#### **`BoletaSelPorEmpleadoYPeriodoProc`** (NUEVO)
```sql
EXEC BoletaSelPorEmpleadoYPeriodoProc @RutEmpleado = 12345678, @Periodo = '202501'
```
Obtiene todas las boletas de un empleado específico en un periodo determinado.
**Nota:** El campo `DP` en la tabla Boleta corresponde al RUT del empleado.

#### **`BoletaInsProc`** (NUEVO)
Inserta una nueva boleta con todos sus campos.

#### **`BoletaUpdProc`** (NUEVO)
Actualiza una boleta existente.

### 2. **BoletaService - Nuevo Método**

```csharp
public List<Boleta> ObtenerPorEmpleadoYPeriodo(int rutEmpleado, string periodo)
```
Servicio que consulta las boletas de un empleado en un periodo específico.

### 3. **frmMntBoleta - Funcionalidad Completa**

#### **Comportamiento del botón btnHelp:**
1. ✅ Abre `frmBuscarEmpleado` (NO frmBuscarBoleta)
2. ✅ Permite seleccionar un empleado
3. ✅ Carga datos del empleado en txtRut, txtNombre, cmbCargo
4. ✅ Carga SOLO las boletas del empleado para el periodo `202501`
5. ✅ Deshabilita los campos del empleado (no editables)

#### **DataGridView Editable:**
```csharp
dataGridView1.AllowUserToAddRows = true;
dataGridView1.AllowUserToDeleteRows = true;
dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
dataGridView1.ReadOnly = false;
```

**Columnas Editables:**
- ✅ `colDependencia` - ComboBox (IdDependencia)
- ✅ `colTipoContrato` - ComboBox (IdTipoContrato)
- ✅ `colNroBoleta` - TextBox numérico
- ✅ `colMntBruto` - TextBox decimal
- ✅ `colMntRetencion` - TextBox decimal
- ✅ `colMntDescuento` - TextBox decimal
- ✅ `colMntLiquido` - TextBox decimal
- ✅ `colTipo` - TextBox/ComboBox
- ✅ `colPeriodo` - ReadOnly (autocalculado)

**Columnas NO Editables:**
- 🔒 `colId` - ID de boleta (PK)

### 4. **Periodo Fijo**
```csharp
private const string PERIODO_ACTUAL = "202501"; // Enero 2025
```
Puedes cambiar este valor en el código si necesitas otro periodo.

## 📋 Modelo de Datos Aclarado

### **Tabla Boleta - Relación con Empleado:**
```sql
CREATE TABLE [dbo].[Boleta] (
    [Periodo]        CHAR(6)        NOT NULL,  -- YYYYMM: 202501
    [IdBoleta]       INT            NOT NULL,  -- ID único en el periodo
    [IdDependencia]  INT            NOT NULL,
    [IdTipoContrato] INT            NOT NULL,
    [IdTipo]         INT            NOT NULL,
    [DP]             INT            NULL,      -- ⭐ RUT del Empleado
    [Bruto]          NUMERIC(18,4)  NULL,
    [JR]             INT            NULL,
    [Retencion]      NUMERIC(18,4)  NULL,
    [Descuentos]     NUMERIC(18,4)  NULL,
    [Liquido]        NUMERIC(18,4)  NULL,
    PRIMARY KEY (Periodo, IdBoleta)
);
```

**Aclaración Campo DP:**
- ✅ `DP` = RUT del Empleado (relación con tabla Empleado)
- Se usa para filtrar boletas por empleado

## 🎯 Flujo de Uso

1. **Usuario abre frmMntBoleta**
2. **Hace clic en botón "?" (btnHelp)**
3. **Se abre frmBuscarEmpleado:**
   - Filtra empleados por nombre
   - Selecciona un empleado con doble clic o botón "Seleccionar"
4. **Se cargan los datos:**
   - RUT, Nombre, Cargo del empleado
   - Todas las boletas del empleado para periodo `202501`
5. **Usuario puede:**
   - ✏️ Editar boletas existentes (montos, dependencia, tipo contrato)
   - ➕ Agregar nuevas filas
   - 🗑️ Eliminar filas
6. **Guardar cambios:**
   - TODO: Implementar guardado al modificar celdas
   - TODO: Agregar botón "Guardar Todo"

## ⚠️ Pendientes / TODO

### 1. **Cargar ComboBox en columnas:**
```csharp
// Necesitas implementar:
private void CargarCombosDependencia()
{
    // Cargar datos desde tabla Dependencia
    // Asignar a colDependencia.DataSource
}

private void CargarCombosTipoContrato()
{
    // Cargar datos desde tabla TipoContrato
    // Asignar a colTipoContrato.DataSource
}
```

### 2. **Implementar Guardado:**
```csharp
private void GuardarBoleta(DataGridViewRow row)
{
    // Validar datos
    // Llamar a BoletaService.GuardarBoleta() o ActualizarBoleta()
}
```

### 3. **Validaciones:**
- Verificar que los montos sean numéricos
- Validar que el líquido = bruto - retención - descuentos
- Verificar que IdBoleta sea único en el periodo

### 4. **Tabla BoletaDetalle:**
La tabla `BoletaDetalle` está definida pero no se usa actualmente.
```sql
CREATE TABLE [dbo].[BoletaDetalle] (
    [Periodo]     CHAR(6) NOT NULL,
    [IdBoleta]    INT     NOT NULL,
    [Item]        INT     NOT NULL,
    [IdValorHora] INT     NOT NULL
);
```
**TODO:** Definir qué representa y cómo se relaciona con Boleta.

## 📝 Ejecutar SPs

```powershell
cd E:\DESARROLLOS\Salud\tmp\HPH\DataBase
.\EjecutarSPs.ps1
```

O manualmente:
```sql
-- Ejecutar script maestro
USE CHPH
GO
-- Copiar y ejecutar contenido de CompileTodosSPs.sql
```

## ✅ Verificación

1. **Compilación:** ✅ Exitosa
2. **Stored Procedures:** ✅ Creados
3. **Servicios:** ✅ Implementados
4. **Formulario:** ✅ Funcional (edición básica)
5. **Integración:** ✅ Conectado con frmBuscarEmpleado

**Estado:** Listo para pruebas y completar guardado de datos.
