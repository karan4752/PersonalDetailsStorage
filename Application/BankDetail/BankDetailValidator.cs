using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using FluentValidation;

namespace Application.BankDetail
{
    public class BankDetailValidator : AbstractValidator<BankDetails>
    {
        public BankDetailValidator()
        {
            RuleFor(x => x.BankAccountNumber).NotEmpty();
            RuleFor(x => x.BankIfscCode).NotEmpty();
            RuleFor(x => x.BankName).NotEmpty();
        }
    }
}