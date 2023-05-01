using System;
namespace swop
{
	public class Receipters: Applicators
	{
		public Receipters()
		{
		}

        public override string? ReadLine()
        {
            return base.ReadLine();
        }

        public override void WriteLine(string line)
        {
            Console.WriteLine($"Receipter: {line}");

            base.WriteLine(line);
        }
    }
}

