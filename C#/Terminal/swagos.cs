using Cosmos.System;
using System;

namespace SwagOs
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Console.WriteLine("welcome to real swagos");
        }

        protected override void Run()
        {
            Console.Write("type: ");
            var wow = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(wow))
            {
                Console.WriteLine("ok");
            }
            else
            {
                Console.WriteLine(wow);
            }
        }
    }
}

// swagos is own by noma sksipo
