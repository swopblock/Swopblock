using System;

namespace Swopblock

{
    public interface ISwopNodeItems
    {
        ISwopWalletItems SwopWallet { get; init; }

        ISwopMarketItem[] SwopMarketItems { get; init; }
    }

    #region Swop Node Details


    public interface ISwopWalletItems
    {

        public IWatchlistItems Watchlist { get; set; }

        public IPortfolioItems Portfolio { get; set; }

        public ISwoblItems Swobl { get; set; }

        public ITaxDocumentItems TaxDocuments { get; set; }

        public IBankCardItems BanksCards { get; set; }

        public ISettingItems Settings { get; set; }

        public INotificationItems Notifications { get; set; }
    }

    #region Swop Wallet Details

    public interface IWatchlistItems
    {
        public IWatchlistItem[] WatchlistItems { get; init; }
    }

    public interface IWatchlistItem { }


    public interface IPortfolioItems
    {
        public IAssetItem[] PortfolioItems { get; init; }
    }

    public interface IAssetItem { }


    public interface ISwoblItems
    {
        public ISwoblItem[] SwoblItems { get; init; }
    }

    public interface ISwoblItem { }


    public interface ITaxDocumentItems
    {
        public ITaxDocumentItem[] TaxDocumentItems { get; init; }
    }

    public interface ITaxDocumentItem { }


    public interface IBankCardItems
    {
        public IBankCardItem[] BankCardItems { get; init; }
    }

    public interface IBankCardItem { }


    public interface ISettingItems
    {
        public ISettingItem[] SettingItems { get; init; }
    }

    public interface ISettingItem { }


    public interface INotificationItems
    {
        public INotificationItem[] NotificationItems { get; init; }
    }

    public interface INotificationItem { }

    #endregion Swop Wallet Set of Items


    public interface ISwopMarketItem
    {
        IBlockItem[] Blocks { get; init; }
    }

    #region Swop Market Details

    public interface IBlockItem
    {
        IEntryItem[] Entries { get; init; }
    }

    public interface IBtcBlockItem : IBlockItem { }

    public interface IEthBlockItem : IBlockItem { }

    public interface IEntryItem
    {
        IContractItem[] Contracts { get; init; }
    }

    public interface IBtcEntryItem : IEntryItem { }

    public interface IContractItem { }

    public interface IChargeItem : IContractItem { }

    public interface IDischargeItem : IContractItem { }

    public interface IOfferItem : IChargeItem { }

    public interface IInvoiceItem : IChargeItem { }

    public interface IDeliveryItem : IDischargeItem { }

    public interface IReceiptItem : IDischargeItem { }

    public interface IBidItem : IOfferItem { }

    public interface IAskItem : IOfferItem { }

    public interface IBuyItem : IInvoiceItem { }

    public interface ISellItem : IInvoiceItem { }

    public interface IPayItem : IDeliveryItem { }

    public interface ICashItem : IDeliveryItem { }

    public interface IExpenseItem : IReceiptItem { }

    public interface IIncomeItem : IReceiptItem { }

    #endregion


   #endregion
















    //ITradeOrders[] Orders { get; set; }

    //IMediums[] Mediums { get; set; }

    //IAssets[] Assets { get; set; } 
}


#region IWallets Members

public interface IUserAdmins { }

    #endregion

    //public interface IUserAssets: ISystems { }


    public interface IMarkets
    {
        IMaterials Materials { get; set; }

        IBalances[] Balances { get; set; }

        IEntries[] Entries { get; set; }
    }

    #region IMarkets Members



    #endregion


    public interface ITradeOrders
    {
        ICharges Charge { get; set; }

        IDischarges Discharge { get; set; }
    }

    #region IOrders Members



    #endregion


    //#endregion

    public interface IEntries
    {
    }

    public interface ICharges
    {
        //IOffers Offer { get; set; }

        //IInvoices Invoice { get; set; }
    }

    public interface IDischarges
    {
        //IDeliveries 
    }


    //public in

    public interface IEntry { }

    public interface IMediums : IBalances { }

    public interface IAssets : IBalances { }

    public interface IMaterials
    {
        //symbol, icon, color, etc.
    }

    public interface IBtcMaterials : IMaterials { }

    public interface IEthMaterials : IMaterials { }

    public interface ISwoblMaterials : IMaterials { }


    public enum MarketRoles
    {
        Bidder,
        Asker,
        Buyer,
        Seller,
    }

    public interface IOrdering
    {
        void Offer();

        void Invoice();

        void Deliver();

        void Receipt();
    }

    public interface IBuying : IOrdering
    {
        void Bid();

        void Buy();

        void Pay();

        void Expense();
    }

    public interface ISelling : IOrdering
    {
        void Ask();

        void Sell();

        void Cash();

        void Income();
    }

    public interface IBalances { }

    
    public interface ILiquidityMarkets { }

    public interface IExchangeMarkets { }

    

    namespace Order
    {
        public interface IOrder
        {
            IOrder New(string parsable);

            string Text();

            //ISystems LiquidityMarket { get; set; }

            MarketRoles LiquidityMarketRole { get; set; }

            //ISystems ExchangeMarket { get; set; }

            MarketRoles ExchangeMarketRole { get; set; }
        }

        public interface IOrderable { IOrdered Order(IOrder order); }

        public interface IOrdered : IVerifiableOrder{ }

        public interface IVerifiableOrder { IVerifiedOrder Order(IOrder order); }

        public interface IVerifiedOrder : ISignableOrder { }

        public interface ISignableOrder { ISignedOrder Sign(IVerifiedOrder order); }

        public interface ISignedOrder : ISubmittableOrder { }

        public interface ISubmittableOrder { ISubmittedOrder Submit(ISignedOrder order); }

        public interface ISubmittedOrder : IConfirmableOrder{ }

        public interface IConfirmableOrder { IConfirmedOrder Confirm(ISubmittedOrder order); }

        public interface IConfirmedOrder : IOrdered { }

        namespace Charge 
        {
            public interface ICharge { ICharge New(string parsable); string Text(); }

            public interface IChargeable { ICharged Charge(ICharge order); }

            public interface ICharged// : IVerifiable
            { }

            namespace Offer
            {
                public interface IOfferable { }

                public interface IOffered { }
            }

            namespace Invoice
            {
                public interface Invoiceable { }

                public interface Invoiced { }
            }

        }

        namespace DisCharge
        {
            public interface IAdministratable { }

            public interface IAdministated { }

            namespace Deliver
            {
                public interface IDeliverable { }

                public interface IDelivered { }
            }

            namespace Receipt
            {
                public interface IReceiptable { }

                public interface IReceipted { }
            }
        }
    }
//}