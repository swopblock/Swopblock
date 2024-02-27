namespace Swopblock.AutoTeller;

public class Markets
{
    // IAMHERE protected 
}

public class BtcMarket : Markets
{

}

public class EthMarket: Markets
{

}

public class UsdMarket: Markets
{

}

public record Address(PublicLock Lock, PrivateKey Key);

public record BtcAddress(BtcPublicLock BtcLock, BtcPrivateKey BtcKey);

public record EthAddress(EthPublicLock EthLock, EthPrivateKey EthKey);

public record UsdAddress(UsdPublicLock UsdLock, UsdPrivateKey UsdKey);

public record ItemNote(Address Address, ItemNote Available, Signature Signature, decimal BaseValueOnHold, string BaseValueUnit);

public record BtcItemNote(Address Address, ItemNote Available, Signature Signature, decimal BaseValueOnHold)

    : ItemNote(Address, Available, Signature, BaseValueOnHold, "BTC");

public record EthItemNote(Address Address, ItemNote Available, Signature Signature, decimal BaseValueOnHold)

    : ItemNote(Address, Available, Signature, BaseValueOnHold, "ETH");

public record UsdItemNote(Address Address, ItemNote Available, Signature Signature, decimal BaseValueOnHold)

    : ItemNote(Address, Available, Signature, BaseValueOnHold, "USD");

public record CashNote(Address Address, ItemNote Available, Signature Signature, decimal BaseValueOnHold, string BaseValueUnit, decimal FaceValueOnHold, string FaceValueUnit)

    : ItemNote(Address, Available, Signature, BaseValueOnHold, BaseValueUnit);

public record BtcCashNote(Address Address, ItemNote Available, Signature Signature, decimal BaseValueOnHold, decimal FaceValueOnHold)

    : CashNote(Address, Available, Signature, BaseValueOnHold, "BTC", FaceValueOnHold, "SWOBL");

public record EthCashNote(Address Address, ItemNote Available, Signature Signature, decimal BaseValueOnHold, decimal FaceValueOnHold)

    : CashNote(Address, Available, Signature, BaseValueOnHold, "ETH", FaceValueOnHold, "SWOBL");

public record UsdCashNote(Address Address, ItemNote Available, Signature Signature, decimal BaseValueOnHold, decimal FaceValueOnHold)

    : CashNote(Address, Available, Signature, BaseValueOnHold, "USD", FaceValueOnHold, "SWOBL");

public record PublicLock(Signature Signature);

public record BtcPublicLock(BtcPrivateKey BtcKey);

public record EthPublicLock(EthPrivateKey EthKey);

public record UsdPublicLock(UsdPrivateKey UsdKey);

public record PrivateKey(Signature Signature); // IAMHERE

public record BtcPrivateKey;

public record EthPrivateKey;

public record UsdPrivateKey;

public record Endorsement(PublicLock InputLock, PrivateKey InputUnlockKey);

public record BtcEndorsement(PublicLock InputLock, PrivateKey InputUnlockKey)

    : Endorsement(InputLock, InputUnlockKey);

public record EthEndorsement(PublicLock InputLock, PrivateKey InputUnlockKey)

    : Endorsement(InputLock, InputUnlockKey);

public record UsdEndorsement(PublicLock InputLock, PrivateKey InputUnlockKey)

    : Endorsement(InputLock, InputUnlockKey);

public record Signature(Endorsement Endorsement, PublicLock OutputLock);

//public record ItemNote(Markets KindOfItem, decimal ItemValue, Signature Signature);

public record CashNoteOld(CashNote KindOfCash, decimal FaceValue, Signature Signature, ItemNote ItemNote)
{
    public Offer MakeAnOffer()
    {
        return null;
    }

    public static CashNoteOld CashAReceipt(Receipt receipt)
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
        return new Estimate(this, new Offer(null, KindsOfOffers.Ask, 1, 2, 3, 4, 100, 200, new Signature(null, null)), "Details");
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

public class Signatory
{

}

public class AutoTellerModel
{
    public Signatory Signatory { get; init; }

    public AutoTellerModel(Signatory signatory)
    {
        Signatory = signatory;
    }

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



