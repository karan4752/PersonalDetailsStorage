using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CardDetail;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CardDetailController : BaseController
    {
        [HttpGet("{bankId}")]
        public async Task<IActionResult> List(Guid bankId)
        {
            return HandleResult(await Mediator.Send(new List.Query { BankId = bankId }));
        }
        [HttpGet("{bankId}/{id}")]
        public async Task<ActionResult<CardDetailDto>> Details(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CardDetail cardDetail)
        {
            return HandleResult(await Mediator.Send(new Create.Command { CardDetail = cardDetail }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, CardDetail cardDetail)
        {
            cardDetail.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { CardDetail = cardDetail }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}