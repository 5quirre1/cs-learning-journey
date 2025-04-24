using System;

namespace OOP
{
    class Car
    {
       string Color = "blue";
       
       static void Main(string[] args)
       {
           Car Carobj = new Car();
           Console.WriteLine(Carobj.Color);
       }
    }
}
