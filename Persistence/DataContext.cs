using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Persistence
{
    //dotnet ef migrations add InitialCreate -p Persistence -s API
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<BankDetails> BankDetail { get; set; }
        public DbSet<UserBankDetails> UserBankDetail { get; set; }
        public DbSet<Photo> Photos { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserBankDetails>(x => x.HasKey(ub => new { ub.AppUserId, ub.BankDetailsId }));

            builder.Entity<UserBankDetails>()
                .HasOne(u => u.AppUser)
                .WithMany(b => b.BankDetails)
                .HasForeignKey(ub => ub.AppUserId);

            builder.Entity<UserBankDetails>()
            .HasOne(u => u.BankDetails)
            .WithMany(b => b.UserBankDetails)
            .HasForeignKey(ub => ub.BankDetailsId);
        }
    }
}