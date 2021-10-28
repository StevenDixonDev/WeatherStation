using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    class WeatherView
    {
        public string GetOpening()
        {
            return "Please specify a city to pull the current weather info for!";
        }

        public string FormatForecast(WeatherData data)
        {
            return $"In {data.name} \n" +
                $"The current temperature is: {data.main.temp} \n" +
                $"The High for the day is {data.main.temp_max} \n" +
                $"The Low for the day is {data.main.temp_min} \n" +
                $"The Pressure is {data.main.pressure} and the Humidity is {data.main.humidity} \n" +
                "Have a great day! \n"; 
        }
    }
}
