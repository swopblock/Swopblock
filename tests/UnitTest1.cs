using System.Collections;
using Swopblock;

namespace tests;

public class TestISwopNodeItems : ISwopNodeItems
{
    private ISwopWalletItems PrivateSwopWallet;

    private ISwopMarketItem[] PrivateSwopMarketItems;

    public TestISwopNodeItems()
    {
        SwopWallet = PrivateSwopWallet = new TestSwopWalletItems();

        SwopMarketItems = PrivateSwopMarketItems = null;
    }

    public ISwopWalletItems SwopWallet
    {
        [Fact]
        get => throw new NotImplementedException();

        init => throw new NotImplementedException();
    }

    public ISwopMarketItem[] SwopMarketItems
    {
        [Fact]
        get => throw new NotImplementedException();

        init => throw new NotImplementedException();
    }
}

public class TestSwopWalletItems : ISwopWalletItems
{
    public IWatchlistItems Watchlist { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public IPortfolioItems Portfolio { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public ISwoblItems Swobl { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public ITaxDocumentItems TaxDocuments { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public IBankCardItems BanksCards { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public ISettingItems Settings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public INotificationItems Notifications { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
