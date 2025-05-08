using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    private static readonly string[] MediaExtensions =
    {
        ".jpg",
        ".jpeg",
        ".png",
        ".gif",
        ".mp4",
        ".mp3",
        ".wav",
        ".ogg",
        ".flv",
        ".mkv"
    };
    private static readonly string UploadUrl = "https://feridinha.com/upload";
    private static bool _isUploading = true;

    static async Task Main(string[] args)
    {
        try
        {
            string filePath = ChooseFile();
            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }
            Thread spinnerThread = new Thread(LoadingSpinner);
            spinnerThread.IsBackground = true;
            spinnerThread.Start();
            bool success = await UploadFileAsync(filePath);

            _isUploading = false;
            spinnerThread.Join(100);

            Console.Write("\r" + new string(' ', 30) + "\r");

            if (success)
            {
                Console.WriteLine("Success!");
            }
        }
        catch (Exception ex)
        {
            _isUploading = false;
            Console.WriteLine($"\rError: {ex.Message}");
        }
    }

    static string ChooseFile()
    {
        List<string> fileChoices = Directory
            .GetFiles(".")
            .Where(f => MediaExtensions.Any(ext => f.ToLower().EndsWith(ext)))
            .Select(Path.GetFileName)
            .ToList();

        if (fileChoices.Count == 0)
        {
            Console.WriteLine("No media files found...");
            return null;
        }

        Console.WriteLine("Select a media file to upload:");
        for (int i = 0; i < fileChoices.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {fileChoices[i]}");
        }

        int choice;
        while (true)
        {
            Console.Write("Enter number (or 0 to cancel): ");
            if (
                int.TryParse(Console.ReadLine(), out choice)
                && choice >= 0
                && choice <= fileChoices.Count
            )
            {
                break;
            }
            Console.WriteLine("Invalid selection. Try again.");
        }

        if (choice == 0)
        {
            Console.WriteLine("Cancelled.");
            return null;
        }

        return fileChoices[choice - 1];
    }

    static void LoadingSpinner()
    {
        char[] spinner = { '|', '/', '-', '\\' };
        int counter = 0;

        while (_isUploading)
        {
            Console.Write($"\rUploading {spinner[counter++ % spinner.Length]}");
            Thread.Sleep(100);
        }
    }

    static async Task<bool> UploadFileAsync(string filePath)
    {
        using (HttpClient client = new HttpClient())
        using (MultipartFormDataContent formData = new MultipartFormDataContent())
        using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            StreamContent fileContent = new StreamContent(fileStream);
            formData.Add(fileContent, "file", Path.GetFileName(filePath));

            HttpResponseMessage response = await client.PostAsync(UploadUrl, formData);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                using (JsonDocument doc = JsonDocument.Parse(responseBody))
                {
                    string fileUrl = doc.RootElement.GetProperty("message").GetString();
                    Console.WriteLine($"File URL: {fileUrl}");
                }
                return true;
            }
            else
            {
                Console.WriteLine($"\rFailed, error: {(int)response.StatusCode}");
                return false;
            }
        }
    }
}
