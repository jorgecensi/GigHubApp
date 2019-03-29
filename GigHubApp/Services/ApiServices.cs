using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GigHubApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        public async Task<string> LoginAsync(string userName, string password)
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
            var jwt = await response.Content.ReadAsStringAsync();

            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(jwt);

            var accessToken = jwtDynamic.Value<string>("access_token");

            return accessToken;
        }

        public async Task<List<Gig>> GetGigsAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json = await client.GetStringAsync("http://gighub.azurewebsites.net/api/gigs");

            var gigs = JsonConvert.DeserializeObject<List<Gig>>(json);

            return gigs;

        }

        public async Task PostGigAsync(Gig gig, string accessToken)
        {
            var client = new HttpClient()
;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json = JsonConvert.SerializeObject(gig);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync("http://gighub.azurewebsites.net/api/gigs", content);

        }

    }
}
