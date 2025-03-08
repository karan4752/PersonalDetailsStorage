using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class BankDetails
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string BankName { get; set; }
        public string BankIfscCode { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankAccountType { get; set; }
        public string BankAccountHolderName { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserEmail { get; set; }
        public string UserAddress { get; set; }
        public string BankBranch { get; set; }
        public long BankBalance { get; set; }
        public ICollection<NetBankingDetail> NetBankingDetails { get; set; }
        public ICollection<CardDetail> CardDetails { get; set; }
        public ICollection<UserBankDetails> UserBankDetails { get; set; } = new List<UserBankDetails>();
    }
}