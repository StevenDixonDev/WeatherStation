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
            // Place ApiKey in app.config before running
            WeatherApi.Initialize(ConfigurationManager.AppSettings["APIKey"]);

            string myCity;
            WeatherView weatherView = new WeatherView();

            bool gatherData = true;
            string redo;
            WeatherData weatherData;

            while (gatherData)
            {
                redo = "";
                Console.WriteLine(weatherView.GetOpening());
                myCity = Console.ReadLine();

                weatherData = await WeatherApi.GetWeatherData(myCity);

                if (weatherData is not null)
                {
                    Console.Write(weatherView.FormatForecast(weatherData));
                }
                else
                {
                    gatherData = false;
                }

                while (redo != "y" && redo != "n") {
                    Console.WriteLine("Would you like to look up another city? [y/n]");
                    redo = Console.ReadLine();
                }

                if (redo == "n") gatherData = false;
            }
         
        }
    
    }

}
