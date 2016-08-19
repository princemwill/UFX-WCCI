using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace UFX_WCCI.Models
{
    public enum FileTypePost
    {
        PicPost = 1, Photo
    }

    public class Posting
    {
      
        public int PostingID { get; set; }
        public string Price { get; set; }
        public string Desc { get; set; }
        public int Quantity { get; set; }
        public string PhotoName { get; set; } /*← This will be the name of the picture*/
        public string PhotoType { get; set; } /*← This will be the type of the picture ex.jpeg*/
        public byte[] PhotoBytes { get; set; } /*← This will be the byte array representation*/
        public FileTypePost FileTypePost { get; set; } /*← This is a custom file you create* LOOK BELOW**/
        public DateTime PostingTime { get; set; }


        public virtual ApplicationUser AppUser { get; set; }
    }
}