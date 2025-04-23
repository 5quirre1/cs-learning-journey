using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Nodes;

class Program
{
    static async Task Main()
    {
        using HttpClient client = new HttpClient();
        HttpResponseMessage response = null;

        try
        {
            string username = string.Empty;
            string apiKey = string.Empty;

            while (true)
            {
                Console.Write("enter your Last.fm username: ");
                username = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(username))
                {
                    Console.WriteLine("\nplease enter a username...");
                    continue;
                }

                break;
            }

            while (true)
            {
                Console.Write("enter your last.fm API key!!!!: ");
                apiKey = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(apiKey))
                {
                    Console.WriteLine("\nplease enter an API key...");
                    continue;
                }
                break;
            }

            string url = $"https://ws.audioscrobbler.com/2.0/?method=user.getrecenttracks&user={username}&api_key={apiKey}&format=json&limit=1";

            response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            JsonNode jsonResponse = JsonNode.Parse(responseBody);

            if (jsonResponse?["recenttracks"]?["track"]?[0] != null)
            {
                JsonNode trackNode = jsonResponse["recenttracks"]["track"][0];
                string artist = trackNode?["artist"]?["#text"]?.ToString();
                string trackName = trackNode?["name"]?.ToString();

                Console.WriteLine($"\n{username}'s recently played track:");
                Console.WriteLine($"artist: {artist}");
                Console.WriteLine($"song: {trackName}");
            }
            else
            {
                Console.WriteLine("\ncould not parse info..");
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"\nRequest error: {e.Message}");
        }
        catch (JsonException e)
        {
            Console.WriteLine($"\njson parsing error: {e.Message}");
            if (response?.Content != null) 
            {
                Console.WriteLine($"raw json greg: {await response.Content.ReadAsStringAsync()}");
            }
        }
    }
}
