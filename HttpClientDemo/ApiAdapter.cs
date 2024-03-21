using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientDemo
{
    public class ApiAdapter
    {
        private readonly HttpClient client;  //WebClient
        public ApiAdapter() 
        {
            client = new HttpClient();  //WebClient
            client.BaseAddress = new Uri("https://sabatex.francecentral.cloudapp.azure.com");
        }

        public async Task<Token> Login(string id, string password)
        {
            var login = new Sabatex.ObjectsExchange.Models.Login { ClientId = new Guid(id), Password = password };
            var response = await client.PostAsJsonAsync("api/v0/login", login) ?? throw new Exception("Login error");
            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadFromJsonAsync<Token>() ?? throw new Exception("Token fail");

                return token;
            }
            throw new Exception($"Not login with error StatusCode: {response.StatusCode}");

        }
    }
}
