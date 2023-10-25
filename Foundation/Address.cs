using System;
namespace Swopblock;

public partial record Address
{
    public static Node SimulateHistory(int TransferCountAverage, int TransferCountDeviation)
    {
        return null;
    }

    public static Address LoadHistory
    (
        int TransferCount
    )

    {
        var transfers = new Transfer[TransferCount];

        for (int i = 0; i < TransferCount; i++)
        {
            transfers[i] = Transfer.LoadHistory();
        }

        //var address = new Address(transfers);

        //return address;

        return null;
    }

}

