# Script PowerShell para ejecutar todos los SPs en SQL Server LocalDB
# Ubicación: E:\DESARROLLOS\Salud\tmp\HPH\DataBase\
# Modelo de Tabla Empleado: Rut (INT), Dv (CHAR(1)), NombreCompleto (VARCHAR(150)), IdCargo (INT)

$ServerInstance = "(localdb)\MSSQLLocalDB"
$Database = "CHPH"
$ScriptPath = "$PSScriptRoot\CompileTodosSPs.sql"

Write-Host "=========================================" -ForegroundColor Cyan
Write-Host "Ejecutando Script de Stored Procedures" -ForegroundColor Cyan
Write-Host "=========================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "Servidor: $ServerInstance" -ForegroundColor Yellow
Write-Host "Base de datos: $Database" -ForegroundColor Yellow
Write-Host "Script: $ScriptPath" -ForegroundColor Yellow
Write-Host ""

try {
    # Ejecutar el script SQL
    Invoke-Sqlcmd -ServerInstance $ServerInstance `
                  -Database $Database `
                  -InputFile $ScriptPath `
                  -Verbose
    
    Write-Host ""
    Write-Host "=========================================" -ForegroundColor Green
    Write-Host "Script ejecutado exitosamente" -ForegroundColor Green
    Write-Host "=========================================" -ForegroundColor Green
}
catch {
    Write-Host ""
    Write-Host "=========================================" -ForegroundColor Red
    Write-Host "Error al ejecutar el script:" -ForegroundColor Red
    Write-Host $_.Exception.Message -ForegroundColor Red
    Write-Host "=========================================" -ForegroundColor Red
    exit 1
}

# Pausa para ver resultados
Write-Host ""
Write-Host "Presiona cualquier tecla para continuar..."
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
