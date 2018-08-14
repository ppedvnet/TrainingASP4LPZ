namespace SecurityDemo.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SecurityDemo.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SecurityDemo.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SecurityDemo.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "Teacher" },
                new IdentityRole { Name = "Student" });

            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            um.AddToRole("54aa2d1e-f9b3-4505-8972-5000021052fc", "Teacher");
        }
    }
}
