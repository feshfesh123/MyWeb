using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TFTB.Identity.Models;

namespace TFTB.Identity.Services
{
    public class ProfileService : IProfileService
    {
        private readonly UserManager<User> _userManager;
        public ProfileService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(sub);

            var claims = new List<Claim>();
            claims.Add(new Claim("fullname", user.Fullname));
            claims.Add(new Claim("money", user.Money.ToString()));
            claims.Add(new Claim("id", user.Id));

            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(sub);
            context.IsActive = (user != null);
        }
    }
}
