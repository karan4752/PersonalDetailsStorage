using System.Net;
using Application.BankDetail;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application;

public class List
{
    public class Query : IRequest<Result<List<BankDetailsDto>>> { public string UserId { get; set; }}

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
            #region Commented previous code
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
            // var bankDetails = await _context.BankDetail
            //                         .Include(b => b.UserBankDetails)
            //                         .ThenInclude(u => u.AppUser)
            //                         .ToListAsync(cancellationToken);
            // var bankDetailsToReturn = _mapper.Map<List<BankDetailsDto>>(bankDetails);
            #endregion
           
            // var bankDetails = await _context.BankDetail
            //                 .ProjectTo<BankDetailsDto>(_mapper.ConfigurationProvider)
            //                 .ToListAsync(cancellationToken);
            var bankDetails = await _context.BankDetail
                    .Where(x => x.UserId == request.UserId)
                    .ProjectTo<BankDetailsDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
            return Result<List<BankDetailsDto>>.Success(bankDetails);
        }
    }
}
