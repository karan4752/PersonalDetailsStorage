using System;
using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.NetbankingDetails;

public class Create
{
    public class Command : IRequest<Result<Unit>>
    {
        public NetBankingDetail NetBankingDetail { get; set; }
    }
    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.NetBankingDetail).SetValidator(new NetBankingDetailValidator());
        }
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
            _context.NetBankingDetail.Add(request.NetBankingDetail);
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            if (!result) return Result<Unit>.Fail("Failed to create NetBankingDetail");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
