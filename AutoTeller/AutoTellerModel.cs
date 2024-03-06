// Autonomous Cryptographic Teller

namespace Swopblock.Act;

#region Asymmetric Cryptography

public abstract record PrivateKey();

public record BtcPrivateKey();

public record EthPrivateKey();


public abstract record Signature() : PrivateKey();

public record BtcSignature() : BtcPrivateKey();

public record EthSignature() : EthPrivateKey();


public abstract record PublicLock();

public record BtcPublicLock();

public record EthPublicLock();


public abstract record Address() : PublicLock();

public record BtcAddress() : Address();

public record EthAddress() : Address();

#endregion


#region Confirmation Base Types

public abstract record Candidate();

public record BtcCandidate() : Candidate();

public record EthCandidate() : Candidate();


public abstract record Confirmation()
{
    public virtual void Write() { }

    public virtual void Sign() { }

    public virtual void Broadcast() { }

    public virtual Confirmation Confirm() { return null; }
}

public record BtcConfirmation() : Confirmation();

public record EthConfirmation() : Confirmation();

#endregion


#region 1. Offers: (First Confirmation Phase)

public record Offer(CashNote Hold);

public record ItemOffer(ItemEstimate ItemEstimate, Offer Offer) : Confirmation();

public record CashOffer(CashEstimate CashEstimate, Offer Offer) : Confirmation();

#endregion

#region 2. Estimates: (Second Confirmation Phase)

public record ItemEstimate();

public record CashEstimate();

public record Estimate(ItemOffer EstimateableItemOffer, CashOffer EstimateableCashOffer) : Confirmation();

#endregion

#region 3. Invoices: (Third Confirmation Phase)

public record ItemValue();

public record CashValue();

public record Invoice(ItemValue Quantity, CashValue Total, Estimate InvoicableEstimate) : Confirmation();

#endregion

#region 4. Tranfers: (Fourth Confirmation Phase)

public record ItemDelivery();

public record CashPayment();

public record Transfer(ItemDelivery Delivery, CashPayment Payment, Invoice TransferableInvoice) : Confirmation();

#endregion

#region 5. Receipts: (Fifth Confirmation Phase)

public record Receipt(ItemNote ItemNote, CashNote CashNote, Transfer ReceiptableTransfer) : Confirmation();

public record Note(ItemNote ItemInput, CashNote CashInput);


public abstract record Item(Signature Seller, decimal ItemValue, Address Buyer)
{
    public string Unit { get { return ""; } }
}

public record BtcItem(BtcSignature Seller, decimal ItemValue, BtcAddress Buyer);

public record EthItem(EthSignature Seller, decimal ItemValue, EthAddress Buyer);

//public record Note(Item Item, Signature Buyer, decimal CashValue, Address Seller);

public record Endorsement(Note Input, PrivateKey Signature);

public record ItemEndorsement(ItemNote Input);

public record ItemNote(decimal Value, string Unit, PublicLock Output);

public record CashNote;// (ItemEndorsement Input, decimal Value, string Unit, PublicItemLock Output, CashEndorsement CashInput, decimal CashValue, PublicLock CashOutput)

    //;//: ItemNote(Value, Unit, Output);

#endregion


#region Markets

public record Blockchain(string Unit);

public record Markets(Blockchain Blockchain)
{
    public virtual CashOffer MakeCashOffer(int a)
    {
        //var offer = new Offer(1);

        //offer.

        return null;
    }

    public virtual ItemOffer MakeItemOffer(int b) { return null; }

    public virtual Estimate MakeEstimate(CashOffer CashOffer)
    {
        //offer.Write();

        //offer.Sign();

        //offer.Broadcast();

        return null;// offer.Confirm();
    }

    public virtual Estimate MakeEstimate(ItemOffer ItemOffer)
    {
        ItemOffer.Write();

        return null;
    }

    public virtual Invoice MakeInvoice(Estimate Estimate) { return null; }

    public virtual Transfer MakeTransfer(Invoice Invoice) { return null; }

    public virtual Receipt MakeReceipt(Transfer Transfer) { return null; }

    public virtual Confirmation Confirm(Confirmation confirmation)
    {
        confirmation.Write();

        confirmation.Sign();

        confirmation.Broadcast();

        return confirmation.Confirm();
    }
}

#endregion


#region Brainstormed Source Coding

/*

public record MarketsA : MarketsZ
{
    public EstimateA MakeEstimate(OfferA Offer) { return null; }
}

public record MarketsB : MarketsZ
{
    public EstimateB MakeEstimate(OfferB Offer)
    {
        var estimate = base.MakeEstimate(Offer);

        
        return estimate;
    }
}

public record Offer(int a)
{
    public void Write() { }

    public void Sign() { }

    public void Broadcast() { }

    public Estimate Confirm() { return null; }
}

public record Estimate(int b)
{
    public void Write() { }

    public void Sign() { }

    public void Broadcast() { }

    public Invoice Confirm() { return null; }
}

public record Invoice(int c)
{
    public void Write() { }

    public void Sign() { }

    public void Broadcast() { }

    public Transfer Confirm() { return null; }
}

public record Transfer(int d)
{
    public void Write() { }

    public void Sign() { }

    public void Broadcast() { }

    public Receipt Confirm() { return null; }
}

public record Receipt(int e)
{
    public Endorsement UseToDraftOffer()
    {
        return null;
    }
}


public class Markets
{
    protected virtual Offer DraftOffer() { throw new NotImplementedException(); }

    protected virtual Estimate MakeEstimate(Offer Offer) { throw new NotImplementedException(); }

    protected virtual Invoice MakeInvoice(Estimate Estimate) { throw new NotImplementedException(); }

    protected virtual Transfer MakeTransfer(Invoice Invoice) { throw new NotImplementedException(); }

    protected virtual Receipt MakeReceipt(Transfer Transfer) { throw new NotImplementedException(); }
}

public class BtcMarket : Markets
{
    public Offer DraftOffer() { return null; }
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



public record ItemNote(decimal Value, string Unit, PublicLock Output);


public record BtcItemNote(BtcEndorsement Input, decimal Value, PublicLock Output)

    : ItemNote(Value, "BTC", Output);

public record EthItemNote(EthEndorsement Input, decimal Value, PublicLock Output)

    : ItemNote(Value, "ETH", Output);

public record UsdItemNote(UsdEndorsement Input, decimal Value, PublicLock Output)

    : ItemNote(Value, "USD", Output);



public record CashNote<ItemEndorsement, PublicItemLock, CashEndorsement, PublicCashLock>(ItemEndorsement Input, decimal Value, string Unit, PublicItemLock Output, CashEndorsement CashInput, decimal CashValue, PublicLock CashOutput)

    ;//: ItemNote(Value, Unit, Output);


public record BtcCashNote<E>(BtcEndorsement Input, decimal Value, PublicLock Output, CashEndorsement CashInput, decimal CashValue, PublicLock CashOutput)

    : ItemNote(Input, Value, "BTC", Output);

public record EthCashNote(ItemNote Input, decimal Value, PublicLock Output, CashNote CashInput, decimal CashValue, PublicLock CashOutput)

    : ItemNote(Input, Value, "ETH", Output);

public record UsdCashNote(ItemNote Input, decimal Value, PublicLock Output, CashNote CashInput, decimal CashValue, PublicLock CashOutput)

    : ItemNote(Input, Value, "USD", Output);



public record PublicLock;

public record BtcPublicLock : PublicLock;

public record EthPublicLock : PublicLock;

public record UsdPublicLock : PublicLock;

public record PrivateKey;

public record BtcPrivateKey : PrivateKey;

public record EthPrivateKey : PrivateKey;

public record UsdPrivateKey : PrivateKey;

public record Endorsement();// (ItemNote InputNote, PrivateKey Signature);

public record CashEndorsement();

public record BtcEndorsement(): Endorsement(); // (BtcItemNote InputNote, PrivateKey InputUnlockKey)

    : Endorsement((ItemNote)InputNote, InputUnlockKey);

public record EthEndorsement(PublicLock InputLock, PrivateKey InputUnlockKey)

    : Endorsement(InputLock, InputUnlockKey);

public record UsdEndorsement(PublicLock InputLock, PrivateKey InputUnlockKey)

    : Endorsement(InputLock, InputUnlockKey);

public record Signature(PrivateKey UnlockInput, PublicLock OutputLock);

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
*/

#endregion

