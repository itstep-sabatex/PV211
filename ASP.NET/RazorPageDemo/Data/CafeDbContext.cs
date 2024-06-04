using Cafe.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPageDemo.Data;

public class CafeDbContext : IdentityDbContext
{
    //public DbSet<Role> Role { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Nomenclature> Nomenclatures { get; set; }
    public DbSet<ClientTable> ClientTables { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    public CafeDbContext(DbContextOptions<CafeDbContext> options): base(options)
    {
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

        modelBuilder.Entity<ClientTable>().HasData(ClientTable.DefaultClientTables());
        modelBuilder.Entity<Nomenclature>().HasData(Nomenclature.DefaultNomenclatures());
        modelBuilder.Entity<Order>().HasData(Order.DefaultOrders());
        modelBuilder.Entity<OrderDetail>().HasData(OrderDetail.Defaults());
        //modelBuilder.Ignore<Waiter>();

    }
}
