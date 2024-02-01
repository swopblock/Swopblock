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

	public record Address;

	public record TxStream;


	#region TRANSACTION

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

    #region PHASE

    public record Phases();

	public record Estimates(CashOfferEntries CashOffer, SaleOfferEntries SaleOffer) : Phases();

	public record Invoices(CashDueEntries CashDue, SaleDueEntries SaleDue) : Phases();

	public record Transfers(CashDeedEntries CashDeed, SaleDeedEntries SaleDeed) : Phases();

	public record Receipts(CashNoteEntries CashNote, SaleNoteEntries SaleNote) : Phases();

    #endregion

    #region ENTRY

    public record Entries();


	public record InvoiceEntries() : Entries();

	public record ReceiptEntries() : Entries();


    public record OfferEntries() : InvoiceEntries();

    public record DueEntries() : InvoiceEntries();


    public record DeedEntries() : ReceiptEntries();

    public record NoteEntries() : ReceiptEntries();


	public record CashOfferEntries(BidCashOfferMetrics BidOffer, BuyCashOfferMetrics BuyOffer) : OfferEntries();

	public record SaleOfferEntries(AskSaleOfferMetrics AskOffer, SellSaleOfferMetrics SellOffer) : OfferEntries();


	public record CashDueEntries(BidCashDueMetrics BidDue, BuyCashDueMetrics BuyDue) : DueEntries();

	public record SaleDueEntries(AskSaleDueMetrics AskDue, SellSaleDueMetrics SellDue) : DueEntries();


	public record CashDeedEntries(BidCashDeedMetrics BidDeed, BuyCashDeedMetrics BuyDeed) : DeedEntries();

	public record SaleDeedEntries(AskSaleDeedMetrics AskDeed, SellSaleDeedMetrics SellDeed) : DeedEntries();


	public record CashNoteEntries(BidCashNoteMetrics BidNote, BuyCashNoteMetrics BuyNote) : NoteEntries();

	public record SaleNoteEntries(AskSaleNoteMetrics AskNote, SellSaleNoteMetrics SellNote) : NoteEntries();

    #endregion

    #region METRIC

    public record Metrics();


	public record OfferMetrics() : Metrics();

	public record DueMetrics() : Metrics();

	public record DeedMetrics() : Metrics();

	public record NoteMetrics() : Metrics();


	public record CashOfferMetrics() : OfferMetrics();

	public record SaleOfferMetrics() : OfferMetrics();


	public record CashDueMetrics() : DueMetrics();

	public record SaleDueMetrics() : DueMetrics();


	public record CashDeedMetrics() : DeedMetrics();

	public record SaleDeedMetrics() : DeedMetrics();


	public record CashNoteMetrics() : NoteMetrics();

	public record SaleNoteMetrics() : NoteMetrics();


	
	public record BidCashOfferMetrics(decimal BidMinimum, decimal BidMaximum, Kinds BidKind, Address BidAddress, TxStream WhenToOpen) : CashOfferMetrics();

	public record BuyCashOfferMetrics(decimal BuyMinimum, decimal BuyMaximum, Kinds BuyKind, Address BuyAddress, TxStream WhenToClose) : CashOfferMetrics();


	public record AskSaleOfferMetrics(decimal AskMinimum, decimal AskMaximum, Kinds AskKind, Address AskAddress, TxStream WhenToOpen) : SaleOfferMetrics();

	public record SellSaleOfferMetrics(decimal SellMinimum, decimal SellMaximum, Kinds SellKind, Address SellAddress, TxStream WhenToClose) : SaleOfferMetrics();


	public record BidCashDueMetrics(decimal BidDue, Kinds BidKind, Address BidAddress, Address AskAddress, TxStream WhenIsDue) : CashDueMetrics();

	public record BuyCashDueMetrics(decimal BuyDue, Kinds BuyKind, Address BuyAddress, Address SellAddress, TxStream WhenIsDue) : CashDueMetrics();


	public record AskSaleDueMetrics(decimal AskDue, Kinds AskKind, Address AskAddress, Address BidAddress, TxStream WhenIsDue) : SaleDueMetrics();

	public record SellSaleDueMetrics(decimal SellDue, Kinds SellKind, Address SellAddress, Address BuyAddress, TxStream WhenIsDue) : SaleDueMetrics();


	public record BidCashDeedMetrics(decimal BidDeed, Kinds BidKind, Address BidAddress, Address AskAddress, TxStream WhenWasConfirmed) : CashDeedMetrics();

	public record BuyCashDeedMetrics(decimal BuyDeed, Kinds BuyKind, Address BuyAddress, Address SellAddress, TxStream WhenWasConfirmed) : CashDeedMetrics();


	public record AskSaleDeedMetrics(decimal AskDeed, Kinds AskKind, Address AskAddress, Address BidAddress, TxStream WhenWasConfirmed) : SaleDeedMetrics();

	public record SellSaleDeedMetrics(decimal SellDeed, Kinds SellKind, Address SellAddress, Address BuyAddress, TxStream WhenWasConfirmed) : SaleDeedMetrics();


	public record BidCashNoteMetrics(decimal BidNote, Kinds BidKind, Address BidAddress, Address AskAddress, TxStream WhenWillBeAvailable) : CashNoteMetrics();

	public record BuyCashNoteMetrics(decimal BuyNote, Kinds BuyKind, Address BuyAddress, Address SellAddress, TxStream WhenWillBeAvailable) : CashNoteMetrics();


	public record AskSaleNoteMetrics(decimal AskNote, Kinds AskKind, Address AskAddress, Address BidAddress, TxStream WhenWillBeAvailable) : SaleNoteMetrics();

	public record SellSaleNoteMetrics(decimal SellNote, Kinds SellKind, Address SellAddress, Address BuyAddress, TxStream WhenWillBeAvailable) : SaleNoteMetrics();

    #endregion
}

