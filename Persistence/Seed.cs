using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedDaata(DataContext dataContext, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>{
                    new AppUser{DisplayName="Karan", UserName="karan",Email="karan@gmail.com"},
                    new AppUser{DisplayName="Jane", UserName="jane",Email="jane@gmail.com"},
                    new AppUser{DisplayName="Bob", UserName="bob",Email="bob@gmail.com"},
                };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");//not proper way to password, but this will do for test project
                }
            }
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