using System;
namespace swop
{
	public class Receipters: Incenters
	{
		public Receipters()
		{
		}

        public string? ReadLine()
        {
            return null; // base.ReadLine();
        }

        public void WriteLine(string line)
        {
            Console.WriteLine($"Receipter: {line}");

            //base.WriteLine(line);
        }
    }
}

