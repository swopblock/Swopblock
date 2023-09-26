using System;
namespace swop
{
    public class ReceiptsOld//: AdminOrderForms
	{
		public ReceiptsOld()
		{

		}

		public new static Receipts Parse(string text)
		{
            if (text.Contains("expensing")) return ExpenseForms.Parse(text);

            if (text.Contains("incoming")) return IncomeForms.Parse(text);

            return new Receipts();
        }
    }
}

