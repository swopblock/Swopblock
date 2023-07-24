using System;

namespace swop;

public class BtcMarkets: IMarkets
{
	public BtcMarkets()
	{
	}

    public IMaterials Materials { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public IBalances[] Balances { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public IEntries[] Entries { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}

