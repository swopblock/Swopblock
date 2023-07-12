using System;

namespace Swopblock
{
    public interface IRelayNodes
    {
        public IWallets Wallet { get; set; }

        public IMarketplace Marketplace { get; set; }
    }


    #region Wallet Details

    public interface IWallets
    {

        public IWatchlist Watchlist { get; set; }

        public IPortfolio Portfolio { get; set; }

        public ICash Cash { get; set; }

        public ITaxDocuments TaxDocuments { get; set; }

        public IBankCards BanksCards { get; set; }

        public ISettings Settings { get; set; }

        public INotifications Notifications { get; set; }
    }

    public interface IWalletItem { }

    public interface IWatchlist: IList<IMarkets>, IWalletItem
    {
    }

    public interface IPortfolio: IList<IAssets>, IWalletItem
    {
    }

    public interface ICash : IList<IMediums>, IWalletItem
    { }

    public interface ITaxDocuments : IList<IDocuments>, IWalletItem
    { }

    public interface IDocuments { }

    public interface IBankCards : IList<ICards>, IWalletItem
    { }

    public interface ICards { }

    public interface ISettings : IList<IControls>, IWalletItem
    { }

    public interface IControls { }

    public interface INotifications: IList<INotices>, IWalletItem
    { }

    public interface INotices { }

    #endregion


    #region Commons Details

    public interface IMarketplace : IList<IMarkets>
    {
        public ISwopStream SwopStream { get; set; }
    }

    public interface ISwopStream
    {
        IOrders[] Orders { get; set; }
    }

    public interface ITradeOrders : IOrders
    {
        public IBuyOrders BuyOrder { get; set;}
        public ISellOrders SellOrder { get; set; }
    }

    public interface IBuyOrders : IOrders { }

    public interface ISellOrders : IOrders { }

    public interface IOrders
    {
        IChargeOrders ChargeOrder { get; set; }

        IDischargeOrders DischargeOrder { get; set; }
    }

    public interface IChargeOrders
    {
        IOffers Offer { get; set; }

        IInvoices Invoice { get; set; }
    }

    public interface IOffers : IEntries { }

    public interface IInvoices : IEntries { }

    public interface IDischargeOrders
    {
        IDeliveries Delivery { get; set; }

        IReceipts Receipt { get; set; }
    }

    public interface IDeliveries : IEntries { }

    public interface IReceipts : IEntries { }


    public interface IMarkets
    {
        //INodes[] 
    }

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