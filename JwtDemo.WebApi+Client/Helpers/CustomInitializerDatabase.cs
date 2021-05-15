using JwtDemo.DataAccess;
using JwtDemo.DataAccess.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
namespace JwtDemo.WebApi_Client.Helpers
{
    public class CustomInitializerDatabase
    {
        public static void InitializeDatabase(IServiceProvider service, IWebHostEnvironment env, IConfiguration config)
        {
            using (var scope = service.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var manager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();


                var resultRole = managerRole.CreateAsync(new IdentityRole
                {
                    Name = "Admin"
                }).Result;

                resultRole = managerRole.CreateAsync(new IdentityRole
                {
                    Name = "User"
                }).Result;

                var email = "admin@gmail.com";
                var admin = new User
                {
                    Email = email,
                    UserName = email
                };
                var user = new User
                {
                    Email = "user@gmail.com",
                    UserName = "user@gmail.com"
                };

                var resultAdmin = manager.CreateAsync(admin, "123456").Result;
                resultAdmin = manager.AddToRoleAsync(admin, "Admin").Result;

                var resultUser = manager.CreateAsync(user, "123456").Result;
                resultUser = manager.AddToRoleAsync(user, "User").Result;
            }
        }
    }
}
