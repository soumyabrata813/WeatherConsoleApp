using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherConsoleApp.Model
{
    public class City_Latitude_Longitude
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public City_Latitude_Longitude()
        {
        }
        public City_Latitude_Longitude(int v1, int v2)
        {
            this.Latitude = v1;
            this.Longitude = v2;
        }
    }
}
