﻿// See https://aka.ms/new-console-template for more information
using Cafe.Models;
using EFCoreDemo;
using EFCoreDemo.Data;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");


var type = typeof(UserRole);
var properties = type.GetProperties();
foreach (var property in properties)
{
    Console.WriteLine(property.Name);
    foreach (var prop in property.GetCustomAttributes(true))
    {
        Console.WriteLine($"Attribute - {prop}");
    }
}
//MyFunction(id,test)
//{
//  return test;
//}

// Execute("MyFunction(id,test)")


using (var context = new CafeDbContext())
{
    //var roles = context.Role.ToArray();
    //roles[0].Name = roles[0].Name + DateTime.Now.ToString();
    //context.Role.Remove(roles[0]);

    //var oberole = context.Role.Single(s => s.Id == 1); // 1record
    //oberole = context.Role.First(s => s.Id == 1);      // 1recort
    //var role = new Role { Name = "EF Core user 2" };
    //context.Role.Add(role);
    //context.SaveChanges();
    //context.Database.GetDbConnection();
    //var user = context.Waiters.Single(s => s.Id == 1);
    //role = context.Role.Single(s=>s.Id == 1);
    //var userRole = new UserRole { Role = Role.admin, WaiterId = user.Id };
    //context.Add(userRole);
    //context.SaveChanges();
    var s = "jhsdk";
    var a =s.DefaultStr();


 }
Console.ReadLine();