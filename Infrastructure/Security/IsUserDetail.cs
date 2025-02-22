using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastructure.Security
{
    public class IsUserDetail : IAuthorizationRequirement
    {

    }
    public class IsUserDetailHandler : AuthorizationHandler<IsUserDetail>
    {
        private readonly DataContext _dbcontext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IsUserDetailHandler(DataContext dbcontext, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _dbcontext = dbcontext;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsUserDetail requirement)
        {
            var userid = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userid == null) return Task.CompletedTask;

            // var bankDetailsId = Guid.Parse(_httpContextAccessor.HttpContext?.Request.RouteValues.SingleOrDefault(x => x.Key == "id").Value?.ToString());
            var bankDetailsId = Guid.Parse(_dbcontext.UserBankDetail.FirstOrDefaultAsync(x => x.AppUserId == userid).Result.BankDetailsId.ToString());
            // if (bankDetailsId == null || bankDetailsId == Guid.Empty) return Task.CompletedTask;
            var userBankDetails = _dbcontext.UserBankDetail
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.AppUserId == userid && x.BankDetailsId == bankDetailsId).Result;


            if (userBankDetails == null) return Task.CompletedTask;

            if (userBankDetails.IsUserBankDetails) context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}