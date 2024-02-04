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


	#region TRANSACTIONS

	public record Transactions(Estimates Estimate, Invoices Invoice, Transfers Transfer, Receipts Receipt, Revisions Revision)

		: TransactionsReceipted(Estimate, Invoice, Transfer, Receipt);

	public record TransactionsEstimated(Estimates Estimate);

	public record TransactionsInvoiced(Estimates Estimate, Invoices Invoice)

		: TransactionsEstimated(Estimate);

	public record TransactionsTransfered(Estimates Estimate, Invoices Invoice, Transfers Transfer)

		: TransactionsInvoiced(Estimate, Invoice);

	public record TransactionsReceipted(Estimates Estimate, Invoices Invoice, Transfers Transfer, Receipts Receipt)

		: TransactionsTransfered(Estimate, Invoice, Transfer);

    #endregion

    #region PHASES

    public record Phases();

	public record Estimates(CashOfferEntries CashOffer, SaleOfferEntries SaleOffer) : Phases();

	public record Invoices(CashDueEntries CashDue, SaleDueEntries SaleDue) : Phases();

	public record Transfers(CashDeedEntries CashDeed, SaleDeedEntries SaleDeed) : Phases();

	public record Receipts(CashNoteEntries CashNote, SaleNoteEntries SaleNote) : Phases();

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


	
	public record BidCashOfferTerms(decimal BidMinimum, decimal BidMaximum, Kinds BidKind, Addresses BidAddress, TxStreams WhenToOpen) : CashOfferTerms();

	public record BuyCashOfferTerms(decimal BuyMinimum, decimal BuyMaximum, Kinds BuyKind, Addresses BuyAddress, TxStreams WhenToClose) : CashOfferTerms();


	public record AskSaleOfferTerms(decimal AskMinimum, decimal AskMaximum, Kinds AskKind, Addresses AskAddress, TxStreams WhenToOpen) : SaleOfferTerms();

	public record SellSaleOfferTerms(decimal SellMinimum, decimal SellMaximum, Kinds SellKind, Addresses SellAddress, TxStreams WhenToClose) : SaleOfferTerms();


	public record BidCashDueTerms(decimal BidDue, Kinds BidKind, Addresses BidAddress, Addresses AskAddress, TxStreams WhenIsDue) : CashDueTerms();

	public record BuyCashDueTerms(decimal BuyDue, Kinds BuyKind, Addresses BuyAddress, Addresses SellAddress, TxStreams WhenIsDue) : CashDueTerms();


	public record AskSaleDueTerms(decimal AskDue, Kinds AskKind, Addresses AskAddress, Addresses BidAddress, TxStreams WhenIsDue) : SaleDueTerms();

	public record SellSaleDueTerms(decimal SellDue, Kinds SellKind, Addresses SellAddress, Addresses BuyAddress, TxStreams WhenIsDue) : SaleDueTerms();


	public record BidCashDeedTerms(decimal BidDeed, Kinds BidKind, Addresses BidAddress, Addresses AskAddress, TxStreams WhenWasConfirmed) : CashDeedTerms();

	public record BuyCashDeedTerms(decimal BuyDeed, Kinds BuyKind, Addresses BuyAddress, Addresses SellAddress, TxStreams WhenWasConfirmed) : CashDeedTerms();


	public record AskSaleDeedTerms(decimal AskDeed, Kinds AskKind, Addresses AskAddress, Addresses BidAddress, TxStreams WhenWasConfirmed) : SaleDeedTerms();

	public record SellSaleDeedTerms(decimal SellDeed, Kinds SellKind, Addresses SellAddress, Addresses BuyAddress, TxStreams WhenWasConfirmed) : SaleDeedTerms();


	public record BidCashNoteTerms(decimal BidNote, Kinds BidKind, Addresses BidAddress, Addresses AskAddress, TxStreams WhenWillBeAvailable) : CashNoteTerms();

	public record BuyCashNoteTerms(decimal BuyNote, Kinds BuyKind, Addresses BuyAddress, Addresses SellAddress, TxStreams WhenWillBeAvailable) : CashNoteTerms();


	public record AskSaleNoteTerms(decimal AskNote, Kinds AskKind, Addresses AskAddress, Addresses BidAddress, TxStreams WhenWillBeAvailable) : SaleNoteTerms();

	public record SellSaleNoteTerms(decimal SellNote, Kinds SellKind, Addresses SellAddress, Addresses BuyAddress, TxStreams WhenWillBeAvailable) : SaleNoteTerms();

    #endregion
}

