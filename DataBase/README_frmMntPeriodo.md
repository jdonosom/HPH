# Implementación Sistema de Gestión de Períodos (frmMntPeriodo)

## Resumen
Se ha implementado un sistema completo de gestión de períodos de proceso que afecta a todos los módulos del sistema. El período activo se muestra en la ventana principal y todos los procesos deben respetar el período en curso.

## Archivos Creados

### 1. Modelo
- **../BusinessHPH/Model/Proceso.cs**
  - Propiedades: Periodo, Año, Descripcion, Apertura, Cierre, Cerrado, Estado
  - Propiedades calculadas: PeriodoFormateado, DescripcionCompleta, EstadoTexto, EstaActivo, PuedeModificar

### 2. Servicio
- **../BusinessHPH/Service/ProcesoService.cs**
  - `Obtener(periodo)` - Obtiene períodos específicos o todos
  - `ObtenerPeriodoActual()` - Obtiene el período actualmente en curso
  - `ObtenerTodos(filtro)` - Lista todos con filtro opcional
  - `GuardarProceso(proceso)` - Inserta nuevo período
  - `ActualizarProceso(proceso)` - Actualiza período existente
  - `EstablecerPeriodoActual(periodo)` - Activa un período
  - `CerrarPeriodo(periodo)` - Cierra un período permanentemente

### 3. Formulario
- **frmMntPeriodo.cs** - Lógica del mantenedor
- **frmMntPeriodo.Designer.cs** - Diseño del formulario
- **frmMntPeriodo.resx** - Recursos

### 4. Stored Procedures
- **../DataBase/ProcesoProcs.sql**
  - `ProcesoSelProc` - Seleccionar períodos
  - `ProcesoSelActualProc` - Obtener período actual
  - `ProcesoListProc` - Listar con filtro
  - `ProcesoInsProc` - Insertar (auto-gestiona estados)
  - `ProcesoUpdProc` - Actualizar (auto-gestiona estados)
  - `ProcesoSetActualProc` - Establecer como actual (con validaciones)
  - `ProcesoCerrarProc` - Cerrar período (irreversible)

### 5. Datos de Prueba
- **../DataBase/03_DatosPruebaProceso.sql**
  - Período 202501 (Enero 2025) - ACTIVO
  - Período 202412 (Diciembre 2024) - CERRADO
  - Período 202411 (Noviembre 2024) - CERRADO
  - Período 202410 (Octubre 2024) - CERRADO

## Archivos Modificados

### 1. frmMain.cs
- Agregado `using HPHBusiness.Service;`
- Método `ActualizarPeriodoActual()` - Actualiza lblPeriodo en ventana principal
- Constructor llama a `ActualizarPeriodoActual()` al iniciar
- Método `periodoDeProcesoToolStripMenuItem_Click()` - Abre frmMntPeriodo

### 2. frmMain.Designer.cs
- Agregado evento Click a `periodoDeProcesoToolStripMenuItem`

### 3. CompileTodosSPs.sql
- Agregados todos los SPs de Proceso

## Estructura de la Base de Datos

```sql
CREATE TABLE [dbo].[Proceso](
    [Periodo] [char](6) NOT NULL,           -- AAAAMM (ej: 202501)
    [Año] [int] NOT NULL,                   -- 2025
    [Descripcion] [varchar](250) NOT NULL,  -- "Período Enero 2025"
    [Apertura] [datetime] NOT NULL,         -- Fecha de apertura
    [Cierre] [datetime] NULL,               -- Fecha de cierre (null si no cerrado)
    [Cerrado] [bit] NOT NULL,               -- Indica si está cerrado
    [Estado] [int] NOT NULL,                -- 0=Inactivo, 1=En Curso, 2=Cerrado
    CONSTRAINT [PK7] PRIMARY KEY ([Periodo])
)
```

## Estados del Período

### Estado 0 - Inactivo
- Período creado pero no activo
- Puede ser modificado
- Puede ser activado

### Estado 1 - En Curso (ACTIVO)
- **Solo puede haber UN período con Estado=1 en todo momento**
- Este es el período que se muestra en frmMain
- Todos los módulos deben usar este período
- Puede ser modificado
- Puede ser cerrado

### Estado 2 - Cerrado
- Período finalizado y cerrado
- **NO puede ser modificado**
- **NO puede ser activado**
- Es solo lectura

## Funcionalidades Implementadas

### 1. Ventana Principal (frmMain)
- **Label lblPeriodo**: Muestra el período actual en formato MM/AAAA
- Color verde si hay período activo
- Color rojo si no hay período activo
- Se actualiza automáticamente al cambiar período

### 2. Formulario frmMntPeriodo

#### Sección Superior
- **lblPeriodoActual**: Muestra el período actualmente en curso

#### Sección Izquierda - Lista de Períodos
- DataGridView con todos los períodos ordenados por período descendente
- Muestra: Período, Año, Descripción, Apertura, Cierre, Cerrado, Estado
- Contador de registros total

#### Sección Derecha - Datos del Período
- **Período**: CHAR(6) formato AAAAMM (ej: 202501)
- **Año**: INT extraído del período
- **Descripción**: VARCHAR(250) descripción del período
- **Fecha Apertura**: DateTime inicio del período
- **Checkbox Fecha Cierre**: Habilita/deshabilita fecha de cierre
- **Fecha Cierre**: DateTime fin del período (opcional)
- **Checkbox Cerrado**: Indica si el período está cerrado
- **Estado**: ComboBox (Inactivo, En Curso, Cerrado)

#### Botones
1. **Nuevo**: 
   - Limpia formulario
   - Sugiere siguiente período automáticamente
   - Habilita controles para edición

2. **Establecer como Actual**:
   - Activa el período seleccionado
   - Desactiva automáticamente el período actual anterior
   - Valida que no esté cerrado
   - Actualiza frmMain

3. **Cerrar Período**:
   - **ADVERTENCIA**: Acción irreversible
   - Establece Cerrado=1, Estado=2
   - Registra fecha de cierre automáticamente
   - No permite modificaciones posteriores

4. **Guardar**:
   - Inserta nuevo período o actualiza existente
   - Auto-detección basada en si Periodo está habilitado
   - Validaciones completas

5. **Cancelar**: Limpia formulario y deshabilita controles

6. **Salir**: Cierra el formulario

## Validaciones Implementadas

### Validaciones de Formulario
1. Período debe ser 6 caracteres numéricos (AAAAMM)
2. Año debe estar entre 2020 y 2100
3. Descripción es obligatoria
4. Estado es obligatorio
5. Fecha cierre debe ser posterior a fecha apertura
6. No se puede cerrar un período sin Estado=1 o Estado=2

### Validaciones de Stored Procedures
1. **ProcesoInsProc**: No permite duplicados de período
2. **ProcesoUpdProc**: Solo puede haber un Estado=1 activo
3. **ProcesoSetActualProc**: 
   - Verifica existencia del período
   - No permite activar períodos cerrados
4. **ProcesoCerrarProc**:
   - Verifica existencia
   - No permite cerrar un período ya cerrado

## Reglas de Negocio

### Regla 1: Un Solo Período Activo
Solo puede existir un período con Estado=1 (En Curso) en todo momento. Los stored procedures garantizan esta regla:
- Al insertar un período con Estado=1, desactiva automáticamente los demás
- Al actualizar un período a Estado=1, desactiva los demás
- Al establecer un período como actual, desactiva el anterior

### Regla 2: Períodos Cerrados son Inmutables
Un período cerrado (Cerrado=1 y Estado=2):
- NO puede ser modificado
- NO puede ser activado
- Es permanente

### Regla 3: Sugerencia Automática
Al crear un nuevo período, el sistema sugiere automáticamente:
- Período: Mes siguiente al período actual
- Año: Calculado automáticamente (incrementa si pasa de diciembre)
- Descripción: "Período [Mes] [Año]"
- Fecha Apertura: Primer día del mes sugerido

## Integración con el Sistema

### Impacto en Otros Módulos

Para que los módulos respeten el período actual, deben:

1. **Obtener el período actual al iniciar**:
```csharp
ProcesoService procesoService = new ProcesoService();
var periodoActual = procesoService.ObtenerPeriodoActual();
if (periodoActual != null)
{
    // Usar periodoActual.Periodo en las operaciones
}
```

2. **Módulos que deben usar el período actual**:
- ✅ **frmMntBoleta**: Ya usa período "202501" hardcodeado → Cambiar a periodo actual
- ✅ **frmMntValorHora**: Ya usa período "2025" → Cambiar a periodo actual
- ✅ **frmAsignacionHorasCargo**: Ya usa período "2025" → Cambiar a periodo actual
- **BoletaService**: Filtros por período
- **ValorHoraService**: Filtros por período
- **ValorHoraCargoService**: Operaciones por período

### Ejemplo de Actualización de Módulos Existentes

#### Antes (frmMntValorHora):
```csharp
private const string PERIODO_ACTUAL = "2025";
```

#### Después:
```csharp
private string periodoActual = string.Empty;

private void Form_Load(object sender, EventArgs e)
{
    ProcesoService procesoService = new ProcesoService();
    var periodo = procesoService.ObtenerPeriodoActual();
    if (periodo != null)
    {
        periodoActual = periodo.Periodo.Substring(0, 4); // Extrae "2025"
        lblPeriodo.Text = $"Período: {periodo.PeriodoFormateado}";
    }
    else
    {
        MessageBox.Show("No hay período activo configurado.", 
            "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        this.Close();
    }
}
```

## Ubicación en el Menú
**Ingreso de datos → Período de proceso**

## Testing

### Compilación
✅ Compilación exitosa sin errores ni advertencias

### Base de Datos
✅ Todos los stored procedures compilados correctamente
✅ Datos de prueba insertados correctamente

### Escenarios de Prueba

1. **Crear nuevo período**:
   - Abre frmMntPeriodo
   - Click en "Nuevo"
   - Verifica sugerencia automática
   - Modifica datos
   - Click en "Guardar"
   - ✅ Período creado correctamente

2. **Establecer período como actual**:
   - Selecciona un período inactivo
   - Click en "Establecer como Actual"
   - Confirma
   - ✅ lblPeriodo en frmMain se actualiza
   - ✅ Solo un período queda con Estado=1

3. **Cerrar período**:
   - Selecciona período activo
   - Click en "Cerrar Período"
   - Confirma advertencia
   - ✅ Período cerrado correctamente
   - ✅ No puede ser reactivado

4. **Validaciones**:
   - Intentar cerrar período ya cerrado → ✅ Mensaje de error
   - Intentar activar período cerrado → ✅ Mensaje de error
   - Período duplicado → ✅ SP valida y rechaza

## Próximos Pasos (IMPORTANTE)

### 1. Actualizar frmMntBoleta
```csharp
// Cambiar de:
private const string PERIODO_ACTUAL = "202501";

// A:
private string periodoActual = string.Empty;

// En Load:
var proceso = new ProcesoService().ObtenerPeriodoActual();
periodoActual = proceso?.Periodo ?? "202501";
```

### 2. Actualizar frmMntValorHora
```csharp
// Cambiar de:
private const string PERIODO_ACTUAL = "2025";

// A:
private string periodoActual = string.Empty;

// En Load:
var proceso = new ProcesoService().ObtenerPeriodoActual();
periodoActual = proceso?.Periodo.Substring(0, 4) ?? "2025";
```

### 3. Actualizar frmAsignacionHorasCargo
```csharp
// Cambiar de:
private const string PERIODO_ACTUAL = "2025";

// A:
private string periodoActual = string.Empty;

// En Load:
var proceso = new ProcesoService().ObtenerPeriodoActual();
periodoActual = proceso?.Periodo.Substring(0, 4) ?? "2025";
```

### 4. Agregar Validación en Todos los Formularios
```csharp
private void ValidarPeriodoActual()
{
    ProcesoService procesoService = new ProcesoService();
    var periodo = procesoService.ObtenerPeriodoActual();
    
    if (periodo == null)
    {
        MessageBox.Show(
            "No hay un período activo configurado.\n\nDebe establecer un período en curso antes de continuar.",
            "Período Requerido",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);
        this.Close();
    }
    
    if (periodo.Cerrado)
    {
        MessageBox.Show(
            "El período actual está cerrado.\n\nNo se pueden realizar modificaciones.",
            "Período Cerrado",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);
        this.Close();
    }
}
```

## Notas Técnicas

1. **Formato del Período**: CHAR(6) = "AAAAMM" (ej: 202501 para Enero 2025)
2. **Estados**: 0=Inactivo, 1=En Curso, 2=Cerrado
3. **Unicidad**: Solo un período puede tener Estado=1
4. **Cierre**: Acción irreversible, auto-registra fecha
5. **Thread Safety**: Los SPs usan transacciones implícitas para evitar condiciones de carrera

## Consideraciones de Performance

1. **Caché del Período Actual**: Los formularios pueden cachear el período actual al cargar
2. **Actualización en Tiempo Real**: frmMntPeriodo notifica a frmMain mediante `NotificarCambioPeriodo()`
3. **Índice**: PRIMARY KEY en Periodo garantiza búsquedas rápidas

## Seguridad

1. **Validación Doble**: Cliente (C#) y Servidor (SQL)
2. **Transacciones**: SPs usan SET NOCOUNT ON para eficiencia
3. **RAISERROR**: Mensajes descriptivos de error desde SQL
4. **Confirmaciones**: Operaciones críticas requieren confirmación del usuario

## Mantenimiento Futuro

### Extensiones Posibles
1. **Auditoría**: Registrar quién y cuándo cierra/activa períodos
2. **Permisos**: Restriccir quién puede cerrar períodos
3. **Notificaciones**: Alertar cuando un período está por vencer
4. **Reportes**: Generar informes por período
5. **Backup**: Respaldar antes de cerrar período

### Mejoras Sugeridas
1. Agregar filtro de búsqueda en DataGridView
2. Exportar lista de períodos a Excel
3. Visualización de línea de tiempo de períodos
4. Indicador visual de período próximo a vencer
