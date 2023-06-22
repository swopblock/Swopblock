using System;

namespace swop;

public class Entry
{
    public IBinding Binding;

    public Crypto Source;

    public Signatures Authorization;

    public decimal Exchange;

    public decimal Medium;

    public Wallet Recipient;

    public Entry()
	{
	}
}

public interface IOrderable: IExecutable, IDischargeable
{
    IOrdered Order(IOrderable orderable)
    {
        var invoiced = Execute(orderable);

        var discharged = Discharge(invoiced);

        return discharged;
    }
}

public interface IOrdered { }

public interface IExecutable: IOfferable, IInvoicable
{
    IDeliverable Execute(IExecutable executable)
    {
        var offered = Offer(executable);

        var invoiced = Invoice(offered);

        return invoiced;
    }
}

public interface IDischargeable: IDeliverable, IReceiptable
{
    IDischarged Discharge(IDeliverable deliverable)
    {
        var delivered = Deliver(deliverable);

        var receipted = Receipt(delivered);

        return receipted;
    }
}

public interface IDischarged: IOrdered { }

public interface IOfferable : IProcessable
{
    IInvoicable Offer(IOfferable offerable)
    {
        var confirmed = Process(offerable);

        return (IInvoicable)confirmed;
    }
}

public interface IInvoicable : IProcessable
{
    IDeliverable Invoice(IInvoicable invoicing);
}

public interface IDeliverable : IProcessable
{
    IReceiptable Deliver(IDeliverable deliverable)
    {
        var delivered = Process(deliverable);

        return (IReceiptable)delivered;
    }
}

public interface IReceiptable : IProcessable
{
    IReceipted Receipt(IReceiptable receiptable)
    {
        var receipted = Process(receiptable);

        return (IReceipted)receipted;
    }
}

public interface IReceipted: IDischarged { }

public interface IProcessable : IVerifiable, ISignable, ISubmitable, IConfirmable
{
    IProcessable Process(IProcessable processable)
    {
        var verified = Verify(processable);

        var signed = Sign(verified);

        var submitted = Submit(signed);

        var confirmed = Confirm(submitted);

        return confirmed;
    }
}

public interface IVerifiable { ISignable Verify(IVerifiable verifiable); }

public interface ISignable { ISubmitable Sign(ISignable signable); }

public interface ISubmitable { IConfirmable Submit(ISubmitable submitable); }

public interface IConfirmable { IProcessable Confirm(IConfirmable confirmable); }

public interface IConfirmed : IOffered, IInvoiced, IDelivered, IReceipted  { }

public interface IOffered { }

public interface IInvoiced { }

public interface IDelivered { }

//public interface IReceipted { }
