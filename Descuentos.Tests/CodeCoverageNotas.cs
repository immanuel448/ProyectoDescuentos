// ============================
// Cobertura de código con Coverlet y ReportGenerator
// ============================
//
// 1. Ejecutar pruebas con recolección de cobertura:
//    dotnet test --collect:"XPlat Code Coverage"
//
//    Esto genera una carpeta llamada 'TestResults' con archivos de resultados (.xml).
//
// 2. Instalar herramienta para generar reporte visual (solo una vez):
//    dotnet tool install --global dotnet-reportgenerator-globaltool
//
// 3. Generar el reporte de cobertura (lo visual):
//    reportgenerator -reports:"TestResults/**/coverage.cobertura.xml" -targetdir:"coverage-report" -reporttypes:Html
//
//    Esto crea una carpeta llamada 'coverage-report' con un archivo HTML visual del porcentaje de cobertura.
//
// 4. Abrir el archivo:
//    Abre coverage-report/index.html en el navegador.
//
// Nota:
// - La opción "Analyze Code Coverage for All Tests" no está disponible en Visual Studio Community Edition.
// - Coverlet + ReportGenerator son alternativas desde la consola para obtener los mismos resultados.
//
// Este proceso permite verificar qué partes del código están cubiertas por pruebas unitarias.
//
