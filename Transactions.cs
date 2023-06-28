using System;

namespace swop;

public class Transactions: ITransactions
{
	public Transactions()
	{
	}

    public IProcessable Confirm(IConfirmable confirmable)
    {
        throw new NotImplementedException();
    }

    public ISubmitable Sign(ISignable signable)
    {
        throw new NotImplementedException();
    }

    public IConfirmable Submit(ISubmitable submitable)
    {
        throw new NotImplementedException();
    }

    public ISignable Verify(IVerifiable verifiable)
    {
        throw new NotImplementedException();
    }
}

public interface ITransactions : IVerifiable, ISignable, ISubmitable, IConfirmable
{

}

