using Dapper;
using Hotsapp.Data.Model;
using Hotsapp.Data.Util;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<int> CreateChat(string myNumber, string remoteNumber, int area)
        {
            using(var conn = DataFactory.OpenConnection())
            {
                return await conn.QueryFirstOrDefaultAsync<int>(@"INSERT INTO wa_chat (PhoneNumber, RemoteNumber, Area) VALUES (@myNumber, @remoteNumber, @area);
SELECT LAST_INSERT_ID();", new { myNumber, remoteNumber, area });
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

        public async Task<IEnumerable<WaChatMessage>> GetPendingMessages(string myNumber)
        {
            using(var conn = DataFactory.OpenConnection())
            {
                return await conn.QueryAsync<WaChatMessage>(@"SELECT * FROM wa_chat_message WHERE !IsProcessed AND ChatPhoneNumber = @phoneNumber AND IsFromMe
ORDER BY MessageId ASC", new { phoneNumber = myNumber });
            }
        }

        public async Task SetMessageProcessed(int messageId)
        {
            using (var conn = DataFactory.OpenConnection())
            {
                await conn.QueryAsync("UPDATE wa_chat_message SET IsProcessed = TRUE WHERE MessageId = @id", new { id = messageId });
            }
        }

        public IEnumerable<WaPhoneArea> GetPhoneAreas(string phoneNumber)
        {
            using(var ctx = DataFactory.GetDataContext())
            {
                return ctx.WaPhoneArea.Where(p => p.PhoneNumber == phoneNumber).OrderBy(p => p.Id).ToList();
            }
        }
    }
}
