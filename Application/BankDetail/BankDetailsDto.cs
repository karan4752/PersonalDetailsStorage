using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Profiles;

namespace Application.BankDetail
{
    public class BankDetailsDto
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string BankName { get; set; }
        public string BankIfscCode { get; set; }
        public string BankAccountNumber { get; set; }
        public bool IsNetBankingAvailable { get; set; }
        public Guid NebankingId { get; set; }
        public bool IsCardDetialsAvailable { get; set; }
        public Guid CardDetailsId { get; set; }
        public string UserName { get; set; }
        public ICollection<Profile> UserBankDetails { get; set; }

    }
}