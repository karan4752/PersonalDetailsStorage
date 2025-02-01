using System.Net;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application;

public class List
{
    public class Query : IRequest<List<BankDetails>> { }

    public class Handler : IRequestHandler<Query, List<BankDetails>>
    {
        private readonly DataContext _context;
        public Handler(DataContext context)
        {
            _context = context;
        }
        public async Task<List<BankDetails>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _context.BankDetail.ToListAsync();
        }
    }
}
