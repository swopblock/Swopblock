using System;

namespace Swopblock.DraftA
{
    public partial record Orders
    (
        CashOffers CashOffer,

        SaleOffers SaleOffer,

        CashDues CashDue,

        SaleDues SaleDue,

        CashDeeds CashDeed,

        SaleDeeds SaleDeed,

        CashNotes CashNode,

        SaleNotes SaleNote
    );

}

namespace Swopblock
{

    public partial record Orders
    {
        void Do()
        {
            
        }
    }

    public record MarketOrderInvoice(OpenedMarketOrder OpenedMarketOrder, ClosedMarketOrder ClosedMarketOrder)
        : Orders(OpenedMarketOrder.PaymentOffer, OpenedMarketOrder.DeliveryOffer, OpenedMarketOrder.PaymentDue, OpenedMarketOrder.DeliveryDue,
            ClosedMarketOrder.PaymentDeed, ClosedMarketOrder.DeliveryDeed, ClosedMarketOrder.PaymentReceipt, ClosedMarketOrder.DeliveryReceipt);

    public record MoneyOrderInvoice(OpenedMoneyOrder OpenedMoneyOrder, ClosedMoneyOrder ClosedMoneyOrder);
    //ToDo: Invoice(...);

    public record DeliveryOrderInvoice(OpenedDeliveryOrder OpenedDeliveryOrder, ClosedDeliveryOrder ClosedDeliveryOrder);
    //ToDo: Invoice(...);

    public record OpenedMarketOrder(CashOffers PaymentOffer, SaleOffers DeliveryOffer, CashDues PaymentDue, SaleDues DeliveryDue);

    public record ClosedMarketOrder(CashDeeds PaymentDeed, SaleDeeds DeliveryDeed, CashNotes PaymentReceipt, SaleNotes DeliveryReceipt);


    public record OpenedMoneyOrder(); //ToDo:

    public record ClosedMoneyOrder(); //ToDo:

    public record OpenedDeliveryOrder(); //ToDo:

    public record ClosedDeliveryOrder(); //ToDo:
}

