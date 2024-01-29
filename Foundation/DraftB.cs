using System;
namespace DraftB
{
	public class DraftB
	{
		public DraftB()
		{
		}
	}



	// TRANSACTION 

	public record Transactions();

	public record TransactionEstimated(Estimates Estimate) : Transactions();

	public record TransactionInvoiced(Estimates Estimate, InvoicesX Invoice)

		: TransactionEstimated(Estimate);

	public record TransactionTransfered(Estimates Estimate, InvoicesX Invoice, TransfersX Transfer)

		: TransactionInvoiced(Estimate, Invoice);

	public record TransactionReceipted(Estimates Estimate, InvoicesX Invoice, TransfersX Transfer, ReceiptsX Receipt)

		: TransactionTransfered(Estimate, Invoice, Transfer);



	// PHASE

	public record Phases();

	public record Estimates(CashOfferEntries CashOffer, SaleOfferEntries SaleOffer) : Phases();

	public record InvoicesX(CashDueEntries CashDue, SaleDueEntries SaleDue) : Phases();

	public record TransfersX(CashDeedEntries CashDeed, SaleDeedEntries SaleDeed) : Phases();

	public record ReceiptsX(CashNoteEntries CashNote, SaleNoteEntries SaleNote) : Phases();



    // ENTRY

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



	// METRIC

	// TODO add in metric base types

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



	public record BidCashOfferMetrics() : CashOfferMetrics();

	public record BuyCashOfferMetrics() : CashOfferMetrics();


	public record AskSaleOfferMetrics() : SaleOfferMetrics();

	public record SellSaleOfferMetrics() : SaleOfferMetrics();


	public record BidCashDueMetrics() : CashDueMetrics();

	public record BuyCashDueMetrics() : CashDueMetrics();


	public record AskSaleDueMetrics() : SaleDueMetrics();

	public record SellSaleDueMetrics() : SaleDueMetrics();


	public record BidCashDeedMetrics() : CashDeedMetrics();

	public record BuyCashDeedMetrics() : CashDeedMetrics();


	public record AskSaleDeedMetrics() : SaleDeedMetrics();

	public record SellSaleDeedMetrics() : SaleDeedMetrics();


	public record BidCashNoteMetrics() : CashNoteMetrics();

	public record BuyCashNoteMetrics() : CashNoteMetrics();


	public record AskSaleNoteMetrics() : SaleNoteMetrics();

	public record SellSaleNoteMetrics() : SaleNoteMetrics();
}

