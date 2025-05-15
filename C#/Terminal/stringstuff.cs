using System;
namespace StringStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            string instructions = "step 1: turn the stove on and put the pan on\nstep2: food in pan\nstep 3: eat food";
            int stepNumber = 5;
            string keyword = $"step {stepNumber}";
            int start = instructions.IndexOf(keyword);
            if (start != -1)
            {
                string after = instructions.Substring(start);
                int nextNewline = after.IndexOf('\n');
                string result = nextNewline != -1 ? after.Substring(0, nextNewline) : after;
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("no found");
            }
        }
    }
}
