using System;
namespace swop
{
	public class Autoers: Applicators
	{
		public Autoers()
		{
		}

        public override string? ReadLine()
        {
            return base.ReadLine();
        }

        public override void WriteLine(string line)
        {
            Console.WriteLine($"Autoer: {line}");

            base.WriteLine(line);
        }
    }
}

