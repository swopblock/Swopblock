using System;
namespace Swopblock;

public partial record Address
{
    protected static decimal FaceValue = 52800000;

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

public partial record BtcAddress(HashSet<Transfer> Transfers): Address(Transfers)
{
}

public partial record EthAddress(HashSet<Transfer> Transfers): Address(Transfers)
{

}

