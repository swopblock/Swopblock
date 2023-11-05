using System;

namespace Swopblock;

public partial record Invoice
{
}

public record MarketOrderInvoice(OpenedMarketOrder OpenedMarketOrder, ClosedMarketOrder ClosedMarketOrder)
    : Invoice(OpenedMarketOrder.PaymentOffer, OpenedMarketOrder.DeliveryOffer, OpenedMarketOrder.PaymentDue, OpenedMarketOrder.DeliveryDue,
        ClosedMarketOrder.PaymentDeed, ClosedMarketOrder.DeliveryDeed, ClosedMarketOrder.PaymentReceipt, ClosedMarketOrder.DeliveryReceipt);

public record MoneyOrderInvoice(OpenedMoneyOrder OpenedMoneyOrder, ClosedMoneyOrder ClosedMoneyOrder);
    //ToDo: Invoice(...);

public record DeliveryOrderInvoice(OpenedDeliveryOrder OpenedDeliveryOrder, ClosedDeliveryOrder ClosedDeliveryOrder);
    //ToDo: Invoice(...);

public record OpenedMarketOrder(PaymentOffers PaymentOffer, DeliveryOffers DeliveryOffer, PaymentDues PaymentDue, DeliveryDues DeliveryDue);

public record ClosedMarketOrder(PaymentDeeds PaymentDeed, DeliveryDeeds DeliveryDeed, PaymentReceipts PaymentReceipt, DeliveryReceipts DeliveryReceipt);


public record OpenedMoneyOrder(); //ToDo:

public record ClosedMoneyOrder(); //ToDo:

public record OpenedDeliveryOrder(); //ToDo:

public record ClosedDeliveryOrder(); //ToDo:

