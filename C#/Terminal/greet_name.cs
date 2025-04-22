using System;

class Program {
    static void Main() {
        Console.WriteLine("what is your name?");
        string name = Console.ReadLine();
        greet(name);
    }

    private static void greet(params string[] names) {
        foreach (string name in names) {
            Console.WriteLine("hai " + name);
        }
    }
}
