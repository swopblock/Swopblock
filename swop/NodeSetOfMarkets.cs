using System;
namespace swop
{
	public class NodeSetOfMarkets
	{
		public LinkedList<IMarkets> LinkedList;

		public NodeSetOfMarkets()
		{
			LinkedList = new LinkedList<IMarkets>(); 
		}
	}
}

