using System;
namespace swop
{
	public class Offers: ExecOrderForms
	{
		public Offers()
		{

		}

        public new static Offers Parse(string text)
        {
            if (text.Contains("bidding")) return Bids.Parse(text);

            if (text.Contains("asking")) return Asks.Parse(text);

            return new Offers();
        }
    }
}

