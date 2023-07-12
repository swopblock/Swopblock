using System;
namespace swop
{
	public class Offers: Entry
	{
		public Offers()
		{
		}

        public static IOfferable Intend(string intention)
        {
            if (intention.StartsWith("I am bidding"))
                return (IOfferable)new BidForms();

            if (intention.StartsWith("I am asking"))
                return (IOfferable)new AskForms();

            return null;
        }

    }
}

