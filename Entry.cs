using System;

namespace swop;

public class Entry
{
    public Crypto Source;

    public Signatures Authorization;

    public decimal Exchange;

    public decimal Medium;

    public Wallet Recipient;

    public Entry()
	{
	}
}

public interface IOrdering : INewable, ISignable, IPendable, IConfirmable { }

public interface INewable { ISignable New(string text); }

public interface ISignable { IPendable Sign(string text); }

public interface IPendable { IConfirmable Pend(string text); }

public interface IConfirmable { INewable Confirm(string text); }


