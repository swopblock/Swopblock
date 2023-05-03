using System;
namespace swop
{
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

		public interface INewing { IOrdering New(); }

		public interface IOrdering { ISigning Order(); }

		public interface ISigning { IPublishing Sign(); }

		public interface IPublishing { IConfirming Publish(); }

		public interface IConfirming { INewing Confirm(); }

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

		public class Offer : INewing, IOrdering, ISigning, IPublishing, IConfirming
		{
			protected Offer() { }

			public virtual IOrdering New()
			{
				switch (this)
				{
					case OrderZ: return (IOrdering)((Offer)this);

					case Receipt: return (IOrdering)((OrderZ)this);

					case Delivery: return (IOrdering)((Receipt)this);

					case Invoice: return (IOrdering)((Delivery)this);

					case Offer: return (IOrdering)((Invoice)this);
				}

				return (IOrdering)((OrderZ)this);
			}

			public virtual IOrdering New(string text)
			{
				//var This = Parse(text);

				switch (this)
				{
					case Receipt: return (IOrdering)(((OrderZ)this));

					case Delivery: return (IOrdering)((Receipt)this);

					case Invoice: return (IOrdering)((Delivery)this);

					case Offer: return (IOrdering)((Invoice)this);
				}

				return (IOrdering)((OrderZ)this);
			}

			public virtual IOrdering New(byte[] binary)
			{
				//var This = Parse(binary);

				return (IOrdering)null;
			}


			public virtual ISigning Order()
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
		}

		public class Invoice : Offer
		{
			protected Invoice() { }

			public override Delivery Confirm()
			{
				return (Delivery)this;
			}
		}

		public class Delivery : Invoice
		{
			protected Delivery() { }

			public override Delivery Confirm()
			{
				return (Receipt)this;
			}
		}

		public class Receipt : Delivery
		{
			protected Receipt() { }
		}

		public class OrderZ : Receipt
		{
			private OrderZ(out Receipt genesis)
			{
				genesis = (Receipt)this;
			}

			public static void MakeOrder()
			{
				var genesis = (Receipt)MakeGenesis();

				var offer = MakeOffer(genesis);

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

			protected static Receipt MakeGenesis()
			{
				Receipt genesis;

				new OrderZ(out genesis);

				return genesis;
			}
		}

		public class Bid : Offer { }

		public class Ask : Offer { }

		public class Buy : Invoice { }

		public class Sell : Invoice { }

		public class Pay : Delivery { }

		public class Cash : Delivery { }

		public class Expense : Receipt { }

		public class Income : Receipt { }
	}
}

