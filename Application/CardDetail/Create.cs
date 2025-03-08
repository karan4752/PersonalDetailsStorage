using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.CardDetail
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
          public Domain.CardDetail CardDetail { get; set; }
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
                _context.CardDetail.Add(request.CardDetail);
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Fail("Failed to create Card details");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}