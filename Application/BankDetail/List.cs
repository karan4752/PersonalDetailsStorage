using System.Net;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application;

public class List
{
    public class Query : IRequest<List<BankDetails>> { }

    public class Handler : IRequestHandler<Query, List<BankDetails>>
    {
        private readonly DataContext _context;
        public ILogger<List> _Logger;
        public Handler(DataContext context, ILogger<List> logger)
        {
            _Logger = logger;
            _context = context;
        }
        public async Task<List<BankDetails>> Handle(Query request, CancellationToken cancellationToken)
        {
            // try
            // {
            //     for (int i = 0; i < 10; i++)
            //     {
            //         cancellationToken.ThrowIfCancellationRequested();
            //         await Task.Delay(1000);
            //         _Logger.LogInformation($"Task {i} is completed");
            //     }
            // }
            // catch (System.Exception)
            // {
            //     _Logger.LogError("Task was cancelled");
            // }
            return await _context.BankDetail.ToListAsync();
        }
    }
}
