// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using System.Data;

Console.WriteLine("Hello, World!");

var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").AddUserSecrets<Program>().Build();


using (var connection = new Microsoft.Data.Sqlite.SqliteConnection(config.GetConnectionString("DefaultConnection")))
{
    connection.Open();
    var dbCommand = connection.CreateCommand();
    dbCommand.CommandText = "select * from role";
    var reader = dbCommand.ExecuteReader();
    while (reader.Read())
    {
        var Id = reader.GetInt32("id");
        var name = reader.GetString("name");
        Console.WriteLine($"Id:{Id}   Name:{name}");
    }

}