using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microrabbit.Banking.Application.Interfaces;
using Microrabbit.Banking.Application.Services;
using Microrabbit.Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microrabbit.Banking.Application.Dtos;

namespace Microrabbit.Banking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankingController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public BankingController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Account>> GetAll()
        {
            return Ok(_accountService.GetAccounts());
        }

        [HttpPost]
        public IActionResult Post([FromBody] AccountTransferDto accountTransfer)
        {
            _accountService.Transfer(accountTransfer);

            return Ok(accountTransfer);
        }
    }
}
