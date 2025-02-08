using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.BankDetail
{
    public class Edit
    {
        public class Command : IRequest
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
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var bankDetail = await _context.BankDetail.FindAsync(request.BankDetails.Id);
                _mapper.Map(request.BankDetails, bankDetail);
                await _context.SaveChangesAsync();
            }
        }
    }
}