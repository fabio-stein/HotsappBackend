using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhatsTroll.Payment;

namespace WhatsTroll.Api.Controllers.MPayment
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentController : BaseController
    {
        private BalanceService _balanceService;
        private PaymentService _paymentService;

        public PaymentController(BalanceService balanceService, PaymentService paymentService)
        {
            _balanceService = balanceService;
            _paymentService = paymentService;
        }
        [HttpGet]
        public async Task<ActionResult> CurrentBalance()
        {
            return Ok(_balanceService.GetBalance((int)UserId));
        }

        [HttpPost]
        public async Task<ActionResult> AddBalance()
        {
            await _balanceService.AddCredits((int)UserId, 1);
            return Ok();
        }

        [HttpPut("{orderId}")]
        public async Task<ActionResult> CaptureOrder(string orderId)
        {
            await _paymentService.CaptureOrder(orderId, (int)UserId);

            return Ok();
        }
    }
}