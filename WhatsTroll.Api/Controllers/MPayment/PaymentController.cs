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
        public PaymentController(BalanceService balanceService)
        {
            _balanceService = balanceService;
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

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> GetTest()
        {
            var order = await PaymentService.CaptureOrder("2G2458003L4094242", true);

            return Ok(order);
        }
    }
}