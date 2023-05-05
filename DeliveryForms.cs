using System;
namespace swop
{
	public class DeliveryForms: ExecOrderForms
	{
		public DeliveryForms()
		{

		}

		public new static DeliveryForms Parse(string text)
		{
            if (text.Contains("paying")) return PayForms.Parse(text);

            if (text.Contains("cashing")) return CashForms.Parse(text);

            return new DeliveryForms();
		}
	}
}

