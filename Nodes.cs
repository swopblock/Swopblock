using System;
namespace swop
{
	public class Nodes
	{
        public NodeSetOfMarkets Markets;

        //public OfferingCores OfferingCore;

        //public InvoicingCores InvoicingCore;

        //public DeliveringCores DeliveringCore;

        //public ReceiptingCores ReceiptingCore;

        //public AppCores[] AppSetOfCores;

        //public AdminCores[] AdminSetOfCores;

        public NodeSetOfNodes Neighborhood;

		public NodeSetOfCores SuperCore;



        public Nodes()
		{
            Markets = new NodeSetOfMarkets();

            Neighborhood = new NodeSetOfNodes();

			SuperCore = new NodeSetOfCores();

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

