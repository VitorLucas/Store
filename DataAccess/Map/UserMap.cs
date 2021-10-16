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
        public static void UserMap(ModelBuilder modelBuilder)
        {
            var map = modelBuilder.Entity<User>().ToTable("USER");
            // Primary Key
            map.HasKey(t => t.Id);

            // Table & Column Mappings
            map.Property(t => t.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            map.Property(t => t.Name).HasColumnName("NAME");
            map.Property(t => t.Password).HasColumnName("PASSWORD");
            map.Property(t => t.RoleId).HasColumnName("ROLE_ID");

            map.HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId);
        }
    }
}
