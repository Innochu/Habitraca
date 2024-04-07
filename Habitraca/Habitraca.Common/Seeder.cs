
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Habitraca.Common
{
    public class Seeder
    {
      public static async Task SeedRoles(IServiceProvider serviceProvider)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var adminExist = await roleManager.RoleExistsAsync("Admin");
    if (!adminExist)
	{
		var role = new IdentityRole("Admin");
		roleManager.CreateAsync(role).Wait();
	}
    var userExist = await roleManager.RoleExistsAsync("User");
    if (!userExist)
    {
        var role = new IdentityRole("User");
        roleManager.CreateAsync(role).Wait();
    }
}
    }
}
