

using Domain.Entities.Application;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace VentasApp.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        //public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager,
        //    RoleManager<ApplicationRole> roleManager)
        //{
        //    var adminrole = new ApplicationRole { Description = "Administrator", Name = "Admin"};
        //    if (roleManager.Roles.All(u => u.Name != adminrole.Name)) 
        //    {
        //        await roleManager.CreateAsync(adminrole);
        //    }
        //    var defaultUser = new ApplicationUser { UserName = "jucardon", Email = "administrator@localhost" };

        //    if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
        //    {
        //        await userManager.CreateAsync(defaultUser, "Password@123");
        //        await userManager.AddToRoleAsync(defaultUser, "Admin");
        //    }
        //}

        public static async Task SeedSampleDataAsync(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            //var adminrole = new ApplicationRole { Description = "Administrator", Name = "Admin" };
            //if (roleManager.Roles.All(u => u.Name != adminrole.Name))
            //{
            //    await roleManager.CreateAsync(adminrole);
            //}
            if (!context.applicationroles.Any())
            {
                var role = new ApplicationRole()
                {
                    Description = "Admin",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    EstadoRegistro = true
                };
                context.Add(role);
                await context.SaveChangesAsync();



                var defaultUser = new ApplicationUser { UserName = "jucardon", Email = "administrator@localhost" };

                if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
                {
                    await userManager.CreateAsync(defaultUser, "Password@123");
                    var userrole = new ApplicationUserRole { RoleId = role.Id, UserId = defaultUser.Id };

                    await context.SaveChangesAsync();
                    context.Add(userrole);
                    await context.SaveChangesAsync();
                }
            }
            //var defaultUser = new ApplicationUser { UserName = "jucardon", Email = "administrator@localhost" };

            //if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            //{
            //    await userManager.CreateAsync(defaultUser, "Password@123");
            //}
            //if (context.applicationroles.Select(t => t).Any()) 
            //{
            //    return;
            //}
            //var role = new ApplicationRole()
            //{
            //    Description = "Admin",
            //    Name = "Admin",
            //    IsActive = true
            //};
            //context.Add(role);
            //context.SaveChanges();
            //if (!(role is null)) 
            //{
            //    var userrole = new ApplicationUserRole()
            //    {
            //        UserId = defaultUser.Id,
            //        RoleId = role.Id,
            //        IsActive = true

            //    };
            //    context.Add(userrole);
            //    context.SaveChanges();
            //}
            //await context.SaveChangesAsync();

        }

    }

}

