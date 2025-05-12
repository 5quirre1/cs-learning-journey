using PeakRequests; // https://github.com/5quirre1/PeakRequests
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace PikiEmojiCheckThing
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
            var response = await PeakRequests.PeakRequests.Get("https://raw.githubusercontent.com/JustAGoodUsername/moaremotes-ext/refs/heads/patch-2/emotes.json");
            if (response != null)
            {
                var json = response.Json();
                var id = Question("enter the ID of the emoji you want to check: ", "sming my head");

                try
                {
                    var emojis = JsonSerializer.Deserialize<JsonElement>(json);

                    bool idExists = false;
                    foreach (var emojiArray in emojis.EnumerateArray())
                    {
                        if (emojiArray[0].GetString()?.Contains(id) == true)
                        {
                            idExists = true;
                            break;
                        }
                    }

                    if (idExists)
                    {
                        Console.WriteLine("emoji is in the list!!");
                    }
                    else
                    {
                        Console.WriteLine("emoji is not in the list..");
                    }
                }
                catch (JsonException ex)
                {
                    Console.WriteLine("failed to parse JSON: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("failed to fetch the response./..");
            }
        }
    }
}
