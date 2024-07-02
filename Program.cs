using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Open_Weather_Map
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Exercise 2

            IConfiguration config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

            string apiKey = config.GetSection("AppSettings")["ApiKey"];

            var client = new HttpClient();

            var cityName = "Somerset";

            var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=imperial";
            var response = client.GetStringAsync(weatherURL).Result;
         

            JObject formattedResponse = JObject.Parse(response);
            var temp = formattedResponse["main"];
            Console.WriteLine(temp);

        }
    }


    
      
}    


