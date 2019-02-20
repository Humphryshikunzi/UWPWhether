using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace UWPWheather
{
   public class OpenWeatherMapProxycs
    {
        public async static Task<RootObject> GetWeather(double lat, double lon)
        {
            var http = new HttpClient();
            var response =
                await http.GetAsync(
                    "https://samples.openweathermap.org/data/2.5/weather?lat=1.2921&lon=39.8219&appid=b6907d289e10d714a6e88b30761fae22");
            var results = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(results));
            var data = (RootObject) serializer.ReadObject(ms);
            return data;;
        }
    }
   [DataContract]
    public class Coord
    {
        [DataMember]
        public double lon { get; set; }
        public double lat { get; set; }
    }
    [DataContract]
    public class Sys
    {
        [DataMember]
        public string country { get; set; }
        [DataMember]
        public int sunrise { get; set; }
        [DataMember]
        public int sunset { get; set; }
    }
    [DataContract]
    public class Weather
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string main { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string icon { get; set; }
    }
    [DataContract]
    public class Main
    {
        public double temp { get; set; }
        [DataMember]
        public int humidity { get; set; }
        [DataMember]
        public int pressure { get; set; }
        [DataMember]
        public double temp_min { get; set; }
        [DataMember]
        public double temp_max { get; set; }
    }
    [DataContract]
    public class Wind
    {
        public double speed { get; set; }
        public double deg { get; set; }
    }
    [DataContract]
    /*
    public class Rain
    {
        public int __invalid_name__3h { get; set; }
    }*/

    public class Clouds
    {
        public int all { get; set; }
    }
    [DataContract]
    public class RootObject
    {
        [DataMember]
        public Coord coord { get; set; }
        [DataMember]
        public Sys sys { get; set; }
        [DataMember]
        public List<Weather> weather { get; set; }
        [DataMember]
        public Main main { get; set; }
        [DataMember]
        public Wind wind { get; set; }
       // [DataMember]
        //public Rain rain { get; set; }
        [DataMember]
        public Clouds clouds { get; set; }
        [DataMember]
        public int dt { get; set; }
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int cod { get; set; }
    }
}
