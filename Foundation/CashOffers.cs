using System;
namespace Swopblock.DraftA
{
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

    public class CashOfferInfo
    {
        public decimal BidMinimum { get; set; }
        public decimal BidMaximum { get; set; }
        public Kinds BidKind { get; set; }
        public Address? BiddingAddress { get; set; }
        public decimal BidExpiration { get; set; }

        public decimal BuyMinimum { get; set; }
        public decimal BuyMaximum { get; set; }
        public Kinds BuyKind { get; set; }
        public Address? BuyAddress { get; set; }
        public Signatures? Signature { get; set; }

        public CashOfferInfo(Kinds bidKind)
        {
            //BidKind = biddingAddress;
        }

        public CashOfferInfo(string text)
        {
            

        }

        public CashOfferInfo(CashOffers original)
        {

        }

        public CashOffers Record()
        {
            return new CashOffers
                (
                    BidMinimum,

                    BidMaximum,

                    BidKind,

                    BiddingAddress,

                    BidExpiration,

                    BuyMinimum,

                    BuyMaximum,

                    BuyKind,

                    BuyAddress,

                    Signature
                );
        }

        public static CashOffers Random()
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

            return null; /* new CashOffers
                (
                    bidMin,

                    bidMax,

                    bidKind,

                    bidAddr,

                    buyMin,

                    buyMax,

                    buyKind,

                    buyAddr,

                    bidExpir
                );*/
        }
    }

    public record CashOffers
        (
            decimal BidMinimum,

            decimal BidMaximum,

            Kinds BidKind,

            Address BiddingAddress,

            decimal BidExpiration,

            decimal BuyMinimum,

            decimal BuyMaximum,

            Kinds BuyKind,

            Address BuyingAddress,

            Signatures Signature
        ):

    Offers
    {
        string[] Format = new string[]
        {
            "I", "bid", "to", "from", "here", "to", "buy", "to", "to", "put",
            "here", "and", "the", "offer", "is", "good", "until", "the",
            "market", "volume", "reaches", "."
        };

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

                and the offer is good until the

                market volume reaches {BidExpiration}.";
            }
        }
    }
}

