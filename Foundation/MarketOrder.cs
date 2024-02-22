using System;

namespace Swopblock.DraftB
{

	public class Core
	{
		public class Reviewer
		{

		}

		public class Dealers
		{

		}

		public class Bidding
		{

		}

		public class Buyingx
		{

		}

		public record Asking
		{

		}

		public class Sellingx
		{

		}

		public record Buying(Bidding Bidding, Asking Asking);

		public record Selling(Asking Asking, Bidding Bidding);

		public record BuyerEstimating;

		public record SellerEstimating;

		public record Invoicing;

		//public record 
	}












	public record Signature(Resource KindOfSignature);

	public record Endorsement(Resource KindOfEndorsement);

	public record Address;

	public record CashSource(Signature Signature, Endorsement Endorsement) : Source(Signature, Endorsement);

	public record ItemSource(Signature Signature, Endorsement Endorsement) : Source(Signature, Endorsement);

	public record Source(Signature Signature, Endorsement Endorsment);


	public record CashCounter(Resource KindOfSignature, Resource KindOfEndorsement);// : Counter(Address);

	public record ItemCounter(Address Address, Source CashSource) : Counter(Address);

	public record Counter(Address Address);



	//public record Source(Cash cash, Item item);

	public enum KindsOfOffer
	{
		Bid,
		Ask
	}

	public record CashOffer;

	public record ItemOffer;

	public record BidOffers : CashOffer;

	public record AskOffers : CashOffer;

	public record BuyOffer : ItemOffer;

	public record SellOffer : ItemOffer;

	public record Offer(CashOffer Cash, ItemOffer Item, KindsOfOffer KindOfOffer)
	{
		public static BidOffers BidOffer = new BidOffers();

		//public static AskOffers
	}

	//public record BidOffer(CashValue Cash, Item Item) : Offer(Cash, Item, KindsOfOffer.Bid);

	//public record AskOffer(CashValue Cash, Item Item) : Offer(Cash, Item, KindsOfOffer.Ask);

	public record Market
	{

	}

	public record BtcMarket : Market;

	public record BuyBtcMarket : BtcMarket;

	public record SellBtcMarket : BtcMarket;

	public record EthMarket : Market;

	public record SwoblMarket : Market;

	//public enum KindOfOrder

	public record Bid(CashOffer Cash, ItemOffer Item) : IWrite;

	public record Ask(CashOffer Cash, ItemOffer Item) : IWrite;

	public record OrderStream;

	public record Reservation;

	public record Expiration;



	public record Open;

	public record Close;

	public record Due;

	public record Done;

	public record Available;

	//public record 

	public interface IWrite
	{
		//public Queue<Order> Orders;

		//public string Text { get; set; }

		//public byte[] Binary { get; set; }


		//public static void Write(OrderStream ) { throw new NotImplementedException(); }
	}

	public interface ISign { }

	public interface IBroadcast { }

	public interface IConfirm { }



	public record CashChangeOrder;

	public record ItemChangeOrder;

	public record BidBuyOrder;

	public record AskSellOrder;



	public interface IEstimateable
	{
		public IInvoiceable Estimate()
		{
			Write();

			Sign();

			Broadcast();

			return Confirm();
		}

		public ISignable Write() { throw new NotImplementedException(); }

		public IBroadcastable Sign() { throw new NotImplementedException(); }

		public IConfirmable Broadcast() { throw new NotImplementedException(); }

		public IInvoiceable Confirm() { throw new NotImplementedException(); }
    }

    public interface IInvoiceable
    {
        public ITransferable Invoice()
        {
            Write();

            Sign();

            Broadcast();

            return Confirm();
        }

        public ISignable Write() { throw new NotImplementedException(); }

        public IBroadcastable Sign() { throw new NotImplementedException(); }

        public IConfirmable Broadcast() { throw new NotImplementedException(); }

        public ITransferable Confirm() { throw new NotImplementedException(); }
    }

    public interface ITransferable
    {
        public IReceiptable Transfer()
        {
            Write();

            Sign();

            Broadcast();

            return Confirm();
        }

        public ISignable Write() { throw new NotImplementedException(); }

        public IBroadcastable Sign() { throw new NotImplementedException(); }

        public IConfirmable Broadcast() { throw new NotImplementedException(); }

        public IReceiptable Confirm() { throw new NotImplementedException(); }
    }

    public interface IReceiptable
    {
        public IOrderable Receipt()
        {
            Write();

            Sign();

            Broadcast();

            return Confirm();
        }

        public ISignable Write() { throw new NotImplementedException(); }

        public IBroadcastable Sign() { throw new NotImplementedException(); }

        public IConfirmable Broadcast() { throw new NotImplementedException(); }

        public IOrderable Confirm() { throw new NotImplementedException(); }
    }

	public interface IOrderable { }



    //public inter


    public interface IUseable : IWritable, ISignable, IBroadcastable, IConfirmable
	{
		IWritable Order(IEstimateable order);

		ISignable Write(IWritable order);

		IBroadcastable Sign(ISignable order);

		IConfirmable Broadcast(IBroadcastable order);

		IUseable Confirm(IConfirmable order);
	}

	public interface IWritable { public ISignable Write(); }

	public interface ISignable { public IBroadcastable Sign(); }

	public interface IBroadcastable { public IConfirmable Broadcast(); }

	public interface IConfirmable { public IConfirmed Confirm(); }

	public interface IConfirmed { public IConfirmed Confirmed(); }




	public record Order(Bid Bid, Ask Ask, Open Reservation, Close Expiration, Endorsement Endorsement)
	{
		
	}

	public record WrittenOrder(Order OrderToWrite);

	public record SignedOrder(WrittenOrder OrderToSign);

	public record BroadcastedOrder(SignedOrder OrderToBroadcast);

	public record ConfirmedOrder(Order OrderToConfirm);

	public record Estimate(Order Order) : IWrite, ISign, IBroadcast, IConfirm 
	{
		//public Queue
		public CashOffer CashOffer
		{
			get;

			set;
		}

		public ItemOffer Item;
	}

	public record Invoicing
	{
		
	}

	public enum KindsOfItemValue { BTC }

	public enum KindsOfFaceValue { SWOBL }

	public enum KindsOfValue { }

	public record Notes(CashValue FaceValue, ItemValue ItemValue, Address Payable);

	public record CashNotes(CashValue FaceValue, Address Payable);

	public record ItemNotes(ItemValue ItemValue, Address Payable);

	public record Orders(CashValue FaceValue, ItemValue ItemValue, Address Receivable);

	public record CashOrders(CashValue FaceValue, Address Receivable);

	public record ItemOrders(ItemValue ItemValue, Address Receivable);

	public record ItemValue(decimal Value, KindsOfItemValue Kind);

	public record CashValue(decimal Value, KindsOfFaceValue Kind);

	//public record Value(decimal Value, KindsOfValue KindOfValue);

	public record Hold(Address HoldAddress, KindsOfValue KindOfHold);


	public record NewOrder(Hold Hold, OrderStream Reservation, OrderStream Expiration, Signature Signature);


	public record BuyOrder  ( NewOrder NewOrder, CashValue Input, ItemOrders Order);

	public record SellOrder ( NewOrder NewOrder, ItemValue Input, CashOrders Order);


	public record BuyMarketOrder  ( NewOrder NewOrder, CashValue MaximumCost, ItemValue MinimumOrder);

	public record SellMarketOrder ( NewOrder NewOrder, ItemValue MaximumOrder, CashValue MinimumPrice);


	public record Invoice(Estimate Estimate) : IEstimateable;

	public record Transfer(Invoice Invoice);

	public record Receipt(Transfer Transfer);

	public record Resource(Receipt Receipt);


	public record Core2(params Resource[] Resources)
	{
		public static Core Genesis()
		{
			return new Core();
		}
	}

	//public record CashValue();

	public record Item();

	//public record BtcResource() : Resource(Resource.Kinds.BTC);

	//public record EthResource() : Resource(Resource.Kinds.ETH);

	//public record SwoblResource() : Resource(Resource.Kinds.SWOBL);

	//public record USDResource() : Resource(Resource.Kinds.USD);

	//public record Resource(Resource.Kinds Kind)
	//{
		public enum Kinds
		{
			BTC,
			ETH,
			SWOBL,
			USD
		}
	//}


			public struct Ordersj
			{
				//public Orders(Resources Source, Resources CounterSource) { }
			}

			public struct Estimates
			{
				public Estimates(Ordersj Order)
				{

				}
			}

			public struct Invoices
			{
				public Invoices(Estimates Estimate)
				{

				}
			}

			public struct Transfers
			{
				public Transfers(Invoices Invoice)
				{

				}
			}

			public struct Receipts
			{
				public Receipts(Transfers Transfer)
				{

				}
			}
		}

	public record Source();
	public record Order()
	{
		public void Core()
		{
			//Resources = new List<Resource>();
		}

		//public List<Resource> Resources;


		//public void Resource()

	}

	public struct MarketOrder
	{
		//CashOffers MakeCashOffer(MarketOrder.Parallels.Buyer Bid) { return null; }

		//SaleOffers MakeSaleOffer(MarketOrder.Parallels.Sellers Ask) { return null; }
		public struct Parallels
		{
            //public Bid MakeBid(CashOffers co)
            //{
                //var order = new Estimates();

                //var invoice = Invoice(estimate);
            //}

            //public Estimates Ask(SaleOffers so)
            //{
            //    return new Estimates();
            //}

            public struct Bid
			{
				public Bid(KindOfBid kind)
				{

				}
				public struct KindOfBid
				{
					public struct Signature
					{
						public struct Address
						{
							//Open.a
						}

						public struct Open
						{
							int a;
						}
					}

					public struct Buy
					{
						public struct Address
						{

						}

						public struct Close
						{

						}
					}
				}

				public struct Bids
				{
					public struct Signatures
					{

					}
				}

				public struct Buys
				{
					public struct Addresses
					{

					}
				}
			}

			public struct Sellers
			{
				public struct Signatures
				{
					public struct Asks
					{

					}

					public struct Sells
					{
						public struct Addresses
						{

						}
					}
				}
			}
		}

		public struct Serials
		{
			public Invoices Invoice(Estimates es)
			{
				return new Invoices();
			}

			public Transfers Buy() { return new Transfers(); }

			public Transfers Sell() { return new Transfers(); }

			public Receipts Receipt() { return new Receipts(); }

			public struct Estimates
			{
				public struct CashOffers
				{
					public struct Bids
					{

					}

					public struct Buys
					{

					}
				}

				public struct SaleOffers
				{
					public struct Asks
					{

					}

					public struct Sells
					{

					}
				}
			}

			public struct Invoices
			{
				public struct CashDues
				{

				}

				public struct SaleDues
				{

				}
			}

			public struct Transfers
			{
				public struct CashDeeds
				{

				}

				public struct SaleDeeds
				{

				}
			}

			public struct Receipts
			{
				public struct CashNotes
				{

				}

				public struct SaleNotes
				{

				}

			}
		}
	}


