using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherConsoleApp;
using WeatherConsoleApp.DataAccess;
using WeatherConsoleApp.Model;
using Newtonsoft.Json;
using System.Net;

namespace WeatherConsoleApp.Test
{
    [TestClass]
    public class WeatherTest
    {
        [TestMethod]
        public void Get_City_Latitude_Longitude_positive()
        {
            string city_name = "Mumbai";
            var actual_result = Weather.Get_City_Latitude_Longitude(city_name);
            Assert.AreEqual(18.9667, actual_result.Latitude);
            Assert.AreEqual(72.8333, actual_result.Longitude);
        }
        [TestMethod]
        public void Get_City_Latitude_Longitude_nagetive()
        {
            string city_name = "xyz";
            var actual_result = Weather.Get_City_Latitude_Longitude(city_name);
            Assert.AreEqual(0, actual_result.Latitude);
            Assert.AreEqual(0, actual_result.Longitude);
        }
    }
}