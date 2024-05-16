using Cafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CafeWpfNet
{
    public class DataAdapter
    {
        HttpClient httpClient;
        public DataAdapter()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7218/");
        }
        public IEnumerable<User>? GetUsersAsync()
        {
            var r = httpClient.GetFromJsonAsync<IEnumerable<User>>("/api/users");

            return r.Result;
        }

        public bool CheckPassword1(int id, string password)
        {
            var values = new Dictionary<string, string>
        {
            { "id", id.ToString() },
            { "password", password }
        };
            var content = new FormUrlEncodedContent(values);
            var r = httpClient.PostAsync("/api/users/checkpassword", content);
            var responce = r.Result;
            if (responce != null) 
            {
                if (responce.IsSuccessStatusCode)
                {
                    var result = responce.Content.ReadFromJsonAsync < bool>();
                    return result.Result;
                }
            
            }
            return false;


        }

        public bool CheckPassword(int id, string password)
        {
            var responce = httpClient.PostAsJsonAsync("/api/users/checkpasswordjson", new {id=id,password=password}).Result;
            if (responce != null)
            {
                if (responce.IsSuccessStatusCode)
                {
                    return responce.Content.ReadFromJsonAsync<bool>().Result;
                }

            }
            return false;


        }


    }
}
