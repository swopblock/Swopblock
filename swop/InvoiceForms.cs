using System;
namespace swop
{
	public class InvoicesOld: AdminOrderForms
	{
		public InvoicesOld()
		{
		}

		public new static Invoices Parse(string text)
		{
            if (text.Contains("buying")) return BuyForms.Parse(text);

            if (text.Contains("selling")) return SellForms.Parse(text);

            return new Invoices();
        }
    }
}

