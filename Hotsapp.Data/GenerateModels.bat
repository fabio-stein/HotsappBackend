@ECHO OFF
dotnet ef dbcontext scaffold "server=hotsapp.censknzoa6og.us-east-1.rds.amazonaws.com;port=3306;user=admin;password=MMPY0DyZvVX5LVrm5V;database=hotsapp" Pomelo.EntityFrameworkCore.MySql -o "Model" -f -c "DataContext" --context-dir Context
PAUSE