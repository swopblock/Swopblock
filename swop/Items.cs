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

        public IWatchlistItems Watchlist { get; init; }

        public IPortfolioItems Portfolio { get; init; }

        public ICashItems Cash { get; init; }

        public ITaxDocumentItems TaxDocuments { get; init; }

        public IBankCardItems BanksCards { get; init; }

        public ISettingItems Settings { get; init; }

        public INotificationItems Notifications { get; init; }
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


    public interface ICashItems
    {
        public ICashItem[] SwoblItems { get; init; }
    }

    public interface ICashItem { }


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
        IOrderItem[] Orders { get; init; }
    }

    #region Swop Market Details

    public interface IEntryItem { }

    public interface IBuyEntryItem : IEntryItem { }

    public interface ISellEntryItem : IEntryItem { }



    public interface IChargeItem : IEntryItem
    {
        ISwopMarketItem DischargingMarket { get; init; }
    }

    public interface IBuyChargeItem : IChargeItem, IBuyEntryItem { }

    public interface ISellChargeItem : IChargeItem, ISellEntryItem { }



    public interface IDischargeItem : IChargeItem
    {
    }

    public interface IBuyDischargeItem : IDischargeItem, IBuyChargeItem { }

    public interface ISellDischargeItem : IDischargeItem, ISellChargeItem { }



    public interface IOfferItem : IChargeItem
    {
        IAddressItem Address { get; init; }

        ISignatureItem OfferSignature { get; init; }
    }

    public interface IBidItem : IOfferItem, IBuyChargeItem { }

    public interface IAskItem : IOfferItem, ISellChargeItem { }



    public interface IAddressItem { }



    public interface IInvoiceItem : IOfferItem, IChargeItem
    {
        IAddressItem ReturnAddress { get; init; }

        IAddressItem DeliveryAddress { get; init; }
    }

    public interface IBuyItem : IInvoiceItem, IBidItem { }

    public interface ISellItem : IInvoiceItem, IAskItem { }



    public interface IDeliveryItem : IInvoiceItem, IDischargeItem
    {
        ISignatureItem DischargingSignature { get; init; }  
    }

    public interface IPaymentItem : IDeliveryItem, IBuyItem { }

    public interface ICashingItem : IDeliveryItem, ISellItem { }



    public interface ISignatureItem { }



    public interface IReceiptItem : IDeliveryItem { }

    public interface IExpenseItem : IReceiptItem, IPaymentItem { }

    public interface IIncomeItem : IReceiptItem, ICashingItem { }



    public interface IOrderItem : IReceiptItem { }

    public interface IBuyOrderItem : IOrderItem, IExpenseItem { }

    public interface ISellOrderItem : IOrderItem, IIncomeItem { }





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