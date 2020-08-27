using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EFDbFirstApproachExample.Models 
{
    public class ProveDbContex : DbContext
    {
        public ProveDbContex () : base("EFDBFirstDatabaseEntities"){
            }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}