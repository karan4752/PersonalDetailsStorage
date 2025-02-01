using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
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
            return Ok();// await _context.BankDetail.FindAsync(id);
        }

    }
}