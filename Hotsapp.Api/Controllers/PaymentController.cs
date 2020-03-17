using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hotsapp.Data.Model;
using Hotsapp.Payment;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Globalization;

namespace Hotsapp.Api.Controllers.MPayment
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentController : BaseController
    {
        private BalanceService _balanceService;
        private PaymentService _paymentService;
        private DataContext _dataContext;
        private IConfiguration _config;

        public PaymentController(BalanceService balanceService, PaymentService paymentService, DataContext dataContext, IConfiguration config)
        {
            _balanceService = balanceService;
            _paymentService = paymentService;
            _dataContext = dataContext;
            _config = config;
        }
        [HttpGet]
        public async Task<ActionResult> CurrentBalance()
        {
            var balance = _balanceService.GetWallet((int)UserId);
            if (balance == null)
                balance = await _balanceService.CreateWallet((int)UserId);

            return Ok(balance.Amount);
        }

        List<OrderModel> orderList = new List<OrderModel>()
        {
            new OrderModel()
            {
                ItemName = "Créditos",
                ItemAmount = 15,
                ItemTotal = 15,
                OrderTotal = 15,
            },
            new OrderModel()
            {
                ItemName = "Créditos",
                ItemAmount = 150,
                ItemTotal = 142.5,
                OrderTotal = 142.5,
            },
            new OrderModel()
            {
                ItemName = "Créditos",
                ItemAmount = 1500,
                ItemTotal = 1350,
                OrderTotal = 1350,
            },
        };

        [HttpPut("{orderId}")]
        public async Task<ActionResult> CaptureOrder(string orderId)
        {
            await _paymentService.CaptureOrder(orderId, (int)UserId);

            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("{option}")]
        public async Task<ActionResult> StartOrder(int option)
        {
            return Ok(orderList[option].HashAndSign(GetKey()));
        }

        [HttpPost]
        public async Task<ActionResult> CompleteOrder([FromBody] OrderModel order)
        {
            if (!order.SignatureValid(GetKey()))
                return BadRequest("Invalid Hash");

            var value = Convert.ToString(order.OrderTotal, CultureInfo.InvariantCulture);
            var res = await _paymentService.CreateOrder(order.ItemAmount, value);

            return Ok(new { res.Id });
        }

        [AllowAnonymous]
        [HttpPost("{code}")]
        public async Task<ActionResult> ApplyCoupon([FromBody] OrderModel order, string code)
        {
            if (!order.SignatureValid(GetKey()))
                return BadRequest("Invalid Hash");

            code = code.Trim().ToUpper();
            if (code != "GOSTEI")
                return BadRequest("Cupom Inválido");

            var discount = (order.ItemTotal * 0.1);
            order.CouponCode = code;
            order.CouponDiscount = discount;
            order.OrderTotal = order.ItemTotal - discount;
            
            return Ok(order.HashAndSign(GetKey()));
        }

        [HttpPost]
        public async Task<ActionResult> RemoveCoupon([FromBody] OrderModel order)
        {
            if (!order.SignatureValid(GetKey()))
                return BadRequest("Invalid Hash");
            order.CouponDiscount = 0;
            order.CouponCode = null;
            order.OrderTotal = order.ItemTotal;

            return Ok(order.HashAndSign(GetKey()));
        }

        private RSAParameters GetKey()
        {
            RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();
            var secret = _config.GetSection("Payment")["PaymentSignKey"];
            RSAalg.ImportCspBlob(Convert.FromBase64String(secret));
            return RSAalg.ExportParameters(true);
        }


        public class OrderModel
        {
            public string ItemName { get; set; }
            public int ItemAmount { get; set; }
            public double ItemTotal { get; set; }
            public string CouponCode { get; set; }
            public double CouponDiscount { get; set; }
            public double OrderTotal { get; set; }

            
            public string Hash { get; set; }

            public OrderModel HashAndSign(RSAParameters key)
            {
                var hash = HashAndSignBytes(GetBytes(), key);
                this.Hash = Convert.ToBase64String(hash);
                return this;
            }

            public bool SignatureValid(RSAParameters key)
            {
                return VerifySignedHash(GetBytes(), Convert.FromBase64String(Hash), key);
            }

            private byte[] GetBytes()
            {
                var clone = JsonConvert.DeserializeObject<OrderModel>(JsonConvert.SerializeObject(this));
                clone.Hash = null;
                var data = JsonConvert.SerializeObject(clone);
                var bytes = Encoding.ASCII.GetBytes(data);
                return bytes;
            }
        }

        public static byte[] HashAndSignBytes(byte[] DataToSign, RSAParameters Key)
        {
            try
            {
                RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();
                RSAalg.ImportParameters(Key);
                return RSAalg.SignData(DataToSign, new SHA1CryptoServiceProvider());
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }

        public static bool VerifySignedHash(byte[] DataToVerify, byte[] SignedData, RSAParameters Key)
        {
            try
            {
                RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();

                RSAalg.ImportParameters(Key);
                return RSAalg.VerifyData(DataToVerify, new SHA1CryptoServiceProvider(), SignedData);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return false;
            }
        }
    }
}