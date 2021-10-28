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
                if (e.Message.Contains("404"))
                {
                    Console.WriteLine("It looks like that city was not found.");
                } else if (e.Message.Contains("401"))
                {
                    Console.WriteLine("An Error Occured, please check you API key.");
                } else
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
                return null;
            }
        }
    }
}
