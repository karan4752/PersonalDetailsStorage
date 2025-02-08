using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.BankDetail
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public BankDetails BankDetails { get; set; }
        }
        public class CommondValidator : AbstractValidator<Command>
        {
            public CommondValidator()
            {
                RuleFor(x => x.BankDetails).SetValidator(new BankDetailValidator());
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
                var bankDetail = await _context.BankDetail.FindAsync(request.BankDetails.Id);
                if (bankDetail == null) return null;
                _mapper.Map(request.BankDetails, bankDetail);
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Fail("Failed to update bank detail");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}