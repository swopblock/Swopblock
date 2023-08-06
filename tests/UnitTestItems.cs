using System.Collections;
using Swopblock;
using Swopblock.Orders;
using Swopblock.TestOrders;

namespace tests;

public class TestISwopNodeItems : ISwopNodeItems
{

    public TestISwopNodeItems()
    {
        SwopWallet = new TestISwopWalletItems();

        SwopMarketItems = new TestISwopMarketItem[2];

        SwopMarketItems[0] = new TestISwopMarketItem();

        SwopMarketItems[1] = new TestISwopMarketItem();
    }

    public ISwopWalletItems SwopWallet
    {
        [Fact]
        get;

        init;
    }

    public ISwopMarketItem[] SwopMarketItems
    {
        [Fact]
        get;

        init;
    }

    [Fact]
    public void TestSwopWalet()
    {
        Assert.NotNull(SwopWallet);
    }

    [Fact]
    public void TestSwopMarketItems()
    {
        Assert.NotNull(SwopMarketItems);
    }

    [Fact]
    public void TestEachSwopMarketItem()
    {
        foreach (var item in SwopMarketItems)
        {
            Assert.NotNull(item);
        }
    }

    public class TestISwopWalletItems : ISwopWalletItems
    {
        public TestISwopWalletItems()
        {
            Watchlist = new TestIWatchlistItems();

            Portfolio = new TestIPortfolioItems();

            Cash = new TestICashItems();

            TaxDocuments = new TestITaxDocumentItems();

            BanksCards = new TestIBankCardItems();

            Settings = new TestISettingItems();

            Notifications = new TestINotificationItems();
        }

        public IWatchlistItems Watchlist
        {
            [Fact]
            get;

            init;
        }

        public IPortfolioItems Portfolio
        {
            [Fact]
            get;

            init;
        }

        public ICashItems Cash
        {
            [Fact]
            get;

            init;
        }

        public ITaxDocumentItems TaxDocuments
        {
            [Fact]
            get;

            init;
        }

        public IBankCardItems BanksCards
        {
            [Fact]
            get;

            init;
        }

        public ISettingItems Settings
        {
            [Fact]
            get;

            init;
        }

        public INotificationItems Notifications
        {
            [Fact]
            get;

            init;
        }

        public class TestIWatchlistItems : IWatchlistItems
        {
            public IWatchlistItem[] WatchlistItems { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
        }

        public class TestIPortfolioItems : IPortfolioItems
        {
            public IAssetItem[] PortfolioItems { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
        }

        public class TestICashItems : ICashItems
        {
            public ICashItem[] SwoblItems { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
        }

        public class TestITaxDocumentItems : ITaxDocumentItems
        {
            public ITaxDocumentItem[] TaxDocumentItems { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
        }

        public class TestIBankCardItems : IBankCardItems
        {
            public IBankCardItem[] BankCardItems { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
        }

        public class TestISettingItems : ISettingItems
        {
            public ISettingItem[] SettingItems { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
        }

        public class TestINotificationItems : INotificationItems
        {
            public INotificationItem[] NotificationItems { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
        }
    }

    public class TestISwopMarketItem : ISwopMarketItem
    {
        public TestISwopMarketItem()
        {
            //Orders = new IOrderItem[2];

            Orders[0] = new TestIBlockItem();

            Orders[1] = new TestIBlockItem();
        }

        public IOrderItem[] Orders
        {
            [Fact]
            get;

            init;
        }

        public class TestIBlockItem : IOrderItem
        {
            public TestIBlockItem()
            {
                Entries = new TestIEntryItem[2];

                Entries[0] = new TestIEntryItem();

                Entries[1] = new TestIEntryItem();
            }
            public IEntryItem[] Entries
            {
                [Fact]
                get;

                init;
            }
            public IMarketItem PersuedMarket { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }

            public class TestIEntryItem : IEntryItem
            {
                public TestIEntryItem()
                {
                    Contracts = new IContractItem[2];

                    Contracts[0] = new TestIContractItem();
                }

                public IContractItem[] Contracts
                {
                    [Fact]
                    get;

                    init;
                }
                public IMarketItem PersuedMarket { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }

                public class TestIContractItem : IContractItem
                {
                }

            }

            public class TestIBtcEntryItem : IBtcEntryItem
            {
                public IContractItem[] Contracts { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
            }

        }

        public class TestIBtcBlockItem : IBtcBlockItem
        {
            public TestIBtcBlockItem()
            {
                //Entries = new TestIBtcEntryItem[2];

                //Entries[0] = new TestIBtcEntryItem();

                //Entries[1] = new TestIBtcEntryItem();
            }

            public IEntryItem[] Entries
            {
                [Fact]
                get;

                init;
            }

            public class TestIBtcEntryItem : IBtcEntryItem
            {
                public IContractItem[] Contracts { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }
            }
        }
    }

    public interface IContractItem { }

    public interface IBtcEntryItem { }

    public interface IBtcBlockItem { }

}

