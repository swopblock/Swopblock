using System;

namespace swop
{
	public class Predicates: Classes
	{
		public string Text;

        public Verbs Verb;

        public SetsOfObjects Objects;

        public Predicates()
		{
		}

		public static Predicates Parse(string text)
		{
			var Predicate = new Predicates();

			Predicate.Verb = Verbs.Parse(text);

			Predicate.Objects = SetsOfObjects.Parse(text);

			return Predicate;
		}
	}
}

