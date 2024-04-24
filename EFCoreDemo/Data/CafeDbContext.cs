using Cafe.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemo.Data
{
    public class CafeDbContext :DbContext
    {
        //public DbSet<Role> Role { get; set; }
        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlite("FileName=C:/Users/serhi/.databases/itstep/cafe2.db");
            optionsBuilder.UseSqlServer("FileName=C:/Users/serhi/.databases/itstep/cafe2.db");

        }
    }
}
