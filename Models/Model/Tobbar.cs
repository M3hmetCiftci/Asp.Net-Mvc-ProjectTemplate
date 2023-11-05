using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompanyWeb.Models.Model
{
    [Table("Tobbar")]
    public class Tobbar
    {
        [Key]
        public int TobbarId { get; set; }
        [Required, StringLength(30, ErrorMessage = "Must contain maximum 30 words")]
        public string MainTitle { get; set; }
        public string HourTitle { get; set; }
        [Required, StringLength(30, ErrorMessage = "Must contain maximum 30 words")]
        public string HourExplanation { get; set; }
        public string TelTitle { get; set; }
        [Required, StringLength(30, ErrorMessage = "Must contain maximum 30 words")]
        public string TelExplanation { get; set; }
        public string MailTitle { get; set; }
        [Required,StringLength(30,ErrorMessage = "Must contain maximum 30 words")]
        public string MailExplanation { get; set; }



    }
}