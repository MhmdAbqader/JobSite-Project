using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace trial2.Models
{
    public class ApplyForJob
    {
        //this class relate AspnetUser table to Job table as relation between them is M:M
        public int ID { get; set; }
        public string MSG { get; set; }
        public DateTime DATE { get; set; }

        public int JodId { get; set; }
        public string UserId { get; set; }
        public virtual Job job { get; set; }
        public virtual ApplicationUser user { get; set; }
    }
}