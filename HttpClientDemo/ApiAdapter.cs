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
        Token? token; 
        public ApiAdapter() 
        {
            client = new HttpClient();  //WebClient
            client.BaseAddress = new Uri("https://sabatex.francecentral.cloudapp.azure.com");
        }

        public async Task Login(string id, string password)
        {
            var login = new Sabatex.ObjectsExchange.Models.Login { ClientId = new Guid(id), Password = password };
            var response = await client.PostAsJsonAsync("api/v0/login", login) ?? throw new Exception("Login error");
            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadFromJsonAsync<Token>() ?? throw new Exception("Token fail");
                this.token = token;
                client.DefaultRequestHeaders.Add("clientId", id);
                client.DefaultRequestHeaders.Add("apiToken", token.AccessToken);
                return;
            }
            throw new Exception($"Not login with error StatusCode: {response.StatusCode}");
        }

        public async Task SendMessage(Guid destination, string message)
        {
            client.DefaultRequestHeaders.Add("destinationId", $"{destination}");
            var response = await client.PostAsJsonAsync("/api/v0/queries", new { objectType = "", objectId = message });
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error send message {response.StatusCode}");
        }
    }
}
