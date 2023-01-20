using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherConsoleApp;
using WeatherConsoleApp.DataAccess;
using WeatherConsoleApp.Model;
using Newtonsoft.Json;
using System.Net;

namespace WeatherConsoleApp.Test
{
    [TestClass]
    public class GetWeatherDataTest
    {
        [TestMethod]
        public void GetData()
        {
            //var getWeatherData = new GetWeatherData();
            City_Latitude_Longitude city_Latitude_Longitude = new City_Latitude_Longitude();
            city_Latitude_Longitude.Latitude = 18.9667;
            city_Latitude_Longitude.Longitude = 72.8333;
            var actual_result=GetWeatherData.GetData(city_Latitude_Longitude);
            var client = new WebClient();
            var expected_result = client.DownloadString("https://api.open-meteo.com/v1/forecast?latitude=18.9667&longitude=72.8333&current_weather=true");
            Result r = new Result();
            r=JsonConvert.DeserializeObject<Result>(expected_result);
            Assert.AreEqual(r.longitude,actual_result.longitude);

        }

        [TestMethod]
        public void GetURI()
        {
            City_Latitude_Longitude city_Latitude_Longitude = new City_Latitude_Longitude();
            city_Latitude_Longitude.Latitude = 18.9667;
            city_Latitude_Longitude.Longitude = 72.8333;
            var actual_result = GetWeatherData.GetURI(city_Latitude_Longitude);
            Assert.AreEqual("https://api.open-meteo.com/v1/forecast?latitude=18.9667&longitude=72.8333&current_weather=true", actual_result);

        }
    }
}