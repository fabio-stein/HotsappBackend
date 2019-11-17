using Dapper;
using Hotsapp.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hotsapp.Data.Context
{
    public class NumberContext : DataContext
    {
        string allocateNumberQuery = @"
BEGIN;
SET @phone = null;
SELECT @phone := Number FROM virtual_number
  WHERE (LastCheckUTC IS NULL OR LastCheckUTC < @timeLimit)
  AND OwnerId IS NOT NULL
  LIMIT 1 FOR UPDATE;
UPDATE virtual_number
  SET LastCheckUTC = @newDate
  WHERE Number = @phone;
SELECT @phone;
COMMIT;
";
        private DbContextOptions<NumberContext> options;

        public NumberContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public async Task<string> TryAllocateNumber()
        {
            using(var conn = Database.GetDbConnection())
            {
                var minTime = DateTime.UtcNow.AddMinutes(-1);
#if DEBUG
                minTime = DateTime.UtcNow.AddSeconds(-5);//Faster restart for debug
#endif
                var number = await conn.QuerySingleOrDefaultAsync<string>(allocateNumberQuery, new { timeLimit = minTime, newDate = DateTime.UtcNow });
                return number;
            }
        }
    }
}
