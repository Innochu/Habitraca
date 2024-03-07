
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Habitraca.Common
{
    public class Seeder
    {
        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!roleManager.RoleExistsAsync("Admin").Result)
			{
				var role = new IdentityRole("Admin");
				roleManager.CreateAsync(role).Wait();
			}

            if (!roleManager.RoleExistsAsync("User").Result)
            {
                var role = new IdentityRole("User");
                roleManager.CreateAsync(role).Wait();
            }
        }
    }
}
