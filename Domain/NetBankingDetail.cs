using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class NetBankingDetail
    {
        public Guid Id { get; set; }
        public Guid BankDetailId { get; set; }
        public BankDetails BankDetails { get; set; }
        public string BankUserId { get; set; }
        public string BankPassword { get; set; }
        public DateOnly PasswordExpireDate { get; set; }
        public string TransactionPassword { get; set; }
        public DateOnly TransactionPasswordExpireDate { get; set; }
    }
}