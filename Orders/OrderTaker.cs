namespace Orders;

public class AutoTeller
{
    public Estimate EstimateTheOffer(Offer offer) { return null; }

    public Invoice InvoiceTheEstimate(Estimate estimate) { return null; }

    public Transfer TransferTheInvoice(Invoice invoice) { return null; }

    public Receipt ReceiptTheTransfer(Transfer transfer) { return null; }
}

public record Cash;

public record Item;

public record Note(Cash cash, Item item)
{
    public Offer MakeAnOffer()
    {
        return null;
    }

    public static Note CashAReceipt(Receipt receipt)
    {
        return null;
    }
}

public record Schedule;

public record Offer(Note Input, string Details) : Schedule
{
    public Estimate MakeAnEstimate(string Details)
    {
        return null;
    }
}

public record Estimate(string Details) : Schedule
{
    public Invoice MakeAnInvoice(string Details)
    {
        return null;
    }
}

public record Invoice(string Details) : Schedule
{
    public Transfer MakeATransfer(string Details)
    {
        return null;
    }
}

public record Transfer(string Details) : Schedule
{
    public Receipt MakeAReceipt(string Details)
    {
        return null;
    }
}

public record Receipt(string Details, Note Output) : Schedule
{
    public Offer MakeAnOffer(string Details)
    {
        return null;
    }
}


