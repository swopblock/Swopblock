using System;

namespace Swopblock;

public record SwopBlock(decimal BaseValue, decimal FaceValue)
{

}



/*
public record SwopBlock(decimal BaseValue, decimal FaceValue)
{
    public static SwopBlock System = new SwopBlock(52800000, 1);

    public virtual SwopBlock Branch => System;

    public void EnqueueOffer(Offers offer)
    {
        OfferQueue.Enqueue(offer);
    }

    public void OpenMarketOrders()
    {
        foreach (var offer in OfferQueue)
        {
            WriteOffer(offer);

            SignOffer(offer);

            BroadcastOffer(offer);

            ConfirmOffer(offer);


            var match = FindMatchingOffer(offer);

            var due = DetermineWhatIsDue(offer, match);

            DueQueue.Enqueue(due);
        }
    }

    public void ProcessDueQueue()
    {
        foreach (var due in DueQueue)
        {
            WriteDeed
        }
    }

    public void EnqueueDeed(Deeds Deed)
    {

    }

    public Receipts DequeueReceipt(Receipts Receipt)
    {
        return null;
    }

    private Queue<Offers> OfferQueue = new Queue<Offers>();

    private Queue<Dues> DueQueue = new Queue<Dues>();

    private Queue<Deeds> DeedQueue = new Queue<Deeds>();

    private Queue<Receipts> ReceiptQueue = new Queue<Receipts>();

    private Queue<OpenedMarketOrder> OpenedMarketOrderQueue = new Queue<OpenedMarketOrder>();

    private Queue<ClosedMarketOrder> ClosedMarketOrderQueue = new Queue<ClosedMarketOrder>();

    private Queue<MarketOrderInvoice> ArchiveOrderQueue = new 

    private Queue<Invoice> InvoiceQueue = new Queue<Invoice>();

    protected virtual void WriteOffer(Offers offer)
    {
        SignOffer(offer);
    }

    protected virtual void SignOffer(Offers offer)
    {
        BroadcastOffer(offer);
    }

    protected virtual void BroadcastOffer(Offers offer)
    {
        ConfirmOffer(offer);
    }

    protected virtual void ConfirmOffer(Offers offer)
    {
        DueQueue.Enqueue
        (
            DetermineWhatIsDue
            (
                offer,

                FindMatchingOffer(offer)
            )
        );
    }

    protected virtual Offers FindMatchingOffer(Offers offer)
    {
        return null;
    }

    protected virtual Dues DetermineWhatIsDue(Offers offer, Offers matchOffer)
    {
        return null;
    }


    protected virtual void WriteDeed(Deeds deed)
    {

    }

    protected virtual void SignDeed(Deeds deed)
    {

    }

    protected virtual void BroadcastDeed(Deeds deed)
    {

    }

    protected virtual void ConfirmDeed(Deeds deed)
    {

    }

}

public record BtcSwopBlock(decimal BtcValue, decimal FaceValue): SwopBlock(BtcValue, FaceValue)
{
    public static BtcSwopBlock Btc = new BtcSwopBlock(0, 1);

    public override SwopBlock Branch => Btc;
}

public record EthSwopBlock(decimal EthValue, decimal FaceValue): SwopBlock(EthValue, FaceValue)
{
    public static EthSwopBlock Eth = new EthSwopBlock(0, 1);

    public override SwopBlock Branch => Eth;
}
*/



