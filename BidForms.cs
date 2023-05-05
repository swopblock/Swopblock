using System;
namespace swop
{
	public class BidForms: OfferForms
	{
		public BidForms()
		{

		}

		public new static BidForms Parse(string text)
		{
			var txt = text.Split("in order to", 2)[0];

			if (txt.Contains("BTC"))
			{
				return BtcBids.Parse(text);
			}

			if (txt.Contains("ETH"))
			{
				return EthBids.Parse(text);
			}

			return new BidForms();
		}
	}



	public class BtcBids: BidForms
	{
		public BtcBids()
		{

		}

		public new static BtcBids Parse(string text)
		{
			var txt = text.Split(' ', 1)[0];

			if (txt.Contains("I"))
			{
				return SignableBtcBids.Parse(text);
			}

			if (txt.Contains("We"))
			{
				return ConfirmedBtcBids.Parse(text);
			}
			return new BtcBids();
		}
	}

	public class SignableBtcBids: BtcBids
	{
		public SignableBtcBids(string text)
		{
			string[] separators =
			{
				"I am bidding at least ",
				" and at most ",
				" SWOBL from my BTC address ",
				" in order to buy at least",
				" and at most ",
				" ",
				" from the market "

			};

			var txt = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
		}

		public new static SignableBtcBids Parse(string text)
		{
			return new SignableBtcBids(text);
		}
	}

	public class ConfirmedBtcBids: BtcBids
	{
		public ConfirmedBtcBids()
		{

		}

		public new static ConfirmedBtcBids Parse(string text)
		{
			return new ConfirmedBtcBids();
		}
	}



	public class EthBids: BidForms
	{
		public EthBids()
		{
		
		}

		public new static EthBids Parse(string text)
		{
            var txt = text.Split(' ', 1)[0];


            if (txt.Contains("I"))
            {
                return SignableEthBids.Parse(text);
            }

            if (txt.Contains("We"))
            {
                return ConfirmedEthBids.Parse(text);
            }

            return new EthBids();
		}
	}

	public class SignableEthBids : EthBids
	{
		public SignableEthBids()
		{

		}

		public new static SignableEthBids Parse(string text)
		{
			return new SignableEthBids();
		}
	}

	public class ConfirmedEthBids : EthBids
	{
		public ConfirmedEthBids()
		{

		}

		public new static ConfirmedEthBids Parse(string text)
		{
			return new ConfirmedEthBids();
		}
	}
}

