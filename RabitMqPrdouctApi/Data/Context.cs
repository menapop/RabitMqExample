using Microsoft.EntityFrameworkCore;
using RabitMqPrdouctApi.Models;

namespace RabitMqPrdouctApi.Data
{
    public class Context : DbContext
    {
        protected readonly IConfiguration Configuration;
        public Context(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Product> Products {get;set;}
    }
}
