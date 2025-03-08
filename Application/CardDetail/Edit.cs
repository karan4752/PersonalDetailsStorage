using System;
using Application.Core;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CardDetail;

public class Edit
{
    public class Command : IRequest<Result<Unit>>
    {
        public Domain.CardDetail CardDetail { get; set; }
    }
    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.CardDetail).SetValidator(new CardDetail.CardDetailValidator());
        }
    }
    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly Persistence.DataContext _context;
        public Handler(Persistence.DataContext context)
        {
            _context = context;
        }
        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var cardDetail = await _context.CardDetail
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == request.CardDetail.Id);
            if (cardDetail == null) return null;
            _context.CardDetail.Update(request.CardDetail);
            var result = await _context.SaveChangesAsync() > 0;
            if (!result) return Result<Unit>.Fail("Failed to update card detail");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
