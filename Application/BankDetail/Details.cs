using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.BankDetail
{
    public class Details
    {
        public class Query : IRequest<Result<BankDetails>>
        {
            public Guid Id;
        }

        public class Handler : IRequestHandler<Query, Result<BankDetails>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Result<BankDetails>> Handle(Query request, CancellationToken cancellationToken)
            {
                var bankDetails = await _context.BankDetail.FindAsync(request.Id);
                return Result<BankDetails>.Success(bankDetails);
            }
        }
    }
}