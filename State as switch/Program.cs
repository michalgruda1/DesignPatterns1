using System;
using System.Text;

namespace DesignPattern1
{
	class Program
	{
		enum State
		{
			Locked,
			Failed,
			Unlocked,
		}

		static void Main(string[] args)
		{
			var state = State.Locked;
			var code = "1234";
			var input = new StringBuilder();

			Console.WriteLine("Type in 4-digit code to unlock the safe (1234)");
			Console.WriteLine("LOCKED");

			while (true)
			{
				switch (state)
				{
					case State.Locked:
						input.Append(Console.ReadKey().KeyChar);
						if (!code.StartsWith(input.ToString()))
						{
							goto case State.Failed;
						}
						else if (code == input.ToString())
						{
							goto case State.Unlocked;
						}
						state = State.Locked;
						break;
					case State.Failed:
						Console.CursorLeft = 0;
						Console.WriteLine("FAILED");
						input.Clear();
						break;
					case State.Unlocked:
						Console.CursorLeft = 0;
						Console.WriteLine("SUCCESS");
						break;
					default:
						throw new ArgumentOutOfRangeException();
				} 
			}
		}
	}
}