using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedDaata(DataContext dataContext)
        {
            if (dataContext.BankDetail.Any()) return;
            var bankDetails = new List<BankDetails>{
                    new BankDetails{
                        BankAccountNumber="123456789",
                        BankIfscCode="1234",
                        BankName="xyz",
                        IsCardDetialsAvailable=false,
                        IsNetBankingAvailable=false,

                    },
                    new BankDetails{
                        BankAccountNumber="987654321",
                        BankIfscCode="4321",
                        BankName="zyx",
                        IsCardDetialsAvailable=false,
                        IsNetBankingAvailable=false,

                    }
            };
            await dataContext.BankDetail.AddRangeAsync(bankDetails);
            await dataContext.SaveChangesAsync();
        }
    }
}