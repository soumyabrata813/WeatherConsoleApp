using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using WeatherConsoleApp.Model;

namespace WeatherConsoleApp.DataAccess
{
    public class GetWeatherData
    {
        public static Result GetData(City_Latitude_Longitude city_latitude_longitude)
        {
            Result r = new Result();
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString(GetURI(city_latitude_longitude));
                r = JsonConvert.DeserializeObject<Result>(result);
            }
            return r;
        }

        public static String GetURI(City_Latitude_Longitude city_latitude_longitude)
        {
            string baseURL = "https://api.open-meteo.com/v1/forecast?";
            string URI = baseURL + "latitude=" + city_latitude_longitude.Latitude + "&longitude=" + city_latitude_longitude.Longitude + "&current_weather=true";
            return URI;
        }
    }
}
