using HRMPj.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Models
{
    public static class DbInitializer
    {
        public static void SeedData
(UserManager<ApplicationUser> userManager)
        {
            SeedUsers(userManager);
        }

        public static void SeedUsers
    (UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync
       ("tzw@gmail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "tzw@gmail.com";
                user.Email = "tzw@gmail.com";


                IdentityResult result = userManager.CreateAsync
                (user, "P@ger123").Result;

               /* if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "NormalUser").Wait();
                }*/
            }

        }


        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.EmployeeInfos.Any())
            {

                EmployeeInfo em = new EmployeeInfo()
                {
                    EmployeeName="Thein Zaw Win",

                };
            }

        }
      
    }
}
