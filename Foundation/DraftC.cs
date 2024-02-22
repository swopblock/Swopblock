using System;
namespace DraftC
{
	public class DraftC
	{
		public DraftC()
		{
		}
	}


	public record CashNote;

	public record NewOrder(CashNote Hold);
	
	public record Estimate(NewOrder NewOrder)
	{
		public void Write() { }

		public void Sign() { }

		public void Broadcast() { }

		public void Confirm() { }
	}

	public record Estimate2(NewOrder NewOrder, int Did) : Estimate(NewOrder);

	public record Invoice(Estimate Estimate);

	public record Transfer(Invoice Invoice);

	public record Receipt(Transfer Transfer);


	public record Market;

	public record BtcMarket : Market;

	public record EthBarket : Market;


	public class Order
	{

		public void Estimating(NewOrder newOrder)
		{
			var Markets = new Market[3];

			var cash = new CashNote();

			var order = new NewOrder(cash);

			var estimate = new Estimate(order);

			var invoice = new Invoice(estimate);
		}

		public void Invoicing() { }

		public void Transferring() { }

		public void Receipting()




		{
            // Specify the data source.
            int[] scores = { 97, 92, 81, 60 };

            // Define the query expression.
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                select score;

            // Execute the query.
            foreach (var i in scoreQuery)
            {
                Console.Write(i + " ");
            }

            // Output: 97 92 81
            //var market = Markets




		}
	}
}








