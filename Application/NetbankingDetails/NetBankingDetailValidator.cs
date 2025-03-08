using System;
using Domain;
using FluentValidation;

namespace Application.NetbankingDetails;

public class NetBankingDetailValidator : AbstractValidator<NetBankingDetail>
{
    public NetBankingDetailValidator()
    {
        RuleFor(x => x.BankUserId).NotEmpty();
        RuleFor(x => x.BankPassword).NotEmpty();
        RuleFor(x => x.PasswordExpireDate).NotEmpty();
        RuleFor(x => x.TransactionPassword).NotEmpty();
        RuleFor(x => x.TransactionPasswordExpireDate).NotEmpty();
    }
}
