using System.Collections;
using Swopblock;

namespace tests;

public class TestRelayNode: IRelayNodes
{
    public IWallets testWallet;

    public IMarketplace testMarketPlace;

    public TestRelayNode()
    {
        testWallet = new TestWallet();

        testMarketPlace = new TestMarketplace();
    }

    public IWallets Wallet
    {
        [Fact]
        get => testWallet;

        [Theory]
        [InlineData(null)]
        set => testWallet = value;
    }

    public IMarketplace Marketplace
    {
        [Fact]
        get => testMarketPlace;

        [Theory]
        [InlineData(null)]
        set => testMarketPlace = value;
    }

    [Fact]
    public void Test1()
    {

    }
}

public class TestWallet : IWallets
{
    public IWatchlist Watchlist { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public IPortfolio Portfolio { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public ICash Cash { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public ITaxDocuments TaxDocuments { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public IBankCards BanksCards { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public ISettings Settings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public INotifications Notifications { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}

public class TestMarketplace : IMarketplace
{
    public Swopblock.IMarkets this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public ISwopStream SwopStream { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public int Count => throw new NotImplementedException();

    public bool IsReadOnly => throw new NotImplementedException();

    public void Add(Swopblock.IMarkets item)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(Swopblock.IMarkets item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(Swopblock.IMarkets[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<Swopblock.IMarkets> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public int IndexOf(Swopblock.IMarkets item)
    {
        throw new NotImplementedException();
    }

    public void Insert(int index, Swopblock.IMarkets item)
    {
        throw new NotImplementedException();
    }

    public bool Remove(Swopblock.IMarkets item)
    {
        throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
