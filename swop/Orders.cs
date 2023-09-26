using System;
using swop;

namespace OrdersNS
{
	public record Availables(decimal FaceValue, decimal BaseValue);

	//public record Parties;

	public record Signatures(Availables Available);//, Parties Party);

	public record Endorsements(Signatures Signature);//, Availables Available, Parties Party);

	//public record Signatures(byte[] Signature, decimal FaceValue, decimal BaseValue) : Available(FaceValue, BaseValue);

	//public record Endorsements : Signatures;

	//public record Addresses();

	//public record Orders12(Orders13 O13);

	//public record Orders13() : Orders12();

	public interface INetwork { }

	public interface IParty { }

	public interface INeighborhood { }

	public interface IAddress { }

	public interface IOrder { }

	public interface ISwopblock { }

	public interface INodes { }

	public interface IChain { }

	public interface IBlock { }// { MarketOrders[] Orders { get; init; } }


	public struct SOrders
	{
		//B BB;
	}

	public struct SDeposits
	{
		decimal a;

		//C cc;
	}

	public struct SWithdrawals
	{
		decimal v;
	}

	public struct SOffers
	{
		SDeposits D;

		SWithdrawals W;
	}

	public struct SBid
	{
		SDeposits Bid;

		SWithdrawals Lot;
	}

	public struct SAsk
	{
		SDeposits Lot;

		SWithdrawals Ask;
	}

	public struct SInvoices
	{
		SCash Cash;

		SItem Item;
	}

	public struct SCash
	{

	}

	public struct SItem
	{

	}

	public struct SReceipts
	{
		SPayments Payment;

		SDelivery Delivery;
	}

	public struct SPayments
	{

	}

	public struct SDelivery
	{

	}

/*
namespace Records
{
	public record Addresses(decimal FaceValue, decimal BaseValue, Signatures Signature);

	public record Values(decimal Face, decimal Base);

	public record Networks
	{
		public record Neighborhood
		{
			public record Parties
			{
				public record Orders
				(
					Orders.Offers Offer,

					//Orders.Invoices Invoice,

					//Orders.Deliveries Delivery,

					//Orders.Receipts Receipt
				)

				{
					public record Offers()
					{
						public record AvailableAddress(Values Value)
						{
							public record Available2
							(
								//Available.Endorsements Endorsement,

								decimal FaceValue,

								decimal BaseValue
							)
								: Values
								(
									FaceValue,

									BaseValue
								);
							
								public record Endorsements(Parties Party);
						}

							}
						}

						public record Fee
						{

						}


						//public record Receiving(): Address
						{

						}

						public record Messages(Messages.Texts Text, Messages.Binaries Binary)
						{
							public record Texts(string Bid, string Ask);

							public record Binaries(byte[] Offer);
						}

					}

					public record Invoices() { }

					public record Deliveries();

					public record Receipts();

					public void Make() { }

				}

				public record Offer()
				{
					//public void Offer() { }
				}
			}
		}
	}
}

namespace Interfaces
{
    public interface IWriteable { ISignable Writing(); }

    public interface ISignable { ISubmitable Signing(); }

    public interface ISubmitable { IVerifiable Submitting(); }

    public interface IVerifiable { IConfirmable Verifying(); }

    public interface IConfirmable { IConfirmable Confirming(); }


    public interface IOfferable : IWriteable, ISignable, ISubmitable, IVerifiable, IConfirmable
	{ IInvoicable Offering(); }

    public interface IInvoiceable : IWriteable, ISignable, ISubmitable, IVerifiable, IConfirmable
	{ IDeliverable Invoicing(); }

    public interface IDeliverable : IWriteable, ISignable, ISubmitable, IVerifiable, IConfirmable
	{ IReceiptable Delivering(); }

    public interface IReceiptable : IWriteable, ISignable, ISubmitable, IVerifiable, IConfirmable
	{ void Receipting(); }

    public interface IOrderable : IOfferable, IInvoicable, IDeliverable, IReceiptable
	{ void Ordering(); }

    public interface IOrderItem : IOrderable
    {
        IOfferItem Offer { get; }

        interface IOfferItem : IOfferable
        {
            IParty Party { get; }
            interface IParty
            {
                ISendingAddress SendingAddress { get; }
                interface ISendingAddress
                {
                    IFaceValues FaceValues { get; }
                    interface IFaceValues
                    {
                        decimal Available { get; }

                        decimal OpeningBid { get; }

                        decimal MaximumBid { get; }

                        IMarket Market { get; }
                        interface IMarket
                        {
                            decimal ReservationVolume { get; }

                            decimal ExpirationVolume { get; }
                        }
                    }

                    IBaseValues BaseValues { get; }
                    interface IBaseValues
                    {
                        decimal Available { get; }

                        decimal OpeningSale { get; }

                        decimal MaximumSale { get; }

                        IMarket Market { get; }
                        interface IMarket
                        {
                            string Symblol { get; }
                        }
                    }
                }

                IReceivingAddress ReceivingAddress { get; }
                interface IReceivingAddress
                {
                    IFaceValues FaceValues { get; }
                    interface IFaceValues
                    {
                        decimal OpeningAsk { get; }

                        decimal MinimumAsk { get; }
                    }

                    IBaseValues BaseValues { get; }
                    interface IBaseValues
                    {
                        string TradingSymbol { get; }

                        decimal OpeningBuy { get; }

                        decimal MinimumBuy { get; }
                    }
                }

                ISignature Signature { get; }
                interface ISignature
                {
                    string Text { get; }

                    byte[] Binary { get; }
                }
            }

            string Text { get; }

            byte[] Binary { get; }
        }


        IInvoiceItem Invoice { get; }

        interface IInvoiceItem : IInvoicable
        {

        }


        IDeliveryItem Delivery { get; }

        interface IDeliveryItem : IDeliverable
        {

        }


        IReceiptItem Receipt { get; }

        interface IReceiptItem : IReceiptable
        {

        }
    }


    public interface IPartyItem
    {
        ISendingAddress SendingAddress { get; }

        IReceivingAddress ReceivingAddress { get; }
    }

    public interface ICounterPartyItem
    {
        ISendingAddress SendingAddress { get; }

        IReceivingAddress ReceivingAddress { get; }
    }

    public interface ISendingAddress { }

    public interface IReceivingAddress { }



    public interface IInvoiceItem
    {
        IOrderItem Order { get; }

        interface ICounterParty { }

        IInvoiceItem.ICounterParty CounterParty { get; }

        IDeliveryItem Delivery { get; }
    }

    public interface IDeliveryItem
    {
        IInvoiceItem Invoice { get; }

        interface IPartyItem { }

        IPartyItem Party { get; }

        interface ICounterPartyItem { }

        IDeliveryItem.ICounterPartyItem CounterParty { get; }

        IReceiptItem Receipt { get; }
    }

    public interface IReceiptItem : IDeliveryItem { }


}

namespace swop
{
	public partial interface IOne: ITwo, IThree
	{

	}

	public interface ITwo { }

	public interface IThree { }


	public interface IA: IB, IC
	{

	}

	public interface IB { }

	public interface IC { }

	public partial interface IOne : IB { }
	namespace Order
	{
		public class PartyInOffers { }

		public class PartyInInvoices : PartyInOffers { }

		public class PartyInDeliveries : PartyInInvoices { }

		public class PartyInReceipts : PartyInDeliveries { }

		public class Parties : PartyInReceipts { }


        public class CounterPartyInOffers { }

        public class CounterPartyInInvoices : CounterPartyInOffers { }

        public class CounterPartyInDeliveries : CounterPartyInInvoices { }

        public class CounterPartyInReceipts : CounterPartyInDeliveries { }

        public class CounterParties : CounterPartyInReceipts { }


		public class SendingAddresses { }

        public class Offer
		{
			internal Parties party = new();

			internal CounterParties counterParty = new();

			public PartyInOffers Party { get { return party; } set { party = (Parties)value; } }

			public CounterPartyInOffers CounterParty { get { return counterParty; } }
		}

		public class Invoice : Offer
		{
			public new PartyInInvoices Party { get { return party; } }

			public new CounterPartyInInvoices CounterParty { get { return counterParty; } }

			public Invoice(Offer offer)
			{
				party = offer.party;
			}
		}

		public class Delivery : Invoice
		{
			public new PartyInDeliveries Party { get { return party; } set { party = }

			public new CounterPartyInDeliveries CounterParty { get { return counterParty; } }
		}

		public record Receipt : Delivery;

		public class OfferParties { int one; }

		public class InvoiceParties : OfferParties { int two; }

		namespace NOffer
		{
			public record Parties;
		}

		namespace NInvoice
		{
			public record Parties: NOffer.Parties;
		}
	}

	public record Orders8
	{
	}

	public record Parties;

	public record Offers8(Parties Party) : Orders8
	{
	}

	public record CounterParties;

	public record Invoices8(CounterParties CounterParty, Parties Party) : Offers8(Party)
	{
	}

	public record Deliveries8 : Invoices8
	{
		public override Parties Party { get; set; }

		public class Parties : Offers8.Parties
		{

		}
	}

	public class Receipts8 : Deliveries8
	{

	}

	
	public class Ordering: IOrderable
	{
		public Signatures Signature;

		private IOrderable OrderStatus;

		private class Offering : OfferForms, IOfferable, IProcessable
		{
			private IProcessable ProcessStatus;

			public Offering()
			{
				ProcessStatus = (IProcessable)((INewable)this);
			}

			public IOfferable Order()
			{
				throw new NotImplementedException();
			}

			public INewable Confirm()
			{
				if (ProcessStatus is IConfirmable confirmable)
				{
					return (INewable)confirmable.Confirm();
				}

				return ProcessStatus;
			}

			public ISignable New()
			{
				throw new NotImplementedException();
			}

			public IInvoiceable Offer()
			{
				throw new NotImplementedException();
			}

			public IConfirmable Pend()
			{
				throw new NotImplementedException();
			}

			public IPendable Sign()
			{
				throw new NotImplementedException();
			}
		}

		private class Invoicing: InvoiceForms
		{

		}

		private class Delivering: DeliveryForms
		{

		}

		public Ordering()
		{
			OrderStatus = (IOrderable)this;
		}

		public class Receipting: ReceiptForms
		{

		}

		public IInvoiceable Offer()
		{
			if (OrderStatus is IOfferable offerable)
			{
				return offerable.Offer();
			}

			return null;
		}

		public IDeliverable Invoice()
		{
			if (OrderStatus is IInvoiceable invoiceable)
			{
				return invoiceable.Invoice();
			}

			return null;
		}

		public IReceiptable Deliver()
		{
			if (OrderStatus is IDeliverable deliverable)
			{
				return deliverable.Deliver();
			}

			return null;
		}

		public IOfferable Receipt()
		{
			if (OrderStatus is IReceiptable receiptable)
			{
				return receiptable.Receipt();
			}

			return null;
		}

		public IOfferable Order()
		{
			var offerable = (IOfferable)this;

			var invoiceable = offerable.Offer();

			var deliverable = invoiceable.Invoice();

			var receiptable = deliverable.Deliver();

			offerable = receiptable.Receipt();

			return null;
		}

		public IOrderable Order(string text)
		{
			throw new NotImplementedException();
		}

		public IInvoiceable Offer(string text)
		{
			throw new NotImplementedException();
		}

		public IDeliverable Invoice(string text)
		{
			throw new NotImplementedException();
		}

		public IReceiptable Deliver(string text)
		{
			throw new NotImplementedException();
		}

		public IOfferable Receipt(string text)
		{
			throw new NotImplementedException();
		}
	}
	

	public class Orders  // : IOrderable
	{
		public Offers Offer;

		public Invoices Invoice;

		public Deliveries Delivery;

		public Receipts Receipt;

		public IOrderable Order(string text)
		{
			//this.Offer(text);

			return (IOrderable)((IOfferable)null);
		}

		public static IOfferable Intend(string intention)
		{
			if (intention.StartsWith("I am bidding"))
				return (IOfferable)new BidForms();

			if (intention.StartsWith("I am asking"))
				return (IOfferable)new AskForms();

			return null;
		}

		public IInvoiceable AddOffer()
		{
			throw new NotImplementedException();
		}

		public IDeliverable AddInvoice()
		{
			throw new NotImplementedException();
		}

		public IReceiptable AddDelivery()
		{
			throw new NotImplementedException();
		}

		public INotifiable AddReceipt()
		{
			throw new NotImplementedException();
		}

		public string Notify()
		{
			return "To Be Done Yet";
		}
	}

	public class AdminOrderForms : Orders
	{
		//public static 
	}

	public class ExecOrderForms : Orders
	{

	}



	public interface IOrderable2 : IOfferable, IInvoiceable, IDeliverable, IReceiptable, INotifiable
	{
		//IOfferable Order();
	}

	public interface IOfferable2 : INotifiable { IInvoiceable AddOffer(); }

	public interface IInvoiceable : INotifiable { IDeliverable AddInvoice(); }

	public interface IDeliverable2 : INotifiable { IReceiptable AddDelivery(); }

	public interface IReceiptable2 : INotifiable { INotifiable AddReceipt(); }

	public interface INotifiable { string Notify(); }
	

	
	namespace NeedsMoreAndRefactoring
	{
		public interface IBuyOrder
		{
			void Bid();

			void Buy();

			void Pay();

			void Expense();
		}

		public interface ISellOrder
		{
			void Ask();

			void Sell();

			void Cash();

			void Income();
		}

		public interface INewing
		{
			IOrdering New();
			IOrdering New(string text);
			IOrdering New(byte[] binary);
		}

		public interface IOrdering { ISigning Order(); }

		public interface ISigning { IPublishing Sign(); }

		public interface IPublishing { IConfirming Publish(); }

		public interface IConfirming { INewing Confirm(); }

		public interface ICycle : INewing, IOrdering, ISigning, IPublishing, IConfirming { }


		public interface IParsing
		{
			IOrdering Parse(string text);

			IOrdering Parse(byte[] binary);
		}

		public interface IFormating
		{
			string Text();

			byte[] Binary();
		}



		public class Offer : ICycle, IParsing, IFormating
		{
			public Offer() { }

			private Offer(out IOrdering ordering)
			{
				ordering = (IOrdering)this;
			}

			public IOrdering New()
			{
				IOrdering ordering;

				new Offer(out ordering);

				return ordering;
			}

			public IOrdering New(string text)
			{
				return (IOrdering)this;
			}

			public IOrdering New(byte[] binary)
			{
				return (IOrdering)this;
			}


			public ISigning Order()
			{
				return (ISigning)this;
			}

			public virtual IPublishing Sign()
			{
				return (IPublishing)this;
			}

			public virtual IConfirming Publish()
			{
				return (IConfirming)this;
			}

			public virtual INewing Confirm()
			{
				return (INewing)this;
			}

			public IOrdering Parse(string text)
			{
				throw new NotImplementedException();
			}

			public IOrdering Parse(byte[] binary)
			{
				throw new NotImplementedException();
			}

			public string Text()
			{
				throw new NotImplementedException();
			}

			public byte[] Binary()
			{
				throw new NotImplementedException();
			}
		}

		public abstract class Invoice : Offer
		{
			private string crumb;

			protected Invoice() { }

			public override Delivery Confirm()
			{
				crumb = "Invoice.Confirm()";

				return (Delivery)this;
			}
		}

		public abstract class Delivery : Invoice
		{
			protected Delivery() { }

			public override Delivery Confirm()
			{
				return null;// (Receipt)this;
			}
		}

		public abstract class Receipt : Delivery
		{
			protected Receipt() { }
		}


		public class Orders : ICycle
		{
			public Orders() { }

			//private Orders(out Receipt genesis)
			//{
				//genesis = null;// (Receipt)this;
			//}

			public static Offer NewOffer()
			{
				return null;// (Offer)new Orders();
			}

			public static Bid NewBid()
			{
				return (Bid)new Bid();
			}

			public static void MakeOrder()
			{
				//var genesis = (Receipt)MakeGenesis();

				Offer offer = null;// = MakeOffer(genesis);

				var invoice = MakeInvoice(offer);

				var delivery = MakeDelivery(invoice);

				var receipt = MakeReceipt(delivery);

				while (true)
				{
					offer = MakeOffer(receipt);

					invoice = MakeInvoice(offer);

					delivery = MakeDelivery(invoice);

					receipt = MakeReceipt(delivery);
				}
			}

			public static Offer MakeOffer(Receipt receipt)
			{
				var offer = receipt.Confirm();

				var ordering = offer.New();

				var signing = ordering.Order();

				var publishing = signing.Sign();

				var confirming = publishing.Publish();

				var phasing = confirming.Confirm();

				return offer;
			}

			public static Invoice MakeInvoice(Offer offer)
			{
				return (Invoice)offer;
			}

			public static Delivery MakeDelivery(Invoice invoice)
			{
				return (Delivery)invoice;
			}

			public static Receipt MakeReceipt(Delivery delivery)
			{
				return (Receipt)delivery;
			}

			private static Receipt MakeGenesis()
			{
				Receipt genesis;

				//new Orders(out genesis);

				return null;// genesis;
			}

			public IOrdering Phase()
			{
				return null;
			}

			public ISigning Order()
			{
				return (ISigning)this;
			}

			public IPublishing Sign()
			{
				return (IPublishing)this;
			}

			public IConfirming Publish()
			{
				return (IConfirming)this;
			}

			public INewing Confirm()
			{
				return (INewing)this;
			}

			public IOrdering New()
			{
				throw new NotImplementedException();
			}

			public IOrdering New(string text)
			{
				throw new NotImplementedException();
			}

			public IOrdering New(byte[] binary)
			{
				throw new NotImplementedException();
			}
		}

		public class Bid : Orders
		{
			public new static Bid NewBid()
			{
				return (Bid)new Orders();
			}
		}

		//public class Ask : Offer { }

		public class Buy : Invoice { }

		public class Sell : Invoice { }

		public class Pay : Delivery { }

		public class Cash : Delivery { }

		//public class Expense : Receipt { }

		//public class Income : Receipt { }
	}
	*/
}