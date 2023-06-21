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

public interface IOrderable: IBindable, IDisolvable
{
    IReceiptable Order(IOfferable offer)
    {
        var invoice = Bind(offer);

        var receipt = Disolve(invoice);

        return receipt;
    }
}

public interface IBindable : IReviewable, ISignable, ISubmitable, IConfirmable
{
    IDeliverable Bind(IOfferable offer)
    {
        // IAMHERE var offer
        return null;
    }
}

public interface IDisolvable : IReviewable, ISignable, ISubmitable, IConfirmable
{
    IReceiptable Disolve(IDeliverable invoice);
}

public interface IOfferable : IReviewable, ISignable, ISubmitable, IConfirmable
{
    IInvoicable Enter(IOfferable entry);
}

public interface IInvoicable
{
    IDeliverable Enter(IInvoicable offer);
}

public interface IDeliverable
{
    IReceiptable Enter(IDeliverable invoice);
}

public interface IReceiptable
{
    IReceiptable Enter(IReceiptable delivery);
}

public interface IReviewable { ISignable Review(IReviewable entered); }

public interface ISignable { ISubmitable Sign(ISignable reviewed); }

public interface ISubmitable { IConfirmable Submit(ISubmitable signed); }

public interface IConfirmable { IReviewable Confirm(IConfirmable submitted); }


