using System;
namespace swop
{
	/*
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
	*/

	public class OrderForms : IOrderable
	{
		public OrderSetOfParts Parts;
		
		public OfferForms OfferForm;

		public InvoiceForms InvoiceForm;

		public DeliveryForms DeliveryForm;

		public ReceiptForms ReceiptForm;

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

        public IInvoiceable Offer()
        {
            throw new NotImplementedException();
        }

        public IDeliverable Invoice()
		{
			throw new NotImplementedException();
		}

		public IReceiptable Deliver()
		{
			throw new NotImplementedException();
		}

		public INotifiable Receipt()
		{
			throw new NotImplementedException();
		}

		public string Notify()
		{
			return "To Be Done Yet";
		}
    }

    public class AdminOrderForms : OrderForms
	{
		//public static 
	}

	public class ExecOrderForms : OrderForms
	{

	}

	public interface IOrdering : INewable, ISignable, IPendable, IConfirmable { }

	public interface INewable { ISignable New(string text); }

	public interface ISignable { IPendable Sign(string text); }

	public interface IPendable { IConfirmable Pend(string text); }

	public interface IConfirmable { INewable Confirm(string text); }


	public interface IOrderable : IOfferable, IInvoiceable, IDeliverable, IReceiptable, INotifiable
	{
		//IOfferable Order();
	}

	public interface IOfferable : INotifiable { IInvoiceable Offer(); }

	public interface IInvoiceable : INotifiable { IDeliverable Invoice(); }

    public interface IDeliverable : INotifiable { IReceiptable Deliver(); }

    public interface IReceiptable : INotifiable { INotifiable Receipt(); }

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
}

