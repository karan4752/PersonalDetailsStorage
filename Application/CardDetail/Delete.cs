using System;
using Application.Core;
using MediatR;
using Persistence;

namespace Application.CardDetail;

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
            var cardDetail = await _context.CardDetail.FindAsync(request.Id);
            if (cardDetail == null) return null;
            _context.CardDetail.Remove(cardDetail);
            var result = await _context.SaveChangesAsync() > 0;
            if (!result) return Result<Unit>.Fail("Failed to delete card detail");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
