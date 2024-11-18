﻿namespace loginAuth.Migrations
{
    using loginAuth.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<loginAuth.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "loginAuth.Models.ApplicationDbContext";
        }

        protected override void Seed(loginAuth.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // 1. Create Admin Role
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole("Admin");
                roleManager.Create(role);
            }

            // 2. Create Customer Role
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole("Customer");
                roleManager.Create(role);
            }

            // 3. Create Admin User
            if (userManager.FindByName("admin@example.com") == null)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    EmailConfirmed = true
                };

                string adminPassword = "Admin@123";

                var result = userManager.Create(adminUser, adminPassword);

                if (result.Succeeded)
                {
                    userManager.AddToRole(adminUser.Id, "Admin");
                }
            }

            // 4. Create Customer User
            if (userManager.FindByName("customer@example.com") == null)
            {
                var customerUser = new ApplicationUser
                {
                    UserName = "customer@example.com",
                    Email = "customer@example.com",
                    EmailConfirmed = true
                };

                string customerPassword = "Customer@123";

                var result = userManager.Create(customerUser, customerPassword);

                if (result.Succeeded)
                {
                    userManager.AddToRole(customerUser.Id, "Customer");
                }
            }
        }
    }
}
