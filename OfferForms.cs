using System;
namespace swop
{
	public class OfferForms: ExecOrderForms
	{
        UInt64 AtLeastMedium;

        UInt64 AtMostMedium;

        Addresses Medium;

        UInt64 AtLeastMediumExpiration;

        UInt64 AtMostMediumExpiration;

        public OfferForms()
		{

		}

        public IInvoiceable Offer() { return null; }

        public new static OfferForms Parse(string text)
        {
            if (text.Contains("bidding")) return BidForms.Parse(text);

            if (text.Contains("asking")) return AskForms.Parse(text);

            return new OfferForms();
        }
    }
}

