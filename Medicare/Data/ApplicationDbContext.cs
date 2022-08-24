using Microsoft.EntityFrameworkCore;
using Medicare.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace Medicare.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
      public DbSet<ProductCategories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<DrList> DrList { get; set; }
        public DbSet<Specialist> Specialists  { get; set; }

        public DbSet<Consultation> Consultations { get; set; }

        public DbSet<DrCity> DrCity { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

       

    }
}
