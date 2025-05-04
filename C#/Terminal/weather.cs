using PeakRequests; // https://github.com/5quirre1/PeakRequests/blob/main/src/PeakReqeusts.cs
using System;

namespace Weather
{
    class Program
    {
        public static string Question(string question, string continuemsg)
        {
            while (true)
            {
                Console.Write(question);
                var input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                Console.WriteLine(continuemsg);
            }
        }
       

        static async Task Main()
        {
            bool isDebug = false;
            string? api_key = "3da8bb24af6562a8a1a9d2c4464b5f8e";

            if (string.IsNullOrWhiteSpace(api_key))
            {
                Console.WriteLine("put it back..");
                return;
            }
            string city = Question("enter the city:  ", "put a city smh");
            string? unit = null;
            while (true)
            {
                unit = Question("enter the unit (c or f):  ", "put a unit..");
                if (unit.ToLower() == "c" || unit.ToLower() == "f")
                {
                    if (unit.ToLower() == "c")
                    {
                        unit = "metric";
                    }
                    else if (unit.ToLower() == "f")
                    {
                        unit = "imperial";
                    }
                    break;
                }
                Console.WriteLine("put one of the right units please");
                continue;
            }

            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={api_key}&units={unit}";

            var response = await PeakRequests.PeakRequests.Get(url);

            if (response.IsSuccessful && !string.IsNullOrWhiteSpace(response.Content))
            {
                var json = response.Json();
                if (json != null)
                {
                    var weather = json?["weather"]?[0]?["description"]?.ToString();
                    var temp = json?["main"]?["temp"]?.ToString();
                    var humidity = json?["main"]?["humidity"]?.ToString();
                    var wind_speed = json?["wind"]?["speed"]?.ToString();
                    var pressure = json?["main"]?["pressure"]?.ToString();
                    Console.WriteLine();
                    Console.WriteLine($"weather: {weather}");
                    Console.WriteLine($"temperature: {temp}");
                    Console.WriteLine($"humidity: {humidity}");
                    Console.WriteLine($"wind Speed: {wind_speed}");
                    Console.WriteLine($"pressure: {pressure}");
                    if (isDebug)
                    {
                        Console.WriteLine("full response because of debug");
                        Console.WriteLine(json);
                    }    
                }
                else
                {
                    Console.WriteLine("error parsing");
                }
            }
            else
            {
                Console.WriteLine($"error: {response.ErrorMessage}");
                if (isDebug)
                {
                    Console.WriteLine($"status Code: {response.StatusCode}");
                    Console.WriteLine($"response: {response.Content}");
                }
            }
        }
    }
}
