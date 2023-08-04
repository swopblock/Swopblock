using System;

namespace Swopblock.Orders
{
    #region Entry Items

    public interface IEntryItem
    {
        //public IMarketItem EntryMarket { get; init; }
    }

    public interface IBuyEntryItem : IEntryItem
    {
        //public IMarketItem BuyMarket { get; init; }

        //public decimal MinimumBiddingAvailable { get; init; }

        //public decimal MaximumBiddingAvailable { get; init; }

        //public decimal MinimumBuyingAvailable { get; init; }

        //public decimal MaximumBuyingAvailable { get; init; }
    }

    public interface ISellEntryItem : IEntryItem
    {
        //public IMarketItem SellMarket { get; init; }

        //public decimal MinimumAskingAvailable { get; init; }

        //public decimal MaximumAskingAvailable { get; init; }

        //public decimal MinimumSellingAvailable { get; init; }

        //public decimal MaximumSellingAvailable { get; init; }
    }

    #endregion

    #region Charge Items

    public interface IChargeItem : IEntryItem
    {
        //IAddressItem ChargingAddress { get; init; }
    }

    public interface IBuyChargeItem : IChargeItem, IBuyEntryItem { }

    public interface ISellChargeItem : IChargeItem, ISellEntryItem { }

    #endregion

    #region Discharge Items

    public interface IDischargeItem : IChargeItem
    {
        //IAddressItem DischargingAddress { get; init; }
    }

    public interface IBuyDischargeItem : IDischargeItem, IBuyChargeItem { }

    public interface ISellDischargeItem : IDischargeItem, ISellChargeItem { }



    #endregion

    #region Offer Items

    public interface IOfferItem : IChargeItem
    {
        //decimal Reservation { get; init; }

        //decimal Expiration { get; init; }

        //ISignatureItem OfferSignature { init; }
    }

    public interface IBidItem : IOfferItem, IBuyChargeItem
    {
        //IMarketItem BiddingMarket { get; init; }

        //decimal MinimumBid { get; init; }

        //decimal MaximumBid { get; init; }

        //IAddressItem BiddingAddress { get; init; }

        //IMarketItem BuyingMarket { get; init; }

        //decimal MinimumBuy { get; init; }

        //decimal MaximumBuy { get; init; }
    }

    public interface IAskItem : IOfferItem, ISellChargeItem
    {
        //IMarketItem SellingMarket { get; init; }

        //decimal MinimumSell { get; init; }

        //decimal MaximumSell { get; init; }

        //IAddressItem SellingAddress { get; init; }

        //IMarketItem AskingMarket { get; init; }

        //decimal MinimumAsk { get; init; }

        //decimal MaximumAsk { get; init; }
    }

    public interface IConsiderationLimitsItem { }

    public interface IObjectLimitsItem { }

    public interface IReservationLimitsItem { }

    public interface IOfferSignatureItem { }

    public interface IMarketItem { }

    #endregion

    #region Invoice Items

    public interface IInvoiceItem : IOfferItem, IChargeItem
    {
    }

    public interface IBuyItem : IInvoiceItem, IBidItem { }

    public interface ISellItem : IInvoiceItem, IAskItem { }

    #endregion

    #region Delivery Items

    public interface IDeliveryItem : IInvoiceItem, IDischargeItem
    {
        //ISignatureItem DischargingSignature { get; init; }
    }

    public interface IPaymentItem : IDeliveryItem, IBuyItem { }

    public interface ICashingItem : IDeliveryItem, ISellItem { }

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
