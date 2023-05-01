using System;
using System.Linq;

namespace swop
{
	public class Applicators: Subjects
	{
        Queue<string> SetOfLines = new Queue<string>();

		public Applicators()
		{
		}

		public virtual void WriteLine(string line)
        {
            SetOfLines.Enqueue(line);
        }

        public virtual string? ReadLine()
        {
            return SetOfLines.Dequeue();
        }

        public static Applicators Parse(string text)
        {
            if (text.Contains("bidding")) return Users.Parse(text);
            if (text.Contains("asking")) return Users.Parse(text);
            if (text.Contains("buying")) return Users.Parse(text);
            if (text.Contains("selling")) return Users.Parse(text);
            if (text.Contains("paying")) return Users.Parse(text);
            if (text.Contains("cashing")) return Users.Parse(text);
            if (text.Contains("expensing")) return Users.Parse(text);
            if (text.Contains("incoming")) return Users.Parse(text);

            return new Applicators();
        }
    }
}

