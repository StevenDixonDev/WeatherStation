using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    class Program
    {
        static async Task Main(string[] args)
        {
            WeatherApi.Initialize(ConfigurationManager.AppSettings["APIKey"]);

            string myCity;

            Console.WriteLine("Welcome to weather station, please specify a city to pull the current weather info for!");
            myCity = Console.ReadLine();

            WeatherData t = await WeatherApi.GetWeatherData(myCity);

            var v = t.weather.Select(vp => $"{vp.description}");
            foreach(var i in v)
            {
                Console.WriteLine(i);
            }
            //Console.WriteLine(t.weather);
        }
    
    }

}
