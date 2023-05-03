using System;
namespace swop
{
	public class Deliveries: Invoices
	{
		public Deliveries()
		{

		}

		public new static Deliveries Parse(string text)
		{
            if (text.Contains("paying")) return Payments.Parse(text);

            if (text.Contains("cashing")) return Cashments.Parse(text);

            return new Deliveries();
		}
	}
}

