using System;
namespace swop
{
	public class Receipts: Deliveries
	{
		public Receipts()
		{

		}

		public new static Receipts Parse(string text)
		{
            if (text.Contains("expensing")) return Expenses.Parse(text);

            if (text.Contains("incoming")) return Incomes.Parse(text);

            return new Receipts();
        }
    }
}

