using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class BankDetailsController:BaseController
    {
        private readonly DataContext _context;
        public BankDetailsController(DataContext context)
        {
            _context = context;

        }
        [HttpGet]//api/bankdetails
        public async Task<ActionResult<List<BankDetails>>> GetBankDetails()
        {
            return await _context.BankDetail.ToListAsync();
        }
        [HttpGet("{id}")]//api/bankdetails/1234-1234-1234
        public async Task<ActionResult<BankDetails>> GetBankDetail(Guid id)
        {
            return await _context.BankDetail.FindAsync(id);
        }

    }
}