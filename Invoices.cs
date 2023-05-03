using System;
namespace swop
{
	public class Invoices: Offers
	{
		public Invoices()
		{
		}

		public new static Invoices Parse(string text)
		{
            if (text.Contains("buying")) return Buys.Parse(text);

            if (text.Contains("selling")) return Sales.Parse(text);

            return new Invoices();
        }
    }
}

