using System;
namespace swop
{
	public class Nodes
	{
		public Assets Cash;

		public GroupOfAssets Assets;

		public GroupOfNodes Peers;

		public GroupOfMarkets Markets;

		public GroupOfOrders OrderHistory;

		public OrderingCores OrderingCore;

        public Nodes()
		{
			Cash = new Assets();

			Peers = new GroupOfNodes();

			Markets = new GroupOfMarkets();

			OrderHistory = new GroupOfOrders();

			OrderingCore = new OrderingCores();
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

