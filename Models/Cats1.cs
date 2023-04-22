using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trial2.Models
{
    public class Cats1
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="نوع الوظيفة")]
        public string catname { get; set; }
        [Required]
        [Display(Name ="وصف الوظيفة")]
        public string catdescription { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}