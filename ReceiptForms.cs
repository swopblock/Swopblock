using System;
namespace swop
{
    public class ReceiptForms: AdminOrderForms
	{
		public ReceiptForms()
		{

		}

		public new static ReceiptForms Parse(string text)
		{
            if (text.Contains("expensing")) return ExpenseForms.Parse(text);

            if (text.Contains("incoming")) return IncomeForms.Parse(text);

            return new ReceiptForms();
        }
    }
}

