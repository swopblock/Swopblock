using System;
namespace swop
{
	public class Orders: Classes
	{
		public Orders()
		{
		}

		public new static Orders Parse(string text)
		{
				if (text.Contains( "bidding")) Offers.Parse(text);
				if (text.Contains( "asking")) Offers.Parse(text);

				if (text.Contains( "buying")) Invoices.Parse(text);
				if (text.Contains( "selling")) Invoices.Parse(text);

				if (text.Contains( "paying")) Deliveries.Parse(text);
				if (text.Contains( "cashing")) Deliveries.Parse(text);

				if (text.Contains( "expensing")) Receipts.Parse(text);
				if (text.Contains( "incoming")) Receipts.Parse(text);

			return new Orders();
		}
	}
}

