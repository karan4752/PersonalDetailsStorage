using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class BankDetails
    {
        public Guid Id { get; set; }
        public string BankName { get; set; }
        public string BankIfscCode { get; set; }
        public string BankAccountNumber { get; set; }
        public bool IsNetBankingAvailable { get; set; }
        public Guid NebankingId { get; set; }
        public bool IsCardDetialsAvailable { get; set; }
        public Guid CardDetailsId { get; set; }
    }
}