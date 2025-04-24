using System;
using System.Threading;
using System.Diagnostics;

namespace WowPeak
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                ShowHelp();
                return;
            }

            string command = args[0].ToLower();

            try
            {
                switch (command)
                {
                    case "now":
                        ShowCurrentTime();
                        break;
                    case "date":
                        ShowCurrentDate();
                        break;
                    case "utc":
                        ShowUtcTime();
                        break;
                    case "countdown":
                        if (args.Length < 2 || !int.TryParse(args[1], out int seconds))
                        {
                            Console.WriteLine("error: put smth for seconds lol");
                            return;
                        }
                        Countdown(seconds);
                        break;
                    case "stopwatch":
                        RunStopwatch();
                        break;
                    case "timer":
                        if (args.Length < 2 || !int.TryParse(args[1], out int minutes))
                        {
                            Console.WriteLine("error: put smth for minute so timer wow haha");
                            return;
                        }
                        Timer(minutes);
                        break;
                    case "zones":
                        ShowTimeZones();
                        break;
                    case "help":
                        ShowHelp();
                        break;
                    default:
                        Console.WriteLine($"unknown command: {command}");
                        ShowHelp();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error: {ex.Message}");
            }
        }

        static void ShowHelp()
        {
            Console.WriteLine("Time CLI - a random thnh made by me");
            Console.WriteLine("how to use: timecli <command> [options]");
            Console.WriteLine();
            Console.WriteLine("commands:");
            Console.WriteLine("  now         show current time");
            Console.WriteLine("  date        show current date");
            Console.WriteLine("  utc         show current UTC time");
            Console.WriteLine("  countdown N run a countdown timer for N seconds");
            Console.WriteLine("  stopwatch   run a stopwatch (press enter to stop)");
            Console.WriteLine("  timer N     set a timer for N minutes");
            Console.WriteLine("  zones       show current time in major time zones");
            Console.WriteLine("  help        show this help message");
        }

        static void ShowCurrentTime()
        {
            Console.WriteLine($"current Time: {DateTime.Now.ToLongTimeString()}");
        }

        static void ShowCurrentDate()
        {
            Console.WriteLine($"current Date: {DateTime.Now.ToLongDateString()}");
        }

        static void ShowUtcTime()
        {
            Console.WriteLine($"UTC Time: {DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")}");
        }

        static void Countdown(int seconds)
        {
            Console.WriteLine($"starting countdown for {seconds} seconds...");
            
            for (int i = seconds; i >= 0; i--)
            {
                Console.Write($"\rtime remaining: {i} seconds   ");
                Thread.Sleep(1000);
            }
            
            Console.WriteLine("\ncountdown complete!!!");
        }

        static void RunStopwatch()
        {
            Console.WriteLine("stopwatch started. press Enter to stop...");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            Console.ReadLine();
            
            stopwatch.Stop();
            TimeSpan elapsed = stopwatch.Elapsed;
            
            Console.WriteLine($"elapsed time: {elapsed.Hours:00}:{elapsed.Minutes:00}:{elapsed.Seconds:00}.{elapsed.Milliseconds / 10:00}");
        }

        static void Timer(int minutes)
        {
            int seconds = minutes * 60;
            DateTime endTime = DateTime.Now.AddMinutes(minutes);
            
            Console.WriteLine($"timer set for {minutes} minutes. Will finish at {endTime.ToShortTimeString()}");
            
            while (seconds > 0)
            {
                Console.Write($"\rtime remaining: {seconds / 60:00}:{seconds % 60:00}   ");
                Thread.Sleep(1000);
                seconds--;
            }
            
            Console.WriteLine("\nTimer complete!");
            
            for (int i = 0; i < 3; i++)
            {
                Console.Beep();
                Thread.Sleep(300);
            }
        }

        static void ShowTimeZones()
        {
            Console.WriteLine("current time in major time zones:");
            
            var timeZones = new (string Name, string Id)[]
            {
                ("Los Angeles (PST/PDT)", "Pacific Standard Time"),
                ("New York (EST/EDT)", "Eastern Standard Time"),
                ("London (GMT/BST)", "GMT Standard Time"),
                ("Paris (CET/CEST)", "Central European Standard Time"),
                ("Tokyo (JST)", "Tokyo Standard Time"),
                ("Sydney (AEST/AEDT)", "AUS Eastern Standard Time")
            };
            
            foreach (var zone in timeZones)
            {
                try
                {
                    var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(zone.Id);
                    var time = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo);
                    Console.WriteLine($"{zone.Name}: {time.ToString("yyyy-MM-dd HH:mm:ss")}");
                }
                catch
                {
                    Console.WriteLine($"{zone.Name}: unable to retrieve time");
                }
            }
        }
    }
}
