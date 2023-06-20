using System;

namespace swop;

public class MarketSetOfOrders
{
	public LinkedList<OrdersOld> LinkedList;

	public MarketSetOfOrders()
	{
		LinkedList = new LinkedList<OrdersOld>();
	}
}

