using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompanyWeb.Models.Model
{
    [Table("Slider")]
    public class Slider
    {
        [Key]
        public int SliderId { get; set; }
        [Required,StringLength(100,ErrorMessage ="Must contain maximum 100 words")]
        public string Titlered { get; set; }
        [Required,StringLength(100,ErrorMessage ="Must contain maximum 100 words")]
        public string Titlewhite { get; set; }
        [Required,StringLength(250, ErrorMessage ="Must contain maximum 250 words")]
        public string Explanation { get; set; }
        public string ImgURL { get; set; }

    }
}