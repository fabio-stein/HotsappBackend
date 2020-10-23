using Dapper;
using Hotsapp.Data.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WaClient.Worker.Data
{
    public class PhoneRepository
    {
        public async Task<int?> CheckActiveChat(string remoteNumber)
        {
            using (var conn = DataFactory.OpenConnection())
            {
                return await conn.QueryFirstOrDefaultAsync<int?>(@"
SELECT * FROM wa_chat
WHERE RemoteNumber = @remoteNumber
AND IsActive", new { remoteNumber });
            }
        }

        public async Task<int> CreateChat(string myNumber, string remoteNumber)
        {
            using(var conn = DataFactory.OpenConnection())
            {
                return await conn.QueryFirstOrDefaultAsync<int>(@"INSERT INTO wa_chat (PhoneNumber, RemoteNumber) VALUES (@myNumber, @remoteNumber);
SELECT LAST_INSERT_ID();", new { myNumber, remoteNumber });
            }
        }

        public async Task InsertMessage(int chatId, string myNumber, string body, DateTime date, bool fromMe)
        {
            using(var conn = DataFactory.OpenConnection())
            {
                await conn.QueryAsync(@"INSERT INTO wa_chat_message (ChatId, ChatPhoneNumber, Body, DateTimeUTC, IsFromMe)
VALUES (@chatId, @myNumber, @body, @date, @fromMe)", new { chatId, myNumber, body, date, fromMe });
            }
        }
    }
}
