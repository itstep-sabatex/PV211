// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Transactions;

using Dapper;
using Cafe.Models;

Console.WriteLine("Hello, World!");
var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").AddUserSecrets<Program>().Build();


using (var connection = new Microsoft.Data.Sqlite.SqliteConnection(config.GetConnectionString("DefaultConnection")))
{
    connection.Open();
    var dbCommand = connection.CreateCommand();
    dbCommand.CommandText = "select * from role";
    var reader = await dbCommand.ExecuteReaderAsync();
    int i = 1;
    while (reader.Read())
    {
        var Id = reader.GetInt32("id");
        var name = reader.GetString("name");
        Console.WriteLine($"Id:{Id}   Name:{name}");
    }

    var roles = await connection.QueryAsync<Role>("select * from role where id > @level",new {level=4});
    foreach (var role in roles)
    {
        Console.WriteLine($"id:{role.Id}  name:{role.Name}");
    }




    dbCommand = connection.CreateCommand();
    dbCommand.CommandText = "insert into role (Name) values (\"New user\")";
    await dbCommand.ExecuteNonQueryAsync();

    var transaction = connection.BeginTransaction();

    dbCommand = connection.CreateCommand();
    dbCommand.Transaction = transaction;
    dbCommand.CommandText = "select * from role";
    reader = await dbCommand.ExecuteReaderAsync();
    i = 1;
    while (reader.Read())
    {
        var Id = reader.GetInt32("id");
        var name = reader.GetString("name");
        Console.WriteLine($"Id:{Id}   Name:{name}");
        var c2 = connection.CreateCommand();
        c2.Transaction = transaction;
        c2.CommandText = $"update role set name=@name where id=@id";// string.Format("update role set name=\"{0}\" where id={1}", name, Id);

        var pId = c2.CreateParameter();
        pId.ParameterName = "id";
        pId.Value = Id;

        var pName = c2.CreateParameter();
        pName.ParameterName = "name";
        pName.Value = $"{name}-{i}";


        await c2.ExecuteNonQueryAsync();
    }
    //transaction.Commit();
    transaction.Rollback();


    dbCommand = connection.CreateCommand();
    dbCommand.CommandText = "select count(id) from role";
    var count = Convert.ToInt32(await dbCommand.ExecuteScalarAsync());
    Console.WriteLine($"Records count: {count}");


}