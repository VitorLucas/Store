using Microsoft.EntityFrameworkCore;
using Model;

namespace DataAccess
{
    public partial class MainContext : DbContext
    {
        public static void RoleMap(ModelBuilder modelBuilder)
        {
            var map = modelBuilder.Entity<Role>().ToTable("ROLE");
            // Primary Key
            map.HasKey(t => t.Id);

            // Table & Column Mappings
            map.Property(t => t.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            map.Property(t => t.Description).HasColumnName("DESCRIPTION");

            map.HasMany(x => x.Users)
                .WithOne(x => x.Role)
                .HasForeignKey(x => x.RoleId);
        }
    }
}
