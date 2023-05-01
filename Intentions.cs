using System;
namespace swop
{
	public class Intentions: Classes
	{
		public string IntentionText;

		public Subjects Subject;

		public Predicates Predicate;

		public Intentions()
		{
		}

		public static Intentions Parse(string text)
		{
			var intentions = new Intentions();

            intentions.Subject = Subjects.Parse(text);

            intentions.Predicate = Predicates.Parse(text);

			intentions.IntentionText += intentions.Subject.Text;

			intentions.IntentionText += intentions.Predicate.Text;

			return intentions;
		}
	}
}

