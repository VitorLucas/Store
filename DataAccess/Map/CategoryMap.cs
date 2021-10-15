using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            map.Property(t => t.Id).HasColumnName("ID");
            map.Property(t => t.Description).HasColumnName("DESCRIPTION");
            map.Property(t => t.Active).HasColumnName("ACTIVE");

            map.HasMany(x => x.Products)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
