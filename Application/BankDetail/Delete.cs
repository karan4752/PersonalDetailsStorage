using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using MediatR;
using Persistence;

namespace Application.BankDetail
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var bankDetail = await _context.BankDetail.FindAsync(request.Id);
                if (bankDetail == null) return null;
                _context.Remove(bankDetail);
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Fail("Failed to delete bank detail");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}