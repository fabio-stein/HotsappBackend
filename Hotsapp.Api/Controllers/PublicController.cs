using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Hotsapp.Data.Model;
using Hotsapp.Data.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Hotsapp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [AllowAnonymous]
    [ApiController]
    public class PublicController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> FreeAction([FromForm] string phoneNumber, [FromForm(Name = "g-recaptcha-response")] string captcha)
        {
            phoneNumber = phoneNumber.Trim().Replace("(", "").Replace(")", "").Replace("-", "");
            if (!CheckValidNumber(phoneNumber))
                return BadRequest("Número inválido");

            phoneNumber = "55" + phoneNumber;

            if (!await CheckCaptcha(captcha))
                return BadRequest("Captcha inválido");

            using(var ctx = DataFactory.GetContext())
            {
                var text = @"Olá, obrigado por utilizar o teste grátis da Hotsapp. 🥳🎉🎊\n\nJá que você se interessou, temos um presentinho para você:\nUtilize o cupom GOSTEI e garanta 10% de desconto no seu pagamento. 🤑\n\nFaça seu cadastro no site e comece a enviar WhatsApp agora mesmo. ✅\n\nCaso ainda tenha alguma dúvida, entre em contato pelo chat online. 🙂👍";
                var lastMessage = await ctx.Message.OrderByDescending(m => m.DateTimeUtc).Where(m => m.Processed && m.Error == false).FirstOrDefaultAsync();
                var newMessage = new Message()
                {
                    Content = text,
                    DateTimeUtc = DateTime.UtcNow,
                    IsInternal = true,
                    InternalNumber = lastMessage.InternalNumber,
                    ExternalNumber = phoneNumber,
                    UserId = 20 // Fabio
                };
                ctx.Add(newMessage);
                await ctx.SaveChangesAsync();
            }
            return Ok("Mensagem enviada com sucesso!");
        }

        private async Task<bool> CheckCaptcha(string captchaReponse)
        {
            var client = new HttpClient();
            var values = new Dictionary<string, string>
{
{ "secret", "6LfZKt4UAAAAAPUo8J_Z0yGeJRnY4okgLq-_PH3b" },
{ "response", captchaReponse }
};

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("https://www.google.com/recaptcha/api/siteverify", content);

            var responseString = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<CaptchaVerifyResponse>(responseString);

            return data.success;
        }

        class CaptchaVerifyResponse
        {
            public bool success { get; set; }
        }

        private bool CheckValidNumber(string number)
        {
            if (String.IsNullOrEmpty(number))
                return false;
            long res = 0;
            if (!long.TryParse(number, out res))
                return false;
            if (number.Length < 10 || number.Length > 11)
                return false;
            return true;
        }
    }
}