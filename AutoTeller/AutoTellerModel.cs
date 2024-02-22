namespace Swopblock.AutoTeller;

public class KindsOfItems
{
    // IAMHERE protected 
}

public class BtcKindOfItems : KindsOfItems
{

}

public class EthKindOfItems : KindsOfItems
{

}

public class KindsOfCash : KindsOfItems
{

}

public class UsdKindOfCash : KindsOfCash
{

}

public class SwoblKindOfCash : KindsOfCash
{

}

public record PublicLock;

public record PrivateKey;

public record Signature(PrivateKey FreeValue, PublicLock LockValue);

public record ItemNote(KindsOfItems KindOfItem, decimal ItemValue, Signature Signature);

public record CashNote(KindsOfCash KindOfCash, decimal FaceValue, Signature Signature, ItemNote ItemNote)
{
    public Offer MakeAnOffer()
    {
        return null;
    }

    public static CashNote CashAReceipt(Receipt receipt)
    {
        return null;
    }
}

public record Schedule;

public enum KindsOfOffers
{
    Bid, Ask
}

public record Offer
(
    CashNote Hold,

    KindsOfOffers KindOfOffer,

    decimal MinimumCash,

    decimal MaximumCash,

    decimal MinimumItem,

    decimal MaximumItem,

    decimal Reservation,

    decimal Expiration,

    Signature Signature
)

: Schedule

{
    public Estimate MakeAnEstimate()
    {
        //var matchedOffer = 
        return new Estimate(this, new Offer(null, KindsOfOffers.Ask, 1, 2, 3, 4, 100, 200, new Signature(new PrivateKey(), new PublicLock())), "Details");
    }

    public void Write()
    {

    }

    public void Sign()
    {

    }

    public void Broadcast()
    {

    }

    public void Confirm()
    {

    }
}

public record Estimate(Offer Offer, Offer CounterOffer, string Details) : Schedule
{
    public Invoice MakeAnInvoice()
    {
        return new Invoice(this, "Details");
    }
}

public record Invoice(Estimate Estimate, string Details) : Schedule
{
    public Transfer MakeATransfer()
    {
        return new Transfer(this, "Details");
    }
}

public record Transfer(Invoice Invoice, string Details) : Schedule
{
    public Receipt MakeAReceipt()
    {
        return new Receipt(this, "Details");
    }
}

public record Receipt(Transfer Transfer, string Details) : Schedule
{
    public Offer MakeAnOffer()
    {
        return null;
    }
}

public record Order(Schedule CurrentSchedule);

public class OfferStream { }

public class EstimateStream { }

public class InvoiceStream { }

public class TransferStream { }

public class ReceiptStream { }

public class OrderStream
{

}

public class AutoTellerModel
{
    private Queue<Offer> Offers = new Queue<Offer>();

    private Queue<Estimate> Estimates = new Queue<Estimate>();

    private Queue<Invoice> Invoices = new Queue<Invoice>();

    private Queue<Transfer> Transfers = new Queue<Transfer>();

    private Queue<Receipt> Receipts = new Queue<Receipt>();


    public Order MakeAnotherOrder(Offer NewOffer)
    {

        var estimate = NewOffer.MakeAnEstimate();

        var invoice = estimate.MakeAnInvoice();

        var transfer = invoice.MakeATransfer();

        var receipt = transfer.MakeAReceipt();

        return new Order(receipt);
    }

    public Estimate EstimateAnotherOffer(Offer NewOffer)
    {
        return NewOffer.MakeAnEstimate();
    }

    public Invoice InvoiceAnotherEstimate(Estimate NewEstimate)
    {
        return NewEstimate.MakeAnInvoice();
    }

    public Transfer TransferAnotherInvoice(Invoice NewInvoice)
    {
        return NewInvoice.MakeATransfer();
    }

    public Receipt ReceiptAnotherTransfer(Transfer NewTransfer)
    {
        return NewTransfer.MakeAReceipt();
    }
}



