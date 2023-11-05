using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompanyWeb.Models.Model
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string ExPlanation { get; set; }
        public string history { get; set; }
        public string BlogImg { get; set; }

    }
}