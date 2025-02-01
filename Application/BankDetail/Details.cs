using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.BankDetail
{
    public class Details
    {
        public class Query : IRequest<BankDetails>
        {
            public Guid Id;
        }

        public class Handler : IRequestHandler<Query, BankDetails>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<BankDetails> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.BankDetail.FindAsync(request.Id);
            }
        }
    }
}