using PeakRequests; // https://github.com/5quirre1/PeakRequests/blob/main/src/PeakReqeusts.cs
using System;
using System.Threading.Tasks;

namespace LastFM
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
            string? username = Question("enter your last.fm username: ", "put a last.fm username please");
            string? apiKey = Question("enter your last.fm api key: ", "put a last.fm api key please");
            string? url = $"https://ws.audioscrobbler.com/2.0/?method=user.getrecenttracks&user={username}&api_key={apiKey}&format=json&limit=1";
            var response = await PeakRequests.PeakRequests.Get(url);
            if (response.IsSuccessful && !string.IsNullOrWhiteSpace(response.Content))
            {
                var json = response.Json();
                if (json != null)
                {
                    var track = json?["recenttracks"]?["track"]?[0];

                    var artist = track?["artist"]?["#text"]?.ToString();
                    var trackName = track?["name"]?.ToString();

                    Console.WriteLine($"{username}'s latest stuff is: '");
                    Console.WriteLine($"{trackName} by {artist}");
                }
            }
            else
            {
                Console.WriteLine("failed to get last.fm data: " + response.ErrorMessage);
                Console.WriteLine("response content: " + response.Content);
            }

        }
    }
}
