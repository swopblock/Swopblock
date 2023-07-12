using System;
namespace swop
{
	public class Intentions: Clauses
	{
		public string IntentionText;

		public Subjects Subject;

		public Predicates Predicate;

		public Intentions()
		{
		}

		public static Intentions ParseSave(string text)
		{
			var intentions = new Intentions();

            intentions.Subject = Subjects.Parse(text);

            intentions.Predicate = Predicates.Parse(text);

			intentions.IntentionText += intentions.Subject.Text;

			intentions.IntentionText += intentions.Predicate.Text;

			return intentions;
		}

		public new static Intentions Parse(string text)
		{
			return null;// Orders.Parse(text);
		}

		public string Text()
		{
			return "";
		}
	}
}

