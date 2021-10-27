using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{

    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class WeatherItem
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class MainItem
    {
        public string temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }

    public class WindItem
    {
        public double speed { get; set; }
        public int deg { get; set; }
    }

    public class CloudItem
    {
        public int all { get; set; }
    }

    public class SysItem
    {
        public int type { get; set; }
        public int id { get; set; }
        public double message { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }
    class WeatherData
    {
        public Coord coord { get; set; }
        public WeatherItem[] weather { get; set; }
        public string Base { get; set; }
        public MainItem main { get; set; }
        public int visibility { get; set; }
        public WindItem wind { get; set; }
        public CloudItem clouds { get; set; }
        public int dt { get; set; }
        public SysItem sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }

    }
}