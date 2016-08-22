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
                UserName = "MotherofGardenLady",
            };
            ir = um.Create(user, "P_assw0rd1");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "canEdit");
            SeedUser = user;
            return ir.Succeeded;
        }

        protected override void Seed(UFX_WCCI.Models.ApplicationDbContext context)
        {
            context.Postings.AddOrUpdate(p => p.AppUser,
            new Models.Posting
            {
                PostingID = 1,
                Desc = "7890 2nd Ave E",
                Quantity = 2,
                PostingTime = DateTime.Now,
                AppUser = SeedUser
            },
            new Models.Posting
            {
                PostingID = 2,
                Desc = "This is some awesomeness and some delicious kale and stuff",
                Quantity = 50,
                PostingTime = DateTime.Now,
                AppUser = SeedUser
            }
            );
        }
    }
}

