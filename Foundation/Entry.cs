using System;

namespace Swopblock.DraftA
{
    [Flags]
    public enum KindsOfEntries
    {
        CashOffer,

        SaleOffer,

        CashDue,

        SaleDue,

        CashDeed,

        SaleDeed,

        CashNode,

        SaleNode
    }

    public class EntryInfo
    {
        // Entry Type

        KindsOfEntries KindsOfEntry;

        public void SetKindsOfEntry(KindsOfEntries KindsOfEntry)
        {
            this.KindsOfEntry |= KindsOfEntry;
        }

        public void ClearKindsOfEntry(KindsOfEntries KindsOfEntry)
        {
            this.KindsOfEntry |= KindsOfEntry;

            this.KindsOfEntry ^= KindsOfEntry;
        }

        public void ClearAllKindsOfEntry()
        {
            this.KindsOfEntry = 0;
        }

        #region Swopblock Transaction

        #region Offered Couple

        #region Cash Offer

        // Bid metrics

        Int64 BidRecordIndex;

        decimal BidMinimum;

        decimal BidMaximum;

        Kinds BidKind;

        Address BidAddress;

        decimal BidReservation;


        // Buy parameters

        decimal BuyMinimum;

        decimal BuyMaximum;

        Kinds BuyKind;

        Address BuyAddress;

        decimal BuyExpiration;

        #endregion

        #region Sale Offer

        // Ask metrics

        Int64 AskRecordIndex;

        decimal AskMinimum;

        decimal AskMaximum;

        Kinds AskKind;

        Address AskAddress;

        decimal AskReservation;


        // Sell parameters

        decimal SellMinimum;

        decimal SellMaximum;

        Kinds SellKind;

        Address SellAddress;

        decimal SellExpiration;

        #endregion

        #endregion

        #region Invoiced Couple

        #region Cash Due

        // Cash Metrics

        Int64 InvoiceRecordIndex; 

        Int64 CashDueSerialNumber;

        decimal CashDueAmount;

        decimal CashDueConfirmationVolume;

        Address CashDueAddress;

        #endregion

        #region Sale Due

        Int64 SaleDueSerialNumber;

        decimal SaleDueAmount;

        decimal SaleDueConfirmationVolume;

        Address SaleDueAddress;

        #endregion

        #endregion

        #region Escrowed Couple

        #region Cash Deed

        // Deed parameters

        Int64 DeedRecordIndex;

        Int64 CashDeedSerialNumber;

        decimal CashDeedAmount;

        decimal CashDeedConfirmationVolume;

        Address CashDeedAddress;

        #endregion

        #region Sale Deed

        Int64 SaleDeedSerialNumber;

        decimal SaleDeed;

        decimal SaleDeedConfirmationVolume;

        Address SaleDeedAddress;

        #endregion

        #endregion

        #region Recorded Couple

        #region Cash Note

        // Note parameters

        Int64 NoteRecordIndex;

        Int64 CashNoteSerialNumber;

        decimal CashNote;

        decimal CashNoteConfirmationVolume;

        Address CashNoteAddress;

        #endregion

        #region Sale Note

        Int64 SaleNoteSerialNumber;

        decimal SaleNote;

        decimal SaleNoteConfirmationVolume;

        Address SaleNoteAddress;

        #endregion

        #endregion

        #endregion


        public void SetBid
        (
            // Bid parameters

            decimal BidMinimum,

            decimal BidMaximum,

            Kinds BidKind,

            Address BidAddress,


            // Buy parameters

            decimal BuyMinimum,

            decimal BuyMaximum,

            Kinds BuyKind,

            Address BuyAddress,


            // Offer parameters

            decimal BidOfferExpiration
        )

        {
            this.KindsOfEntry = KindsOfEntries.CashOffer;

            this.BidMinimum = BidMinimum;

            this.BidMaximum = BidMaximum;

            this.BidKind = BidKind;

            this.BidAddress = BidAddress;

            this.BuyMinimum = BuyMinimum;

            this.BuyMaximum = BuyMaximum;

            this.BuyKind = BuyKind;

            this.BuyAddress = BuyAddress;

            this.BidOfferExpiration = OfferExpiration;
        }

        public void SetAsk()
        {

        }

        public void SetInvoice()

        public void PreviewBid()
        {

        }

        public void PreviewAsk()
        {

        }

        public void PreviewInvoice()
        {

        }

        public void PreviewDeeds()
        {

        }

        public void PreviewNotes()
        {

        }

        public void AddSaleDeed()
        {

        }

        public void AddCashNote()
        {

        }

        public void AddSaleNote()
        {

        }

        // from self

        public string Text()
        {
            return null;
        }

        public Byte[] Binary()
        {
            return null;
        }

        public EntryInfo Info()
        {
            return null;
        }

        public Entry Record()
        {
            return null;
        }

        // from info

        public static string Text(EntryInfo record)
        {
            return record.Text();
        }

        public static Byte[] Binary(EntryInfo record)
        {
            return record.Binary();
        }

        public static EntryInfo Info(EntryInfo record)
        {
            return null;
        }

        public static Entry Record(EntryInfo record)
        {
            return null;
        }

        // from a text

        public static string Text(string text)
        {
            return null;
        }

        public static Byte[] Binary(string text)
        {
            EntryInfo.Record()
            return null;
        }

        public static EntryInfo Info(string text)
        {
            return null;
        }

        public static Entry Record(string text)
        {
            return null;
        }

        // from a binary

        public static string Text(Byte[] binary)
        {
            return null;
        }

        public static Byte[] Binary(Byte[] binary)
        {
            return null;
        }

        public static EntryInfo Info(Byte[] binary)
        {
            return null;
        }

        public static Entry Record(Byte[] binary)
        {
            //switch ()
            {

            }
            return null;
        }
    }

    public record Entry
    {

    }
}


namespace Swopblock
{

    public partial record Entries
    {
        public static Entries SimulateHistory()
        {
            return null;
        }

        public static Entries LoadHistory()
        {
            var transfer = new Entries();

            return transfer;
        }

        public static Entries NewRandomEntry()
        {
            return new Entries();
        }

    }

    public record BtcTransfer : Entries
    {

    }

    public record EthTransfer : Entries
    {

    }
}