using System;
namespace swop
{
	public class OffersOld//: ExecOrderForms
	{
        UInt64 AtLeastMedium;

        UInt64 AtMostMedium;

        Addresses Medium;

        UInt64 AtLeastMediumExpiration;

        UInt64 AtMostMediumExpiration;

        public OffersOld()
		{

		}

        //public IInvoiceable Offer() { return null; }

        public new static Offers Parse(string text)
        {
            if (text.Contains("bidding")) return BidForms.Parse(text);

            if (text.Contains("asking")) return AskForms.Parse(text);

            return new Offers();
        }
    }
}

