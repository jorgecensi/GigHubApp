using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GigHubApp.Models;
using Newtonsoft.Json;

namespace GigHubApp.Services
{
    public class ApiServices
    {
        public ApiServices()
        {
        }

        public async Task<bool> RegisterAsync(
            string name, 
            string email, 
            string password, 
            string confirmPassword)
        {
            var client = new HttpClient();

            var model = new RegisterBindingModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword,
                Name = name
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("http://gighub.azurewebsites.net/api/Account/Register", content);

            return response.IsSuccessStatusCode;
        }

        public async Task LoginAsync(string userName, string password)
        {
            var keyVakues = new List<KeyValuePair<string, string>> 
            { 
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type","password")
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "http://gighub.azurewebsites.net/Token")
            {
                Content = new FormUrlEncodedContent(keyVakues)
            };

            var client = new HttpClient();
            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
        }

    }
}
