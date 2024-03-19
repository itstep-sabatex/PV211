// See https://aka.ms/new-console-template for more information
using HttpClientDemo;
using Microsoft.VisualBasic.FileIO;
using System.Linq.Expressions;
using System.Net.Http.Json;

Console.WriteLine("Hello, World!");

HttpClient client = new HttpClient();  //WebClient





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

var student = new Student { Id = 1,Name="Jonn",Description="Student AO",FirstName="Jonn",LastName="Faro" };
student.FirstName = "Hary";
//client.DefaultRequestHeaders.Add("MyHeader", "XXRT");
//var responce = await client.PostAsJsonAsync("https://www.google.com", student);
//var responce = await client.GetStringAsync("https://www.google.com");//  GetAsync("https://www.google.com");
var responce = await client.GetAsync("https://www.google.com");
if (responce.IsSuccessStatusCode)
{
    var s = await responce.Content.ReadAsStringAsync();
}
