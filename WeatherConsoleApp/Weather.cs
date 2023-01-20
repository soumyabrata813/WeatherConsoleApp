using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using WeatherConsoleApp.Model;
using WeatherConsoleApp.DataAccess;

namespace WeatherConsoleApp
{
    public class Weather
    {
        static void Main(string[] args)
        {
            string city_name = null;
            if (args.Length==0)
            {
                Console.WriteLine("Enter City - ");
                city_name = Console.ReadLine();
            }
            else
            {
                city_name = args[0];
            }
            Run_WeatherApp(city_name);
        }

        public static void Run_WeatherApp(string city_name)
        {
            City_Latitude_Longitude city_Latitude_Longitude = Get_City_Latitude_Longitude(city_name);
            if(city_Latitude_Longitude.Latitude!=0 &&city_Latitude_Longitude.Longitude!=0)
            {
                Result result= GetWeatherData.GetData(city_Latitude_Longitude);
                Print_Weather(city_name,result);
            }
            else
            {
                Console.WriteLine("City name not found- "+ city_name);
            }
        }

        public static City_Latitude_Longitude Get_City_Latitude_Longitude(string city_name)
        {
            City_Latitude_Longitude city_latitude_longitude = new City_Latitude_Longitude(0,0);
            List<City_Details> city_Details = new List<City_Details>();
            string text = File.ReadAllText(@"city_latitude_longitude.json");
            city_Details = JsonConvert.DeserializeObject<List<City_Details>>(text);
            foreach (var city in city_Details)
            {
                if (city.City.ToLower().Equals(city_name.ToLower()))
                {
                    city_latitude_longitude.Latitude = Convert.ToDouble(city.Lat);
                    city_latitude_longitude.Longitude = Convert.ToDouble(city.Lng);
                    break;
                }
            }
            return city_latitude_longitude;
        }
        public static void Print_Weather(string city_name,Result result)
        {
            var time=result.current_weather.time.Split('T');
            Console.WriteLine(city_name+ " weather on " +time[0]+" at "+time[1]);
            Console.WriteLine("temperature- "+result.current_weather.temperature);
            Console.WriteLine("windspeed- " + result.current_weather.windspeed);
            Console.Write("winddirection- " + result.current_weather.winddirection);
        }
    }
}
