using System;

namespace Swopblock.DraftA
{
    public record Offers
    {
        public Offers Parse(string formatedOffer)
        {
            switch (formatedOffer)
            {
                //case "bid": return CashOffers.Random();
                    //case "ask": return SaleOfferX.Random();
            }

            return null;
        }
    }

}

namespace Swopblock
{

    /*
     * Offer:
     * 
     * I am holding {PaymentKind is a Kind.Face} located at my address {HoldingAddress is a Key.Public}
     * to {OfferKind is a Kind.Face} that at least {PaymentMinimum is an Amount.Face}
     * and at most {PaymentMaximum is an Amount.Face } {PaymentKind is a Kind.Face} 
     * be paid at {GenericPaymentAddress}
     * as payment for at least {DeliveryMinimum}
     * and at most {DeliveryMaximum} {DeliveryKind}
     * to be delivered at {GenericDeliveryAddress}
     * and this offer is good until the {DeliveryKind}
     * market volume reaches {ExpirationVolume} {PaymentKind}.
     * 
     * Bid Offer:
     * 
     * I am holding {PaymentKind is a Kind.Face} located at my address {HoldingAddress is a Key.Public}
     * to bid that at least {PaymentMinimum is an Amount.Face}
     * and at most {PaymentMaximum is an Amount.Face} {PaymentKind is a Key.Face} 
     * be paid to you
     * as payment for at least {DeliveryMinimum is an Amount.Base}
     * and at most {DeliveryMaximum is an Amount.Base} {DeliveryKind is an Kind.Base}
     * to be delivered to me at my address {DeliveryAddress is a Key.Public}
     * and this offer is good until the {DeliveryKind is a Kind.Base}
     * market volume reaches {ExpirationVolume is a Volume.Face} {PaymentKind is a Kind.Face}.
     * 
     * 
     * Sell Offer:
     * 
     * I am holding {PaymentKind} located at my address {HoldingAddress}
     * to ask that at least {PaymentMinimum}
     * and at most {PaymentMaximum} {PaymentKind} 
     * be paid to me at my address {PaymentAddress}
     * as payment for at least {DeliveryMinimum}
     * and at most {DeliveryMaximum} {DeliveryKind}
     * to be delivered to you
     * and this offer is good until the {DeliveryKind}
     * market volume reaches {ExpirationVolume} {PaymentKind}.
    */

    //public record Values(Amounts Amount, Kinds Kind, Symbols Symbol, Volumes Volume, Circulations Circulation);


    public record BlockChainValues();

    public record BtcValues();

    public record EthValues();

    public record SwopblockValues();

    public record UsdValues();


    public record Amounts(string Base, string Face);

    public record BlockchainAmounts(string Base, string Face) : Amounts(Base, Face);

    public record BtcAmounts(string Base, string Face) : BlockchainAmounts(Base, Face);

    public record EthAmounts(string Base, string Face) : BlockchainAmounts(Base, Face);

    public record SwopblockAmounts(string Base, string Face) : Amounts(Base, Face);

    public record UsdAmounts(string Base, string Face) : SwopblockAmounts(Base, Face);


    public record Kinds(string Kind, string Symbol);

    public record BlockchainKinds(string Kind, string Symbol) : Kinds(Kind, Symbol);

    public record BitcoinKind() : BlockchainKinds("Bitcoin", "BTC");

    public record EthereumKind() : BlockchainKinds("Ethereum", "ETH");

    public record SwopblockKinds(string Kind, string Symbol) : Kinds(Kind, Symbol);

    public record CashKind() : SwopblockKinds("Cash", "USD");



    public record Keys(string Public, string Private);

    public record BlockchainKeys(string a);

    public record Volumes(string Base, string Face);

    public record Circulations(string Base, string Face);



    public record EndorsementOfValue(string b);

    public record SignatureOfValue(string Signature);

    public record AmountOfFaceValue(string Amount);

    public record KindOfFaceValue(string Kind);

    public record SymbolOfFaceValue(string Symbol);

    public record PublicKeyOfFaceValue(string Key);

    public record VolumeOfFaceValue(string Volume);

    public record SignatureOfFaceValue(string Signature);

    //public record BaseKindOfValue(string KindOfValue): KindOfValue;

    //public record UsdBaseKindOfValue(): BaseKindOfValue("USD");

    //public record BtcBaseKindOfValue(): BaseKindOfValue("BTC");

    //public record EthBaseKindOfValue(): BaseKindOfValue("ETH");

    public record FaceKindOfValue(string KindOfValue);

    public record SwoblKindOfValue() : FaceKindOfValue("SWOBL");



    public record KeyOfValue;


    public record KindOfKey; // IAMHERE

    //public record AddressKindOfPublicKey(string KindOfPublicKey): KindOfPublicKey;

    //public record BitcoinBlockchainKindOfPublicKey(): AddressKindOfPublicKey("Bitcoin");

    //public record EthereumBlockchainKindOfPublicKey(): AddressKindOfPublicKey("Ethereum");

    //public record CompanyTransactionKindOfPublicKey(string KindOfPublicKey): KindOfPublicKey;

    //public record SwopblockCompanyTransactionKindOfPublicKey(): CompanyTransactionKindOfPublicKey("Swopblock");



    public record Ledger;


    public record KindOfLedgers(string KindOfLedger);

    public record BlockchainKindOfLedger() : KindOfLedgers("Blockchain");

    public record BtcBlockchainKindOfLedger() : BlockchainKindOfLedger();

    public record EthBlockchainKindOfLedger() : BlockchainKindOfLedger();

    public record CashJournalKindOfLedger() : KindOfLedgers("CashJournal");

    public record SwopblockCashJournalKindOfLedger() : CashJournalKindOfLedger();



    public record CustodyOfValue();

    public record BaseCustodyOfValue();

    public record UsdBaseCustodyOfValue() : BaseCustodyOfValue();

    public record FaceCustodyOfValue();



    public record BaseValueOfTheValue(decimal BaseValue);

    public record FaceValueOfTheValue(decimal FaceValue);


    public record MaximumOfNewBid(decimal FaceValueMaximum);

    public record MinimumOfNewBid(decimal FaceValueMinimum);

    public record MaximumOfNewDelivery(decimal BaseValue);

    public record MinimumOfNewDelivery(decimal BaseValue);

    public record VolumeOfNewExpiration(decimal FaceValue);

    public record KindOfNewExpiration(string Name);

    //public record BiddingPayments(FaceKindOfTheValue KindOfThePaymentValue, LocationOfTheValue LocationOfThePaymentValue, FaceValueOfTheValue MinimumAmountOfThePaymentValue, FaceValueOfTheValue MaximumAmountOfThePaymentValue);

    //public record BiddingDeliveries(BaseKindOfTheValue KindOfTheDeliveryValue, LocationOfTheValue LocationOfTheDeliveryValue, BaseValueOfTheValue MinimumAmountOfTheDeliveryValue, BaseValueOfTheValue MaximumAmountOfDeliveryValue);

    public record AskingPayments();

    public record AskingDeliveries();

    public record OfferExpirations();

    //public record BiddingOffers(BiddingPayments BiddingPayment, BiddingDeliveries BiddingDelivery, OfferExpirations Expiration);

    //public record AskingOffers(AskingPayments AskingPayment, AskingDeliveries AskingDelivery, OfferExpiration Expiration)



    //public record MaximumOfAsk(decimal FaceValueMaximum);

    //public record MinimumOfAsk(decimal FaceValueMinimum);

    //public record MarketMaximumOf

    //public record PublicKindOfAddresses(byte[] Location, string Name)

    //: KindOfAddresses("a public kind of address");

    //public record 

    //public record DeliveryKindOfAddresses(string KindOfAddress) : Kinds("a delivery kind of");

    public record Private(byte[] TheLocation);

    public record Orders_;

    //public record AskingOffer(decimal Minimum, decimal Maximum, Public Location);

    public record BiddingOffer(decimal Minimum, decimal Maximum, Kinds Kind);

    //public record OfferExpiration(DeliveryKinds )


    //public record 
    //public record Values(string Name);

    //public record PaymentValues(string Name, decimal FaceValue): Values("PaymentKind");

    //public record SwoblValues(decimal FaceValue) : PaymentValues("SWOBL", FaceValue);

    //public record DeliveryValues(string Name, decimal BaseValue): Values("DeliveryKind");

    //public record BtcValues(decimal BaseValue) : DeliveryValues("BTC", BaseValue);

    //public record EthValues(decimal BaseValue) : DeliveryValues("ETH", BaseValue);

    //public record Amounts(decimal Amount): Value("some kind of value"); 

    public record AddressNew(string Name, Amounts Amounts);

    //public record 

    //public record PaymentOffers()

    public partial record Offers
    {
        public void Write()
        {

        }

        public void Sign()
        {

        }

        public void Broadcast()
        {

        }



    }
}

