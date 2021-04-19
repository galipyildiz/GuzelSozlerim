using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuzelSozlerim.Data
{
    public static class DataSeed
    {
        public static async Task SeedRollerVeKullanicilarAsync(RoleManager<IdentityRole> roleManager, UserManager<Kullanici> userManager )
        {
            var adminRoleName = "admin";
            var adminUserEmail = "admin@example.com";
            if (!await roleManager.RoleExistsAsync(adminRoleName))
            {
                await roleManager.CreateAsync(new IdentityRole(adminRoleName));
            }
            if (!await userManager.Users.AnyAsync(x=>x.UserName == adminUserEmail))
            {
                var user = new Kullanici()
                {
                    UserName = adminUserEmail,
                    Email = adminUserEmail,
                    GorunenAd = "Admin",
                };
                await userManager.CreateAsync(user, "Ankara1.");
                await userManager.AddToRoleAsync(user, adminRoleName);
            }
        }
    }
}
