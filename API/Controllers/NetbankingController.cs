using System;
using Application.NetbankingDetails;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class NetbankingController : BaseController
{
    [HttpGet("{bankId}")]
    public async Task<IActionResult> List(Guid bankId)
    {
        return HandleResult(await Mediator.Send(new List.Query { Id = bankId }));
    }
    [HttpGet("{bankId}/{id}")]
    public async Task<IActionResult> Details(Guid id)
    {
        return HandleResult(await Mediator.Send(new Detail.Query { Id = id }));
    }
    [HttpPost]
    public async Task<IActionResult> Create(NetBankingDetail netBankingDetail)
    {
        return HandleResult(await Mediator.Send(new Create.Command { NetBankingDetail = netBankingDetail }));
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(Guid id, NetBankingDetail netBankingDetail)
    {
        netBankingDetail.Id = id;
        return HandleResult(await Mediator.Send(new Edit.Command { NetbankingDetail = netBankingDetail }));
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
    }
}
