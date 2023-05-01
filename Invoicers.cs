using System;
namespace swop
{
	public class Invoicers: Applicators
	{
		public Invoicers()
		{
		}

        public override string? ReadLine()
        {
            return base.ReadLine();
        }

        public override void WriteLine(string line)
        {
            Console.WriteLine($"Invoicer: {line}");

            base.WriteLine(line);
        }
    }
}

