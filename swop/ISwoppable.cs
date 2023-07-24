using System;

namespace Swopblock;

public interface ISwopState
{
	ISwopState Verify();
}

public interface ISwoppable
{
	//public
	int Swop(int MarketID)
	{
		throw new NotImplementedException();
	}

	public int Verify()
	{
		return 1;
	}
}

