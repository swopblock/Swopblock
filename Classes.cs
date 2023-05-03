using System;
namespace swop
{
	public class Clauses
	{
		public Subjects Subject;

		public Predicates Predicate;

		public Clauses()
		{

		}

		public static Clauses Parse(string text)
		{
			if (text.EndsWith(".") == false)
			{
				return new Clauses();
			}

			if (Char.IsUpper(text[0]) == false)
			{
				return new Clauses();
			}

            return Intentions.Parse(text);
		}

		public void Text()
		{

		}
	}
}

