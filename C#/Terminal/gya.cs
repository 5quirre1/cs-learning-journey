using System;
using System.Threading;

namespace Main
{
class DetectLGGGGGGBTQAHHHPeople
{
	public static void Sleep(int AHH)
	{
		Thread.Sleep(AHH);
	}
	public static void Introf()
	{
		Console.WriteLine("haev  you ever wanted to see if lgb tbq");
		Sleep(1000);
		Console.WriteLine("ever though t \"do i llike peiople of same gender\"");
		Sleep(1000);
		Console.WriteLine("then wow yere yiu go");
	}
	public static void Detect(params string[] name)
	{
		 foreach (string g in name) {
			Random rnd = new Random();
			var lgbbt = rnd.Next(1, 101);
			string message = "AGGGGGGG";
			if (g == "names")
			{
				lgbbt = 44444;
			} else if (g == "squirrel")
			{
				lgbbt = 999;
			} else if (g == "nomaakip")
			{
				lgbbt = 432;
			} else if (g == "wish")
			{
				lgbbt = 700;
			}
			if (lgbbt < 20 || lgbbt < 40)
			{
			    message = "wow not a lot lggrbvb";
			} else if (lgbbt > 60 || lgbbt > 80 || lgbbt > 100)
			{
			    message = "wow lgtbh pro";
			}
			Console.WriteLine($"you are {lgbbt} lggtbh, {message}");
		}

	}
	static void Main(string[] args)
	{
		Introf();
		Console.WriteLine("==================================================");
		Console.WriteLine("welcome to lgbtqgreg detecter");
		Console.WriteLine("pyt yiyr name to start test");
		while (true)
		{
			var name = Console.ReadLine();
			name = name.ToLower();
			if (string.IsNullOrWhiteSpace(name))
			{
				Console.WriteLine("put name smh");
				continue;
			} else
			{
				Detect(name);
				break;
			}
		}

	}
}
}
