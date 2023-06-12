using System;
namespace swop
{
	public class Invoicers: Incenters
	{
		public Invoicers()
		{
		}

        public string? ReadLine()
        {
            return null; // base.ReadLine();
        }

        public void WriteLine(string line)
        {
            Console.WriteLine($"Invoicer: {line}");

            //base.WriteLine(line);
        }
    }
}

