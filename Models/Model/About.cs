using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompanyWeb.Models.Model
{
    [Table("About")]
    public class About
    {
        [Key]
        public int AboutId { get; set; }
        public string TitleRed { get; set; }
        public string TitleWhite { get; set; }
        public string  Explanation { get; set; }
        public string Tickt1 { get; set; }
        public string Tickt2  { get; set; }
        public string Tickt3 { get; set; }
        public string Tickt4 { get; set; }
        public string ImgURL { get; set; }

    }
}