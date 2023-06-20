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

