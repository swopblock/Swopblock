using System;

namespace Swopblock;
using System;
using System.Threading.Tasks;

// remember to protocol-buy a portion of crypto being sold

// market orders

/* 
 * Trader: (Buyer and Seller)
 * 
 * 1. Address Open is trader command input.
 * 
 * 2. Address Opened is trader report output.
 * 
 * 3. Address Close is trader command input.
 * 
 * 4. Address Closed is trader report output.
 * 
 * Buyer:  
 * 
 * 1. Payment Offer is buyer command input.
 * 
 * 2. Payment Due is buyer report output.
 * 
 * 3. Payment Deed is buyer report output.
 * 
 * 4. Payment Receipt is buyer report output.
 * 
 * Seller: 
 * 
 * 1. Delivery Offer is seller command input.
 * 
 * 2. Delivery Due is seller report output.
 * 
 * 3. Delivery Deed is seller command input.
 * 
 * 4. Delivery Receipt is seller report output.
 * 
 *
 * Trader:
 * 
 * 
 * 1. Address Open
 * 
 * I am opening my {DeliverableKind} address {NewTradeAddress} with 
 * a beginning balance of {PayableBalance} {PayableKind} to be open for trading.
 * 
 * I am opening my BTC address X with a beginning balance of 10 SWOBL to be open for trading.
 * 
 * 
 * 2. Address Opened
 * 
 * You opened a {DeliverableKind} address {NewTradeAddress} with
 * a beginning balance of {PayableBalance} {PayableKind} to be open for trading.
 * 
 * You opened a BTC address X with a beginning balance of 10 SWOBL to be open for trading.
 * 
 * 
 * 3. Address Close
 * 
 * I am closing my {DeliverableKind} address {TradeAddress} with 
 * an ending balance of {PayableBalance} {PayableKind} to be closed for trading.
 * 
 * I am closing my BTC address X with an ending balance of 0 SWOBL to be closed for trading.
 * 
 * 
 * 4. Address Closed
 * 
 * You closed a {DeliverableKind} address {TradeAddress} 
 *******************************************************************************
 * 1. Offer is a text Command input: 
 * 
 * 
 * Payment Offer: (message from buyer to seller)
 * 
 * I am holding {PaymentKind} located at my address {PaymentSendingAddress}
 * to bid that at least {PaymentMinimum}
 * and at most {PaymentMaximum} {PaymentKind} 
 * be paid to your receiving address
 * as payment for at least {DeliveryMinimum}
 * and at most {DeliveryMaximum} {DeliveryKind}
 * to be delivered to my receiving address {DeliveryReceivingAddress}
 * and this offer is good until the {DeliveryKind}
 * market volume reaches {ExpirationVolume} {PaymentKind}.
 * 
 * 
 * Delivery Offer: (message from seller to buyer)
 * 
 * I am holding {PaymentKind} located at my address {DeliverySendingAddress}
 * to ask that at least {PaymentMinimum}
 * and at most {PaymentMaximum} {PaymentKind} 
 * be paid to my receiving address {PaymentReceivingAddress}
 * as payment for at least {DeliveryMinimum}
 * and at most {DeliveryMaximum} {DeliveryKind}
 * to be delivered to your receiving address
 * and this offer is good until the {DeliveryKind}
 * market volume reaches {ExpirationVolume} {PaymentKind}.
 * 
 * Compare:
 * 
 * I am holding {PaymentKind}
 * I am holding {PaymentKind}
 * BidAsk: I have USD
 *
 * located at my address {PaymentSendingAddress}
 * located at my address {DeliverySendingAddress} 
 * BidAsk: at {123}
 *
 * to bid that at least {PaymentMinimum}
 * to ask that at least {PaymentMinimum}
 * to [bid, ask] 30
 * 
 * and at most {PaymentMaximum} {PaymentKind} 
 * and at most {PaymentMaximum} {PaymentKind}
 * - 70 USD
 * 
 * be paid to your receiving address
 * be paid to my receiving address {PaymentReceivingAddress}
 * ["", "be paid to # 567"
 * 
 * as payment for at least {DeliveryMinimum}
 * as payment for at least {DeliveryMinimum}
 * in the purchase of 40
 *
 * and at most {DeliveryMaximum} {DeliveryKind}
 * and at most {DeliveryMaximum} {DeliveryKind}
 * - 80 BTC
 * 
 *
 * to be delivered to my receiving address {DeliveryReceivingAddress}
 * to be delivered to your receiving address
 * to be delivered to # 987
 *
 * and this offer is good until the {DeliveryKind}
 * and this offer is good until the {DeliveryKind}
 * and this offer is good until the BTC
 *
 * market volume reaches {ExpirationVolume} {PaymentKind}.
 * market volume reaches {ExpirationVolume} {PaymentKind}.
 * market volume reaches 100000000 USD.
 *
 *
 *
 * 2. Payment Due is a text Report output:
 * 
 * Payment Due: (message to buyer)
 * 
 * It is confirmed that {PaymentDue} {PaymentKind} 
 * is on hold at your address {PaymentSendingAddress}
 * and is payment due them for your purchase of {DeliveryDue} {DeliveryKind}
 * which will be released to their payment receiving address {PaymentReceivingAddress} 
 * when you receive delivery of your purchase from their delivery sending address {DeliverySendingAddress}
 * 
 * Delivery Due: (message to seller)
 * 
 * It is confirmed that {PaymentDue} {PaymentKind} 
 * is on hold at their address {PaymentSendingAddress}
 * and is payment due you for their purchase of {DeliveryDue} {DeliveryKind}
 * and will be released to your payment receiving address {PaymentReceivingAddress}
 * when they receive delivery of their purchase at their address {DeliveryReceivingAddress}.
 * 
 * 
 * Compare:
 * 
 * It is confirmed that {PaymentDue} {PaymentKind} 
 * It is confirmed that {PaymentDue} {PaymentKind} 
 * 
 * is on hold at your  address {PaymentSendingAddress}
 * is on hold at their address {PaymentSendingAddress}
 * 
 * and is payment due to them for your  purchase of {DeliveryDue} {DeliveryKind}
 * and is payment due to you  for their purchase of {DeliveryDue} {DeliveryKind}
 * 
 * which will be released to their payment receiving address {PaymentReceivingAddress} 
 * which will be released to your  payment receiving address {PaymentReceivingAddress}
 * 
 * when you  receive delivery of your  purchase from their delivery sending address {DeliverySendingAddress}
 * when they receive delivery of their purchase at   their                  address {DeliveryReceivingAddress}.
 * 
 * 
 * 
 * 
 * 3. Payment Deed is a text Report output:
 * 
 * Payment Deed: (message from buyer to seller)
 * 
 * I am auto paying {PaymentDeed} {PaymentKind} that was on hold at my address {PaymentSendingAddress}
 * as payment for my purchase of {DeliveryDue} {DeliveryKind} 
 * to be released to your payment receiving address {PaymentReceivingAddress}
 * when I receive delivery of my purchase at my address {DeliveryAddress}.
 * 
 * I am auto delivering {DeliveryDeed} {DeliveryKind} that was on hold at my address {DeliverySendingAddress}
 * as delivery of your purchase for {PaymentDue} {PaymentKind}
 * to be released from your payment sending address {SendingPaymentAddress}
 * and received to my payment receiving address {ReceivingPaymentAddress}
 * when you receive delivery of your purchase at your address {DeliveryAddress}.
 * 
 * 4. Payment Receipt is a text Report output:
 * 
 * It is confirmed that {PaymentReceipt} {PaymentKind} was on hold at your address {PaymentSendingAddress}
 * and was paid for your purchase of {DeliveryReceipt} {DeliveryKind}
 * and was released to their payment receiving address {PaymentReceivingAddress} 
 * when they sent delivery of your purchase from their delivery sending address {DeliverySendingAddress}
 * to your delivery receiving address {DeliveryReceivingAddress}.
 * 
 * It is confirmed that {PaymentReceipt} {PaymentKind} was on hold at their address {PaymentSendingAddress}
 * and was paid for their purchase of {DeliveryReceipt} {DeliveryKind}
 * and was released to your payment receiving address {PaymentReceivingAddress}
 * when you sent delivery of their purchase from your delivery sending address {DeliverySendingAddress}
 * to their delivery receiving address {DeliveryReceivingAddress}.
 * 
 * and joining the addesf
 * 
 * 
 *******************************************************************************
 * 1. Delivery Offer is optional command input: 
 * 
 * I am holding {DeliveryKind} located at my address {HoldingAddress}
 * to {Ask} that at least {PaymentMinimum}
 * and at most {PaymentMaximum} {PaymentKind} 
 * be paid at my address {PaymentAddress}
 * as payment for at least {DeliveryMinimum}
 * and at most {DeliveryMaximum} {DeliveryKind}
 * to be delivered at your address.
 * 
 * and this offer is signed with my signature {Signature}
 * and is good until the {DeliveryKind} 
 * market volume reaches {ExpirationVolume} {PaymentKind}.
 * 
 * 2. Delivery Due is a text Report output:
 * 
 * We are reporting the {DeliveryDue} {DeliveryKind} that is on hold at your address {HoldingAddress}
 * was sold for {PaymentDue} {PaymentKind} for you to receive
 * when you deliver your {DeliveryKind} to the delivery address {DeliveryAddress}.
 * 
 * 3. Delivery Deed is a text command output:
 * 
 * I am delivering the {DeliveryDone} {DeliveryKind} that was on hold at my address {HoldingAddress}
 * that was sold for {PaymentDone} {PaymentKind}
 * and released for payment to the payment address {PaymentAddress}
 * when you received delivery of your purchase.
 *  
 * 
 * 
 * and if using your liquidity located at your address {
 * 
 * 
 * 
 * and by protocol the hold 
 * located at my address {. IAMHERE
 * 
 *  * that will be market-unlocked and received in payment to the address {UnlockingAddress}
 * as a Swopblock market order for at least {AtLeastBaseValue} and at most {AtMostBaseValue} {BaseValue.Symbol}
 * that addwill be delivered from the address 0x293847 and 
 * the offer is ordered by the signature {0x238947} and
 * is good until the market volume reaches 209348 SWOBL.
 * 
 * from the market    ... as an offer to the market  in an order for Y.
 * 
 * You will pay      X ... as due to the address  T    in an order for Y.
 * You will deliver  Y ... as due to the address  T    in an order for Y.
 * 
 * I am paying     X ... as a deed to the address  T   in an order for Y. 
 * I am delivering Y ... as a deed to the address  T   in an order for X.
 * 
 * I have received Y ... as a receipt to the address T in an order for X.
 * I have received X ... as a receipt to the address T in an order for Y.
 * 
 */

public enum KindsX
{
    BtcKind,
    EthKind,
    SwoblKind
}

public record AddressX;

/*
 * Buyer's CashOffer
 * 
 * "I bid 30 to 40 SWOBL from here () to buy 40 to 80 BTC to put here () and the offer is good until the market volume reaches 1 million."
 * 
 * "I bid {BidMinimum} "
 * "to {BidMaximum} {BidKind} "
 * "from here ({BiddingAddress}) "
 * "to buy {BuyMinumum} "
 * "to {BuyMaximum} {BuyKind} "
 * "to put here ({BuyingAddress}) "
 * "and the offer is good until the market volume reaches {BidExpiration}."
 */

public record OfferX
{
    public OfferX Parse(string formatedOffer)
    {
        switch (formatedOffer)
        {
            case "bid": return CashOfferX.Random();
            //case "ask": return SaleOfferX.Random();
        }

        return null;
    }
}
public record CashOfferX
    (
        decimal BidMinimum,
        decimal BidMaximum,
        KindsX BidKind,
        AddressX BiddingAddress,
        decimal BuyMinimum,
        decimal BuyMaximum,
        KindsX BuyKind,
        AddressX BuyingAddress,
        decimal BidExpiration
    )
    : OfferX
{
    string[] Format = new string [] { "I", "bid", "to", "from", "here", "to", "buy", "to", "to", "put", "here",
        "and", "the", "offer", "is", "good", "until", "the", "market", "volume", "reaches", "."};

    public static CashOfferX Random()
    {
        decimal bidMin = 10;
        decimal bidMax = 90;
        KindsX bidKind = KindsX.SwoblKind;
        AddressX bidAddr = new AddressX();
        decimal buyMin = 20;
        decimal buyMax = 80;
        KindsX buyKind = KindsX.BtcKind;
        AddressX buyAddr = new AddressX();
        decimal bidExpir = 1000000;

        return new CashOfferX(bidMin, bidMax, bidKind, bidAddr, buyMin, buyMax, buyKind, buyAddr, bidExpir);
    }
    public string Text
    {
        get
        {
            return

            $@"I bid {BidMinimum} 
            to {BidMaximum} {BidKind}
            from here ({BiddingAddress}) 
            to buy {BuyMinimum} 
            to {BuyMaximum} {BuyKind}
            to put here ({BuyingAddress})
            and the offer is good until the market volume reaches {BidExpiration}.";
        }
    }

    public static CashOfferX Parse(string format)
    {
        switch (format)
        {
            case "bid": return null;
        }

        return null;
    }
}


/*
 * Seller's SaleOffer
 * "I ask 30 to 40 SWOBL to put here () to sell 40 to 80 BTC from here () and the offer is good until the market volume reaches 1 million."
 * 
 * "I ask {AskMinimum} "
 * "to {AskMaximum} {AskKind} "
 * "to put here ({AskingAddress}) "
 * "to sell {SellMinimum} "
 * "to {SellMaximum} {SellKind} "
 * "from here ({SellingAddress}) "
 * "and the offer is good until the market volume reaches {AskExpiration}."
 * 
 */

public record SaleOfferX
    (
        decimal AskMinimum,
        decimal AskMaximum,
        KindsX AskKind,
        AddressX AskingAddress,
        decimal SellMinimum,
        decimal SellMaximum,
        KindsX SellKind,
        AddressX SellingAddress,
        decimal AskExpiration
    )
{
    public static SaleOfferX Random()
    {
        decimal askMin = 10;
        decimal askMax = 90;
        KindsX askKind = KindsX.SwoblKind;
        AddressX askAddr = new AddressX();
        decimal sellMin = 20;
        decimal sellMax = 80;
        KindsX sellKind = KindsX.BtcKind;
        AddressX sellAddr = new AddressX();
        decimal askExpir = 1000000;

        return new SaleOfferX(askMin, askMax, askKind, askAddr, sellMin, sellMax, sellKind, sellAddr, askExpir);
    }

    public string Text
    {
        get
        {
            return

            $@"I ask {AskMinimum} 
            to {AskMaximum} {AskKind}
            to put here ({AskingAddress}) 
            to sell {SellMinimum} 
            to {SellMaximum} {SellKind}
            from here ({SellingAddress})
            and the offer is good until the market volume reaches {AskExpiration}.";
        }
    }
}

/* 
 * Buyer's CashDue
 * Your 35 SWOBL from here () payable to here () for the purchase of 50 BTC from here () is due before the market volume reaches 2 million."
 *
 * "Your {PaymentAmount} {PaymentKind}
 * "from here ({BiddingAddress})
 * "payable to here ({AskingAddress})
 * "for the purchase of {DeliveryAmount} {DeliveryKind}
 * "from here ({SellingAddress})
 * "is due before the market volume reaches {AskExpiration} million."
 */

public record CashDueX
    (
        decimal PaymentAmount,
        KindsX PaymentKind,
        AddressX BiddingAddress,
        AddressX AskingAddress,
        decimal DeliveryAmount,
        KindsX DeliveryKind,
        AddressX SellingAddress,
        decimal AskExpiration
    );

/*
 *
 *
 * Seller's SaleDue
 * Your 50 BTC from here () deliverable to here () for the price of 35 SWOBL from here () is due before the market volume reaches 2 million."
 *
 * "Your {DeliveryAmount} {DeliveryKind} "
 * "from here ({SellingAddress}) "
 * "deliverable to here ({BuyingAddress}) "
 * "for the price of {PaymentAmount} {PaymentKind} "
 * "from here ({BiddingAddress}) "
 * "is due before the market volume reaches {BidExpiration}."
 *
 *
 *
 * Buyer's CashDeed
 * I am paying 35 SWOBL from here () to there () in trade for the delivery of 50 BTC from there () to here ().
 * 
 * "I am paying {PaymentAmount} {PaymentKind} "
 * "from here ({BiddingAddress}) "
 * "to there ({AskingAddress}) "
 * "in trade for the delivery of {DeliveryAmount} {DeliveryKind} "
 * "from there ({SellingAddress}) "
 * "to here ({AskingAddress})."
 * 
 * Seller's SaleDeed
 * I am deliverying 50 BTC from here () to there () in trade for the payment of 35 SWOBL from there () to here ().
 *
 * "I am deliverying {DeliveryAmount} {DeliveryKind} "
 * "from here ({SellingAddress}) "
 * "to there ({BuyingAddress}) "
 * "in trade for the payment of {PaymentAmount} {PaymentKind} "
 * "from there ({BiddingAddress}) "
 * "to here ({AskingAddress})."
 *
 * 
 * 
 * Buyer's CashNote
 * Your payment of 35 SWOBL from here () to there () is confirmed in trade for the delivery of 50 BTC from there () to here ().
 *
 * "Your payment of {PaymentAmount} {PaymentKind}
 * "from here ({BiddingAddress}) "
 * "to there ({AskingAddress}) "
 * "is confirmed in trade for the delivery of {DeliveryAmount} {DeliveryKind} "
 * "from there ({SellingAddress}) to here ({BuyingAddress})."
 * 
 * 
 * Seller's SaleNote
 * Your delivery of 50 BTC from here () to there () is confirmed in trade for the payment of 35 SWOBL from there () to here ().
 * 
 * "Your delivery of {DeliveryAmount} {DeliveryKind} "
 * "from here ({SellingAddress}) "
 * "to there ({BuyingAddress}) "
 * "is confirmed in trade for the payment of {PaymentAmount} {PaymentKind} "
 * "from there ({BiddingAddress}) "
 * "to here ({AskingAddress})."
 * 
 * 
 * 
 * 
 * CashNote
 * 
 * It is confirmed that 35 SWOBL from (2834798)
 * was paid to (23848)
 * for 50 BTC from: 298374
 * when the BTC was delivered to: 98787.
 * 
 * I deliver 50 BTC #923847
 * to #28347
 * and receive 35 SWOBL #298347
 * 
 * 
 * 
 * I have a SWOBL                             1. {PaymentKind} 
 * cash note  #123456789                            2. {PaymentSendingAddress} 
 * to bid                                   3. {OfferKind}
 * 30                                       4. {PaymentMinimum} 
 * to 70 SWOBL                              5. {PaymentMaximum} {PaymentKind}
 * to be paid to you                        6. {DeliveryMinimum}
 * in a purchase of 40                      7. {DeliveryMaximum} {DeliveryKind}
 * to 80 BTC                                8. {DeliveryReceivingAddress}
 * to be delivered to #ABCDEF               9. {DeliveryKind}
 * and this offer is good until the BTC    10. {ExpirationVolume} {PaymentKind}.
 * market volume reaches 100000 SWOBL      11. 
 * 
 * I have SWOBL                             1. {PaymentKind} 
 * at #987654321                            2. {PaymentSendingAddress} 
 * to ask                                   3. {OfferKind}
 * 40                                       4. {PaymentMinimum} 
 * to 60 SWOBL  
 * to be paid to #FEDCBA                    5. {PaymentMaximum} {PaymentKind}
 * in a purchase of 50                      6. {DeliveryMinimum}
 * to 70 BTC                                7. {DeliveryMaximum} {DeliveryKind}
 * to be delivered to you                   8. {DeliveryReceivingAddress}
 * and this offer is good until the BTC     9. {DeliveryKind}
 * market volume reaches 200000 SWOBL      10. {ExpirationVolume} {PaymentKind}.
 * 
 * 
 * 
 * It is confirmed that 50 SWOBL
 * is held at #123456789
 * and is payment for 51 BTC
 * and the payment will be released to #FEDCBA
 * when the BTC is delivered to #ABCDEF.
 * 
 * It is confirmed that 50 SWOBL
 * is held at #987654321
 * and is payment for 51 BTC
 * and the payment will be released to #FEDCBA
 * when the BTC is delivered to #ABCDEF.
 * 
 * 
 * I am paying 50 SWOBL 
 * which was held at my address #123456789
 * to procure my purchase of 51 BTC
 * to be released from my payment address #
 * 

// cross market orders

// market money orders

// cross market money orders

public class UniversalLedgerDefinition
{

    FaceValues UniversalFaceValueSummary;

    UniversalAccountDefinition FaceValueUncirculatedInventory;

    #region Feet

    BlockchainLedgerDefinition[] BlockchainLedgers;

    #endregion

    public UniversalLedgerDefinition()
    {
        FaceValueUncirculatedInventory = new UniversalAccountDefinition();

        BlockchainLedgers = new BlockchainLedgerDefinition
    }

    #region Refactor
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
    #endregion
}

public class UniversalAccountDefinition
{
    #region Head

    public UniversalLedgerDefinition UniversalLedger;

    #endregion

    public FaceValues UniversalFaceValueBalance;

    FaceValues Balance = new FaceValues(52800000);

    private void Increase(FaceValues value)
    {

    }

    private void Decrease(FaceValues value)
    {

    }
}

public class BlockchainLedgerDefinition
{
    public UniversalLedgerDefinition UniversalLedger;

    public FaceValues BlockchainFaceValueSummary;

    public BaseValues BlockchainBaseValueSummary;

    public BlockchainAccountDefinition BlockchainAcount;


    #region Refactor

    public BlockchainLedgerDefinition()
    {
    }

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

    #endregion
}

public class BlockchainAccountDefinition
{
    public BlockchainLedgerDefinition BlockchainLedger;

    public FaceValues BlockchainFaceValueBalance;

    public BlockchainAccountDefinition(decimal initialFaceValueBalance, decimal initialBaseValueBalance)
    {
        FaceValueBalance = new FaceValues(initialFaceValueBalance);

        BaseValueBalance = new BaseValues(initialBaseValueBalance);
    }

    FaceValues FaceValueProtocolBalance;
}

public class UserLedgerDefinition
{
    public BlockchainLedgerDefinition BlockchainLedger;

    public FaceValues UserFaceValueSummary;

    public BaseValues UserBaseValueSummary;

    public List<UserAccountDefinition> UserAccounts;
}

public class UserAccountDefinition
{
    public UserLedgerDefinition UserLedger;

    public FaceValues UserFaceValueBalance;

    public BaseValues UserBaseValueBalance;

    public UserTransferRecord[] UserTransfers;
}

public record UserTransferRecord(UserTransferRecord PreviousUserTransfer, UserAccountDefinition PayingParty, FaceValues PaymentUserFaceValue, UserAccountDefinition DeliveringParty, BaseValues DeliveryUserBaseValue);


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



