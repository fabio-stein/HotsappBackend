using Dapper;
using Hotsapp.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotsapp.Data.Context
{
    public class ConnectionFlowContext : DataContext
    {
        string getFlowQuery = @"
BEGIN;
SET @flowId = null;
SELECT @flowId := Id FROM connection_flow
  WHERE (IsActive IS NULL)
  LIMIT 1 FOR UPDATE;
UPDATE connection_flow
  SET IsActive = TRUE
  WHERE Id = @flowId;
SELECT @flowId;
COMMIT;
";
        private DbContextOptions<ConnectionFlowContext> options;

        public ConnectionFlowContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public async Task<string> TryGetFlow()
        {
            using(var conn = Database.GetDbConnection())
            {
                var number = await conn.QuerySingleOrDefaultAsync<string>(getFlowQuery);
                return number;
            }
        }
    }
}
