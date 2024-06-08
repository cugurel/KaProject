using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = (localdb)\\local; database=uqrtml; integrated security = true; TrustServerCertificate=True;");
        }

        public DbSet<CustomerFile> CustomerFiles { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<Year> Years { get; set; }
    }
}
