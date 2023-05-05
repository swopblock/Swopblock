using System;
namespace swop
{
	public class OfferForms: ExecOrderForms
	{
		public OfferForms()
		{

		}

        public new static OfferForms Parse(string text)
        {
            if (text.Contains("bidding")) return BidForms.Parse(text);

            if (text.Contains("asking")) return AskForms.Parse(text);

            return new OfferForms();
        }
    }
}

