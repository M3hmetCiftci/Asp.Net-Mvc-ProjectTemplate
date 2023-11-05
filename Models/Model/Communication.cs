using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CompanyWeb.Models.Model
{
    [Table("Communucation")]
    public class Communication
    {
        [Key]
        public int Id { get; set; }
        public string Hour { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string Youtube { get; set; }
        public string Instagram { get; set; }
        public string Linked { get; set; }

    }
}