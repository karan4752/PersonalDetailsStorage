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
                        UserId=userManager.Users.FirstOrDefault(u=>u.UserName=="karan").Id,
                        BankAccountHolderName="Karan",
                        BankAccountType="Savings",
                        BankBalance=10000,
                        BankBranch="abc",
                        BankAccountNumber="123456789",
                        BankIfscCode="1234",
                        BankName="xyz",
                    },
                    new BankDetails{
                        UserId=userManager.Users.FirstOrDefault(u=>u.UserName=="karan").Id,
                        BankAccountHolderName="Jane",
                        BankAccountType="Savings",
                        BankBalance=20000,
                        BankBranch="def",
                        BankAccountNumber="987654321",
                        BankIfscCode="4321",
                        BankName="zyx",

                    }
            };
            await dataContext.BankDetail.AddRangeAsync(bankDetails);
            var userBankDetails = new List<UserBankDetails>{
                new UserBankDetails{
                    AppUserId=userManager.Users.FirstOrDefault(u=>u.UserName=="karan").Id,
                    BankDetailsId=bankDetails[0].Id,
                    IsUserBankDetails=true
                },
            };
            await dataContext.UserBankDetail.AddRangeAsync(userBankDetails);
            if (dataContext.CardDetail.Any()) return;
            var cardDetails = new List<CardDetail>{
                new CardDetail{
                    CardNumber="123456789",
                    CardType="Debit",
                    CardExpiryDate=DateOnly.FromDateTime(DateTime.Now.AddMonths(3)),
                    CardCvv="123",
                    CardHolderName="Karan",
                    BankDetailId=bankDetails[0].Id,
                    CardBrand="Visa",
                    CardPinNumber="1234",
                    CardPinExpiryDate=DateOnly.FromDateTime(DateTime.Now.AddMonths(6)),

                },
                new CardDetail{
                    CardNumber="987654321",
                    CardType="Credit",
                    CardExpiryDate=DateOnly.FromDateTime(DateTime.Now.AddMonths(2)),
                    CardCvv="321",
                    CardHolderName="Jane",
                    BankDetailId=bankDetails[0].Id,
                    CardBrand="Visa",
                    CardPinNumber="1234",
                    CardPinExpiryDate=DateOnly.FromDateTime(DateTime.Now.AddMonths(6)),
                },
                new CardDetail{
                    CardNumber="123456789",
                    CardType="Debit",
                    CardExpiryDate=DateOnly.FromDateTime(DateTime.Now.AddMonths(3)),
                    CardCvv="123",
                    CardHolderName="Bob",
                    BankDetailId=bankDetails[1].Id,
                    CardBrand="Visa",
                    CardPinNumber="1234",
                    CardPinExpiryDate=DateOnly.FromDateTime(DateTime.Now.AddMonths(6)),
                },
                new CardDetail{
                    CardNumber="987654321",
                    CardType="Credit",
                    CardExpiryDate=DateOnly.FromDateTime(DateTime.Now.AddMonths(2)),
                    CardCvv="321",
                    CardHolderName="Bob",
                    BankDetailId=bankDetails[1].Id,
                    CardBrand="Visa",
                    CardPinNumber="1234",
                    CardPinExpiryDate=DateOnly.FromDateTime(DateTime.Now.AddMonths(6)),
                }
            };
            await dataContext.CardDetail.AddRangeAsync(cardDetails);
            await dataContext.SaveChangesAsync();
        }
    }
}