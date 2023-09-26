using System;

namespace Swopblock;

public class MarketClass
{

}

public record EntryRecord(MarketClass PersuedMarket);

public record BuyEntryRecord(MarketClass BuyMarket) : EntryRecord(BuyMarket);

public class OrderRecords
{
	public OrderRecords()
	{
	}
}

