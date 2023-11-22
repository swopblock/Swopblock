using System;

namespace Swopblock;
using System;
using System.Threading.Tasks;

public class SwopblockLedger
{
    private readonly object FaceValueLock = new object();

    private decimal PrivateFaceValue = Genesis;

    public const decimal Genesis = 52800000;

    public decimal Debit(decimal faceValue)
    {
        decimal result = 0;

        if (faceValue < 0)
        {
            return result;
        }

        lock (FaceValueLock)
        {
            if (PrivateFaceValue >= (faceValue * 2))
            {
                PrivateFaceValue -= faceValue;

                result = faceValue;
            }
        }

        return result;
    }

    public decimal Credit(decimal faceValue)
    {
        decimal result = 0;

        if (faceValue < 0)
        {
            return result;
        }

        lock (FaceValueLock)
        {
            if (PrivateFaceValue >= (faceValue * 2))
            {
                PrivateFaceValue += faceValue;

                result = faceValue;
            }
        }

        return result;
    }

    public decimal GetFaceValue()
    {
        lock (FaceValueLock)
        {
            return PrivateFaceValue;
        }
    }
}


public class GenericSubLedger : SwopblockLedger
{
    private readonly object BaseValueLock = new object();

    private decimal PrivateBaseValue = GenesisBaseValue;

    public const decimal GenesisBaseValue = 1;

    public decimal Debit(decimal faceValue)
    {
        decimal result = 0;

        if (faceValue < 0)
        {
            return result;
        }

        lock (BaseValueLock)
        {
            if (PrivateBaseValue >= (faceValue * 2))
            {
                PrivateBaseValue -= faceValue;

                result = faceValue;
            }
        }

        return result;
    }

    public decimal Credit(decimal faceValue)
    {
        decimal result = 0;

        if (faceValue < 0)
        {
            return result;
        }

        lock (BaseValueLock)
        {
            if (PrivateBaseValue >= (faceValue * 2))
            {
                PrivateBaseValue += faceValue;

                result = faceValue;
            }
        }

        return result;
    }

    public decimal GetFaceValue()
    {
        lock (BaseValueLock)
        {
            return PrivateBaseValue;
        }
    }


}

/*
public abstract class S
{
    public FaceValues SwoblCash;

    public static S[] History = new S[4096];

    public static long i = 0; 

    public static void Survey(decimal WidthSwobl, decimal HeightUsd)
    {

    }

    public static void Record(string certificate, decimal WidthSwobl, decimal HeightUsd)
    {

    }

    public S (decimal BaseValue)
    {
        //var investment = new S();


        return null;
    }

    public virtual FaceValues CashOnDelivery(BaseValues Delivery)
    {
        return null;
    }

    public virtual FaceValues MarketValue
    {
        get
        {
            return null;
        }
    }

    public virtual FaceValues MarketCap
    {
        get
        {
            return null;
        }
    }

    public virtual BaseValues Market
    {
        get
        {
            return null;
        }
    }

    //public virtual FaceValues CashOnHold(BaseValues Hold)
    //{

    //}

    //public static DebitSystemAccout(decimal FaceValue);




    protected static decimal BranchBaseValue;


    public static decimal BidFaceValue;

    public static decimal BidBaseValue;

    public static decimal AskFaceValue;

    public static decimal AskBaseValue;

    public S()
    {
    }

    public S(decimal FaceValue)
    {
    }

    public S(decimal FaceValue, decimal BaseValue)
    {
    }

    public static S GetPaymentOffer
        (
            decimal ReservedPaymentOffer,

            decimal MinimumPaymentOffer,

            decimal RequiredDeliveryReceipt,

            decimal MaximumDeliveryReceipt
        )
    {
        
        return null;
    }

    public S SpotValues(S Bid, S Ask) { return null; }

    //public decimal SpotFaceValue(decimal BaseValue) { return null; }

    //public decimal SpotBaseValue(decimal FaceValue)
    //{
        //return null; }

    //protected static decimal FaceValueUncirculated = 52800000;



    //public static Swopblocks Genesis = new Swopblock()
}

*/

public record FaceValues(decimal FaceValue);

public record BaseValues(decimal BaseValue)
{
    //public static async Task<SwopblockLedger Join() { }
}








public class BtcLedger// : Swopblocks(BtcValueChange, FaceValueChange)
{
    //public FaceValues  
    //public static decimal BtcBaseValueUncirculated = 1;
}

public class EthLedger//: Swopblocks(EthValueChange, FaceValueChange)
{
    public static decimal EthBaseValueUncirculated = 1;
}










public record MoneyBlocks;

public record MarketBlocks;

public record SecondBlocks;

public record MinuteBlocks;

public record HourBlocks;

public record DayBlocks;

public record MonthBlocks;

public record QuarterBlocks;

public record YearBlocks;

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



