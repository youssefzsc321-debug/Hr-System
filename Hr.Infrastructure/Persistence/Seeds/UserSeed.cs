using Hr.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Infrastructure.Persistence.Seeds
{
    public static class UserSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    FullName = "Youssef Abuzaid",
                    UserName = "youssef.admin",
                    Email = "admin@hr.com",
                    EmailConfirmed = true,
                };

                await userManager.CreateAsync(user, "753951420Tt#");
            }
        }
    }
}
