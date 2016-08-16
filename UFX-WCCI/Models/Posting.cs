using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UFX_WCCI.Models
{
    public class Posting
    {
        public int PostingID { get; set; }
        public string Price { get; set; }
        public string Desc { get; set; }
        public int Quantity { get; set; }
        public string Photo { get; set; }
        public DateTime PostingTime { get; set; }

        public virtual ApplicationUser AppUser { get; set; }
    }
}