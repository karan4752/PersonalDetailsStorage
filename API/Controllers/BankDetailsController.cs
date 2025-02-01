using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.BankDetail;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class BankDetailsController : BaseController
    {
        [HttpGet]//api/bankdetails
        public async Task<ActionResult<List<BankDetails>>> GetBankDetails()
        {
            return await Mediator.Send(new List.Query());
        }
        [HttpGet("{id}")]//api/bankdetails/1234-1234-1234
        public async Task<ActionResult<BankDetails>> GetBankDetail(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> Create(BankDetails bankDetails)
        {
            await Mediator.Send(new Create.Command { BankDetails = bankDetails });
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Edit(Guid id, BankDetails bankDetails)
        {
            bankDetails.Id = id;
            await Mediator.Send(new Edit.Command { BankDetails = bankDetails });
            return Ok();
        }
    }
}