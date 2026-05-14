# Implementación frmMntDependencia

## Resumen
Se ha implementado el mantenedor de Dependencias siguiendo el patrón establecido en el sistema (similar a frmMntCargo y frmMntValorHora).

## Archivos Creados

### 1. Formulario Principal
- **frmMntDependencia.cs** - Lógica del formulario de mantenimiento
- **frmMntDependencia.Designer.cs** - Diseño del formulario
- **frmMntDependencia.resx** - Recursos del formulario

### 2. Formulario de Búsqueda
- **frmBuscarDependencia.cs** - Lógica del diálogo de búsqueda
- **frmBuscarDependencia.Designer.cs** - Diseño del formulario de búsqueda
- **frmBuscarDependencia.resx** - Recursos del formulario de búsqueda

### 3. Stored Procedures
- **../DataBase/DependenciaProcs.sql** - Archivo con los procedimientos almacenados:
  - `DependenciaListProc` - Lista todas las dependencias con filtro opcional
  - `DependenciaInsProc` - Inserta nueva dependencia
  - `DependenciaUpdProc` - Actualiza dependencia existente
  - `DependenciaSelProc` - Ya existía (retorna solo activas)

## Archivos Modificados

### 1. DependenciaService.cs
Se agregaron los siguientes métodos:
- `ObtenerTodas(string filtro)` - Obtiene todas las dependencias con filtro
- `GuardarDependencia(Dependencia)` - Inserta nueva dependencia
- `ActualizarDependencia(Dependencia)` - Actualiza dependencia existente

### 2. frmMain.Designer.cs
- Se agregó evento Click al menu item `dependenciaToolStripMenuItem`

### 3. frmMain.cs
- Se agregó método `dependenciaToolStripMenuItem_Click` para abrir el formulario

### 4. CompileTodosSPs.sql
- Se agregaron los procedimientos almacenados DependenciaListProc, DependenciaInsProc y DependenciaUpdProc

## Funcionalidad Implementada

### Formulario frmMntDependencia
- **Búsqueda por ID**: Al ingresar un ID y salir del campo, carga automáticamente la dependencia
- **Búsqueda avanzada**: Botón "?" abre frmBuscarDependencia para búsqueda por descripción
- **Inserción**: Si el ID no existe, permite crear nueva dependencia
- **Actualización**: Si el ID existe, carga los datos y permite modificar
- **Validación**: Campo descripción es obligatorio
- **Estado**: CheckBox para activar/desactivar dependencias

### Formulario frmBuscarDependencia
- DataGridView con todas las dependencias (activas e inactivas)
- Filtro en tiempo real por descripción
- Doble click para seleccionar
- Contador de registros mostrados

## Estructura de la Base de Datos

```sql
CREATE TABLE [dbo].[Dependencia](
    [IdDependencia] [int] IDENTITY(1,1) NOT NULL,
    [Descripcion] [varchar](200) NULL,
    [Estado] [bit] NULL,
    CONSTRAINT [PK6] PRIMARY KEY NONCLUSTERED ([IdDependencia] ASC)
)
```

## Datos de Prueba
La tabla ya contiene 25 dependencias reales (centros de salud):
- SAPU LA GRANJA
- CESFAM GRANJA SUR
- CESFAM SANTA JULIA
- Etc.

Estos datos fueron cargados previamente mediante el script 02_DatosPrueba.sql.

## Ubicación en el Menú
**Administración → Dependencia**

## Patrón de Diseño Utilizado

El formulario sigue el patrón estándar del sistema:
1. Campo ID con auto-búsqueda al salir (evento Leave)
2. Botón "?" para búsqueda avanzada
3. Auto-detección de INSERT vs UPDATE basado en existencia del ID
4. Validación antes de guardar
5. Mensajes de confirmación
6. Limpieza del formulario después de operación exitosa

## Testing

### Compilación
✅ Compilación exitosa sin errores ni advertencias

### Base de Datos
✅ Todos los stored procedures compilados correctamente:
- DependenciaSelProc
- DependenciaListProc
- DependenciaInsProc
- DependenciaUpdProc

## Notas Técnicas

1. **Imagen del formulario**: Se dejó comentada la línea que asigna la imagen `Resources.Dependencia` ya que el recurso no existe. Se puede agregar posteriormente al archivo Resources.resx.

2. **Método AsignarParametroBoolean**: Se utiliza este método (no AsignarParametroBooleano) siguiendo el patrón de CargoService.

3. **EjecutarComando()**: Este método no retorna valor, por lo que se usa una variable booleana local para retornar el resultado de las operaciones de guardado/actualización.

4. **Filtro en DependenciaSelProc**: El procedimiento original solo retorna dependencias activas. Para el mantenedor, se creó DependenciaListProc que retorna todas (activas e inactivas).

## Próximos Pasos (Opcional)

1. Agregar imagen Resources.Dependencia al archivo Resources.resx
2. Implementar pruebas de integración
3. Agregar auditoría de cambios si es necesario
