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
        public static void ProductMap(ModelBuilder modelBuilder)
        {
            var map = modelBuilder.Entity<Product>().ToTable("PRODUCT");
            // Primary Key
            map.HasKey(t => t.Id);

            // Table & Column Mappings
            map.Property(t => t.Id).HasColumnName("ID");
            map.Property(t => t.Description).HasColumnName("DESCRIPTION"); 
            map.Property(t => t.CategoryId).HasColumnName("CATEGORY_ID");
            map.Property(t => t.Code).HasColumnName("CODE");
            map.Property(t => t.Dimension).HasColumnName("DIMENSION");
            map.Property(t => t.Price).HasColumnName("PRICE").HasPrecision(18, 4);
            map.Property(t => t.Reference).HasColumnName("REFERENCE");
            map.Property(t => t.StockBalance).HasColumnName("STOCK_BALANCE");
            map.Property(t => t.Active).HasColumnName("ACTIVE");

            map.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
