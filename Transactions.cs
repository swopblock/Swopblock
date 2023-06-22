using System;

namespace swop;

public class Transactions: ITransactions
{
	public Transactions()
	{
	}

    public IVerifiable Confirm(string text)
    {
        throw new NotImplementedException();
    }

    public ISignable New(string text)
    {
        throw new NotImplementedException();
    }

    public IConfirmable Pend(string text)
    {
        throw new NotImplementedException();
    }

    public IPendable Sign(string text)
    {
        throw new NotImplementedException();
    }
}

public interface ITransactions : IVerifiable, ISignable, IPendable, IConfirmable
{

}

