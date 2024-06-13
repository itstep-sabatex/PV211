using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NuGet.Packaging.Signing;

namespace RazorPageDemo.Data
{
    public class DataSeed
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider,IConfiguration configuration)
        {
            // roles
            using var roleManeger = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var roles = roleManeger.Roles.Select(x => x.Name).ToList();
            var eRoles = Enum.GetNames<Roles>();
            var rolesSeed = new List<string>();
            configuration.Bind("Roles",rolesSeed);
            foreach (var role in rolesSeed) 
            {
                if (!roles.Contains(role)) 
                {
                    await roleManeger.CreateAsync(new IdentityRole(role));
                }
            
            }
            var adminUser = "fake@mail.server";
            using var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            var user = await userManager.FindByEmailAsync(adminUser);
            if (user != null)
            {
                if (!await userManager.IsInRoleAsync(user, Enum.GetName(Roles.Administrator)))
                {
                    await userManager.AddToRoleAsync(user, Enum.GetName(Roles.Administrator));
                }
            }


            adminUser = "admin@contoso.com";
            user = new AppUser
            {
                Email = adminUser,
                NormalizedEmail = adminUser.ToUpper(),
                UserName = adminUser,
                NormalizedUserName = adminUser.ToUpper(),
                //PasswordHash ="",
                EmailConfirmed = true,
                SecurityStamp= Guid.NewGuid().ToString("D")
            };

            var passwordHasher = new PasswordHasher<AppUser>();
            var hash = passwordHasher.HashPassword(user, "SuperPass123!");
            using var context = serviceProvider.GetRequiredService<CafeDbContext>();
            //await context.AddAsync(user);
            //await context.SaveChangesAsync();
            
            //var u = await userManager.CreateAsync(user);
            var userStore = serviceProvider.GetRequiredService<IUserStore<AppUser>>();

            //var emailStore = serviceProvider.GetRequiredService<IUserEmailStore<AppUser>>();
            await userStore.SetUserNameAsync(user, adminUser, CancellationToken.None);
            //await emailStore.SetEmailAsync(user, adminUser, CancellationToken.None);
            user.Email = adminUser;
            user.NormalizedEmail = adminUser.ToUpper();

            user.EmailConfirmed = true;
            user.Description = "";
            user.IdCode = "1234567890";
            var result = await userManager.CreateAsync(user, "SuperPass123!");

            var userRoles = userManager.GetRolesAsync(user);
            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(user, Enum.GetName(Roles.Administrator));
            }




        }



    }
}
