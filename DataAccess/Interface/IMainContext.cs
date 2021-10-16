using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IMainContext
    {
        DbSet<Category> Category { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<User> User { get; set; }
        DbSet<Role> Role { get; set; }

        int SaveChanges();
    }
}
