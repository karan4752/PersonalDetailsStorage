using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.BankDetail
{
    public class Create
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
            private readonly IUserAccessor _userAccessor;
            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                if (request.BankDetails == null)
                {
                    return Result<Unit>.Fail("BankDetail cannot be null");
                }
                var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());

                var userBankDetails = new UserBankDetails
                {
                    AppUser = user,
                    BankDetails = request.BankDetails,
                    IsUserBankDetails = true
                };

                request.BankDetails.UserBankDetails.Add(userBankDetails);
                _context.BankDetail.Add(request.BankDetails);
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Fail("Failed to create Bank details");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}