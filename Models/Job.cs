using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace trial2.Models
{
    public class Job
    {
        public int Id { get; set; }
        [DisplayName("أسم الوظيفة")]
        public string jobtitle { get; set; }
        [DisplayName("وصف الوظيفة")]
        public string jobcontent { get; set; }
        [DisplayName("صورة الوظيفة")]
        public string jobImage { get; set; }
        [DisplayName("نوع ا لوظيفة")]
        public int cat_id { get; set; }
        public string UserId { get; set; }
       
        public virtual Cats1 category { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}