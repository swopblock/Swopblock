using System;

namespace swop;

public class MarketSetOfOrders
{
	public LinkedList<Orders> LinkedList;

	public MarketSetOfOrders()
	{
		LinkedList = new LinkedList<Orders>();
	}
}

