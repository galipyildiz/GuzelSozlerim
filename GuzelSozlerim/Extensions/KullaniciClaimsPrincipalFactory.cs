using GuzelSozlerim.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GuzelSozlerim.Extensions
{
    public class KullaniciClaimsPrincipalFactory : UserClaimsPrincipalFactory<Kullanici, IdentityRole>
    {
        //https://www.tryingtocode.co.uk/posts/2020/04/12-adding-claims-to-dotnet-core
        public KullaniciClaimsPrincipalFactory(UserManager<Kullanici> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> optionsAccessor)
        : base(userManager, roleManager, optionsAccessor)
        {
        }
        
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(Kullanici user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("GorunenAd", user.GorunenAd));//cookiye gorunen ad yazılcak
            return identity;
        }
    }
}
