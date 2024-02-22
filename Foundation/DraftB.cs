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

	public record Signatures;

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
		public Orders PlaceCashOrder(CashOfferMessages cashOfferEntry)
		{
			Orders order = null;

			return order;
		}
	}

    #endregion

    #region STAGES

    public record Stages();

	public record Estimates(BuyerEstimates BuyerEstimate, SellerEstimates SellerEstimate) : Stages()
	{
		public static Estimates MakeCashOffer(CashOfferMessages cashOffer)
		{
			return null;
		}

		public static Estimates MakeSaleOffer(SaleOfferMessages saleOffer)
		{
			return null;
		}
	}

	public record Invoices(BuyerInvoices BuyerInvoice, SellerInvoices SellerInvoice) : Stages()
	{
		public static Invoices MakeInvoice(Estimates Buyer, Estimates Seller)
		{
			return null;
		}

		public static Invoices MakeInvoice(CashDueMessages CashDue, SaleDueMessages saleDue)
		{
			return null;
		}
	}

	public record Transfers(BuyerTransfers BuyerTransfer, SellerTransfers Seller) : Stages()
	{
		public static Transfers MakeTransfer(CashDeedMessages cashDeed, SaleDeedMessages saleDeed)
		{
			return null;
		}
	}

	public record Receipts(BuyerReceipts BuyerReceipt, SellerReceipts SellerReceipt) : Stages()
	{
		public static Transfers MakeReceipt(CashNoteMessages cashNote, SaleNoteMessages saleNote)
		{
			return null;
		}
	}

    #endregion

    #region MESSAGES

    public record Messages();


	public record InvoiceMessages() : Messages();

	public record ReceiptMessages() : Messages();


    public record OfferMessages() : InvoiceMessages();

    public record DueMessages() : InvoiceMessages();


    public record DeedMessages() : ReceiptMessages();

    public record NoteMessages() : ReceiptMessages();


	public record CashOfferMessages(string CashOfferText) : OfferMessages();

	public record SaleOfferMessages(string SaleOfferText) : OfferMessages();


	public record CashDueMessages(string CashDueText) : DueMessages();

	public record SaleDueMessages(string SaleDueText) : DueMessages();


	public record CashDeedMessages(string CashDeedText) : DeedMessages();

	public record SaleDeedMessages(string SaleDeedText) : DeedMessages();


	public record CashNoteMessages(string CashNoteText) : NoteMessages();

	public record SaleNoteMessages(string SaleNoteText) : NoteMessages();

    #endregion

    #region DEALERS

	public record Dealers();

	public record Buyers(Signatures BidAddress, Addresses BuyAddress) : Dealers();

	public record Sellers(Signatures AskAddress, Addresses SellAddress) : Dealers();

	public record BuyerEstimates
		(
			BidCashOfferTerms BidCashOfferTerms,

			BuyCashOfferTerms BuyCashOfferTerms,

			Buyers Buyer,

			CashOfferMessages CashOfferMessage
		);

	public record SellerEstimates
		(
			AskSaleOfferTerms AskSaleOfferTerms,

			SellSaleOfferTerms SellSaleOfferTerms,

			Sellers Seller,

			SaleOfferMessages SaleOfferMessage
		);

	public record BuyerInvoices
        (
            BidCashDueTerms BidCashDueTerms,

            BuyCashDueTerms BuyCashDueTerms,

            Buyers Buyer,

			CashDueMessages CashDueMessage
        );

    public record SellerInvoices
    (
        AskSaleDueTerms AskSaleDueTerms,

        SellSaleDueTerms SellSaleDueTerms,

        Sellers Seller,

		SaleDueMessages SaleDueMessage
    );

    public record BuyerTransfers
		(
            BidCashDeedTerms BidCashDeedTerms,

            BuyCashDeedTerms BuyCashDeedTerms,

            Buyers Buyer,

			CashDeedMessages CashDeedMessages
        );

    public record SellerTransfers
    (
        AskSaleDeedTerms AskSaleDeedTerms,

        SellSaleDeedTerms SellSaleDeedTerms,

        Sellers Seller,

		SaleDeedMessages SaleDeedMessage
    );

    public record BuyerReceipts
		(
            BidCashNoteTerms BidCashOfferTerms,

            BuyCashNoteTerms BuyCashOfferTerms,

            Buyers Buyer,

			CashNoteMessages CashNoteMessage
        );

    public record SellerReceipts
    (
        AskSaleNoteTerms AskSaleNoteTerms,

        SellSaleNoteTerms SellSaleNoteTerms,

        Sellers Seller,

		SaleNoteMessages SaleNoteMessage
    );

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

