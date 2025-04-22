using System;

namespace BallWOW {
class Peak {
	static void Main(string[] args) {
		string[] answers = {
			"It is certain.",
			"It is decidedly so.",
			"Without a doubt.",
			"Yes, definitely.",
			"You may rely on it.",
			"As I see it, yes.",
			"Most likely.",
			"Outlook good.",
			"Yes.",
			"Reply hazy, try again.",
			"Ask again later.",
			"Better not tell you now.",
			"Cannot predict now.",
			"Concentrate and ask again.",
			"Don't count on it.",
			"My reply is no.",
			"My sources say no.",
			"Outlook not so good.",
			"Very doubtful."
		};

		Random random = new Random();

		while (true) {
			Console.WriteLine("welcome to C# 8 Ball made by Squirrel./..");
			Console.WriteLine("ask a question to the 8 Ball... (or say exit)\n");
			var fff = Console.ReadLine();
                
			if (string.IsNullOrWhiteSpace(fff)) {
				Console.WriteLine("aska  aa a a a a aquiwst");
				continue;
			} else if (fff.ToLower() == "exit") {
				Console.WriteLine("ok bai");
				break;
			} else {
			    // https://stackoverflow.com/a/48799167
				int index = random.Next(answers.Length);
				string randomItem = answers[index];
				Console.WriteLine($"8b Ball says: {randomItem}..\n");
			}
		}
	}
}
}
