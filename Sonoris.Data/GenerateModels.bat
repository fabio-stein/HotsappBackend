@ECHO OFF
dotnet ef dbcontext scaffold "server=sonorisdata.csgrxoop9tel.sa-east-1.rds.amazonaws.com;port=3306;user=Sonoris;password=oQxQTlNZB9JqTJPqxWpL;database=sonoris" MySql.Data.EntityFrameworkCore -o "Model" -f -c "DataContext" --context-dir Context
PAUSE