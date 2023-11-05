using System;
namespace Swopblock;

public partial record Transfer
{
    public static Transfer SimulateHistory()
    {
        return null;
    }

    public static Transfer LoadHistory()
    {
        var transfer  = new Transfer();

        return transfer;
    }

}

public record BtcTransfer: Transfer
{

}

public record EthTransfer : Transfer
{

}