namespace UFX_WCCI.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using UFX_WCCI.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UFX_WCCI.Models.ApplicationDbContext>
    {
        public ApplicationUser SeedUser;
            
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        bool AddUserAndRole(UFX_WCCI.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("canEdit"));
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "GardenLady1",
            };
            ir = um.Create(user, "GardenLady1!");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "canEdit");
            SeedUser = user;
            SeedUser.Latitude = 41.1618538f;
            SeedUser.Longitude = -80.69716f;
            return ir.Succeeded;
        }

        protected override void Seed(UFX_WCCI.Models.ApplicationDbContext context)
        {
            AddUserAndRole(context);
            context.Postings.AddOrUpdate(p => p.PostingID,
            new Models.Posting
            {
                PostingID = 1,
                Desc = "golden potatoes",
                Quantity = 20,
                Price = "20.00",
                PostingTime = DateTime.Now,
                AppUser = SeedUser
            },
            new Models.Posting
            {
                PostingID = 2,
                Desc = "Curly kale",
                Quantity = 50,
                Price = "free",
                PostingTime = DateTime.Now,
                AppUser = SeedUser
            }
            );
        }
    }
}

