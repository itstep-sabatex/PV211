﻿using Cafe.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeWpfEFCore.Data
{
    public class CafeDbContext :DbContext
    {
        //public DbSet<Role> Role { get; set; }
        public DbSet<User> Waiters { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(Config.Configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                        .HasData(new User[] { User.Admin,User.Manager,User.Barmen,User.Cook,User.Waiter });
            modelBuilder.Entity<UserRole>().HasData(new UserRole[] 
            {
                new UserRole { Id=1,Role=Role.Admin,UserId=User.Admin.Id},
                new UserRole { Id=2,Role=Role.Manager,UserId=User.Manager.Id},
                new UserRole {Id=3,Role=Role.Waiter,UserId=User.Waiter.Id},
                new UserRole {Id=4,Role=Role.Cook,UserId=User.Cook.Id},
                new UserRole {Id=5,Role=Role.Bar,UserId=User.Barmen.Id}
            });

            //modelBuilder.Ignore<Waiter>();

        }
    }
}