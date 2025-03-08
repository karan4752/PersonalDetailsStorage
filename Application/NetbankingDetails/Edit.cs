using System;
using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.NetbankingDetails;

public class Edit
{
    public class Command : IRequest<Result<Unit>>
    {
        public NetBankingDetail NetbankingDetail { get; set; }
    }
    public class CommondValidator : AbstractValidator<Command>
    {
        public CommondValidator()
        {
            RuleFor(x => x.NetbankingDetail).SetValidator(new NetBankingDetailValidator());
        }
    }
    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public Handler(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var netBankingDetail = await _context.NetBankingDetail
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(i => i.Id == request.NetbankingDetail.Id);
            if (netBankingDetail == null) return null;
            _mapper.Map(request.NetbankingDetail, netBankingDetail);
            _context.NetBankingDetail.Update(request.NetbankingDetail);
            var result = await _context.SaveChangesAsync() > 0;
            if (!result) return Result<Unit>.Fail("Failed to update Netbanking detail");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
