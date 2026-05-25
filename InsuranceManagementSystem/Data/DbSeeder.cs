using Microsoft.AspNetCore.Identity;
using InsuranceManagementSystem.Models;

namespace InsuranceManagementSystem.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Create roles
            string[] roleNames = { "Admin", "User" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Create admin user
            var adminEmail = "admin@insurance.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FirstName = "Admin",
                    LastName = "User",
                    PhoneNumber = "1234567890",
                    Address = "123 Admin Street",
                    City = "Admin City",
                    State = "Admin State",
                    ZipCode = "12345",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, "Admin@123");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // Create a test user
            var testEmail = "user@test.com";
            var testUser = await userManager.FindByEmailAsync(testEmail);

            if (testUser == null)
            {
                testUser = new ApplicationUser
                {
                    UserName = testEmail,
                    Email = testEmail,
                    FirstName = "Test",
                    LastName = "User",
                    PhoneNumber = "9876543210",
                    Address = "456 Test Avenue",
                    City = "Test City",
                    State = "Test State",
                    ZipCode = "54321",
                    DateOfBirth = new DateTime(1995, 5, 15),
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(testUser, "Test@123");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(testUser, "User");
                }
            }
        }
    }
}
