using System;
namespace swop
{
	public class InvoiceForms: AdminOrderForms
	{
		public InvoiceForms()
		{
		}

		public new static InvoiceForms Parse(string text)
		{
            if (text.Contains("buying")) return BuyForms.Parse(text);

            if (text.Contains("selling")) return SellForms.Parse(text);

            return new InvoiceForms();
        }
    }
}

