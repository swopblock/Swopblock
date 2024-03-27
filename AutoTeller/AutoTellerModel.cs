namespace Swopblock.Alpha;

public record AutoTeller(AutoTill AutoTill, Account[] UserAccounts, params Markets[] Markets)
{
    public void Load()
    {

    }

    public void Sync()
    {

    }

    public virtual bool VerifyHold(CashNote Hold)
    {
        return false;
    }

    public virtual Bid? MakeBidOffer(CashNote Hold, CashOffer CashOffer, ItemEstimate ItemEstimate)
    {
        return VerifyHold(Hold) ? new Bid(Hold, CashOffer, ItemEstimate) : null;
    }

    public virtual Ask? MakeAskOffer(CashNote Hold, ItemOffer ItemOffer, CashEstimate CashEstimate)
    {
        return VerifyHold(Hold) ? new Ask(Hold, ItemOffer, CashEstimate) : null;
    }

    public virtual Receipt? MakeBuyOrder(CashNote Hold, CashOffer CashOffer, ItemEstimate ItemEstimate)
    {
        var bid = MakeBidOffer(Hold, CashOffer, ItemEstimate);

        var estimate = bid?.MakeEstimate();

        var invoice = estimate?.MakeInvoice();

        var transfer = invoice?.MakeTransfer();

        var receipt = transfer?.MakeReceipt();

        return receipt;
    }

    public virtual Receipt? MakeSellOrder(CashNote Hold, ItemOffer ItemOffer, CashEstimate CashEstimate)
    {
        var ask = MakeAskOffer(Hold, ItemOffer, CashEstimate);

        var estimate = ask?.MakeEstimate();

        var invoice = estimate?.MakeInvoice();

        var transfer = invoice?.MakeTransfer();

        var receipt = transfer?.MakeReceipt();

        return receipt;
    }
}

public record AutoTill(string Units, params Account[] TillAccounts);

    //: Markets(Units, TillAccounts);

public record Markets(string Units, Message[] MessageHistory)
{
    public virtual Offer MakeOffer() { throw new NotImplementedException(); }

    public virtual Estimate MakeEstimate(Offer Offer) { throw new NotImplementedException(); }

    public virtual Invoice MakeInvoice(Estimate Estimate) { throw new NotImplementedException(); }

    public virtual Transfer MakeTransfer(Invoice Invoice) { throw new NotImplementedException(); }

    public virtual Receipt MakeReceipt(Transfer Transfer) { throw new NotImplementedException(); }
}



#region Asymmetric Cryptographic Base Types

public abstract record PrivateKey();

public abstract record Signature() : PrivateKey();


public abstract record PublicLock();

public abstract record Address() : PublicLock();

public record Account(string Units, PublicLock PublicLock, PrivateKey PrivateKey);

#endregion


#region Other Base Types

public abstract record Candidate();

public record BtcCandidate() : Candidate();

public record EthCandidate() : Candidate();

public record Message();

public abstract record Process()
{
    public virtual Process Execute()
    {
        Verify();

        Write();

        Sign();

        var candidates = Broadcast();

        return Confirm(candidates);
    }

    public abstract bool Verify();

    public abstract void Write();

    public abstract void Sign();

    public abstract Message[] Broadcast();

    public abstract Process Confirm(Message[] Candidates);
}


public abstract record Offer() : Process()
{
}

#endregion


#region 1A. Asks: (Offer Asking Confirmation Phase 1A)

public record CashNote();

public record CashEstimate();

public record ItemOffer();

public record Ask(CashNote Hold, ItemOffer ItemOffer, CashEstimate CashEstimate)

    : Offer()
{
    public virtual Ask MakeAskOffer(Receipt[] Holdings)
    {
        //VerifyHold();

        Write();

        Sign();

        var candidates = Broadcast();

        return (Ask) Confirm(candidates);
    }

    public Receipt MakeSellOrder(Receipt[] Holdings)
    {
        var estimate = MakeEstimate();

        var invoice = estimate.MakeInvoice();

        var transfer = invoice.MakeTransfer();

        var receipt = transfer.MakeReceipt();

        return receipt;
    }

    public Estimate MakeEstimate()
    {
        throw new NotImplementedException();
    }

    public override bool Verify()
    {
        throw new NotImplementedException();
    }

    public override void Write()
    {
        throw new NotImplementedException();
    }

    public override void Sign()
    {
        throw new NotImplementedException();
    }

    public override Message[] Broadcast()
    {
        throw new NotImplementedException();
    }

    public override Process Confirm(Message[] Candidates)
    {
        throw new NotImplementedException();
    }
}

#endregion

#region 1B. Bids: (Offer Bidding Confirmation Phase 1B)

public record CashOffer();

public record ItemEstimate();

public record Bid(CashNote Hold, CashOffer CashOffer, ItemEstimate ItemEstimate)

    : Offer()
{
    public Estimate MakeEstimate()
    {
        Write();

        Sign();

        var messages = Broadcast();

        return (Estimate) this.Confirm(messages);
    }

    public override void Write() { }

    public override void Sign() { }

    public override Message[] Broadcast()
    {
        throw new NotImplementedException();
    }

    public override Process Confirm(Message[] Candidates)
    {
        throw new NotImplementedException();
    }

    public override bool Verify()
    {
        throw new NotImplementedException();
    }
}

#endregion

#region 2. Estimates: (Estimating Confirmation Phase 2)

public record Estimate(Bid EstimateableBid, Ask EstimateableAsk) : Process()
{
    public Invoice MakeInvoice()
    {
        return (Invoice) this.Execute();
    }

    public override Process Execute()
    {
        return base.Execute();
    }

    public override void Write()
    {
    }

    public override void Sign()
    {
    }

    public override Message[] Broadcast()
    {
        throw new NotImplementedException();
    }

    public new Invoice Confirm2(Message[] Candidates)
    {
        throw new NotImplementedException();
    }

    public override bool Verify()
    {
        return EstimateableBid.Verify();
    }

    public override Process Confirm(Message[] Candidates)
    {
        throw new NotImplementedException();
    }
}

public record BtcEstimate(Bid EstimateableBid, Ask EstimateableAsk)

    : Estimate(EstimateableBid, EstimateableAsk);

public record EthEstimate(Bid EstimateableBid, Ask EstimateableAsk)

    : Estimate(EstimateableBid, EstimateableAsk);


#endregion

#region 3. Invoices: (Invoicing Confirmation Phase 3)

public record ItemValue();

public record CashValue();

public record Invoice(Estimate InvoicableEstimate, ItemValue Quantity, CashValue Total)

    : Process()
{
    public override Message[] Broadcast()
    {
        throw new NotImplementedException();
    }

    public override Process Confirm(Message[] Candidates)
    {
        throw new NotImplementedException();
    }

    public Transfer MakeTransfer()
    {
        throw new NotImplementedException();
    }

    public override void Sign()
    {
        throw new NotImplementedException();
    }

    public override bool Verify()
    {
        throw new NotImplementedException();
    }

    public override void Write()
    {
        throw new NotImplementedException();
    }
}


#endregion

#region 4. Tranfers: (Transferring Confirmation Phase 4)

public record ItemDelivery();

public record CashPayment();

public record Transfer(Invoice TransferableInvoice, ItemDelivery Delivery, CashPayment Payment)

    : Process()
{
    public override Message[] Broadcast()
    {
        throw new NotImplementedException();
    }

    public override Process Confirm(Message[] Candidates)
    {
        throw new NotImplementedException();
    }

    public Receipt MakeReceipt()
    {
        throw new NotImplementedException();
    }

    public override void Sign()
    {
        throw new NotImplementedException();
    }

    public override bool Verify()
    {
        throw new NotImplementedException();
    }

    public override void Write()
    {
        throw new NotImplementedException();
    }
}

#endregion

#region 5. Receipts: (Receipting Confirmation Phase 5)

public record ItemNote();

//public record CashNote();

public record Receipt(ItemNote ItemNote, CashNote CashNote, Transfer ReceiptableTransfer)

    : Process()
{
    public override Message[] Broadcast()
    {
        throw new NotImplementedException();
    }

    public override Process Confirm(Message[] Candidates)
    {
        throw new NotImplementedException();
    }

    public override void Sign()
    {
        throw new NotImplementedException();
    }

    public override bool Verify()
    {
        throw new NotImplementedException();
    }

    public override void Write()
    {
        throw new NotImplementedException();
    }
}

#endregion


public record Note(ItemNote ItemInput, CashNote CashInput);


public abstract record Item(Signature Seller, decimal ItemValue, Address Buyer)
{
    public string Unit { get { return ""; } }
}

//public record BtcItem(Signature Seller, decimal ItemValue, BtcAddress Buyer);

//public record EthItem(EthSignature Seller, decimal ItemValue, EthAddress Buyer);

//public record Note(Item Item, Signature Buyer, decimal CashValue, Address Seller);

public record Endorsement(Note Input, PrivateKey Signature);

public record ItemEndorsement(ItemNote Input);

//public record ItemNote(decimal Value, string Unit, PublicLock Output);

//public record CashNote;// (ItemEndorsement Input, decimal Value, string Unit, PublicItemLock Output, CashEndorsement CashInput, decimal CashValue, PublicLock CashOutput)

    //;//: ItemNote(Value, Unit, Output);

//#endregion


#region Markets

public record Blockchain(string Unit);

public record Markets2(Blockchain Blockchain)
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
        //ItemOffer.Write();

        return null;
    }

    //public virtual Invoice MakeInvoice(Estimate Estimate) { return null; }

    //public virtual Transfer MakeTransfer(Invoice Invoice) { return null; }

    //public virtual Receipt MakeReceipt(Transfer Transfer) { return null; }

    //public virtual Confirmation Confirm(Confirmation confirmation)
    //{
        //confirmation.Write();

        //confirmation.Sign();

        //confirmation.Broadcast();

        //return confirmation.Confirm();
    //}
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

