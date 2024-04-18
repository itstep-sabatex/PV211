// See https://aka.ms/new-console-template for more information
using Cafe.Models;
using EFCoreDemo.Data;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");


using (var context = new CafeDbContext())
{
    var roles = context.Role.ToArray();
    roles[0].Name = roles[0].Name + DateTime.Now.ToString();
    context.Role.Remove(roles[0]);

    var oberole = context.Role.Single(s => s.Id == 1); // 1record
    oberole = context.Role.First(s => s.Id == 1);      // 1recort
    var role = new Role { Name = "EF Core user 2" };
    context.Role.Add(role);
    context.SaveChanges();
    context.Database.GetDbConnection();
    var user = context.Waiters.Single(s => s.Id == 1);
    role = context.Role.Single(s=>s.Id == 1);
    var userRole = new UserRole { RoleId = role.Id, WaiterId = user.Id };
    context.Add(userRole);
    context.SaveChanges();

 }
Console.ReadLine();