using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace WeatherStation
{
    class WeatherApi
    {
        private static HttpClient client;
        private static string Key;

        public static void Initialize(string APIKey)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
            Key = APIKey;
        }

        public static async Task<WeatherData> GetWeatherData(string city)
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                HttpResponseMessage response = await client.GetAsync($"weather?q={city}&appid={Key}");

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                WeatherData myData = JsonConvert.DeserializeObject<WeatherData>(responseBody);

                return myData;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return new WeatherData();
            }
        }
    }
}
