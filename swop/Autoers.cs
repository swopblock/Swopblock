using System;
namespace swop
{
	public class Autoers: Incenters
	{
		public Autoers()
		{
		}

        public  string? ReadLine()
        {
            return null;// base.ReadLine();
        }

        public  void WriteLine(string line)
        {
            Console.WriteLine($"Autoer: {line}");

            //base.WriteLine(line);
        }
    }
}

