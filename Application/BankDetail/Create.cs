using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.BankDetail
{
    public class Create
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
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                _context.BankDetail.Add(request.BankDetails);
                await _context.SaveChangesAsync();
            }
        }
    }
}