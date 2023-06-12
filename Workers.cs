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
            if (text.Contains("bidding")) return UsersOld.Parse(text);
            if (text.Contains("asking")) return UsersOld.Parse(text);
            if (text.Contains("buying")) return UsersOld.Parse(text);
            if (text.Contains("selling")) return UsersOld.Parse(text);
            if (text.Contains("paying")) return UsersOld.Parse(text);
            if (text.Contains("cashing")) return UsersOld.Parse(text);
            if (text.Contains("expensing")) return UsersOld.Parse(text);
            if (text.Contains("incoming")) return UsersOld.Parse(text);

            return new Applicators();
        }
    }
}

