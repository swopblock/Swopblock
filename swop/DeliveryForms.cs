using System;
namespace swop
{
	public class DeliveriesOld//: ExecOrderForms
	{
		public DeliveriesOld()
		{

		}

		public new static Deliveries Parse(string text)
		{
            if (text.Contains("paying")) return PayForms.Parse(text);

            if (text.Contains("cashing")) return CashForms.Parse(text);

            return new Deliveries();
		}
	}
}

