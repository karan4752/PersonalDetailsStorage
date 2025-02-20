using System.Net;
using Application.BankDetail;
using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application;

public class List
{
    public class Query : IRequest<Result<List<BankDetailsDto>>> { }

    public class Handler : IRequestHandler<Query, Result<List<BankDetailsDto>>>
    {
        private readonly DataContext _context;
        public ILogger<List> _Logger;
        private readonly IMapper _mapper;
        public Handler(DataContext context, ILogger<List> logger, IMapper mapper)
        {
            _mapper = mapper;
            _Logger = logger;
            _context = context;
        }
        public async Task<Result<List<BankDetailsDto>>> Handle(Query request, CancellationToken cancellationToken)
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
            var bankDetails = await _context.BankDetail
                                    .Include(b => b.UserBankDetails)
                                    .ThenInclude(u => u.AppUser)
                                    .ToListAsync(cancellationToken);
            var bankDetailsToReturn = _mapper.Map<List<BankDetailsDto>>(bankDetails);
            return Result<List<BankDetailsDto>>.Success(bankDetailsToReturn);
        }
    }
}
