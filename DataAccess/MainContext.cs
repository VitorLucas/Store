using DataAccess.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model;

namespace DataAccess
{
    public partial class MainContext : DbContext, IMainContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }

        public MainContext(DbContextOptions<MainContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            CategoryMap(modelBuilder);
            ProductMap(modelBuilder);
            UserMap(modelBuilder);
            ProductMap(modelBuilder);
            ProductMap(modelBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
