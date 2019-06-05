using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorSS.Data
{
    public class WeatherForecastService
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public async Task<List<Todo>> GetForecastAsync(DateTime startDate)
        {
            HttpClient client = new HttpClient();
            var path = @"https://localhost:44346/api/todo";
            HttpResponseMessage response = client.GetAsync(path).Result;
            string json = "";
            if (response.IsSuccessStatusCode)
            {
                json =  response.Content.ReadAsStringAsync().Result;
            }
            return JsonConvert.DeserializeObject<List<Todo>>(json);

        }
    }
}
