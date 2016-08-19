namespace UFX_WCCI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UFX_WCCI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UFX_WCCI.Models.ApplicationDbContext context)
        {
            context.Postings.AddOrUpdate(p => p.AppUser,
            new Models.Posting
            {
                PostingID = 1,
                Desc = "7890 2nd Ave E",
                Quantity = 2,
                Photo = "https://jpeg.org/images/jpeg-home.jpg",
                PostingTime = DateTime.Now
            },
            new Models.Posting
            {
                PostingID = 2,
                Desc = "This is some awesomeness and some delicious kale and stuff",
                Quantity = 50,
                Photo = "https://authoritynutrition.com/wp-content/uploads/2013/05/kale.jpg",
                PostingTime = DateTime.Now
            }
            );
        }
    }
}

