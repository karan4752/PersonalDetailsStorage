using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class UserBankDetails
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Guid BankDetailsId { get; set; }
        public BankDetails BankDetails { get; set; }
        public bool IsUserBankDetails { get; set; }
        
    }
}