using Microsoft.EntityFrameworkCore;
using OnionPronia.Domain.Entities;
using System.Reflection;
using System.Reflection.Emit;


namespace OnionPronia.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           //modelBuilder.ApplyConfiguration(new Configuration.ProductConfiguration());
           //modelBuilder.ApplyConfiguration(new Configuration.CategoryConfiguration());
           //modelBuilder.ApplyConfiguration(new Configuration.TagConfiguration());
           //modelBuilder.ApplyConfiguration(new Configuration.ProductTagConfiguration());

           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
           base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductTag> ProductTags { get; set;
        



        }
}
