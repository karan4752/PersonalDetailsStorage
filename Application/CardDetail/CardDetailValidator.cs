using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Validators;

namespace Application.CardDetail
{
    public class CardDetailValidator : AbstractValidator<Domain.CardDetail>
    {
        public CardDetailValidator()
        {
            RuleFor(x => x.CardNumber).NotEmpty();
            RuleFor(x => x.CardHolderName).NotEmpty();
            RuleFor(x => x.CardExpiryDate).NotEmpty();
            RuleFor(x => x.CardCvv).NotEmpty();
            RuleFor(x => x.CardPinNumber).NotEmpty();
        }
    }
}