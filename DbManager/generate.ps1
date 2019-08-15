
Write-Host Generating...
rm ..\DbManager\Model\*
rm ..\DbManager\Contexts\DataContext.cs
Scaffold-DbContext "User ID=postgres;Password=tempdev;Host=localhost;Port=5432;Database=sonoris;Pooling=true;" Npgsql.EntityFrameworkCore.PostgreSQL -Force -DataAnnotations -OutputDir "..\DbManager\Model" -Context "DataContext"
mv ..\DbManager\Model\DataContext.cs ..\DbManager\Contexts -Force
Write-Host Success

