using System;
using System.IO;

namespace Wow
{
    class Program
    {
        static void Main(string[] args)
        {
            string wow = "wpw";
            File.WriteAllText("filename.txt", wow);
            var thing = File.ReadAllText("filename.txt");
            Console.WriteLine(thing);
        }
    }
}
