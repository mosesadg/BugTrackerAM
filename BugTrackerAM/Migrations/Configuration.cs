namespace BugTrackerAM.Migrations
{
    using BugTrackerAM.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BugTrackerAM.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BugTrackerAM.Models.ApplicationDbContext context)
        {

            var roleManager = new RoleManager<IdentityRole>(
                 new RoleStore<IdentityRole>(context));


            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });

            }
            if (!context.Roles.Any(r => r.Name == "Project Manager"))
            {
                roleManager.Create(new IdentityRole { Name = "Project Manager" });

            }

            if (!context.Roles.Any(r => r.Name == "Developer"))
            {
                roleManager.Create(new IdentityRole { Name = "Developer" });

            }
            if (!context.Roles.Any(r => r.Name == "Submitter"))
            {
                roleManager.Create(new IdentityRole { Name = "Submitter" });

            }


            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            ApplicationUser user;


            if (!context.Users.Any(r => r.Email == "admin@coderfoundry.com"))
            {
                user = new ApplicationUser

                {
                    UserName = "moses.adg@gmail.com",
                    Email = "moses.adg@gmail.com",
                    FirstName = "Anand",
                    LastName = "Moses",
                    DisplayName = "Anand Moses"
                };
                userManager.Create(user, "ABC123!");
            }

            user = userManager.FindByEmail("moses.adg@gmail.com"); //new addition
            userManager.AddToRole(user.Id, "Admin");//new addition

            if (!context.Users.Any(r => r.Email == "lreaves@coderfoundry.com"))
            {
                user = new ApplicationUser

                {
                    UserName = "lreaves@coderfoundry.com",
                    Email = "lreaves@coderfoundry.com",
                    FirstName = "Lawrence",
                    LastName = "Reaves",
                    DisplayName = "Lawrence Reaves"
                };
                userManager.Create(user, "Password-1");
            }

            user = userManager.FindByEmail("lreaves@coderfoundry.com");
            userManager.AddToRole(user.Id, "Project Manager");

            if (!context.Users.Any(r => r.Email == "bdavis@coderfoundry.com"))
            {
                user = new ApplicationUser

                {
                    UserName = "bdavis@coderfoundry.com",
                    Email = "bdavis@coderfoundry.com",
                    FirstName = "Bobby",
                    LastName = "Davis",
                    DisplayName = "Bobby Davis"
                };
                userManager.Create(user, "Password-1");
            }

            user = userManager.FindByEmail("bdavis@coderfoundry.com");
            userManager.AddToRole(user.Id, "Project Manager");

            if (!context.Users.Any(r => r.Email == "ajensen@coderfoundry.com"))
            {
                user = new ApplicationUser

                {
                    UserName = "ajensen@coderfoundry.com",
                    Email = "ajensen@coderfoundry.com",
                    FirstName = "Andrew",
                    LastName = "Jensen",
                    DisplayName = "Andrew Jensen"
                };
                userManager.Create(user, "Password-1");
            }

            user = userManager.FindByEmail("ajensen@coderfoundry.com");
            userManager.AddToRole(user.Id, "Submitter");

            if (!context.Users.Any(r => r.Email == "tjones@coderfoundry.com"))
            {
                user = new ApplicationUser

                {
                    UserName = "tjones@coderfoundry.com",
                    Email = "tjones@coderfoundry.com",
                    FirstName = "TJ",
                    LastName = "Jones",
                    DisplayName = "TJ Jones"
                };
                userManager.Create(user, "Password-1");
            }

            user = userManager.FindByEmail("tjones@coderfoundry.com");
            userManager.AddToRole(user.Id, "Developer");

            if (!context.Users.Any(r => r.Email == "tparrish@coderfoundry.com"))
            {
                user = new ApplicationUser

                {
                    UserName = "tparrish@coderfoundry.com",
                    Email = "tparrish@coderfoundry.com",
                    FirstName = "Thomas",
                    LastName = "Parrish",
                    DisplayName = "Thomas Parrish"
                };
                userManager.Create(user, "Password-1");
            }

            user = userManager.FindByEmail("tparrish@coderfoundry.com");
            userManager.AddToRole(user.Id, "Developer");
        

           


       









            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
