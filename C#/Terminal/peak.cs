using System;

namespace Wow
{
    class Peak
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the peak tester");
            Console.WriteLine("First put your name");

            string name = Console.ReadLine();
            name = name.ToLower();

            if (name == "squirrel")
            {
                Console.WriteLine("wow so peak");
            }
            else if (name == "noma" || name == "nomaakip" || name == "swag")
            {
                Console.WriteLine("WOW WOW WOW SO SWAG #SWAG #SWAG #I LOVE DRINKING");
            }
            else if (name == "wish")
            {
                Console.WriteLine("come back wish..");
            }
            else
            {
                Console.WriteLine("AAAA");
            }
        }
    }
}
