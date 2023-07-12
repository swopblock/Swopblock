using System;
namespace swop
{
	public class Subjects: Clauses
	{
		public string Text;

		public Subjects()
		{
		}

		public static Subjects Parse(string text)
		{

			return new Subjects();
		}
	}
}

