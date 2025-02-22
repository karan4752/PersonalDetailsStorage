using System.Security.Claims;
using Application;
using Application.BankDetail;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize(Policy = "IsUserDetail")]
    public class BankDetailsController : BaseController
    {
        [HttpGet]//api/bankdetails
        public async Task<IActionResult> GetBankDetails(CancellationToken cancellationToken)
        {
            var userId = GetUserId();
            return HandleResult(await Mediator.Send(new List.Query { UserId = userId }, cancellationToken));
        }

        [HttpGet("{id}")]//api/bankdetails/1234-1234-1234
        public async Task<IActionResult> GetBankDetail(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));

        }

        [HttpPost]
        public async Task<IActionResult> Create(BankDetails bankDetails)
        {
            var userId = GetUserId();
            bankDetails.UserId = userId;
            return HandleResult(await Mediator.Send(new Create.Command { BankDetails = bankDetails }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, BankDetails bankDetails)
        {
            bankDetails.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { BankDetails = bankDetails }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}