using System;

namespace Application.NetbankingDetails;

public class NetBankingDetailDto
{
    public Guid Id { get; set; }
    public Guid BankDetailId { get; set; }
    public string BankUserId { get; set; }
    public string BankPassword { get; set; }
    public DateOnly PasswordExpireDate { get; set; }
    public string TransactionPassword { get; set; }
    public DateOnly TransactionPasswordExpireDate { get; set; }
}
