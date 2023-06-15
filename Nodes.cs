using System;
namespace swop
{
	public class Nodes
	{
		//public OfferingCores OfferingCore;

		//public InvoicingCores InvoicingCore;

		//public DeliveringCores DeliveringCore;

		//public ReceiptingCores ReceiptingCore;

		//public AppCores[] AppSetOfCores;

		//public AdminCores[] AdminSetOfCores;

		public NetworkSetOfNodes Neighborhood;

		public SuperSetOfCores SuperCore;

		public SuperSetOfMarkets SuperMarket;


        public Nodes()
		{
			Neighborhood = new NetworkSetOfNodes();

			SuperCore = new SuperSetOfCores();

			SuperMarket = new SuperSetOfMarkets();
		}

		public void Run()
		{
			var input = Console.In;
			var output = Console.Out;
		}

		public void OfferIntention(string intention)
		{
			//return null;
		}

		public string[] OrderNotifications()
		{
			return null;
		}

		public string ReceiptNotification()
		{
			return null;
		}
    }
}

