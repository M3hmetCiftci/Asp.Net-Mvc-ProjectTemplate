using CompanyWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CompanyWeb.Models.DBContext
{
    public class CompanyDBContext: DbContext
    {
       public CompanyDBContext() : base("CompanyWeb") { }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Tobbar> Tobbar { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Blog> Blog { get; set; }

        public System.Data.Entity.DbSet<CompanyWeb.Models.Model.Communication> Communications { get; set; }
    }
}