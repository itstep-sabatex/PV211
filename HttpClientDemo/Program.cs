// See https://aka.ms/new-console-template for more information
using HttpClientDemo;
using Microsoft.VisualBasic.FileIO;
using System.Linq.Expressions;
using System.Net.Http.Json;



Console.WriteLine("Hello, World!");

var adapter = new ApiAdapter();
await adapter.Login("1eea3e56-e9d7-4c72-a5a0-c12006a84949", "Aa1234567890-=");
await adapter.SendMessage(new Guid("a6d4954b-c385-43dc-a6e6-60d60cd5096f"), "Hello");
//var messages = await adapter.GetMessages();



HttpClient client = new HttpClient();
client.BaseAddress = new Uri("https://api.privatbank.ua/p24api/");
int year = 2024;
int mounth = 1;
DateTime date = new DateTime(year,mounth,1);
while (date.Month == mounth)
{
    
    var response = await client.GetAsync($"exchange_rates?date= {date.ToString("dd.MM.yyyy")}");
    var rate = await response.Content.ReadFromJsonAsync<ExchangeDescriptor>();
    date = date.AddDays(1);
    Thread.Sleep(1000);
    Console.WriteLine(date);
}
//WebClient
client.BaseAddress = new Uri("https://sabatex.francecentral.cloudapp.azure.com");
await client.DeleteAsync("api/v0/queries/12312");

// request   - запит до сервера
// response  - відповідь сервера
// 
// GET - запит
//  url - http:\\www.google.com\index?Id=23
// http/https - протокол
// www.google.com - DNS адреса сервера (можна IP адресу)
// index.html - route (маршрут)
// ?id=23


//POST - відправка даних на сервер
// url - http:\\www.google.com\index
// параметри передаються в Body
// результат повертаэться в BODY


// DELETE - видалення даних 
// http://google.com/clients/12


// PUT //PATH


// class Stude
//var a = new {Id=new Guid(),Password="password"};

//client.DefaultRequestHeaders.Add("MyHeader", "XXRT");
//var responce = await client.PostAsJsonAsync("https://www.google.com", student);
//var responce = await client.GetStringAsync("https://www.google.com");//  GetAsync("https://www.google.com");
var responce = await client.GetAsync("https://www.google.com");

System.Text.Json.JsonSerializer.Serialize(new { Id = new Guid(), Password = "password" });
var r  = await client.PostAsJsonAsync("login", new { Id = new Guid(), Password = "password" });
if (responce.IsSuccessStatusCode)
{
    var s = await responce.Content.ReadAsStringAsync();
    int start = 0;
    int count = 0;
    while(-1 != (start = s.IndexOf("<div", start)))
    {
        count++;
        start++;

    }
}

// <div> </div>