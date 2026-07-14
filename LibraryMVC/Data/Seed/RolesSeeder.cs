using Microsoft.AspNetCore.Identity;

namespace LibraryMVC.Data.Seed
{
    public static class RolesSeeder
    {
        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roles = { "Admin", "User" };
            foreach(var role in roles)
            {
                if(! await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
