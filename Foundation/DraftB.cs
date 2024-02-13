namespace DraftB
{
	[Flags]
	public enum Revisions
	{
		Alpha01
	}

    public enum Kinds
	{
		BTC, ETH, SWOBL
	}

	public record Addresses;

	public record TxStreams;


	#region ORDERS

	public record Orders()
	{
		public const Revisions Revision = Revisions.Alpha01;

		public static Orders PlaceOrder(Estimates Estimate)
		{
			Orders order = null;

			return order;
		}
	}


	public record EstimatedOrders(Estimates Estimate) : Orders()
	{
		public InvoicedOrders InvoiceOrder()
		{
			InvoicedOrders invoice = null;

			return invoice;
		}
	}

	public record InvoicedOrders(Estimates Estimate, Invoices Invoice)

		: EstimatedOrders(Estimate)

	{
		public TransferredOrders TransferOrder()
		{
			TransferredOrders transfer = null;

			return transfer;
		}
	}

	public record TransferredOrders(Estimates Estimate, Invoices Invoice, Transfers Transfer)

		: InvoicedOrders(Estimate, Invoice)

	{
		public ReceiptedOrders ReceiptOrder()
		{
			ReceiptedOrders receipt = null;

			return receipt;
		}
	}

	public record ReceiptedOrders(Estimates Estimate, Invoices Invoice, Transfers Transfer, Receipts Receipt)

		: TransferredOrders(Estimate, Invoice, Transfer)

	{
		public Orders PlaceCashOrder(CashOfferEntries cashOfferEntry)
		{
			Orders order = null;

			return order;
		}
	}

    #endregion

    #region STAGES

    public record Stages();

	public record Estimates(CashOfferEntries CashOffer, SaleOfferEntries SaleOffer) : Stages()
	{
		public static Estimates MakeCashOffer(CashOfferEntries cashOffer)
		{
			return null;
		}

		public static Estimates MakeSaleOffer(SaleOfferEntries saleOffer)
		{
			return null;
		}
	}

	public record Invoices(CashDueEntries CashDue, SaleDueEntries SaleDue) : Stages()
	{
		public static Invoices MakeInvoice(Estimates Buyer, Estimates Seller)
		{
			return null;
		}

		public static Invoices MakeInvoice(CashDueEntries CashDue, SaleDueEntries saleDue)
		{
			return null;
		}
	}

	public record Transfers(CashDeedEntries CashDeed, SaleDeedEntries SaleDeed) : Stages()
	{
		public static Transfers MakeTransfer(CashDeedEntries cashDeed, SaleDeedEntries saleDeed)
		{
			return null;
		}
	}

	public record Receipts(CashNoteEntries CashNote, SaleNoteEntries SaleNote) : Stages()
	{
		public static Transfers MakeReceipt(CashNoteEntries cashNote, SaleNoteEntries saleNote)
		{
			return null;
		}
	}

    #endregion

    #region ENTRIES

    public record Entries();


	public record InvoiceEntries() : Entries();

	public record ReceiptEntries() : Entries();


    public record OfferEntries() : InvoiceEntries();

    public record DueEntries() : InvoiceEntries();


    public record DeedEntries() : ReceiptEntries();

    public record NoteEntries() : ReceiptEntries();


	public record CashOfferEntries(BidCashOfferTerms BidOffer, BuyCashOfferTerms BuyOffer) : OfferEntries();

	public record SaleOfferEntries(AskSaleOfferTerms AskOffer, SellSaleOfferTerms SellOffer) : OfferEntries();


	public record CashDueEntries(BidCashDueTerms BidDue, BuyCashDueTerms BuyDue) : DueEntries();

	public record SaleDueEntries(AskSaleDueTerms AskDue, SellSaleDueTerms SellDue) : DueEntries();


	public record CashDeedEntries(BidCashDeedTerms BidDeed, BuyCashDeedTerms BuyDeed) : DeedEntries();

	public record SaleDeedEntries(AskSaleDeedTerms AskDeed, SellSaleDeedTerms SellDeed) : DeedEntries();


	public record CashNoteEntries(BidCashNoteTerms BidNote, BuyCashNoteTerms BuyNote) : NoteEntries();

	public record SaleNoteEntries(AskSaleNoteTerms AskNote, SellSaleNoteTerms SellNote) : NoteEntries();

    #endregion

    #region DEALERS

	public record Dealers();

	public record Buyers(Addresses BidAddress, Addresses BuyAddress) : Dealers();

	public record Sellers(Addresses AskAddress, Addresses SellAddress) : Dealers();

	public record BuyerEstimate
		(
			BidCashOfferTerms BidCashOfferTerms,

			BuyCashOfferTerms BuyCashOfferTerms,

			Addresses BidAddress,

			Addresses BuyAddress,

			TxStreams WhenToOpen
		)

		: Buyers(BidAddress, BuyAddress);

	public record SellerEstimate
		(
			AskSaleOfferTerms AskSaleOfferTerms,

			SellSaleOfferTerms SellSaleOfferTerms,

			Addresses AskAddress,

			Addresses SellAddress
		)

		: Sellers(AskAddress, SellAddress);

	public record BuyerInvoice
        (
            BidCashDueTerms BidCashDueTerms,

            BuyCashDueTerms BuyCashDueTerms,

            Addresses BidAddress,

            Addresses BuyAddress
        )

        : Buyers(BidAddress, BuyAddress);

    public record SellerInvoice
    (
        AskSaleDueTerms AskSaleDueTerms,

        SellSaleDueTerms SellSaleDueTerms,

        Addresses AskAddress,

        Addresses SellAddress
    )

		: Sellers(AskAddress, SellAddress);

    public record BuyerTransfer
		(
            BidCashDeedTerms BidCashDeedTerms,

            BuyCashDeedTerms BuyCashDeedTerms,

            Addresses BidAddress,

            Addresses BuyAddress
        )

        : Buyers(BidAddress, BuyAddress);

    public record SellerTransfer
    (
        AskSaleDeedTerms AskSaleDeedTerms,

        SellSaleDeedTerms SellSaleDeedTerms,

        Addresses AskAddress,

        Addresses SellAddress
    )

		: Sellers(AskAddress, SellAddress);

    public record BuyerReceipt
		(
            BidCashNoteTerms BidCashOfferTerms,

            BuyCashNoteTerms BuyCashOfferTerms,

            Addresses BidAddress,

            Addresses BuyAddress
        )

        : Buyers(BidAddress, BuyAddress);

    public record SellerReceipt
    (
        AskSaleNoteTerms AskSaleNoteTerms,

        SellSaleNoteTerms SellSaleNoteTerms,

        Addresses AskAddress,

        Addresses SellAddress
    )

		: Sellers(AskAddress, SellAddress);

    #endregion


    #region TERMS

    public record Terms();


	public record OfferTerms() : Terms();

	public record DueTerms() : Terms();

	public record DeedTerms() : Terms();

	public record NoteTerms() : Terms();


	public record CashOfferTerms() : OfferTerms();

	public record SaleOfferTerms() : OfferTerms();


	public record CashDueTerms() : DueTerms();

	public record SaleDueTerms() : DueTerms();


	public record CashDeedTerms() : DeedTerms();

	public record SaleDeedTerms() : DeedTerms();


	public record CashNoteTerms() : NoteTerms();

	public record SaleNoteTerms() : NoteTerms();


	
	public record BidCashOfferTerms(decimal BidMinimum, decimal BidMaximum, Kinds BidKind, TxStreams WhenToOpenBid) : CashOfferTerms();

	public record BuyCashOfferTerms(decimal BuyMinimum, decimal BuyMaximum, Kinds BuyKind, TxStreams WhenToCloseBuy) : CashOfferTerms();


	public record AskSaleOfferTerms(decimal AskMinimum, decimal AskMaximum, Kinds AskKind, TxStreams WhenToOpenAsk) : SaleOfferTerms();

	public record SellSaleOfferTerms(decimal SellMinimum, decimal SellMaximum, Kinds SellKind, TxStreams WhenToCloseSell) : SaleOfferTerms();


	public record BidCashDueTerms(decimal BidDue, Kinds BidKind, TxStreams WhenIsBidDue) : CashDueTerms();

	public record BuyCashDueTerms(decimal BuyDue, Kinds BuyKind, TxStreams WhenIsBuyDue) : CashDueTerms();


	public record AskSaleDueTerms(decimal AskDue, Kinds AskKind, TxStreams WhenIsAskDue) : SaleDueTerms();

	public record SellSaleDueTerms(decimal SellDue, Kinds SellKind, TxStreams WhenIsSellDue) : SaleDueTerms();


	public record BidCashDeedTerms(decimal BidDeed, Kinds BidKind, TxStreams WhenWasBidConfirmed) : CashDeedTerms();

	public record BuyCashDeedTerms(decimal BuyDeed, Kinds BuyKind, TxStreams WhenWasBuyConfirmed) : CashDeedTerms();


	public record AskSaleDeedTerms(decimal AskDeed, Kinds AskKind, TxStreams WhenWasAskConfirmed) : SaleDeedTerms();

	public record SellSaleDeedTerms(decimal SellDeed, Kinds SellKind, TxStreams WhenWasSellConfirmed) : SaleDeedTerms();


	public record BidCashNoteTerms(decimal BidNote, Kinds BidKind, TxStreams WhenWillBidBeAvailable) : CashNoteTerms();

	public record BuyCashNoteTerms(decimal BuyNote, Kinds BuyKind, TxStreams WhenWillBuyBeAvailable) : CashNoteTerms();


	public record AskSaleNoteTerms(decimal AskNote, Kinds AskKind, TxStreams WhenWillAskBeAvailable) : SaleNoteTerms();

	public record SellSaleNoteTerms(decimal SellNote, Kinds SellKind, TxStreams WhenWillSellBeAvailable) : SaleNoteTerms();

    #endregion
}

