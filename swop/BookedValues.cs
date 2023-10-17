using System;
namespace Swopblock
{
    /*
    public struct Values2
    {
        decimal Base, Face;

        public struct Ordered
        {
            //public struct 
        }
    }

    //public struct Ordered

    public struct ReceiptedValues
    {
        public struct OrderedValues
        {
            public struct FacedValues
            {
                public struct BaseValues
                {
                    decimal Value;
                }

                BaseValues Base;

                decimal Value;
            }

            FacedValues Minimum, Maximum;
        }

        OrderedValues Ordered;

        FaceValues Receipted;
    }

    */


    public abstract record Addresses2;


    public record BaseValues

        (decimal BaseValue)

        : Addresses2;


    public record FaceValues

        (decimal BaseValue, decimal FaceValue)

        : BaseValues

            (BaseValue);

    public record OrderedValues

        (decimal BaseValue, decimal FaceValue, decimal OrderedBaseValue, decimal OrderedFaceValue, decimal OrderedBaseVolume, decimal OrderedFaceVolume)

        : FaceValues

            (BaseValue, FaceValue);


    public record ReceiptedValues

     (decimal BaseValue, decimal FaceValue, decimal OrderedBaseValue, decimal OrderedFaceValue, decimal OrderedBaseVolume, decimal OrderedFaceVolume)

       : FaceValues

            (BaseValue, FaceValue);


  public record MarketOrderedBooks

        (decimal MarketBaseValue, decimal MarketFaceValue, decimal MarketOrderedBaseValue, decimal MarketOrderedFaceValue, decimal MarketBaseVolume, decimal MarketFaceVolume, OrderedValues[] OrderedValues)

        : OrderedValues

            (MarketBaseValue, MarketFaceValue, MarketOrderedBaseValue, MarketOrderedFaceValue, MarketBaseVolume, MarketFaceValue);

    public record ExchangeOrderedBooks

        (decimal ExchangeBaseValue, decimal ExchangeFaceValue, decimal ExchangeOrderedBaseValue, decimal ExchangeOrderedFaceValue, decimal ExchangeBaseVolume, decimal ExchangeFaceVolume, MarketOrderedBooks[] MarketOrderedBooks)

        : OrderedValues

            (ExchangeBaseValue, ExchangeFaceValue, ExchangeOrderedBaseValue, ExchangeOrderedFaceValue, ExchangeBaseVolume, ExchangeFaceVolume);


    namespace XOrders
    {
        public record Instructions

            (Instructions Previous,  decimal Counter, decimal CounterExpiration, decimal RegisterA, decimal RegisterB);

        public record Signature;

        public record Orders;


        public record BuyersBiddingOrders

            (FaceValues BuyersBidAvailability,

            decimal BuyersOpeningBid, decimal BuyersMaximumBid,

            decimal BuyersOpeningLot, decimal BuyersMaximumLot,

            decimal BuyersReservationVolume, decimal BuyersExpirationVolume,

            Addresses2 BuyersDeliveryReceivingAddress)

            : Orders;

        public record SellersAskingOrders

            (FaceValues SellersLotAvailability,

            decimal SellersOpeningAsk, decimal SellersMinimumAsk,

            decimal SellersOpeningLot, decimal SellersMinimumLot,

            decimal SellersReservationVolume, decimal SellersExpirationVolume,

            Addresses2 SellersPaymentReceivingAddress)

            : Orders;


        public record Invoices

            (BuyersBiddingOrders BiddingOrder,

            decimal OpeningMarketVolume,

            decimal Closing,

            SellersAskingOrders AskingOrder);

        public record PaymentDues

            (FaceValues BuyersAvailability, decimal BuyersPaymentDue, Addresses2 SellersPaymentReceivingAddress);

        public record DeliveryDues

            (FaceValues SellersAvailability, decimal SellersDeliveryDue, Addresses2 BuyersDeliveryReceivingAddress);



        public record PaymentOrders

            (FaceValues AvialableFaceValue, decimal PaymentOrder, FaceValues PendigFaceValue);

        public record DeliveryOrders

            (BaseValues AvailableBaseValue, decimal DeliveryOrder, BaseValues PendingBaseValue);



        public record ReceiptersPaymentConfirmations;

        public record OrderOrders

            (decimal BaseOrder, decimal FaceOrder, decimal BookBaseOrder, decimal BookFaceOrder, decimal BookBaseVolume, decimal BookFaceVolume)

            //: FaceOrders

                //(BaseOrder, FaceOrder)
                ;


        public record MarketOrders

            (decimal MarketBaseOrder, decimal MarketFaceOrder, decimal MarketBookBaseOrder, decimal MarketBookFaceOrder, decimal MarketBaseVolume, decimal MarketFaceVolume);//, BookOrders[] BookOrders)

                //: BookOrders

                //(MarketBaseOrder, MarketFaceOrder, MarketBookBaseOrder, MarketBookFaceOrder, MarketBaseVolume, MarketFaceOrder);
                

        public record BidOrder

            (FaceValues FaceValue, decimal MaximumBidOrder);//, FaceOrders MinimumBidOrder, )

        public record ExchangeOrders

            (decimal ExchangeBaseOrder, decimal ExchangeFaceOrder, decimal ExchangeBookBaseOrder, decimal ExchangeBookFaceOrder, decimal ExchangeBaseVolume, decimal ExchangeFaceVolume, MarketOrders[] MarketOrders)

                //: BookOrders

                //(ExchangeBaseOrder, ExchangeFaceOrder, ExchangeBookBaseOrder, ExchangeBookFaceOrder, ExchangeBaseVolume, ExchangeFaceVolume);
                ;

    }
}

