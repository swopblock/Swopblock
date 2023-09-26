using System;
using System.Diagnostics;

namespace Swopblock.OrdersOldNS
{
    #region Entry Items

    public interface IEntryItem { }

    public interface IBaseValue { decimal Value { get; set; } }

    public interface IFaceValue { decimal Value { get; set; } }

    #endregion

    #region Charge Items

    public interface IChargeItem : IEntryItem { }

    #endregion

    #region Discharge Items

    public interface IDischargeItem : IEntryItem { }

    #endregion

    #region Offer Items

    public interface IOfferItem : IChargeItem
    {
        ISourceOfferItem Source { get; set; }

        IDestinationOfferItem Destination { get; set; }

        decimal Reservation { get; set; }

        decimal Expiration { get; set; }

        ISignatureItem Signature { get; set; }
    }

    public interface IAddressOfferItem
    {
        IAddressItem Address { get; set; }

        IOfferLimits Limits { get; set; }
    }

    public interface ISourceOfferItem : IAddressOfferItem { }

    public interface IDestinationOfferItem : IAddressOfferItem { }

    public interface IAddressSource : IAddressItem { }

    public interface IAddressDestination : IAddressItem { }

    public interface IOfferLimits
    {
        decimal Minimum { get; set; }

        decimal Maximum { get; set; }
    }

    public interface IPaymentLimits : IOfferLimits { }

    public interface ICachingLimits : IOfferLimits { }


    public interface IPaymentSource : IAddressSource { }

    public interface IPaymentDestination : IAddressDestination { }

    public interface ICachingSource : IAddressSource { }

    public interface ICachingDestination : IAddressDestination { }

    public interface IPaymentSourceOfferItem : ISourceOfferItem { }

    public interface ICachingDestinationOfferItem : IDestinationOfferItem { }

    public interface IBiddingOfferItem : IOfferItem
    {
        IPaymentSourceOfferItem PaymentSource { get; set; }

        ICachingDestinationOfferItem CachingDestination { get; set; }
    }

    public interface IPaymentDestinationOfferItem : IDestinationOfferItem { }

    public interface ICachingSourceOfferItem : ISourceOfferItem { }

    public interface IAskingOfferItem : IOfferItem
    {
        ICachingSourceOfferItem CachingSource { get; set; }

        IPaymentDestinationOfferItem PaymentDestination { get; set; }
    }

    public interface IMarketItem { }

    #endregion

    #region Invoice Items

    public interface IInvoiceItem : IChargeItem
    {
        IAskingOfferItem AskingOffer { get; set; }

        IBiddingOfferItem BiddingOffer { get; set; }
    }

    public interface IInvoicePricePoint
    {
        IInitialCoinOffering ICO { get; set; }

        decimal BaseValue { get; set; }

        decimal FaceValue { get; set; }
    }

    public interface IInitialCoinOffering
    {
        const decimal GenesisSupply = 52800000.0M;

        decimal SupplyRemaining { get; set; }

        decimal ExchangeVolume { get; set; }

        IMarketItem[] CirculatingMarkets { get; set; } //?? IAMHHERE
    }

    //IAMHERE

    //Price points are derived by observing the interaction between the Swopblock protocol predetermined demand and supply curve, which helps brands determine the possible profit margin for a product or service.Several factors contribute to the price points, but the demand and supply of the product or service must remain proportional to the price.

    public interface ITransferableItem
    {
        IMarketItem TransferringMarket { get; set; }
        decimal TransferringAmount { get; set; }
        IAddressItem SendingAddress { get; set; }
        IAddressItem ReceivingAddress { get; set; }
    }

    public interface IBuyInvoiceItem : IInvoiceItem
    {
        // { get; set; }
    }

    public interface ISellInvoiceItem : IInvoiceItem
    {

        ITransferableItem Receivable { get; set; }
    }

    #endregion

    #region Delivery Items

    public interface IDeliveryItem : IInvoiceItem, IDischargeItem
    {
        //IAMHERE
    }

    public interface IPaymentItem : IDeliveryItem { }

    public interface ICashingItem : IDeliveryItem { }

    #endregion

    #region Receipt Items

    public interface IReceiptItem : IDeliveryItem { }

    public interface IExpenseItem : IReceiptItem, IPaymentItem { }

    public interface IIncomeItem : IReceiptItem, ICashingItem { }

    #endregion

    #region Order Items

    public interface IOrderItem : IReceiptItem { }

    public interface IBuyOrderItem : IOrderItem, IExpenseItem { }

    public interface ISellOrderItem : IOrderItem, IIncomeItem { }

    #endregion
}
