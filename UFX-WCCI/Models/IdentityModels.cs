using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace UFX_WCCI.Models
{
    public enum FileType
    {
        Avatar = 1, Photo
    }

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public string Bio { get; set; }        
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string PhotoName { get; set; } /*← This will be the name of the picture*/
public string PhotoType { get; set; } /*← This will be the type of the picture ex.jpeg*/
public byte[] PhotoBytes { get; set; } /*← This will be the byte array representation*/
public FileType FileType { get; set; } /*← This is a custom file you create* LOOK BELOW**/


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<UFX_WCCI.Models.Posting> Postings { get; set; }

        
    }
}