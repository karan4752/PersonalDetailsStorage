using Application;
using Application.BankDetail;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BankDetailsController : BaseController
    {
        [HttpGet]//api/bankdetails
        public async Task<ActionResult<List<BankDetails>>> GetBankDetails(CancellationToken cancellationToken)
        {
            return await Mediator.Send(new List.Query(),cancellationToken);
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
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, BankDetails bankDetails)
        {
            bankDetails.Id = id;
            await Mediator.Send(new Edit.Command { BankDetails = bankDetails });
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await Mediator.Send(new Delete.Command { Id = id });
            return Ok();
        }
    }
}