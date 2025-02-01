using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
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
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var bankDetail = await _context.BankDetail.FindAsync(request.BankDetails.Id);
                bankDetail.BankAccountNumber = request.BankDetails.BankAccountNumber ?? bankDetail.BankAccountNumber;
                bankDetail.BankIfscCode = request.BankDetails.BankIfscCode ?? bankDetail.BankIfscCode;
                bankDetail.BankName = request.BankDetails.BankName ?? bankDetail.BankName;
                await _context.SaveChangesAsync();
            }
        }
    }
}