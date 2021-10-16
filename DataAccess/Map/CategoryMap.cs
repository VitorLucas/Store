using Microsoft.EntityFrameworkCore;
using Model;

namespace DataAccess
{
    public partial class MainContext : DbContext
    {
        public static void CategoryMap(ModelBuilder modelBuilder)
        {
            var map = modelBuilder.Entity<Category>().ToTable("CATEGORY");
            // Primary Key
            map.HasKey(t => t.Id);

            // Table & Column Mappings
            map.Property(t => t.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            map.Property(t => t.Description).HasColumnName("DESCRIPTION");
            map.Property(t => t.Active).HasColumnName("ACTIVE");
             
            map.HasMany(x => x.Products)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
